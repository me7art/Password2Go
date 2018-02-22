namespace Password2Go.Modules.Preview
{
    partial class SitePreviewUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtbPassword = new Telerik.WinControls.UI.RadTextBoxControl();
            this.rbDecrypt = new Telerik.WinControls.UI.RadButton();
            this.rtbComment = new Telerik.WinControls.UI.RadTextBoxControl();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.rtbLogin = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rtbURL = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rtbPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDecrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbComment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbURL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbPassword
            // 
            this.rtbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPassword.IsReadOnly = true;
            this.rtbPassword.IsReadOnlyCaretVisible = true;
            this.rtbPassword.Location = new System.Drawing.Point(87, 73);
            this.rtbPassword.Name = "rtbPassword";
            this.rtbPassword.Size = new System.Drawing.Size(440, 20);
            this.rtbPassword.TabIndex = 9;
            this.rtbPassword.ThemeName = "Office2013Dark";
            // 
            // rbDecrypt
            // 
            this.rbDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDecrypt.Location = new System.Drawing.Point(417, 157);
            this.rbDecrypt.Name = "rbDecrypt";
            this.rbDecrypt.Size = new System.Drawing.Size(110, 24);
            this.rbDecrypt.TabIndex = 8;
            this.rbDecrypt.Text = "Decrypt";
            this.rbDecrypt.ThemeName = "Office2013Dark";
            this.rbDecrypt.Click += new System.EventHandler(this.rbDecrypt_Click);
            // 
            // rtbComment
            // 
            this.rtbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbComment.IsReadOnly = true;
            this.rtbComment.IsReadOnlyCaretVisible = true;
            this.rtbComment.Location = new System.Drawing.Point(87, 99);
            this.rtbComment.Multiline = true;
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(440, 51);
            this.rtbComment.TabIndex = 6;
            this.rtbComment.ThemeName = "Office2013Dark";
            // 
            // rtbLogin
            // 
            this.rtbLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbLogin.IsReadOnly = true;
            this.rtbLogin.IsReadOnlyCaretVisible = true;
            this.rtbLogin.Location = new System.Drawing.Point(87, 47);
            this.rtbLogin.Name = "rtbLogin";
            this.rtbLogin.Size = new System.Drawing.Size(440, 20);
            this.rtbLogin.TabIndex = 11;
            this.rtbLogin.ThemeName = "Office2013Dark";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(23, 73);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(58, 19);
            this.radLabel2.TabIndex = 12;
            this.radLabel2.Text = "Password";
            this.radLabel2.ThemeName = "Office2013Dark";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(21, 99);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(60, 19);
            this.radLabel6.TabIndex = 13;
            this.radLabel6.Text = "Comment";
            this.radLabel6.ThemeName = "Office2013Dark";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.rtbURL);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.rtbLogin);
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Controls.Add(this.rtbComment);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.rbDecrypt);
            this.radGroupBox1.Controls.Add(this.rtbPassword);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Selected Item";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(536, 189);
            this.radGroupBox1.TabIndex = 14;
            this.radGroupBox1.Text = "Selected Item";
            this.radGroupBox1.ThemeName = "Office2013Dark";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(53, 22);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(28, 19);
            this.radLabel1.TabIndex = 20;
            this.radLabel1.Text = "URL";
            this.radLabel1.ThemeName = "Office2013Dark";
            // 
            // rtbURL
            // 
            this.rtbURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbURL.IsReadOnly = true;
            this.rtbURL.IsReadOnlyCaretVisible = true;
            this.rtbURL.Location = new System.Drawing.Point(87, 21);
            this.rtbURL.Name = "rtbURL";
            this.rtbURL.Size = new System.Drawing.Size(440, 20);
            this.rtbURL.TabIndex = 18;
            this.rtbURL.ThemeName = "Office2013Dark";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(44, 48);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(37, 19);
            this.radLabel3.TabIndex = 14;
            this.radLabel3.Text = "Login";
            this.radLabel3.ThemeName = "Office2013Dark";
            // 
            // SitePreviewUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radGroupBox1);
            this.DoubleBuffered = true;
            this.Name = "SitePreviewUI";
            this.Size = new System.Drawing.Size(536, 189);
            ((System.ComponentModel.ISupportInitialize)(this.rtbPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDecrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbComment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbURL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBoxControl rtbPassword;
        private Telerik.WinControls.UI.RadButton rbDecrypt;
        private Telerik.WinControls.UI.RadTextBoxControl rtbComment;
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
        private Telerik.WinControls.UI.RadTextBoxControl rtbLogin;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBoxControl rtbURL;
    }
}
