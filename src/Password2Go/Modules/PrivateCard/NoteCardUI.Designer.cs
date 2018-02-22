namespace Password2Go.Modules.PrivateCard
{
    partial class NoteCardUI
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
            this.tbTitle = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.tbNotePriv = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNotePriv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.tbTitle);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.FooterText = "This information is stored in plain text";
            this.radGroupBox1.FooterVisibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Public data";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(369, 72);
            this.radGroupBox1.TabIndex = 8;
            this.radGroupBox1.Text = "Public data";
            this.radGroupBox1.ThemeName = "Office2013Dark";
            // 
            // tbTitle
            // 
            this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTitle.Location = new System.Drawing.Point(67, 26);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(297, 20);
            this.tbTitle.TabIndex = 0;
            this.tbTitle.ThemeName = "Office2013Dark";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(34, 26);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(30, 19);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Title";
            this.radLabel1.ThemeName = "Office2013Dark";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.tbNotePriv);
            this.radGroupBox2.Controls.Add(this.radLabel6);
            this.radGroupBox2.FooterText = "This information will be encrypted";
            this.radGroupBox2.FooterVisibility = Telerik.WinControls.ElementVisibility.Visible;
            this.radGroupBox2.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox2.HeaderText = "Protected data";
            this.radGroupBox2.Location = new System.Drawing.Point(3, 81);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(369, 292);
            this.radGroupBox2.TabIndex = 9;
            this.radGroupBox2.Text = "Protected data";
            this.radGroupBox2.ThemeName = "Office2013Dark";
            // 
            // tbNotePriv
            // 
            this.tbNotePriv.AcceptsReturn = true;
            this.tbNotePriv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNotePriv.Location = new System.Drawing.Point(7, 46);
            this.tbNotePriv.Multiline = true;
            this.tbNotePriv.Name = "tbNotePriv";
            this.tbNotePriv.Size = new System.Drawing.Size(357, 224);
            this.tbNotePriv.TabIndex = 7;
            this.tbNotePriv.ThemeName = "Office2013Dark";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(7, 21);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(34, 19);
            this.radLabel6.TabIndex = 3;
            this.radLabel6.Text = "Note";
            this.radLabel6.ThemeName = "Office2013Dark";
            // 
            // NoteCardUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radGroupBox2);
            this.DoubleBuffered = true;
            this.Name = "NoteCardUI";
            this.Size = new System.Drawing.Size(375, 377);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbNotePriv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBoxControl tbTitle;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadTextBoxControl tbNotePriv;
        private Telerik.WinControls.UI.RadLabel radLabel6;
    }
}
