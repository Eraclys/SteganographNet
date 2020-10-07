namespace SteganographNet.UI.ImageSteganographer
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._openImageFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveImageFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this._saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._labelName = new System.Windows.Forms.Label();
            this._labelMaxCapacity = new System.Windows.Forms.Label();
            this._labelHeight = new System.Windows.Forms.Label();
            this._labelWidth = new System.Windows.Forms.Label();
            this._textBoxMessage = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._radioButtonFile = new System.Windows.Forms.RadioButton();
            this._radioButtonMessage = new System.Windows.Forms.RadioButton();
            this.buttonEmbed = new System.Windows.Forms.Button();
            this.buttonExctract = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._groupBoxMessage = new System.Windows.Forms.GroupBox();
            this._groupBoxFile = new System.Windows.Forms.GroupBox();
            this.labelTargetFile = new System.Windows.Forms.Label();
            this.buttonExtractFile = new System.Windows.Forms.Button();
            this._textBoxTargetFile = new System.Windows.Forms.TextBox();
            this.buttonSelectTargetFile = new System.Windows.Forms.Button();
            this.buttonEmbedFile = new System.Windows.Forms.Button();
            this.labelSourceFileLocation = new System.Windows.Forms.Label();
            this.buttonSelectSourceFile = new System.Windows.Forms.Button();
            this._textBoxSourceFile = new System.Windows.Forms.TextBox();
            this._openSourceFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveTargetFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this._groupBoxMessage.SuspendLayout();
            this._groupBoxFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // _openImageFileDialog
            // 
            this._openImageFileDialog.FileName = "openFileDialog1";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1026, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._openToolStripMenuItem,
            this.toolStripSeparator,
            this._saveToolStripMenuItem,
            this._saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this._exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // _openToolStripMenuItem
            // 
            this._openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
            this._openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this._openToolStripMenuItem.Text = "&Open";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
            // 
            // _saveToolStripMenuItem
            // 
            this._saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveToolStripMenuItem.Name = "_saveToolStripMenuItem";
            this._saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this._saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this._saveToolStripMenuItem.Text = "&Save";
            // 
            // _saveAsToolStripMenuItem
            // 
            this._saveAsToolStripMenuItem.Name = "_saveAsToolStripMenuItem";
            this._saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this._saveAsToolStripMenuItem.Text = "Save &As";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // _exitToolStripMenuItem
            // 
            this._exitToolStripMenuItem.Name = "_exitToolStripMenuItem";
            this._exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this._exitToolStripMenuItem.Text = "E&xit";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._labelName);
            this.groupBox1.Controls.Add(this._labelMaxCapacity);
            this.groupBox1.Controls.Add(this._labelHeight);
            this.groupBox1.Controls.Add(this._labelWidth);
            this.groupBox1.Location = new System.Drawing.Point(265, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 127);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Image stats";
            // 
            // _labelName
            // 
            this._labelName.AutoSize = true;
            this._labelName.Location = new System.Drawing.Point(7, 19);
            this._labelName.Name = "_labelName";
            this._labelName.Size = new System.Drawing.Size(42, 15);
            this._labelName.TabIndex = 0;
            this._labelName.Text = "Name:";
            // 
            // _labelMaxCapacity
            // 
            this._labelMaxCapacity.AutoSize = true;
            this._labelMaxCapacity.Location = new System.Drawing.Point(7, 67);
            this._labelMaxCapacity.Name = "_labelMaxCapacity";
            this._labelMaxCapacity.Size = new System.Drawing.Size(99, 15);
            this._labelMaxCapacity.TabIndex = 0;
            this._labelMaxCapacity.Text = "Storage Capacity:";
            // 
            // _labelHeight
            // 
            this._labelHeight.AutoSize = true;
            this._labelHeight.Location = new System.Drawing.Point(7, 52);
            this._labelHeight.Name = "_labelHeight";
            this._labelHeight.Size = new System.Drawing.Size(49, 15);
            this._labelHeight.TabIndex = 0;
            this._labelHeight.Text = "Height: ";
            // 
            // _labelWidth
            // 
            this._labelWidth.AutoSize = true;
            this._labelWidth.Location = new System.Drawing.Point(7, 35);
            this._labelWidth.Name = "_labelWidth";
            this._labelWidth.Size = new System.Drawing.Size(45, 15);
            this._labelWidth.TabIndex = 0;
            this._labelWidth.Text = "Witdh: ";
            // 
            // _textBoxMessage
            // 
            this._textBoxMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textBoxMessage.Location = new System.Drawing.Point(6, 51);
            this._textBoxMessage.Multiline = true;
            this._textBoxMessage.Name = "_textBoxMessage";
            this._textBoxMessage.Size = new System.Drawing.Size(466, 400);
            this._textBoxMessage.TabIndex = 3;
            this._textBoxMessage.TextChanged += new System.EventHandler(this.TextBoxMessage_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._radioButtonFile);
            this.groupBox2.Controls.Add(this._radioButtonMessage);
            this.groupBox2.Location = new System.Drawing.Point(12, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(244, 127);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Options";
            // 
            // _radioButtonFile
            // 
            this._radioButtonFile.AutoSize = true;
            this._radioButtonFile.Location = new System.Drawing.Point(6, 47);
            this._radioButtonFile.Name = "_radioButtonFile";
            this._radioButtonFile.Size = new System.Drawing.Size(43, 19);
            this._radioButtonFile.TabIndex = 0;
            this._radioButtonFile.TabStop = true;
            this._radioButtonFile.Text = "File";
            this._radioButtonFile.UseVisualStyleBackColor = true;
            this._radioButtonFile.CheckedChanged += new System.EventHandler(this.RadioButtonFile_CheckedChanged);
            // 
            // _radioButtonMessage
            // 
            this._radioButtonMessage.AutoSize = true;
            this._radioButtonMessage.Location = new System.Drawing.Point(6, 22);
            this._radioButtonMessage.Name = "_radioButtonMessage";
            this._radioButtonMessage.Size = new System.Drawing.Size(71, 19);
            this._radioButtonMessage.TabIndex = 0;
            this._radioButtonMessage.TabStop = true;
            this._radioButtonMessage.Text = "Message";
            this._radioButtonMessage.UseVisualStyleBackColor = true;
            this._radioButtonMessage.CheckedChanged += new System.EventHandler(this.RadioButtonMessage_CheckedChanged);
            // 
            // buttonEmbed
            // 
            this.buttonEmbed.Location = new System.Drawing.Point(364, 22);
            this.buttonEmbed.Name = "buttonEmbed";
            this.buttonEmbed.Size = new System.Drawing.Size(108, 23);
            this.buttonEmbed.TabIndex = 5;
            this.buttonEmbed.Text = "Embed Message";
            this.buttonEmbed.UseVisualStyleBackColor = true;
            this.buttonEmbed.Click += new System.EventHandler(this.ButtonEmbed_Click);
            // 
            // buttonExctract
            // 
            this.buttonExctract.Location = new System.Drawing.Point(260, 22);
            this.buttonExctract.Name = "buttonExctract";
            this.buttonExctract.Size = new System.Drawing.Size(104, 23);
            this.buttonExctract.TabIndex = 6;
            this.buttonExctract.Text = "Extract Message";
            this.buttonExctract.UseVisualStyleBackColor = true;
            this.buttonExctract.Click += new System.EventHandler(this.ButtonExtract_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Location = new System.Drawing.Point(496, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(518, 581);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // _groupBoxMessage
            // 
            this._groupBoxMessage.Controls.Add(this.buttonEmbed);
            this._groupBoxMessage.Controls.Add(this.buttonExctract);
            this._groupBoxMessage.Controls.Add(this._textBoxMessage);
            this._groupBoxMessage.Location = new System.Drawing.Point(12, 160);
            this._groupBoxMessage.Name = "_groupBoxMessage";
            this._groupBoxMessage.Size = new System.Drawing.Size(478, 457);
            this._groupBoxMessage.TabIndex = 8;
            this._groupBoxMessage.TabStop = false;
            this._groupBoxMessage.Text = "Message";
            this._groupBoxMessage.Visible = false;
            // 
            // _groupBoxFile
            // 
            this._groupBoxFile.Controls.Add(this.labelTargetFile);
            this._groupBoxFile.Controls.Add(this.buttonExtractFile);
            this._groupBoxFile.Controls.Add(this._textBoxTargetFile);
            this._groupBoxFile.Controls.Add(this.buttonSelectTargetFile);
            this._groupBoxFile.Controls.Add(this.buttonEmbedFile);
            this._groupBoxFile.Controls.Add(this.labelSourceFileLocation);
            this._groupBoxFile.Controls.Add(this.buttonSelectSourceFile);
            this._groupBoxFile.Controls.Add(this._textBoxSourceFile);
            this._groupBoxFile.Location = new System.Drawing.Point(13, 160);
            this._groupBoxFile.Name = "_groupBoxFile";
            this._groupBoxFile.Size = new System.Drawing.Size(478, 457);
            this._groupBoxFile.TabIndex = 7;
            this._groupBoxFile.TabStop = false;
            this._groupBoxFile.Text = "File";
            this._groupBoxFile.Visible = false;
            // 
            // labelTargetFile
            // 
            this.labelTargetFile.AutoSize = true;
            this.labelTargetFile.Location = new System.Drawing.Point(5, 73);
            this.labelTargetFile.Name = "labelTargetFile";
            this.labelTargetFile.Size = new System.Drawing.Size(70, 15);
            this.labelTargetFile.TabIndex = 1;
            this.labelTargetFile.Text = "Destination:";
            // 
            // buttonExtractFile
            // 
            this.buttonExtractFile.Location = new System.Drawing.Point(402, 90);
            this.buttonExtractFile.Name = "buttonExtractFile";
            this.buttonExtractFile.Size = new System.Drawing.Size(75, 23);
            this.buttonExtractFile.TabIndex = 2;
            this.buttonExtractFile.Text = "Extract";
            this.buttonExtractFile.UseVisualStyleBackColor = true;
            this.buttonExtractFile.Click += new System.EventHandler(this.ButtonExtractFile_Click);
            // 
            // _textBoxTargetFile
            // 
            this._textBoxTargetFile.Location = new System.Drawing.Point(5, 91);
            this._textBoxTargetFile.Name = "_textBoxTargetFile";
            this._textBoxTargetFile.Size = new System.Drawing.Size(309, 23);
            this._textBoxTargetFile.TabIndex = 0;
            // 
            // buttonSelectTargetFile
            // 
            this.buttonSelectTargetFile.Location = new System.Drawing.Point(321, 91);
            this.buttonSelectTargetFile.Name = "buttonSelectTargetFile";
            this.buttonSelectTargetFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectTargetFile.TabIndex = 2;
            this.buttonSelectTargetFile.Text = "Browse";
            this.buttonSelectTargetFile.UseVisualStyleBackColor = true;
            this.buttonSelectTargetFile.Click += new System.EventHandler(this.ButtonSelectTargetFile_Click);
            // 
            // buttonEmbedFile
            // 
            this.buttonEmbedFile.Location = new System.Drawing.Point(402, 40);
            this.buttonEmbedFile.Name = "buttonEmbedFile";
            this.buttonEmbedFile.Size = new System.Drawing.Size(75, 23);
            this.buttonEmbedFile.TabIndex = 2;
            this.buttonEmbedFile.Text = "Embed";
            this.buttonEmbedFile.UseVisualStyleBackColor = true;
            this.buttonEmbedFile.Click += new System.EventHandler(this.ButtonEmbedFile_Click);
            // 
            // labelSourceFileLocation
            // 
            this.labelSourceFileLocation.AutoSize = true;
            this.labelSourceFileLocation.Location = new System.Drawing.Point(6, 22);
            this.labelSourceFileLocation.Name = "labelSourceFileLocation";
            this.labelSourceFileLocation.Size = new System.Drawing.Size(46, 15);
            this.labelSourceFileLocation.TabIndex = 1;
            this.labelSourceFileLocation.Text = "Source:";
            // 
            // buttonSelectSourceFile
            // 
            this.buttonSelectSourceFile.Location = new System.Drawing.Point(321, 40);
            this.buttonSelectSourceFile.Name = "buttonSelectSourceFile";
            this.buttonSelectSourceFile.Size = new System.Drawing.Size(75, 23);
            this.buttonSelectSourceFile.TabIndex = 2;
            this.buttonSelectSourceFile.Text = "Browse";
            this.buttonSelectSourceFile.UseVisualStyleBackColor = true;
            this.buttonSelectSourceFile.Click += new System.EventHandler(this.ButtonSelectSourceFile_Click);
            // 
            // _textBoxSourceFile
            // 
            this._textBoxSourceFile.Location = new System.Drawing.Point(6, 40);
            this._textBoxSourceFile.Name = "_textBoxSourceFile";
            this._textBoxSourceFile.Size = new System.Drawing.Size(309, 23);
            this._textBoxSourceFile.TabIndex = 0;
            // 
            // _openSourceFileDialog
            // 
            this._openSourceFileDialog.FileName = "openFileDialog1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 629);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._groupBoxFile);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this._groupBoxMessage);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Main";
            this.Text = "Image Steganographer";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this._groupBoxMessage.ResumeLayout(false);
            this._groupBoxMessage.PerformLayout();
            this._groupBoxFile.ResumeLayout(false);
            this._groupBoxFile.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog _openImageFileDialog;
        private System.Windows.Forms.SaveFileDialog _saveImageFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripMenuItem _saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label _labelWidth;
        private System.Windows.Forms.Label _labelHeight;
        private System.Windows.Forms.Label _labelMaxCapacity;
        private System.Windows.Forms.Label _labelName;
        private System.Windows.Forms.TextBox _textBoxMessage;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonEmbed;
        private System.Windows.Forms.Button buttonExctract;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox _groupBoxMessage;
        private System.Windows.Forms.RadioButton _radioButtonFile;
        private System.Windows.Forms.RadioButton _radioButtonMessage;
        private System.Windows.Forms.GroupBox _groupBoxFile;
        private System.Windows.Forms.Label labelSourceFileLocation;
        private System.Windows.Forms.TextBox _textBoxSourceFile;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonEmbedFile;
        private System.Windows.Forms.TextBox _textBoxTargetFile;
        private System.Windows.Forms.Button buttonSelectTargetFile;
        private System.Windows.Forms.Button buttonSelectSourceFile;
        private System.Windows.Forms.Button buttonExtractFile;
        private System.Windows.Forms.Label labelTargetFile;
        private System.Windows.Forms.OpenFileDialog _openSourceFileDialog;
        private System.Windows.Forms.SaveFileDialog _saveTargetFileDialog;
    }
}

