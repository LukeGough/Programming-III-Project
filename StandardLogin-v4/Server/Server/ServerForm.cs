using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{

    public partial class ServerForm : Form
    {
        #region Variables
        // Init pipeServer
        private PipeServer pipeServer = new PipeServer();

        // User repository class for DB operations
        static UserRepository userRepo = new UserRepository();

        // Password Manger
        static PasswordManager pwdManager = new PasswordManager();

        // Admin details
        int adminUserId = 000;
        string adminPassword = "admin";

        // CSV File
        string csvFile = "UserExport.csv";
        #endregion

        #region IPC Pipes
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
            // Display message to server
            tbReceived.Text = ("Total connected clients: " + pipeServer.TotalConnectedClients + "\r\n");
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
                    string returnMessage = UserLogin(salt, int.Parse(words[1]), words[2]);

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
                    string returnMessage = UserCreation(int.Parse(words[1]), words[2]);

                    // Add to Servers Textbox
                    tbReceived.Text += UserCreation(int.Parse(words[1]), words[2]) + "\r\n";

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
        #region User Login
        // User Login
        public static string UserLogin(string salt, int userId, string password)
        {
            // Check if a User object with that UserId already exists
            if (!userRepo.UserExists(userId))
            {
                return "A user with that User ID does not exist.";
            }
            else
            {
                // Retrieve the values from the database
                User userCompare = userRepo.GetUser(userId);

                bool result = pwdManager.IsPasswordMatch(password, userCompare.Salt, userCompare.PasswordHash);

                if (result == true)
                    return "Successfully logged in.";
                else
                    return "Password does not match.";
            }
        }
        #endregion
        #region User Creation
        // User Creation
        public static string UserCreation(int userId, string password)
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
        #endregion
        #region Admin User Creation
        // Admin Account Creation
        public void AdminUserCreation(int userId, string password)
        {
            string adminAccount = UserCreation(userId, password);
            tbReceived.Text += "Creating Admin account..." + "\r\n";
            tbReceived.Text += "Admin User ID: " + userId + "\r\n";
            tbReceived.Text += "Admin Password: " + password + "\r\n";
            DisplayUsers();
        }
        #endregion
        #endregion

        #region Form Events
        #region Start Button
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Start the pipe server if it's not already running
            if (!pipeServer.Running)
            {
                pipeServer.Start(tbPipeName.Text);
                btnStart.Enabled = false;

                tbReceived.Text = "Server has started." + "\r\n";

                // Setting up a Admin account
                AdminUserCreation(adminUserId, adminPassword);
            }
            else
                tbReceived.Text += "Server already running.";
        }
        #endregion
        #region Create Button
        // Create User Button
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // If server is not running
                if (!pipeServer.Running)
                    tbReceived.Text = "Server is currently not running." + "\r\n";
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
                        tbReceived.Text = UserCreation(int.Parse(tbUserId.Text), tbPassword.Text) + "\r\n";
                        tbReceived.Text += "User ID: " + tbUserId.Text + "\r\n";
                        tbReceived.Text += "Password: " + tbPassword.Text + "\r\n";

                        // Clear tbUserId and tbUserPassword
                        tbUserId.Clear();
                        tbPassword.Clear();

                        // Display users in lstUsers
                        DisplayUsers();
                    }
                }
            }
            catch (Exception)
            {
                tbReceived.Text = "Unable to create user.";
            }
        }
        #endregion
        #region Search Button
        // Search Button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // If server is not running
                if (!pipeServer.Running)
                    tbReceived.Text = "Server is currently not running." + "\r\n";
                else
                {
                    // Clear selected in lstUsers
                    lstUsers.ClearSelected();

                    // Check if tbUserId is empty
                    if (string.IsNullOrEmpty(tbSearch.Text))
                        tbReceived.Text = "Please enter a User ID.";
                    else
                    {
                        // Get the LinkedList users from userRepo
                        LinkedList<User> users = userRepo.GetUsers();

                        // Get the searched text from tbSearch
                        int search = int.Parse(tbSearch.Text);

                        // Search using RecursiveSearch
                        bool found = RecursiveSearch(users, search);
                        if(found)
                        {
                            // Display message to server
                            tbReceived.Text = "User ID " + search + " found.";

                            // Select the searched in lstUsers
                            //int index = lstUsers.FindString(search);
                            int index = lstUsers.FindString(search.ToString());
                            if (index != -1)
                                lstUsers.SetSelected(index, true);
                        }
                        // If not found
                        else
                            // Display message to server
                            tbReceived.Text = "User ID " + search + " not found.";
                    }

                    // Clear tbSearch
                    tbSearch.Clear();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region CSVExport Button
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                ExportCSV();
                // Display message to server
                tbReceived.Text = "Users exported to csv.";
            }
            catch (Exception ex)
            {
                // Display message to server
                tbReceived.Text = "Unable to export users to csv.";
                MessageBox.Show("Expection: " + ex.Message);
            }
        }
        #endregion
        #endregion

        #region Display Method
        private void DisplayUsers()
        {
            // Clear lstUsers
            lstUsers.Items.Clear();

            // Get userIds from userRepo
            List<int> userIds = userRepo.GetUserIds();

            // Sort
            List<int> sorted = MergeSort(userIds);

            // loop through sorted List and display into lstUsers
            foreach (int u in sorted)
                lstUsers.Items.Add(u);
        }
        #endregion

        #region Sorting Method (Merge Sort)
        // Must contain sorting algorithm
        private static List<int> MergeSort(List<int> userIds)
        {
            if (userIds.Count <= 1)
                return userIds;

            // Lists used to store objects in the left and right of the merge sort
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = userIds.Count / 2;
            for (int i = 0; i < middle; i++)
                left.Add(userIds[i]);

            for (int i = middle; i < userIds.Count; i++)
                right.Add(userIds[i]);

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            
            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())
                    {
                        result.Add(left.First());
                        left.Remove(left.First());
                    }
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }

            return result;
        }
        #endregion

        #region Searching Method (Recursive Search)
        // Must contain searching technique
        // Code advanced searching techniques for use with complex data structures
        // Recursive Search
        private static bool RecursiveSearch(LinkedList<User> users, int search)
        {
            // Set current as the first node in users
            LinkedListNode<User> current = users.First;
            return RecursiveSearch(current, search);
        }

        private static bool RecursiveSearch(LinkedListNode<User> current, int search)
        {
            // Base case
            if (current == null)
                return false;

            if (current.Value.UserId == search)
                return true;

            return RecursiveSearch(current.Next, search);
        }
        #endregion

        #region CSVHelper (Thirdparty Package)
        private void ExportCSV()
        {
            LinkedList<User> users = userRepo.GetUsers();
            List<CSVRecord> csvRecords = new List<CSVRecord>();

            foreach (User u in users)
            {
                //MessageBox.Show("UserId: " + u.UserId +"\n PasswordHash: "+ u.PasswordHash + "\n Salt: " + u.Salt);
                AddRecord(csvRecords, u.UserId, u.PasswordHash, u.Salt);
            }

        }

        private void AddRecord(List<CSVRecord> csvRecords, int userId, string passwordHash, string salt)
        {
            try
            {
                // Encoding passwordHash
                var utf8PasswordHash = Utf8Encoder.GetString(Utf8Encoder.GetBytes(passwordHash));

                // Encoding salt
                var utf8Salt = Utf8Encoder.GetString(Utf8Encoder.GetBytes(salt));

                csvRecords.Add(new CSVRecord { UserId = userId, PasswordHash = utf8PasswordHash, Salt = utf8Salt });

                using (StreamWriter writer = new StreamWriter(csvFile, false))
                using (var csv = new CsvHelper.CsvWriter(writer))
                {
                    csv.WriteRecords(csvRecords);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception" + ex.Message);
                MessageBox.Show("UserId: " + userId + "\nPasswordHash: " + passwordHash + "\nSalt: " + salt);
                //throw;
            }
        }

        /* When trying to export passwordHash and salt with AddRecord() received a ExceptionUnable to translate Unicode character exception
        * Using UTF8 to encode the text
        * https://stackoverflow.com/questions/9775028/asp-net-unable-to-translate-unicode-character-xxx-at-index-yyy-to-specified-co
        */
        private readonly Encoding Utf8Encoder = Encoding.GetEncoding(
            "UTF-8",
            new EncoderReplacementFallback(string.Empty),
            new DecoderExceptionFallback()
        );
        #endregion
    }
}
