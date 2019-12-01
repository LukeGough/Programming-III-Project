// <copyright file="ClientForm.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Client
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// Represents ClientForm.
    /// </summary>
    public partial class ClientForm : Form
    {
        private PipeClient pipeClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientForm"/> class.
        /// </summary>
        public ClientForm()
        {
            this.InitializeComponent();
            this.CreateNewPipeClient();

            // Needs to be set for the Form KeyDown event to work properly
            this.KeyPreview = true;
        }

        private void CreateNewPipeClient()
        {
            if (this.pipeClient != null)
            {
                this.pipeClient.MessageReceived -= this.pipeClient_MessageReceived;
                this.pipeClient.ServerDisconnected -= this.pipeClient_ServerDisconnected;
            }

            this.pipeClient = new PipeClient();
            this.pipeClient.MessageReceived += this.pipeClient_MessageReceived;
            this.pipeClient.ServerDisconnected += this.pipeClient_ServerDisconnected;
        }

        private void pipeClient_ServerDisconnected()
        {
            this.Invoke(new PipeClient.ServerDisconnectedHandler(this.EnableStartButton));
        }

        private void EnableStartButton()
        {
            this.btnConnect.Enabled = true;
        }

        private void pipeClient_MessageReceived(byte[] message)
        {
            this.Invoke(new PipeClient.MessageReceivedHandler(this.DisplayReceivedMessage), new object[] { message });
        }

        private void DisplayReceivedMessage(byte[] message)
        {
            this.tbReceived.Clear();

            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);

            if (str == "Successfully logged in.")
            {
                this.btnAnnualSalaries.Enabled = true;
                this.btnPayroll.Enabled = true;
            }

            if (str == "close")
            {
                this.pipeClient.Disconnect();

                this.CreateNewPipeClient();
                this.pipeClient.Connect(this.tbPipeName.Text);
            }

            this.tbReceived.Text += str + "\r\n";
        }

        // Create Button
        private void btnConnect_Click(object sender, EventArgs e)
        {
            this.pipeClient.Connect(this.tbPipeName.Text);

            if (this.pipeClient.Connected)
            {
                this.btnConnect.Enabled = false;
                this.tbReceived.Text = "Client connected.";
            }
            else
            {
                this.tbReceived.Text = "Client unable to connect.";
            }
        }

        // Login Button
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pipeClient.Connected)
                {
                    if (string.IsNullOrEmpty(this.tbUserId.Text))
                    {
                        this.tbReceived.Text = "Please enter a User ID.";
                    }
                    else if (string.IsNullOrEmpty(this.tbPassword.Text))
                    {
                        this.tbReceived.Text = "Please enter a Password.";
                    }
                    else
                    {
                        // Send information to server
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        this.pipeClient.SendMessage(encoder.GetBytes("l" + "," + int.Parse(this.tbUserId.Text) + "," + this.tbPassword.Text));

                        // Clear tbUserId and tbPassword
                        this.tbUserId.Clear();
                        this.tbPassword.Clear();
                    }
                }
                else
                {
                    this.tbReceived.Text = "Client not connected.";
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // AnnualSalaries Button
        private void btnAnnualSalaries_Click(object sender, EventArgs e)
        {
            try
            {
                // Process to start the AnnualSalariesApp.exe
                ProcessStartInfo annualSalariesApp = new ProcessStartInfo("AnnualSalariesApp.exe");
                Process.Start(annualSalariesApp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Payroll Button
        private void btnPayroll_Click(object sender, EventArgs e)
        {
            try
            {
                // Process to start the PayrollApp.exe
                ProcessStartInfo payrollApp = new ProcessStartInfo("PayrollApp.exe");
                Process.Start(payrollApp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Form KeyDown Event
        private void ClientForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                // Ctrl + W to close appliactions
                if (e.Control && e.Control && e.KeyCode == Keys.W)
                {
                    this.pipeClient.Disconnect();
                    Application.Exit();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
