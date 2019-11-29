using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form
    {
        private PipeClient pipeClient;

        public ClientForm()
        {
            InitializeComponent();
            CreateNewPipeClient();
        }

        void CreateNewPipeClient()
        {
            if (pipeClient != null)
            {
                pipeClient.MessageReceived -= pipeClient_MessageReceived;
                pipeClient.ServerDisconnected -= pipeClient_ServerDisconnected;
            }

            pipeClient = new PipeClient();
            pipeClient.MessageReceived += pipeClient_MessageReceived;
            pipeClient.ServerDisconnected += pipeClient_ServerDisconnected;
        }

        void pipeClient_ServerDisconnected()
        {
            Invoke(new PipeClient.ServerDisconnectedHandler(EnableStartButton));
        }

        void EnableStartButton()
        {
            btnConnect.Enabled = true;
        }

        void pipeClient_MessageReceived(byte[] message)
        {
            Invoke(new PipeClient.MessageReceivedHandler(DisplayReceivedMessage),
                new object[] { message });
        }

        void DisplayReceivedMessage(byte[] message)
        {
            tbReceived.Clear();

            ASCIIEncoding encoder = new ASCIIEncoding();
            string str = encoder.GetString(message, 0, message.Length);

            if (str == "close")
            {
                pipeClient.Disconnect();

                CreateNewPipeClient();
                pipeClient.Connect(tbPipeName.Text);
            }

            tbReceived.Text += str + "\r\n";
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            pipeClient.Connect(tbPipeName.Text);

            if (pipeClient.Connected)
            {
                btnConnect.Enabled = false;
                tbReceived.Text = "Client connected.";
            }
            else
                tbReceived.Text = "Client unable to connect.";
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (pipeClient.Connected)
                {
                    if (string.IsNullOrEmpty(tbUserId.Text))
                    {
                        tbReceived.Text = "Please enter a User ID.";
                    }
                    else if (string.IsNullOrEmpty(tbPassword.Text))
                    {
                        tbReceived.Text = "Please enter a Password.";
                    }
                    else
                    {
                        // Send information to server
                        ASCIIEncoding encoder = new ASCIIEncoding();
                        pipeClient.SendMessage(encoder.GetBytes("l" + "," + tbUserId.Text + "," + tbPassword.Text));

                        // Clear tbUserId and tbPassword
                        tbUserId.Clear();
                        tbPassword.Clear();
                    }
                }
                else
                    tbReceived.Text = "Client not connected.";
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
