namespace SnippingToolAdvance
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.ntyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ntyMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToClipboardStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToImgurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.grpImgurSettings = new System.Windows.Forms.GroupBox();
            this.cmbAutoDeleteOptions = new System.Windows.Forms.ComboBox();
            this.lblAutoDelete = new System.Windows.Forms.Label();
            this.chkOpenBrowser = new System.Windows.Forms.CheckBox();
            this.lblAPIKeyStatusSet = new System.Windows.Forms.LinkLabel();
            this.lblAPIKeyStatus = new System.Windows.Forms.Label();
            this.grpSnippingToolAdvanceSettings = new System.Windows.Forms.GroupBox();
            this.chkAutoStart = new System.Windows.Forms.CheckBox();
            this.chkShowImage = new System.Windows.Forms.CheckBox();
            this.tmrAutoDelete = new System.Windows.Forms.Timer(this.components);
            this.lblLaura = new System.Windows.Forms.LinkLabel();
            this.ntyMenuStrip.SuspendLayout();
            this.grpImgurSettings.SuspendLayout();
            this.grpSnippingToolAdvanceSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // ntyIcon
            // 
            this.ntyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ntyIcon.ContextMenuStrip = this.ntyMenuStrip;
            this.ntyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ntyIcon.Icon")));
            this.ntyIcon.Text = "SnippingToolAdvance";
            this.ntyIcon.Visible = true;
            this.ntyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ntyIcon_MouseDoubleClick);
            // 
            // ntyMenuStrip
            // 
            this.ntyMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToClipboardStripMenuItem,
            this.saveToFileToolStripMenuItem,
            this.uploadToImgurToolStripMenuItem,
            this.convertToTextToolStripMenuItem,
            this.settingsToolStripMenuItem1});
            this.ntyMenuStrip.Name = "ntyMenuStrip";
            this.ntyMenuStrip.Size = new System.Drawing.Size(172, 114);
            // 
            // copyToClipboardStripMenuItem
            // 
            this.copyToClipboardStripMenuItem.Checked = true;
            this.copyToClipboardStripMenuItem.CheckOnClick = true;
            this.copyToClipboardStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.copyToClipboardStripMenuItem.Name = "copyToClipboardStripMenuItem";
            this.copyToClipboardStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.copyToClipboardStripMenuItem.Text = "Copy to Clipboard";
            this.copyToClipboardStripMenuItem.Click += new System.EventHandler(this.showDialogToolStripMenuItem_Click);
            // 
            // saveToFileToolStripMenuItem
            // 
            this.saveToFileToolStripMenuItem.CheckOnClick = true;
            this.saveToFileToolStripMenuItem.Name = "saveToFileToolStripMenuItem";
            this.saveToFileToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.saveToFileToolStripMenuItem.Text = "Save to File";
            this.saveToFileToolStripMenuItem.Click += new System.EventHandler(this.saveToFileToolStripMenuItem_Click);
            // 
            // uploadToImgurToolStripMenuItem
            // 
            this.uploadToImgurToolStripMenuItem.CheckOnClick = true;
            this.uploadToImgurToolStripMenuItem.Name = "uploadToImgurToolStripMenuItem";
            this.uploadToImgurToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.uploadToImgurToolStripMenuItem.Text = "Upload to Imgur";
            this.uploadToImgurToolStripMenuItem.Click += new System.EventHandler(this.uploadToImgurToolStripMenuItem_Click);
            // 
            // convertToTextToolStripMenuItem
            // 
            this.convertToTextToolStripMenuItem.CheckOnClick = true;
            this.convertToTextToolStripMenuItem.Name = "convertToTextToolStripMenuItem";
            this.convertToTextToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.convertToTextToolStripMenuItem.Text = "Convert to Text";
            this.convertToTextToolStripMenuItem.Click += new System.EventHandler(this.convertToTextToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem1
            // 
            this.settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            this.settingsToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.settingsToolStripMenuItem1.Text = "Settings";
            this.settingsToolStripMenuItem1.Click += new System.EventHandler(this.settingsToolStripMenuItem1_Click);
            // 
            // grpImgurSettings
            // 
            this.grpImgurSettings.Controls.Add(this.cmbAutoDeleteOptions);
            this.grpImgurSettings.Controls.Add(this.lblAutoDelete);
            this.grpImgurSettings.Controls.Add(this.chkOpenBrowser);
            this.grpImgurSettings.Controls.Add(this.lblAPIKeyStatusSet);
            this.grpImgurSettings.Controls.Add(this.lblAPIKeyStatus);
            this.grpImgurSettings.Location = new System.Drawing.Point(12, 12);
            this.grpImgurSettings.Name = "grpImgurSettings";
            this.grpImgurSettings.Size = new System.Drawing.Size(302, 104);
            this.grpImgurSettings.TabIndex = 1;
            this.grpImgurSettings.TabStop = false;
            this.grpImgurSettings.Text = "Imgur Settings";
            // 
            // cmbAutoDeleteOptions
            // 
            this.cmbAutoDeleteOptions.AutoCompleteCustomSource.AddRange(new string[] {
            "Auto delete on exit",
            "Auto delete after 5 minutes",
            "Auto delete after 10 minutes",
            "Never auto delete"});
            this.cmbAutoDeleteOptions.FormattingEnabled = true;
            this.cmbAutoDeleteOptions.Items.AddRange(new object[] {
            "Auto delete on exit ",
            "Auto delete after 5 minutes",
            "Auto delete after 10 minutes",
            "Never auto delete"});
            this.cmbAutoDeleteOptions.Location = new System.Drawing.Point(122, 26);
            this.cmbAutoDeleteOptions.Name = "cmbAutoDeleteOptions";
            this.cmbAutoDeleteOptions.Size = new System.Drawing.Size(174, 21);
            this.cmbAutoDeleteOptions.TabIndex = 8;
            this.cmbAutoDeleteOptions.SelectedIndexChanged += new System.EventHandler(this.cmbAutoDeleteOptions_SelectedIndexChanged);
            // 
            // lblAutoDelete
            // 
            this.lblAutoDelete.AutoSize = true;
            this.lblAutoDelete.Location = new System.Drawing.Point(6, 29);
            this.lblAutoDelete.Name = "lblAutoDelete";
            this.lblAutoDelete.Size = new System.Drawing.Size(110, 13);
            this.lblAutoDelete.TabIndex = 7;
            this.lblAutoDelete.Text = "Auto Delete Settings: ";
            // 
            // chkOpenBrowser
            // 
            this.chkOpenBrowser.AutoSize = true;
            this.chkOpenBrowser.Location = new System.Drawing.Point(9, 53);
            this.chkOpenBrowser.Name = "chkOpenBrowser";
            this.chkOpenBrowser.Size = new System.Drawing.Size(138, 17);
            this.chkOpenBrowser.TabIndex = 6;
            this.chkOpenBrowser.Text = "Open browser after snip";
            this.chkOpenBrowser.UseVisualStyleBackColor = true;
            this.chkOpenBrowser.CheckedChanged += new System.EventHandler(this.chkOpenBrowser_CheckedChanged);
            // 
            // lblAPIKeyStatusSet
            // 
            this.lblAPIKeyStatusSet.ActiveLinkColor = System.Drawing.Color.Red;
            this.lblAPIKeyStatusSet.AutoSize = true;
            this.lblAPIKeyStatusSet.LinkColor = System.Drawing.Color.Red;
            this.lblAPIKeyStatusSet.Location = new System.Drawing.Point(96, 73);
            this.lblAPIKeyStatusSet.Name = "lblAPIKeyStatusSet";
            this.lblAPIKeyStatusSet.Size = new System.Drawing.Size(44, 13);
            this.lblAPIKeyStatusSet.TabIndex = 5;
            this.lblAPIKeyStatusSet.TabStop = true;
            this.lblAPIKeyStatusSet.Text = "Not set!";
            this.lblAPIKeyStatusSet.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAPIKeyStatusSet_LinkClicked);
            // 
            // lblAPIKeyStatus
            // 
            this.lblAPIKeyStatus.AutoSize = true;
            this.lblAPIKeyStatus.Location = new System.Drawing.Point(6, 73);
            this.lblAPIKeyStatus.Name = "lblAPIKeyStatus";
            this.lblAPIKeyStatus.Size = new System.Drawing.Size(84, 13);
            this.lblAPIKeyStatus.TabIndex = 4;
            this.lblAPIKeyStatus.Text = "API Key Status: ";
            // 
            // grpSnippingToolAdvanceSettings
            // 
            this.grpSnippingToolAdvanceSettings.Controls.Add(this.lblLaura);
            this.grpSnippingToolAdvanceSettings.Controls.Add(this.chkAutoStart);
            this.grpSnippingToolAdvanceSettings.Controls.Add(this.chkShowImage);
            this.grpSnippingToolAdvanceSettings.Location = new System.Drawing.Point(12, 122);
            this.grpSnippingToolAdvanceSettings.Name = "grpSnippingToolAdvanceSettings";
            this.grpSnippingToolAdvanceSettings.Size = new System.Drawing.Size(302, 87);
            this.grpSnippingToolAdvanceSettings.TabIndex = 2;
            this.grpSnippingToolAdvanceSettings.TabStop = false;
            this.grpSnippingToolAdvanceSettings.Text = "General Settings";
            // 
            // chkAutoStart
            // 
            this.chkAutoStart.AutoSize = true;
            this.chkAutoStart.Location = new System.Drawing.Point(6, 42);
            this.chkAutoStart.Name = "chkAutoStart";
            this.chkAutoStart.Size = new System.Drawing.Size(131, 17);
            this.chkAutoStart.TabIndex = 1;
            this.chkAutoStart.Text = "Run on system startup";
            this.chkAutoStart.UseVisualStyleBackColor = true;
            this.chkAutoStart.CheckedChanged += new System.EventHandler(this.chkAutoStart_CheckedChanged);
            // 
            // chkShowImage
            // 
            this.chkShowImage.AutoSize = true;
            this.chkShowImage.Location = new System.Drawing.Point(6, 19);
            this.chkShowImage.Name = "chkShowImage";
            this.chkShowImage.Size = new System.Drawing.Size(130, 17);
            this.chkShowImage.TabIndex = 0;
            this.chkShowImage.Text = "Show image after snip";
            this.chkShowImage.UseVisualStyleBackColor = true;
            this.chkShowImage.CheckedChanged += new System.EventHandler(this.chkShowImage_CheckedChanged);
            // 
            // tmrAutoDelete
            // 
            this.tmrAutoDelete.Interval = 1000;
            this.tmrAutoDelete.Tick += new System.EventHandler(this.tmrAutoDelete_Tick);
            // 
            // lblLaura
            // 
            this.lblLaura.AutoSize = true;
            this.lblLaura.Location = new System.Drawing.Point(268, 71);
            this.lblLaura.Name = "lblLaura";
            this.lblLaura.Size = new System.Drawing.Size(34, 13);
            this.lblLaura.TabIndex = 3;
            this.lblLaura.TabStop = true;
            this.lblLaura.Text = "Laura";
            this.lblLaura.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblLaura_LinkClicked);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 221);
            this.Controls.Add(this.grpSnippingToolAdvanceSettings);
            this.Controls.Add(this.grpImgurSettings);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SnippingToolAdvanced";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ntyMenuStrip.ResumeLayout(false);
            this.grpImgurSettings.ResumeLayout(false);
            this.grpImgurSettings.PerformLayout();
            this.grpSnippingToolAdvanceSettings.ResumeLayout(false);
            this.grpSnippingToolAdvanceSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon ntyIcon;
        private System.Windows.Forms.ContextMenuStrip ntyMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToImgurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertToTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem1;
        private System.Windows.Forms.GroupBox grpImgurSettings;
        private System.Windows.Forms.GroupBox grpSnippingToolAdvanceSettings;
        private System.Windows.Forms.LinkLabel lblAPIKeyStatusSet;
        private System.Windows.Forms.Label lblAPIKeyStatus;
        private System.Windows.Forms.CheckBox chkOpenBrowser;
        private System.Windows.Forms.CheckBox chkShowImage;
        private System.Windows.Forms.ComboBox cmbAutoDeleteOptions;
        private System.Windows.Forms.Label lblAutoDelete;
        private System.Windows.Forms.CheckBox chkAutoStart;
        private System.Windows.Forms.Timer tmrAutoDelete;
        private System.Windows.Forms.LinkLabel lblLaura;
    }
}

