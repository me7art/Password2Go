namespace Password2Go.Dialogs
{
    partial class DatabaseInfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseInfoDialog));
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.radTextBoxControl1 = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rbChangeDirectory = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCancel = new Telerik.WinControls.UI.RadButton();
            this.rbSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbChangeDirectory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radTextBoxControl1
            // 
            this.radTextBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radTextBoxControl1.IsReadOnly = true;
            this.radTextBoxControl1.IsReadOnlyCaretVisible = true;
            this.radTextBoxControl1.Location = new System.Drawing.Point(12, 38);
            this.radTextBoxControl1.Name = "radTextBoxControl1";
            this.radTextBoxControl1.Size = new System.Drawing.Size(384, 20);
            this.radTextBoxControl1.TabIndex = 1;
            this.radTextBoxControl1.ThemeName = "Office2013Dark";
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(109, 20);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Database directory";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.radLabel1.ThemeName = "Office2013Dark";
            // 
            // rbChangeDirectory
            // 
            this.rbChangeDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbChangeDirectory.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.rbChangeDirectory.Location = new System.Drawing.Point(402, 38);
            this.rbChangeDirectory.Name = "rbChangeDirectory";
            this.rbChangeDirectory.Size = new System.Drawing.Size(94, 20);
            this.rbChangeDirectory.TabIndex = 23;
            this.rbChangeDirectory.Text = "Change directory";
            this.rbChangeDirectory.ThemeName = "Office2013Dark";
            this.rbChangeDirectory.Click += new System.EventHandler(this.rbChangeDirectory_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Location = new System.Drawing.Point(12, 70);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(484, 20);
            this.radLabel2.TabIndex = 24;
            this.radLabel2.Text = "You need to restart the program for the changes to take effect.";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.radLabel2.ThemeName = "Office2013Dark";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.rbCancel);
            this.panel1.Controls.Add(this.rbSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 103);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(508, 35);
            this.panel1.TabIndex = 25;
            // 
            // rbCancel
            // 
            this.rbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.rbCancel.Location = new System.Drawing.Point(415, 6);
            this.rbCancel.Name = "rbCancel";
            this.rbCancel.Size = new System.Drawing.Size(90, 24);
            this.rbCancel.TabIndex = 4;
            this.rbCancel.Text = "Cancel";
            this.rbCancel.ThemeName = "Office2013Dark";
            // 
            // rbSave
            // 
            this.rbSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rbSave.Location = new System.Drawing.Point(319, 6);
            this.rbSave.Name = "rbSave";
            this.rbSave.Size = new System.Drawing.Size(90, 24);
            this.rbSave.TabIndex = 3;
            this.rbSave.Text = "Save";
            this.rbSave.ThemeName = "Office2013Dark";
            // 
            // DatabaseInfoDialog
            // 
            this.AcceptButton = this.rbSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.rbCancel;
            this.ClientSize = new System.Drawing.Size(508, 138);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.rbChangeDirectory);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radTextBoxControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DatabaseInfoDialog";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Database Info";
            this.ThemeName = "Office2013Dark";
            ((System.ComponentModel.ISupportInitialize)(this.radTextBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbChangeDirectory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
        private Telerik.WinControls.UI.RadTextBoxControl radTextBoxControl1;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton rbChangeDirectory;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton rbCancel;
        private Telerik.WinControls.UI.RadButton rbSave;
    }
}