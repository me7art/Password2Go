namespace Password2Go.Dialogs
{
    partial class PassphraseDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassphraseDialog));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbOk = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rtbPassword1 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.rcbRememberPassword = new Telerik.WinControls.UI.RadCheckBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbPassword1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcbRememberPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.rbOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 111);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(323, 35);
            this.panel1.TabIndex = 12;
            // 
            // rbOk
            // 
            this.rbOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rbOk.Location = new System.Drawing.Point(221, 6);
            this.rbOk.Name = "rbOk";
            this.rbOk.Size = new System.Drawing.Size(90, 24);
            this.rbOk.TabIndex = 20;
            this.rbOk.Text = "Ok";
            this.rbOk.ThemeName = "Office2013Dark";
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(0, 0);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(323, 35);
            this.radLabel3.TabIndex = 11;
            this.radLabel3.Text = "Password description";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLabel3.ThemeName = "Office2013Dark";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(15, 47);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(61, 19);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Password:";
            this.radLabel1.ThemeName = "Office2013Dark";
            // 
            // rtbPassword1
            // 
            this.rtbPassword1.Location = new System.Drawing.Point(82, 46);
            this.rtbPassword1.Name = "rtbPassword1";
            this.rtbPassword1.PasswordChar = '*';
            this.rtbPassword1.Size = new System.Drawing.Size(237, 20);
            this.rtbPassword1.TabIndex = 10;
            this.rtbPassword1.ThemeName = "Office2013Dark";
            // 
            // rcbRememberPassword
            // 
            this.rcbRememberPassword.Location = new System.Drawing.Point(81, 76);
            this.rcbRememberPassword.Name = "rcbRememberPassword";
            this.rcbRememberPassword.Size = new System.Drawing.Size(131, 18);
            this.rcbRememberPassword.TabIndex = 15;
            this.rcbRememberPassword.Text = "Remember password";
            this.rcbRememberPassword.ThemeName = "Office2013Dark";
            // 
            // PassphraseDialog
            // 
            this.AcceptButton = this.rbOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 146);
            this.Controls.Add(this.rcbRememberPassword);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.rtbPassword1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PassphraseDialog";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter password";
            this.ThemeName = "Office2013Dark";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbPassword1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rcbRememberPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton rbOk;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBoxControl rtbPassword1;
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
        private Telerik.WinControls.UI.RadCheckBox rcbRememberPassword;
    }
}