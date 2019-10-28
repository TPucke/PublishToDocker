namespace PublishShinyApp
{
    partial class Form1
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
            this.comboBaseRegistry = new System.Windows.Forms.ComboBox();
            this.lblBasePassword = new System.Windows.Forms.Label();
            this.lblBaseUserName = new System.Windows.Forms.Label();
            this.txtBasePassword = new System.Windows.Forms.TextBox();
            this.txtBaseUserName = new System.Windows.Forms.TextBox();
            this.chkBaseAnonymous = new System.Windows.Forms.CheckBox();
            this.grpBaseRegistry = new System.Windows.Forms.GroupBox();
            this.btnBaseLogin = new System.Windows.Forms.Button();
            this.chkBaseConnected = new System.Windows.Forms.CheckBox();
            this.grpTargetRegistry = new System.Windows.Forms.GroupBox();
            this.btnTargetLogin = new System.Windows.Forms.Button();
            this.chkTargetConnected = new System.Windows.Forms.CheckBox();
            this.chkTargetAnonymous = new System.Windows.Forms.CheckBox();
            this.comboTargetRegistry = new System.Windows.Forms.ComboBox();
            this.lblTargetPassword = new System.Windows.Forms.Label();
            this.txtTargetUserName = new System.Windows.Forms.TextBox();
            this.lblTargetUserName = new System.Windows.Forms.Label();
            this.txtTargetPassword = new System.Windows.Forms.TextBox();
            this.comboBaseRepository = new System.Windows.Forms.ComboBox();
            this.lstPackages = new System.Windows.Forms.ListBox();
            this.btnApplicationFolder = new System.Windows.Forms.Button();
            this.lblApplicationFolder = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lstTags = new System.Windows.Forms.ListBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.txtAddPackage = new System.Windows.Forms.TextBox();
            this.btnAddPackage = new System.Windows.Forms.Button();
            this.grpBaseRegistry.SuspendLayout();
            this.grpTargetRegistry.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBaseRegistry
            // 
            this.comboBaseRegistry.FormattingEnabled = true;
            this.comboBaseRegistry.Items.AddRange(new object[] {
            "registry.hub.docker.com",
            "localhost:5000"});
            this.comboBaseRegistry.Location = new System.Drawing.Point(6, 19);
            this.comboBaseRegistry.Name = "comboBaseRegistry";
            this.comboBaseRegistry.Size = new System.Drawing.Size(165, 21);
            this.comboBaseRegistry.TabIndex = 0;
            this.comboBaseRegistry.Text = "registry.hub.docker.com";
            // 
            // lblBasePassword
            // 
            this.lblBasePassword.AutoSize = true;
            this.lblBasePassword.Location = new System.Drawing.Point(17, 105);
            this.lblBasePassword.Name = "lblBasePassword";
            this.lblBasePassword.Size = new System.Drawing.Size(56, 13);
            this.lblBasePassword.TabIndex = 96;
            this.lblBasePassword.Text = "Password:";
            // 
            // lblBaseUserName
            // 
            this.lblBaseUserName.AutoSize = true;
            this.lblBaseUserName.Location = new System.Drawing.Point(13, 78);
            this.lblBaseUserName.Name = "lblBaseUserName";
            this.lblBaseUserName.Size = new System.Drawing.Size(60, 13);
            this.lblBaseUserName.TabIndex = 95;
            this.lblBaseUserName.Text = "UserName:";
            // 
            // txtBasePassword
            // 
            this.txtBasePassword.Enabled = false;
            this.txtBasePassword.Location = new System.Drawing.Point(75, 102);
            this.txtBasePassword.Name = "txtBasePassword";
            this.txtBasePassword.PasswordChar = '*';
            this.txtBasePassword.Size = new System.Drawing.Size(193, 20);
            this.txtBasePassword.TabIndex = 94;
            // 
            // txtBaseUserName
            // 
            this.txtBaseUserName.Enabled = false;
            this.txtBaseUserName.Location = new System.Drawing.Point(75, 71);
            this.txtBaseUserName.Name = "txtBaseUserName";
            this.txtBaseUserName.Size = new System.Drawing.Size(193, 20);
            this.txtBaseUserName.TabIndex = 93;
            // 
            // chkBaseAnonymous
            // 
            this.chkBaseAnonymous.AutoSize = true;
            this.chkBaseAnonymous.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBaseAnonymous.Checked = true;
            this.chkBaseAnonymous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBaseAnonymous.Location = new System.Drawing.Point(6, 46);
            this.chkBaseAnonymous.Name = "chkBaseAnonymous";
            this.chkBaseAnonymous.Size = new System.Drawing.Size(84, 17);
            this.chkBaseAnonymous.TabIndex = 92;
            this.chkBaseAnonymous.Text = "Anonymous:";
            this.chkBaseAnonymous.UseVisualStyleBackColor = true;
            this.chkBaseAnonymous.CheckedChanged += new System.EventHandler(this.chkAnonymous_CheckedChanged);
            // 
            // grpBaseRegistry
            // 
            this.grpBaseRegistry.Controls.Add(this.btnBaseLogin);
            this.grpBaseRegistry.Controls.Add(this.chkBaseConnected);
            this.grpBaseRegistry.Controls.Add(this.chkBaseAnonymous);
            this.grpBaseRegistry.Controls.Add(this.comboBaseRegistry);
            this.grpBaseRegistry.Controls.Add(this.lblBasePassword);
            this.grpBaseRegistry.Controls.Add(this.txtBaseUserName);
            this.grpBaseRegistry.Controls.Add(this.lblBaseUserName);
            this.grpBaseRegistry.Controls.Add(this.txtBasePassword);
            this.grpBaseRegistry.Location = new System.Drawing.Point(12, 12);
            this.grpBaseRegistry.Name = "grpBaseRegistry";
            this.grpBaseRegistry.Size = new System.Drawing.Size(277, 133);
            this.grpBaseRegistry.TabIndex = 97;
            this.grpBaseRegistry.TabStop = false;
            this.grpBaseRegistry.Text = "Base Image Registry";
            // 
            // btnBaseLogin
            // 
            this.btnBaseLogin.Location = new System.Drawing.Point(193, 17);
            this.btnBaseLogin.Name = "btnBaseLogin";
            this.btnBaseLogin.Size = new System.Drawing.Size(75, 23);
            this.btnBaseLogin.TabIndex = 98;
            this.btnBaseLogin.Text = "Login";
            this.btnBaseLogin.UseVisualStyleBackColor = true;
            this.btnBaseLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkBaseConnected
            // 
            this.chkBaseConnected.AutoSize = true;
            this.chkBaseConnected.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBaseConnected.Enabled = false;
            this.chkBaseConnected.Location = new System.Drawing.Point(190, 46);
            this.chkBaseConnected.Name = "chkBaseConnected";
            this.chkBaseConnected.Size = new System.Drawing.Size(78, 17);
            this.chkBaseConnected.TabIndex = 97;
            this.chkBaseConnected.Text = "Connected";
            this.chkBaseConnected.UseVisualStyleBackColor = true;
            // 
            // grpTargetRegistry
            // 
            this.grpTargetRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpTargetRegistry.Controls.Add(this.btnTargetLogin);
            this.grpTargetRegistry.Controls.Add(this.chkTargetConnected);
            this.grpTargetRegistry.Controls.Add(this.chkTargetAnonymous);
            this.grpTargetRegistry.Controls.Add(this.comboTargetRegistry);
            this.grpTargetRegistry.Controls.Add(this.lblTargetPassword);
            this.grpTargetRegistry.Controls.Add(this.txtTargetUserName);
            this.grpTargetRegistry.Controls.Add(this.lblTargetUserName);
            this.grpTargetRegistry.Controls.Add(this.txtTargetPassword);
            this.grpTargetRegistry.Location = new System.Drawing.Point(511, 12);
            this.grpTargetRegistry.Name = "grpTargetRegistry";
            this.grpTargetRegistry.Size = new System.Drawing.Size(277, 133);
            this.grpTargetRegistry.TabIndex = 98;
            this.grpTargetRegistry.TabStop = false;
            this.grpTargetRegistry.Text = "Target Image Registry";
            // 
            // btnTargetLogin
            // 
            this.btnTargetLogin.Location = new System.Drawing.Point(193, 17);
            this.btnTargetLogin.Name = "btnTargetLogin";
            this.btnTargetLogin.Size = new System.Drawing.Size(75, 23);
            this.btnTargetLogin.TabIndex = 98;
            this.btnTargetLogin.Text = "Login";
            this.btnTargetLogin.UseVisualStyleBackColor = true;
            this.btnTargetLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // chkTargetConnected
            // 
            this.chkTargetConnected.AutoSize = true;
            this.chkTargetConnected.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTargetConnected.Enabled = false;
            this.chkTargetConnected.Location = new System.Drawing.Point(190, 46);
            this.chkTargetConnected.Name = "chkTargetConnected";
            this.chkTargetConnected.Size = new System.Drawing.Size(78, 17);
            this.chkTargetConnected.TabIndex = 97;
            this.chkTargetConnected.Text = "Connected";
            this.chkTargetConnected.UseVisualStyleBackColor = true;
            // 
            // chkTargetAnonymous
            // 
            this.chkTargetAnonymous.AutoSize = true;
            this.chkTargetAnonymous.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTargetAnonymous.Checked = true;
            this.chkTargetAnonymous.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTargetAnonymous.Location = new System.Drawing.Point(6, 46);
            this.chkTargetAnonymous.Name = "chkTargetAnonymous";
            this.chkTargetAnonymous.Size = new System.Drawing.Size(84, 17);
            this.chkTargetAnonymous.TabIndex = 92;
            this.chkTargetAnonymous.Text = "Anonymous:";
            this.chkTargetAnonymous.UseVisualStyleBackColor = true;
            this.chkTargetAnonymous.CheckedChanged += new System.EventHandler(this.chkAnonymous_CheckedChanged);
            // 
            // comboTargetRegistry
            // 
            this.comboTargetRegistry.FormattingEnabled = true;
            this.comboTargetRegistry.Items.AddRange(new object[] {
            "localhost:5000",
            "registry.hub.docker.com"});
            this.comboTargetRegistry.Location = new System.Drawing.Point(6, 19);
            this.comboTargetRegistry.Name = "comboTargetRegistry";
            this.comboTargetRegistry.Size = new System.Drawing.Size(165, 21);
            this.comboTargetRegistry.TabIndex = 0;
            this.comboTargetRegistry.Text = "localhost:5000";
            // 
            // lblTargetPassword
            // 
            this.lblTargetPassword.AutoSize = true;
            this.lblTargetPassword.Location = new System.Drawing.Point(17, 105);
            this.lblTargetPassword.Name = "lblTargetPassword";
            this.lblTargetPassword.Size = new System.Drawing.Size(56, 13);
            this.lblTargetPassword.TabIndex = 96;
            this.lblTargetPassword.Text = "Password:";
            // 
            // txtTargetUserName
            // 
            this.txtTargetUserName.Enabled = false;
            this.txtTargetUserName.Location = new System.Drawing.Point(75, 71);
            this.txtTargetUserName.Name = "txtTargetUserName";
            this.txtTargetUserName.Size = new System.Drawing.Size(193, 20);
            this.txtTargetUserName.TabIndex = 93;
            // 
            // lblTargetUserName
            // 
            this.lblTargetUserName.AutoSize = true;
            this.lblTargetUserName.Location = new System.Drawing.Point(13, 78);
            this.lblTargetUserName.Name = "lblTargetUserName";
            this.lblTargetUserName.Size = new System.Drawing.Size(60, 13);
            this.lblTargetUserName.TabIndex = 95;
            this.lblTargetUserName.Text = "UserName:";
            // 
            // txtTargetPassword
            // 
            this.txtTargetPassword.Enabled = false;
            this.txtTargetPassword.Location = new System.Drawing.Point(75, 102);
            this.txtTargetPassword.Name = "txtTargetPassword";
            this.txtTargetPassword.PasswordChar = '*';
            this.txtTargetPassword.Size = new System.Drawing.Size(193, 20);
            this.txtTargetPassword.TabIndex = 94;
            // 
            // comboBaseRepository
            // 
            this.comboBaseRepository.FormattingEnabled = true;
            this.comboBaseRepository.Items.AddRange(new object[] {
            "rocker/shiny"});
            this.comboBaseRepository.Location = new System.Drawing.Point(13, 165);
            this.comboBaseRepository.Name = "comboBaseRepository";
            this.comboBaseRepository.Size = new System.Drawing.Size(276, 21);
            this.comboBaseRepository.TabIndex = 99;
            this.comboBaseRepository.SelectedIndexChanged += new System.EventHandler(this.comboBaseRepository_SelectedIndexChanged);
            // 
            // lstPackages
            // 
            this.lstPackages.FormattingEnabled = true;
            this.lstPackages.Location = new System.Drawing.Point(308, 250);
            this.lstPackages.Name = "lstPackages";
            this.lstPackages.Size = new System.Drawing.Size(209, 186);
            this.lstPackages.TabIndex = 100;
            // 
            // btnApplicationFolder
            // 
            this.btnApplicationFolder.Location = new System.Drawing.Point(308, 195);
            this.btnApplicationFolder.Name = "btnApplicationFolder";
            this.btnApplicationFolder.Size = new System.Drawing.Size(72, 23);
            this.btnApplicationFolder.TabIndex = 101;
            this.btnApplicationFolder.Text = "App Folder";
            this.btnApplicationFolder.UseVisualStyleBackColor = true;
            this.btnApplicationFolder.Click += new System.EventHandler(this.btnApplicationFolder_Click);
            // 
            // lblApplicationFolder
            // 
            this.lblApplicationFolder.AutoSize = true;
            this.lblApplicationFolder.Location = new System.Drawing.Point(396, 200);
            this.lblApplicationFolder.Name = "lblApplicationFolder";
            this.lblApplicationFolder.Size = new System.Drawing.Size(0, 13);
            this.lblApplicationFolder.TabIndex = 102;
            // 
            // lstTags
            // 
            this.lstTags.FormattingEnabled = true;
            this.lstTags.Location = new System.Drawing.Point(12, 192);
            this.lstTags.Name = "lstTags";
            this.lstTags.Size = new System.Drawing.Size(277, 251);
            this.lstTags.TabIndex = 103;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(712, 165);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(75, 23);
            this.btnBuild.TabIndex = 104;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // txtAddPackage
            // 
            this.txtAddPackage.Location = new System.Drawing.Point(308, 224);
            this.txtAddPackage.Name = "txtAddPackage";
            this.txtAddPackage.Size = new System.Drawing.Size(119, 20);
            this.txtAddPackage.TabIndex = 105;
            // 
            // btnAddPackage
            // 
            this.btnAddPackage.Location = new System.Drawing.Point(433, 222);
            this.btnAddPackage.Name = "btnAddPackage";
            this.btnAddPackage.Size = new System.Drawing.Size(84, 23);
            this.btnAddPackage.TabIndex = 106;
            this.btnAddPackage.Text = "Add Package";
            this.btnAddPackage.UseVisualStyleBackColor = true;
            this.btnAddPackage.Click += new System.EventHandler(this.btnAddPackage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddPackage);
            this.Controls.Add(this.txtAddPackage);
            this.Controls.Add(this.btnBuild);
            this.Controls.Add(this.lstTags);
            this.Controls.Add(this.lblApplicationFolder);
            this.Controls.Add(this.btnApplicationFolder);
            this.Controls.Add(this.lstPackages);
            this.Controls.Add(this.comboBaseRepository);
            this.Controls.Add(this.grpTargetRegistry);
            this.Controls.Add(this.grpBaseRegistry);
            this.Name = "Form1";
            this.Text = "Form1";
            this.grpBaseRegistry.ResumeLayout(false);
            this.grpBaseRegistry.PerformLayout();
            this.grpTargetRegistry.ResumeLayout(false);
            this.grpTargetRegistry.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBaseRegistry;
        private System.Windows.Forms.Label lblBasePassword;
        private System.Windows.Forms.Label lblBaseUserName;
        private System.Windows.Forms.TextBox txtBasePassword;
        private System.Windows.Forms.TextBox txtBaseUserName;
        private System.Windows.Forms.CheckBox chkBaseAnonymous;
        private System.Windows.Forms.GroupBox grpBaseRegistry;
        private System.Windows.Forms.Button btnBaseLogin;
        private System.Windows.Forms.CheckBox chkBaseConnected;
        private System.Windows.Forms.GroupBox grpTargetRegistry;
        private System.Windows.Forms.Button btnTargetLogin;
        private System.Windows.Forms.CheckBox chkTargetConnected;
        private System.Windows.Forms.CheckBox chkTargetAnonymous;
        private System.Windows.Forms.ComboBox comboTargetRegistry;
        private System.Windows.Forms.Label lblTargetPassword;
        private System.Windows.Forms.TextBox txtTargetUserName;
        private System.Windows.Forms.Label lblTargetUserName;
        private System.Windows.Forms.TextBox txtTargetPassword;
        private System.Windows.Forms.ComboBox comboBaseRepository;
        private System.Windows.Forms.ListBox lstPackages;
        private System.Windows.Forms.Button btnApplicationFolder;
        private System.Windows.Forms.Label lblApplicationFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ListBox lstTags;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.TextBox txtAddPackage;
        private System.Windows.Forms.Button btnAddPackage;
    }
}

