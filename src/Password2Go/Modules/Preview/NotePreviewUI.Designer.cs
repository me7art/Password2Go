namespace Password2Go.Modules.Preview
{
    partial class NotePreviewUI
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.rtbNote = new Telerik.WinControls.UI.RadTextBoxControl();
            this.rbDecrypt = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbNote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDecrypt)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Controls.Add(this.rtbNote);
            this.radGroupBox1.Controls.Add(this.rbDecrypt);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Selected Item";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(484, 185);
            this.radGroupBox1.TabIndex = 15;
            this.radGroupBox1.Text = "Selected Item";
            this.radGroupBox1.ThemeName = "Office2013Dark";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(8, 21);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(34, 19);
            this.radLabel6.TabIndex = 13;
            this.radLabel6.Text = "Note";
            this.radLabel6.ThemeName = "Office2013Dark";
            // 
            // rtbNote
            // 
            this.rtbNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbNote.IsReadOnly = true;
            this.rtbNote.IsReadOnlyCaretVisible = true;
            this.rtbNote.Location = new System.Drawing.Point(8, 46);
            this.rtbNote.Multiline = true;
            this.rtbNote.Name = "rtbNote";
            this.rtbNote.Size = new System.Drawing.Size(467, 100);
            this.rtbNote.TabIndex = 6;
            this.rtbNote.ThemeName = "Office2013Dark";
            // 
            // rbDecrypt
            // 
            this.rbDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDecrypt.Location = new System.Drawing.Point(365, 153);
            this.rbDecrypt.Name = "rbDecrypt";
            this.rbDecrypt.Size = new System.Drawing.Size(110, 24);
            this.rbDecrypt.TabIndex = 8;
            this.rbDecrypt.Text = "Decrypt";
            this.rbDecrypt.ThemeName = "Office2013Dark";
            this.rbDecrypt.Click += new System.EventHandler(this.rbDecrypt_Click);
            // 
            // NotePreviewUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radGroupBox1);
            this.DoubleBuffered = true;
            this.Name = "NotePreviewUI";
            this.Size = new System.Drawing.Size(484, 185);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rtbNote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDecrypt)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadTextBoxControl rtbNote;
        private Telerik.WinControls.UI.RadButton rbDecrypt;
    }
}
