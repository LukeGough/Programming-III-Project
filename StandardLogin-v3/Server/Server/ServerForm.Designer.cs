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
            this.lbUserIdSearch = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.lstUsers = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.grpUserCreate.SuspendLayout();
            this.grpUsers.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(234, 37);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(112, 31);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "Start Server";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tbPipeName
            // 
            this.tbPipeName.Location = new System.Drawing.Point(18, 38);
            this.tbPipeName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPipeName.Name = "tbPipeName";
            this.tbPipeName.ReadOnly = true;
            this.tbPipeName.Size = new System.Drawing.Size(205, 26);
            this.tbPipeName.TabIndex = 1;
            this.tbPipeName.Text = "\\\\.\\pipe\\myNamedPipe";
            // 
            // lbPipeName
            // 
            this.lbPipeName.AutoSize = true;
            this.lbPipeName.Location = new System.Drawing.Point(18, 14);
            this.lbPipeName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPipeName.Name = "lbPipeName";
            this.lbPipeName.Size = new System.Drawing.Size(90, 20);
            this.lbPipeName.TabIndex = 0;
            this.lbPipeName.Text = "Pipe Name:";
            // 
            // tbReceived
            // 
            this.tbReceived.Location = new System.Drawing.Point(18, 78);
            this.tbReceived.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbReceived.Multiline = true;
            this.tbReceived.Name = "tbReceived";
            this.tbReceived.ReadOnly = true;
            this.tbReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbReceived.Size = new System.Drawing.Size(326, 141);
            this.tbReceived.TabIndex = 3;
            // 
            // grpUserCreate
            // 
            this.grpUserCreate.Controls.Add(this.btnCreate);
            this.grpUserCreate.Controls.Add(this.lbPassword);
            this.grpUserCreate.Controls.Add(this.lbUserId);
            this.grpUserCreate.Controls.Add(this.tbPassword);
            this.grpUserCreate.Controls.Add(this.tbUserId);
            this.grpUserCreate.Location = new System.Drawing.Point(18, 231);
            this.grpUserCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpUserCreate.Name = "grpUserCreate";
            this.grpUserCreate.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpUserCreate.Size = new System.Drawing.Size(328, 155);
            this.grpUserCreate.TabIndex = 4;
            this.grpUserCreate.TabStop = false;
            this.grpUserCreate.Text = "User Create";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(207, 109);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(112, 35);
            this.btnCreate.TabIndex = 5;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(9, 74);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(78, 20);
            this.lbPassword.TabIndex = 3;
            this.lbPassword.Text = "Password";
            // 
            // lbUserId
            // 
            this.lbUserId.AutoSize = true;
            this.lbUserId.Location = new System.Drawing.Point(24, 34);
            this.lbUserId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserId.Name = "lbUserId";
            this.lbUserId.Size = new System.Drawing.Size(64, 20);
            this.lbUserId.TabIndex = 2;
            this.lbUserId.Text = "User ID";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(98, 69);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(220, 26);
            this.tbPassword.TabIndex = 1;
            // 
            // tbUserId
            // 
            this.tbUserId.Location = new System.Drawing.Point(98, 29);
            this.tbUserId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserId.Name = "tbUserId";
            this.tbUserId.Size = new System.Drawing.Size(220, 26);
            this.tbUserId.TabIndex = 0;
            // 
            // grpUsers
            // 
            this.grpUsers.Controls.Add(this.btnExportCSV);
            this.grpUsers.Controls.Add(this.lbUserIdSearch);
            this.grpUsers.Controls.Add(this.btnSearch);
            this.grpUsers.Controls.Add(this.tbSearch);
            this.grpUsers.Controls.Add(this.lstUsers);
            this.grpUsers.Location = new System.Drawing.Point(356, 31);
            this.grpUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpUsers.Name = "grpUsers";
            this.grpUsers.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpUsers.Size = new System.Drawing.Size(308, 355);
            this.grpUsers.TabIndex = 5;
            this.grpUsers.TabStop = false;
            this.grpUsers.Text = "User IDs";
            // 
            // lbUserIdSearch
            // 
            this.lbUserIdSearch.AutoSize = true;
            this.lbUserIdSearch.Location = new System.Drawing.Point(182, 29);
            this.lbUserIdSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserIdSearch.Name = "lbUserIdSearch";
            this.lbUserIdSearch.Size = new System.Drawing.Size(119, 20);
            this.lbUserIdSearch.TabIndex = 7;
            this.lbUserIdSearch.Text = "User ID Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(182, 94);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(119, 35);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(182, 54);
            this.tbSearch.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(119, 26);
            this.tbSearch.TabIndex = 6;
            // 
            // lstUsers
            // 
            this.lstUsers.FormattingEnabled = true;
            this.lstUsers.ItemHeight = 20;
            this.lstUsers.Location = new System.Drawing.Point(9, 29);
            this.lstUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstUsers.Name = "lstUsers";
            this.lstUsers.Size = new System.Drawing.Size(166, 304);
            this.lstUsers.TabIndex = 6;
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Location = new System.Drawing.Point(182, 137);
            this.btnExportCSV.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(119, 35);
            this.btnExportCSV.TabIndex = 8;
            this.btnExportCSV.Text = "Export to CSV";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 418);
            this.Controls.Add(this.grpUsers);
            this.Controls.Add(this.grpUserCreate);
            this.Controls.Add(this.tbReceived);
            this.Controls.Add(this.lbPipeName);
            this.Controls.Add(this.tbPipeName);
            this.Controls.Add(this.btnStart);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ServerForm";
            this.Text = "Server";
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
    }
}

