using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{

    public partial class ServerForm : Form
    {
        // Init pipeServer
        private PipeServer pipeServer = new PipeServer();

        // User repository class for DB operations
        static UserRepository userRepo = new UserRepository();

        // Password Manger
        static PasswordManager pwdManager = new PasswordManager();

        // Admin details
        string adminUserId = "000";
        string adminPassword = "admin";

        #region Pipe Stuff
        public ServerForm()
        {
            InitializeComponent();

            // Pipe Message receivers
            pipeServer.MessageReceived += pipeServer_MessageReceived;
            pipeServer.ClientDisconnected += pipeServer_ClientDisconnected;
        }

        void pipeServer_ClientDisconnected()
        {
            Invoke(new PipeServer.ClientDisconnectedHandler(ClientDisconnected));
        }

        void ClientDisconnected()
        {
            MessageBox.Show("Total connected clients: " + pipeServer.TotalConnectedClients);
        }

        void pipeServer_MessageReceived(byte[] message)
        {
            Invoke(new PipeServer.MessageReceivedHandler(DisplayMessageReceived), new object[] { message });
        }

        void DisplayMessageReceived(byte[] message)
        {
            try
            {
                tbReceived.Clear();

                ASCIIEncoding encoder = new ASCIIEncoding();

                // Convert message into array (user ID & password)
                string[] words;
                string str = encoder.GetString(message, 0, message.Length);
                words = str.Split(',');

                // User Login
                if (string.Equals(words[0], "l"))
                {
                    tbReceived.Text += "Login Request" + "\r\n";
                    tbReceived.Text += "User ID: " + words[1] + "\r\n";
                    tbReceived.Text += "Password: " + words[2] + "\r\n";

                    string salt = null;
                    string passwordHash = pwdManager.GeneratePasswordHash(words[2], out salt);

                    // User Login & Password comparison
                    string returnMessage = UserLogin(salt, words[1], words[2]);

                    // Add to Servers Textbox
                    tbReceived.Text += returnMessage + "\r\n";

                    // Send to Client
                    //byte[] messageBuffer = encoder.GetBytes(UserLogin(salt, words[1], words[2]));
                    byte[] messageBuffer = encoder.GetBytes(returnMessage);
                    pipeServer.SendMessage(messageBuffer);
                }

                // User Creation
                if (string.Equals(words[0], "c"))
                {
                    tbReceived.Text += "Create Request" + "\r\n";
                    tbReceived.Text += "User ID: " + words[1] + "\r\n";
                    tbReceived.Text += "Password: " + words[2] + "\r\n";

                    // User creation
                    string returnMessage = UserCreation(words[1], words[2]);

                    // Add to Servers Textbox
                    tbReceived.Text += UserCreation(words[1], words[2]) + "\r\n";

                    // Send to Client
                    byte[] messageBuffer = encoder.GetBytes(returnMessage);
                    pipeServer.SendMessage(messageBuffer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
        #endregion

        #region User Login and Creation
        // User Login
        public static string UserLogin(string salt, string userId, string password)
        {
            // Check if a User object with that UserId already exists
            if (!userRepo.UserExists(userId))
            {
                return "A user with that User ID does not exist.";
            }
            else
            {
                // retrieve the values from the database
                User userCompare = userRepo.GetUser(userId);

                bool result = pwdManager.IsPasswordMatch(password, userCompare.Salt, userCompare.PasswordHash);

                if (result == true)
                {
                    return "Successfully logged in.";
                }
                else
                {
                    return "Password does not match.";
                }
            }
        }

        // User Creation
        public static string UserCreation(string userId, string password)
        {
            // Check if a User object with that UserId already exists
            if (userRepo.UserExists(userId))
            {
                return "A user with that User ID already exists.";
            }
            else
            {
                // Hash and Salt
                string salt = null;
                string passwordHash = pwdManager.GeneratePasswordHash(password, out salt);

                // Save values in the databse
                User user = new User
                {
                    UserId = userId,
                    PasswordHash = passwordHash,
                    Salt = salt
                };

                // Add the user to the databse
                userRepo.AddUser(user);

                return "User successfully created.";
            }
        }

        // Admin Account Creation
        public void AdminUserCreation(string userId, string password)
        {
            string adminAccount = UserCreation(userId, password);
            tbReceived.Text += "Creating Admin account..." + "\r\n";
            tbReceived.Text += "Admin User ID: " + userId + "\r\n";
            tbReceived.Text += "Admin Password: " + password + "\r\n";
        }
        #endregion

        #region Form Events
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Start the pipe server if it's not already running
            if (!pipeServer.Running)
            {
                pipeServer.Start(tbPipeName.Text);
                btnStart.Enabled = false;

                tbReceived.Text += "Server has started." + "\r\n";

                // Setting up a Admin account
                AdminUserCreation(adminUserId, adminPassword);
            }
            else
                tbReceived.Text += "Server already running.";
        }

        // Create User Button
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // If server is not running
                if (!pipeServer.Running)
                {
                    tbReceived.Text = "Server is currently not running." + "\r\n";
                    tbReceived.Text += "Unable to create user.";
                }
                else
                {
                    // Check if tbUserId is empty
                    if (string.IsNullOrEmpty(tbUserId.Text))
                    {
                        tbReceived.Text = "Please enter a User ID.";
                    }
                    // Check if tbPassword is empty
                    else if (string.IsNullOrEmpty(tbPassword.Text))
                    {
                        tbReceived.Text = "Please enter a Password.";
                    }
                    // Create user
                    else
                    {
                        // Display message to server
                        tbReceived.Text = UserCreation(tbUserId.Text, tbPassword.Text) + "\r\n";
                        tbReceived.Text += "User ID: " + tbUserId.Text + "\r\n";
                        tbReceived.Text += "Password: " + tbPassword.Text + "\r\n";

                        // Clear tbUserId and tbUserPassword
                        tbUserId.Clear();
                        tbPassword.Clear();
                    }
                }
            }
            catch (Exception)
            {
                tbReceived.Text = "Unable to create user.";
            }
        }
        #endregion
    }
}
