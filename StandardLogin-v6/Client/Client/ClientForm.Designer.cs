namespace Client
{
    partial class ClientForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.tbPipeName = new System.Windows.Forms.TextBox();
            this.lbPipeName = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lbUserId = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbReceived = new System.Windows.Forms.TextBox();
            this.grpApplications = new System.Windows.Forms.GroupBox();
            this.grpAnnualSalaries = new System.Windows.Forms.GroupBox();
            this.btnAnnualSalaries = new System.Windows.Forms.Button();
            this.grpUserLogin = new System.Windows.Forms.GroupBox();
            this.btnPayroll = new System.Windows.Forms.Button();
            this.grpPayroll = new System.Windows.Forms.GroupBox();
            this.lbExitApplication = new System.Windows.Forms.Label();
            this.grpApplications.SuspendLayout();
            this.grpAnnualSalaries.SuspendLayout();
            this.grpUserLogin.SuspendLayout();
            this.grpPayroll.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(65, 45);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(148, 20);
            this.tbPassword.TabIndex = 3;
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(65, 19);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(148, 20);
            this.tbUserId.TabIndex = 2;
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(12, 25);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.ReadOnly = true;
            this.tbPipeName.Size = new System.Drawing.Size(138, 20);
            this.tbPipeName.TabIndex = 0;
            this.tbPipeName.Text = "\\\\.\\pipe\\myNamedPipe";
            // 
            // lbPipeName
            // 
            this.lbPipeName.AutoSize = true;
            this.lbPipeName.Location = new System.Drawing.Point(12, 9);
            this.lbPipeName.Name = "lbPipeName";
            this.lbPipeName.Size = new System.Drawing.Size(62, 13);
            this.lbPipeName.TabIndex = 0;
            this.lbPipeName.Text = "Pipe Name:";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(156, 25);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 20);
            this.btnConnect.TabIndex = 1;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(133, 71);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(80, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lbUserId
            // 
            this.lbUserId.AutoSize = true;
            this.lbUserId.Location = new System.Drawing.Point(16, 22);
            this.lbUserId.Name = "lbUserId";
            this.lbUserId.Size = new System.Drawing.Size(43, 13);
            this.lbUserId.TabIndex = 0;
            this.lbUserId.Text = "User ID";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(6, 48);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 0;
            this.lbPassword.Text = "Password";
            // 
            // tbReceived
            // 
            this.tbReceived.Location = new System.Drawing.Point(12, 51);
            this.tbReceived.Multiline = true;
            this.tbReceived.Name = "tbReceived";
            this.tbReceived.ReadOnly = true;
            this.tbReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReceived.Size = new System.Drawing.Size(219, 93);
            this.tbReceived.TabIndex = 0;
            // 
            // grpApplications
            // 
            this.grpApplications.Controls.Add(this.grpAnnualSalaries);
            this.grpApplications.Location = new System.Drawing.Point(237, 25);
            this.grpApplications.Name = "grpApplications";
            this.grpApplications.Size = new System.Drawing.Size(200, 227);
            this.grpApplications.TabIndex = 5;
            this.grpApplications.TabStop = false;
            this.grpApplications.Text = "Applications";
            // 
            // grpAnnualSalaries
            // 
            this.grpAnnualSalaries.Controls.Add(this.btnAnnualSalaries);
            this.grpAnnualSalaries.Location = new System.Drawing.Point(6, 19);
            this.grpAnnualSalaries.Name = "grpAnnualSalaries";
            this.grpAnnualSalaries.Size = new System.Drawing.Size(188, 100);
            this.grpAnnualSalaries.TabIndex = 9;
            this.grpAnnualSalaries.TabStop = false;
            this.grpAnnualSalaries.Text = "Annual Salaries Application";
            // 
            // btnAnnualSalaries
            // 
            this.btnAnnualSalaries.Enabled = false;
            this.btnAnnualSalaries.Location = new System.Drawing.Point(6, 19);
            this.btnAnnualSalaries.Name = "btnAnnualSalaries";
            this.btnAnnualSalaries.Size = new System.Drawing.Size(176, 75);
            this.btnAnnualSalaries.TabIndex = 7;
            this.btnAnnualSalaries.Text = "Launch AnnualSalaries";
            this.btnAnnualSalaries.UseVisualStyleBackColor = true;
            this.btnAnnualSalaries.Click += new System.EventHandler(this.btnAnnualSalaries_Click);
            // 
            // grpUserLogin
            // 
            this.grpUserLogin.Controls.Add(this.tbUserId);
            this.grpUserLogin.Controls.Add(this.tbPassword);
            this.grpUserLogin.Controls.Add(this.lbUserId);
            this.grpUserLogin.Controls.Add(this.btnLogin);
            this.grpUserLogin.Controls.Add(this.lbPassword);
            this.grpUserLogin.Location = new System.Drawing.Point(12, 150);
            this.grpUserLogin.Name = "grpUserLogin";
            this.grpUserLogin.Size = new System.Drawing.Size(219, 101);
            this.grpUserLogin.TabIndex = 6;
            this.grpUserLogin.TabStop = false;
            this.grpUserLogin.Text = "User Login";
            // 
            // btnPayroll
            // 
            this.btnPayroll.Enabled = false;
            this.btnPayroll.Location = new System.Drawing.Point(6, 19);
            this.btnPayroll.Name = "btnPayroll";
            this.btnPayroll.Size = new System.Drawing.Size(176, 81);
            this.btnPayroll.TabIndex = 8;
            this.btnPayroll.Text = "Launch Payroll";
            this.btnPayroll.UseVisualStyleBackColor = true;
            this.btnPayroll.Click += new System.EventHandler(this.btnPayroll_Click);
            // 
            // grpPayroll
            // 
            this.grpPayroll.Controls.Add(this.btnPayroll);
            this.grpPayroll.Location = new System.Drawing.Point(243, 146);
            this.grpPayroll.Name = "grpPayroll";
            this.grpPayroll.Size = new System.Drawing.Size(188, 100);
            this.grpPayroll.TabIndex = 9;
            this.grpPayroll.TabStop = false;
            this.grpPayroll.Text = "Payroll Application";
            // 
            // lbExitApplication
            // 
            this.lbExitApplication.AutoSize = true;
            this.lbExitApplication.Location = new System.Drawing.Point(12, 254);
            this.lbExitApplication.Name = "lbExitApplication";
            this.lbExitApplication.Size = new System.Drawing.Size(152, 13);
            this.lbExitApplication.TabIndex = 10;
            this.lbExitApplication.Text = "Ctrl + W to exit this application.";
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 271);
            this.Controls.Add(this.lbExitApplication);
            this.Controls.Add(this.grpPayroll);
            this.Controls.Add(this.grpUserLogin);
            this.Controls.Add(this.tbReceived);
            this.Controls.Add(this.grpApplications);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.lbPipeName);
            this.Controls.Add(this.tbPipeName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ClientForm";
            this.Text = "Client";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ClientForm_KeyDown);
            this.grpApplications.ResumeLayout(false);
            this.grpAnnualSalaries.ResumeLayout(false);
            this.grpUserLogin.ResumeLayout(false);
            this.grpUserLogin.PerformLayout();
            this.grpPayroll.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.Label lbPipeName;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label lbUserId;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbReceived;
        private System.Windows.Forms.GroupBox grpApplications;
        private System.Windows.Forms.GroupBox grpUserLogin;
        private System.Windows.Forms.GroupBox grpAnnualSalaries;
        private System.Windows.Forms.Button btnAnnualSalaries;
        private System.Windows.Forms.Button btnPayroll;
        private System.Windows.Forms.GroupBox grpPayroll;
        private System.Windows.Forms.Label lbExitApplication;
    }
}

