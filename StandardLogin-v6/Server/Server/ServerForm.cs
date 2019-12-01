// <copyright file="ServerForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Server
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// This is the ServerForm.
    /// </summary>
    public partial class ServerForm : Form
    {
        // Init pipeServer
        private PipeServer pipeServer = new PipeServer();

        // User repository class for DB operations
        private static UserRepository userRepo = new UserRepository();

        // Password Manger
        private static PasswordManager pwdManager = new PasswordManager();

        // Admin details
        private int adminUserId = 0;
        private string adminPassword = "admin";

        // CSV File
        private string csvFile = "UserExport.csv";

        /// <summary>
        /// Initializes a new instance of the <see cref="ServerForm"/> class.
        /// Initializes this form.
        /// </summary>
        public ServerForm()
        {
            this.InitializeComponent();

            // Pipe Message receivers
            this.pipeServer.MessageReceived += this.PipeServer_MessageReceived;
            this.pipeServer.ClientDisconnected += this.pipeServer_ClientDisconnected;

            // Needs to be set for the Form KeyDown event to work properly
            this.KeyPreview = true;
        }

        // IPC Pipes
        private void pipeServer_ClientDisconnected()
        {
            this.Invoke(new PipeServer.ClientDisconnectedHandler(this.ClientDisconnected));
        }

        private void ClientDisconnected()
        {
            // Display message to server
            this.tbReceived.Text = "Total connected clients: " + this.pipeServer.TotalConnectedClients + "\r\n";
        }

        private void PipeServer_MessageReceived(byte[] message)
        {
            this.Invoke(new PipeServer.MessageReceivedHandler(this.DisplayMessageReceived), new object[] { message });
        }

        private void DisplayMessageReceived(byte[] message)
        {
            try
            {
                this.tbReceived.Clear();

                ASCIIEncoding encoder = new ASCIIEncoding();

                // Convert message into array (user ID & password)
                string[] words;
                string str = encoder.GetString(message, 0, message.Length);
                words = str.Split(',');

                // User Login
                if (string.Equals(words[0], "l"))
                {
                    this.tbReceived.Text += "Login Request" + "\r\n";
                    this.tbReceived.Text += "User ID: " + words[1] + "\r\n";
                    this.tbReceived.Text += "Password: " + words[2] + "\r\n";

                    string salt = null;
                    string passwordHash = pwdManager.GeneratePasswordHash(words[2], out salt);

                    // User Login & Password comparison
                    string returnMessage = UserLogin(int.Parse(words[1]), words[2], salt);

                    // Add to Servers Textbox
                    this.tbReceived.Text += returnMessage + "\r\n";

                    // Send to Client
                    byte[] messageBuffer = encoder.GetBytes(returnMessage);
                    this.pipeServer.SendMessage(messageBuffer);
                }

                // User Creation
                if (string.Equals(words[0], "c"))
                {
                    this.tbReceived.Text += "Create Request" + "\r\n";
                    this.tbReceived.Text += "User ID: " + words[1] + "\r\n";
                    this.tbReceived.Text += "Password: " + words[2] + "\r\n";

                    // User creation
                    string returnMessage = UserCreation(int.Parse(words[1]), words[2]);

                    // Add to Servers Textbox
                    this.tbReceived.Text += UserCreation(int.Parse(words[1]), words[2]) + "\r\n";

                    // Send to Client
                    byte[] messageBuffer = encoder.GetBytes(returnMessage);
                    this.pipeServer.SendMessage(messageBuffer);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        /// <summary>
        /// Method used form logging in a user.
        /// </summary>
        /// <param name="userId">Variable which passes through the UserId.</param>
        /// <param name="password">Variable which passes through the Password.</param>
        /// <param name="salt">Variable which passes through the Salt.</param>
        /// <returns>Returns a String.</returns>
        public static string UserLogin(int userId, string password, string salt)
        {
            // Check if a User object with that UserId already exists
            if (!userRepo.UserExists(userId))
            {
                return "A user with that User ID does not exist.";
            }
            else
            {
                // Retrieve the values from the userRepo
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

        /// <summary>
        /// Method used for user creation.
        /// </summary>
        /// <param name="userId">Variable which passes through the UserId.</param>
        /// <param name="password">Variable which passes through the Password.</param>
        /// <returns>Returns a string.</returns>
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
                    Salt = salt,
                };

                // Add the user to the databse
                userRepo.AddUser(user);

                return "User successfully created.";
            }
        }

        /// <summary>
        /// Method used to create an admin user.
        /// </summary>
        /// <param name="userId">Variable which passes through the UserId.</param>
        /// <param name="password">Variable which passes through the Password.</param>
        public void AdminUserCreation(int userId, string password)
        {
            string adminAccount = UserCreation(userId, password);
            this.tbReceived.Text += "Creating Admin account..." + "\r\n";
            this.tbReceived.Text += "Admin User ID: " + userId + "\r\n";
            this.tbReceived.Text += "Admin Password: " + password + "\r\n";
            this.DisplayUsers();
        }

        // Start Button
        private void btnStart_Click(object sender, EventArgs e)
        {
            // Start the pipe server if it's not already running
            if (!this.pipeServer.Running)
            {
                this.pipeServer.Start(this.tbPipeName.Text);
                this.btnStart.Enabled = false;

                this.tbReceived.Text = "Server has started." + "\r\n";

                // Setting up a Admin account
                this.AdminUserCreation(this.adminUserId, this.adminPassword);
            }
            else
            {
                this.tbReceived.Text += "Server already running.";
            }
        }

        // Create User Button
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                // If server is not running
                if (!this.pipeServer.Running)
                {
                    this.tbReceived.Text = "Server is currently not running." + "\r\n";
                }
                else
                {
                    // Check if tbUserId is empty
                    if (string.IsNullOrEmpty(this.tbUserId.Text))
                    {
                        this.tbReceived.Text = "Please enter a User ID.";
                    }

                    // Check if tbPassword is empty
                    else if (string.IsNullOrEmpty(this.tbPassword.Text))
                    {
                        this.tbReceived.Text = "Please enter a Password.";
                    }

                    // Create user
                    else
                    {
                        // Display message to server
                        this.tbReceived.Text = UserCreation(int.Parse(this.tbUserId.Text), this.tbPassword.Text) + "\r\n";
                        this.tbReceived.Text += "User ID: " + this.tbUserId.Text + "\r\n";
                        this.tbReceived.Text += "Password: " + this.tbPassword.Text + "\r\n";

                        // Clear tbUserId and tbUserPassword
                        this.tbUserId.Clear();
                        this.tbPassword.Clear();

                        // Display users in lstUsers
                        this.DisplayUsers();
                    }
                }
            }
            catch (Exception)
            {
                this.tbReceived.Text = "Unable to create user.";
            }
        }

        // Search Button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                // If server is not running
                if (!this.pipeServer.Running)
                {
                    this.tbReceived.Text = "Server is currently not running." + "\r\n";
                }
                else
                {
                    // Clear selected in lstUsers
                    this.lstUsers.ClearSelected();

                    // Check if tbUserId is empty
                    if (string.IsNullOrEmpty(this.tbSearch.Text))
                    {
                        this.tbReceived.Text = "Please enter a User ID.";
                    }
                    else
                    {
                        // Get the LinkedList users from userRepo
                        LinkedList<User> users = userRepo.GetUsers();

                        // Get the searched text from tbSearch
                        int search = int.Parse(this.tbSearch.Text);

                        // Search using RecursiveSearch
                        bool found = RecursiveSearch(users, search);
                        if (found)
                        {
                            // Display message to server
                            this.tbReceived.Text = "User ID " + search + " found.";

                            // Select the searched in lstUsers
                            int index = this.lstUsers.FindString(search.ToString());
                            if (index != -1)
                            {
                                this.lstUsers.SetSelected(index, true);
                            }
                        }

                        // If not found
                        else
                        {
                            // Display message to server
                            this.tbReceived.Text = "User ID " + search + " not found.";
                        }
                    }

                    // Clear tbSearch
                    this.tbSearch.Clear();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // CSVExport Button
        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                this.ExportCSV();

                // Display message to server
                this.tbReceived.Text = "Users exported to csv.";
            }
            catch (Exception ex)
            {
                // Display message to server
                this.tbReceived.Text = "Unable to export users to csv.";
                MessageBox.Show("Expection: " + ex.Message);
            }
        }

        // Form KeyDown Event
        private void ServerForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Ctrl + W to close appliactions
                if (e.Control && e.Control && e.KeyCode == Keys.W)
                {
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Display Method
        private void DisplayUsers()
        {
            // Clear lstUsers
            this.lstUsers.Items.Clear();

            // Get userIds from userRepo
            List<int> userIds = userRepo.GetUserIds();

            // Sort
            List<int> sorted = MergeSort(userIds);

            // loop through sorted List and display into lstUsers
            foreach (int u in sorted)
            {
                this.lstUsers.Items.Add(u);
            }
        }

        // Must contain sorting algorithm
        // Sorting Method (Merge Sort)
        private static List<int> MergeSort(List<int> userIds)
        {
            if (userIds.Count <= 1)
            {
                return userIds;
            }

            // Lists used to store objects in the left and right of the merge sort
            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = userIds.Count / 2;
            for (int i = 0; i < middle; i++)
            {
                left.Add(userIds[i]);
            }

            for (int i = middle; i < userIds.Count; i++)
            {
                right.Add(userIds[i]);
            }

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

        // Must contain searching technique
        // Code advanced searching techniques for use with complex data structures
        // Searching Method (Recursive Search)
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
            {
                return false;
            }

            if (current.Value.UserId == search)
            {
                return true;
            }

            return RecursiveSearch(current.Next, search);
        }

        // CSVHelper (Thirdparty Package)
        private void ExportCSV()
        {
            LinkedList<User> users = userRepo.GetUsers();
            List<CSVRecord> csvRecords = new List<CSVRecord>();

            foreach (User u in users)
            {
                this.AddRecord(csvRecords, u.UserId, u.PasswordHash, u.Salt);
            }
        }

        private void AddRecord(List<CSVRecord> csvRecords, int userId, string passwordHash, string salt)
        {
            try
            {
                // Encoding passwordHash
                var utf8PasswordHash = this.utf8Encoder.GetString(this.utf8Encoder.GetBytes(passwordHash));

                // Encoding salt
                var utf8Salt = this.utf8Encoder.GetString(this.utf8Encoder.GetBytes(salt));

                csvRecords.Add(new CSVRecord { UserId = userId, PasswordHash = utf8PasswordHash, Salt = utf8Salt });

                using (StreamWriter writer = new StreamWriter(this.csvFile, false))
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
            }
        }

        /* When trying to export passwordHash and salt with AddRecord() received a ExceptionUnable to translate Unicode character exception
        * Using UTF8 to encode the text
        * https://stackoverflow.com/questions/9775028/asp-net-unable-to-translate-unicode-character-xxx-at-index-yyy-to-specified-co
        */
        private readonly Encoding utf8Encoder = Encoding.GetEncoding(
            "UTF-8",
            new EncoderReplacementFallback(string.Empty),
            new DecoderExceptionFallback());
    }
}
