namespace Server
{
    partial class ServerForm
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
            this.btnStart = new System.Windows.Forms.Button();
            this.tbPipeName = new System.Windows.Forms.TextBox();
            this.lbPipeName = new System.Windows.Forms.Label();
            this.tbReceived = new System.Windows.Forms.TextBox();
            this.grpUserCreate = new System.Windows.Forms.GroupBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUserId = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.tbUserId = new System.Windows.Forms.TextBox();
            this.grpUsers = new System.Windows.Forms.GroupBox();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.lbUserIdSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lbExitApplication = new System.Windows.Forms.Label();
            this.grpUserCreate.SuspendLayout();
            this.grpUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(156, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 20);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(12, 25);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.ReadOnly = true;
            this.tbPipeName.Size = new System.Drawing.Size(138, 20);
            this.tbPipeName.TabIndex = 1;
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
            // tbReceived
            // 
            this.tbReceived.Location = new System.Drawing.Point(12, 51);
            this.tbReceived.Multiline = true;
            this.tbReceived.Name = "tbReceived";
            this.tbReceived.ReadOnly = true;
            this.tbReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReceived.Size = new System.Drawing.Size(219, 93);
            this.tbReceived.TabIndex = 3;
            // 
            // grpUserCreate
            // 
            this.grpUserCreate.Controls.Add(this.btnCreate);
            this.grpUserCreate.Controls.Add(this.lbPassword);
            this.grpUserCreate.Controls.Add(this.lbUserId);
            this.grpUserCreate.Controls.Add(this.tbPassword);
            this.grpUserCreate.Controls.Add(this.tbUserId);
            this.grpUserCreate.Location = new System.Drawing.Point(12, 150);
            this.grpUserCreate.Name = "grpUserCreate";
            this.grpUserCreate.Size = new System.Drawing.Size(219, 101);
            this.grpUserCreate.TabIndex = 4;
            this.grpUserCreate.TabStop = false;
            this.grpUserCreate.Text = "User Create";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(138, 71);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(6, 48);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(53, 13);
            this.lbPassword.TabIndex = 3;
            this.lbPassword.Text = "Password";
            // 
            // lbUserId
            // 
            this.lbUserId.AutoSize = true;
            this.lbUserId.Location = new System.Drawing.Point(16, 22);
            this.lbUserId.Name = "lbUserId";
            this.lbUserId.Size = new System.Drawing.Size(43, 13);
            this.lbUserId.TabIndex = 2;
            this.lbUserId.Text = "User ID";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(65, 45);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(148, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(65, 19);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(148, 20);
            this.tbUserId.TabIndex = 0;
            // 
            // grpUsers
            // 
            this.grpUsers.Controls.Add(this.btnExportCSV);
            this.grpUsers.Controls.Add(this.lbUserIdSearch);
            this.grpUsers.Controls.Add(this.btnSearch);
            this.grpUsers.Controls.Add(this.tbSearch);
            this.grpUsers.Controls.Add(this.lstUsers);
            this.grpUsers.Location = new System.Drawing.Point(237, 24);
            this.grpUsers.Name = "grpUsers";
            this.grpUsers.Size = new System.Drawing.Size(205, 227);
            this.grpUsers.TabIndex = 5;
            this.grpUsers.TabStop = false;
            this.grpUsers.Text = "User IDs";
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Location = new System.Drawing.Point(121, 89);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(79, 35);
            this.btnExportCSV.TabIndex = 8;
            this.btnExportCSV.Text = "Export to CSV";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // lbUserIdSearch
            // 
            this.lbUserIdSearch.AutoSize = true;
            this.lbUserIdSearch.Location = new System.Drawing.Point(121, 19);
            this.lbUserIdSearch.Name = "lbUserIdSearch";
            this.lbUserIdSearch.Size = new System.Drawing.Size(80, 13);
            this.lbUserIdSearch.TabIndex = 7;
            this.lbUserIdSearch.Text = "User ID Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(121, 61);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(79, 23);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(121, 35);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(81, 20);
            this.tbSearch.TabIndex = 6;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.Location = new System.Drawing.Point(6, 19);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(112, 199);
            this.lstUsers.TabIndex = 6;
            // 
            // lbExitApplication
            // 
            this.lbExitApplication.AutoSize = true;
            this.lbExitApplication.Location = new System.Drawing.Point(9, 254);
            this.lbExitApplication.Name = "lbExitApplication";
            this.lbExitApplication.Size = new System.Drawing.Size(152, 13);
            this.lbExitApplication.TabIndex = 6;
            this.lbExitApplication.Text = "Ctrl + W to exit this application.";
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 271);
            this.Controls.Add(this.lbExitApplication);
            this.Controls.Add(this.grpUsers);
            this.Controls.Add(this.grpUserCreate);
            this.Controls.Add(this.tbReceived);
            this.Controls.Add(this.lbPipeName);
            this.Controls.Add(this.tbPipeName);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ServerForm";
            this.Text = "Server";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServerForm_KeyDown);
            this.grpUserCreate.ResumeLayout(false);
            this.grpUserCreate.PerformLayout();
            this.grpUsers.ResumeLayout(false);
            this.grpUsers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox tbPipeName;
        private System.Windows.Forms.Label lbPipeName;
        private System.Windows.Forms.TextBox tbReceived;
        private System.Windows.Forms.GroupBox grpUserCreate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbUserId;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.TextBox tbUserId;
        private System.Windows.Forms.GroupBox grpUsers;
        private System.Windows.Forms.ListBox lstUsers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label lbUserIdSearch;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Label lbExitApplication;
    }
}

