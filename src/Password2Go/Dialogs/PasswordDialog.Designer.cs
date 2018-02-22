namespace Password2Go.Dialogs
{
    partial class PasswordDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordDialog));
            this.rtbPassword1 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.rtbPassword2 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.rbOk = new Telerik.WinControls.UI.RadButton();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            ((System.ComponentModel.ISupportInitialize)(this.rtbPassword1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbPassword2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbPassword1
            // 
            this.rtbPassword1.Location = new System.Drawing.Point(129, 46);
            this.rtbPassword1.Name = "rtbPassword1";
            this.rtbPassword1.PasswordChar = '*';
            this.rtbPassword1.Size = new System.Drawing.Size(190, 20);
            this.rtbPassword1.TabIndex = 0;
            this.rtbPassword1.ThemeName = "Office2013Dark";
            // 
            // rtbPassword2
            // 
            this.rtbPassword2.Location = new System.Drawing.Point(129, 72);
            this.rtbPassword2.Name = "rtbPassword2";
            this.rtbPassword2.PasswordChar = '*';
            this.rtbPassword2.Size = new System.Drawing.Size(190, 20);
            this.rtbPassword2.TabIndex = 1;
            this.rtbPassword2.ThemeName = "Office2013Dark";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(15, 47);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(61, 19);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Password:";
            this.radLabel1.ThemeName = "Office2013Dark";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(15, 73);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(108, 19);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Confirm password:";
            this.radLabel2.ThemeName = "Office2013Dark";
            // 
            // rbOk
            // 
            this.rbOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOk.Location = new System.Drawing.Point(229, 6);
            this.rbOk.Name = "rbOk";
            this.rbOk.Size = new System.Drawing.Size(90, 24);
            this.rbOk.TabIndex = 3;
            this.rbOk.Text = "Ok";
            this.rbOk.ThemeName = "Office2013Dark";
            this.rbOk.Click += new System.EventHandler(this.rbOk_Click);
            // 
            // radLabel3
            // 
            this.radLabel3.AutoSize = false;
            this.radLabel3.BackColor = System.Drawing.Color.Transparent;
            this.radLabel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel3.Location = new System.Drawing.Point(0, 0);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(331, 35);
            this.radLabel3.TabIndex = 5;
            this.radLabel3.Text = "Password description";
            this.radLabel3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLabel3.ThemeName = "VisualStudio2012Dark";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.rbOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 111);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 35);
            this.panel1.TabIndex = 6;
            // 
            // PasswordDialog
            // 
            this.AcceptButton = this.rbOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 146);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.rtbPassword2);
            this.Controls.Add(this.rtbPassword1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordDialog";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter password";
            this.ThemeName = "Office2013Dark";
            ((System.ComponentModel.ISupportInitialize)(this.rtbPassword1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbPassword2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadTextBoxControl rtbPassword1;
        private Telerik.WinControls.UI.RadTextBoxControl rtbPassword2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadButton rbOk;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
    }
}