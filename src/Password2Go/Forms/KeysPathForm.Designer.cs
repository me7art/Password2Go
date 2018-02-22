namespace Password2Go.Forms
{
    partial class KeysPathForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KeysPathForm));
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.rtbPublicKeyPath = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.rbSelectPrivateFile = new Telerik.WinControls.UI.RadButton();
            this.rbSelectPublicFile = new Telerik.WinControls.UI.RadButton();
            this.rtbPrivateKeyPath = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCancel = new Telerik.WinControls.UI.RadButton();
            this.rbOk = new Telerik.WinControls.UI.RadButton();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            ((System.ComponentModel.ISupportInitialize)(this.rtbPublicKeyPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbSelectPrivateFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSelectPublicFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbPrivateKeyPath)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbPublicKeyPath
            // 
            this.rtbPublicKeyPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPublicKeyPath.Location = new System.Drawing.Point(15, 55);
            this.rtbPublicKeyPath.Name = "rtbPublicKeyPath";
            this.rtbPublicKeyPath.Size = new System.Drawing.Size(359, 20);
            this.rtbPublicKeyPath.TabIndex = 10;
            this.rtbPublicKeyPath.ThemeName = "Office2013Dark";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(15, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(89, 19);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Public key path";
            this.radLabel1.ThemeName = "Office2013Dark";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.rbSelectPrivateFile);
            this.radGroupBox1.Controls.Add(this.rbSelectPublicFile);
            this.radGroupBox1.Controls.Add(this.rtbPrivateKeyPath);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.rtbPublicKeyPath);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Configuration";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(417, 139);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Configuration";
            this.radGroupBox1.ThemeName = "Office2013Dark";
            // 
            // rbSelectPrivateFile
            // 
            this.rbSelectPrivateFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSelectPrivateFile.Location = new System.Drawing.Point(380, 105);
            this.rbSelectPrivateFile.Name = "rbSelectPrivateFile";
            this.rbSelectPrivateFile.Size = new System.Drawing.Size(28, 20);
            this.rbSelectPrivateFile.TabIndex = 40;
            this.rbSelectPrivateFile.Text = "...";
            this.rbSelectPrivateFile.ThemeName = "Office2013Dark";
            this.rbSelectPrivateFile.Click += new System.EventHandler(this.rbSelectPrivateFile_Click);
            // 
            // rbSelectPublicFile
            // 
            this.rbSelectPublicFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSelectPublicFile.Location = new System.Drawing.Point(380, 55);
            this.rbSelectPublicFile.Name = "rbSelectPublicFile";
            this.rbSelectPublicFile.Size = new System.Drawing.Size(28, 20);
            this.rbSelectPublicFile.TabIndex = 20;
            this.rbSelectPublicFile.Text = "...";
            this.rbSelectPublicFile.ThemeName = "Office2013Dark";
            this.rbSelectPublicFile.Click += new System.EventHandler(this.rbSelectPublicFile_Click);
            // 
            // rtbPrivateKeyPath
            // 
            this.rtbPrivateKeyPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbPrivateKeyPath.Location = new System.Drawing.Point(15, 105);
            this.rtbPrivateKeyPath.Name = "rtbPrivateKeyPath";
            this.rtbPrivateKeyPath.Size = new System.Drawing.Size(359, 20);
            this.rtbPrivateKeyPath.TabIndex = 30;
            this.rtbPrivateKeyPath.ThemeName = "Office2013Dark";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(15, 81);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(94, 19);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Private key path";
            this.radLabel2.ThemeName = "Office2013Dark";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.rbCancel);
            this.panel1.Controls.Add(this.rbOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 139);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 33);
            this.panel1.TabIndex = 3;
            // 
            // rbCancel
            // 
            this.rbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.rbCancel.Location = new System.Drawing.Point(304, 6);
            this.rbCancel.Name = "rbCancel";
            this.rbCancel.Size = new System.Drawing.Size(110, 24);
            this.rbCancel.TabIndex = 60;
            this.rbCancel.Text = "Cancel";
            this.rbCancel.ThemeName = "Office2013Dark";
            // 
            // rbOk
            // 
            this.rbOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rbOk.Location = new System.Drawing.Point(188, 6);
            this.rbOk.Name = "rbOk";
            this.rbOk.Size = new System.Drawing.Size(110, 24);
            this.rbOk.TabIndex = 50;
            this.rbOk.Text = "Ok";
            this.rbOk.ThemeName = "Office2013Dark";
            // 
            // KeysPathForm
            // 
            this.AcceptButton = this.rbOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.rbCancel;
            this.ClientSize = new System.Drawing.Size(417, 172);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KeysPathForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Keys Location";
            this.ThemeName = "Office2013Dark";
            ((System.ComponentModel.ISupportInitialize)(this.rtbPublicKeyPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbSelectPrivateFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSelectPublicFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbPrivateKeyPath)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadTextBoxControl rtbPublicKeyPath;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton rbSelectPrivateFile;
        private Telerik.WinControls.UI.RadButton rbSelectPublicFile;
        private Telerik.WinControls.UI.RadTextBoxControl rtbPrivateKeyPath;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton rbCancel;
        private Telerik.WinControls.UI.RadButton rbOk;
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
    }
}