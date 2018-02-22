namespace Password2Go.Forms
{
    partial class PrivateCardInputForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCancel = new Telerik.WinControls.UI.RadButton();
            this.rbAdd = new Telerik.WinControls.UI.RadButton();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.panel2 = new System.Windows.Forms.Panel();
            this.radLabel_category = new Telerik.WinControls.UI.RadLabel();
            this.rbEdit = new Telerik.WinControls.UI.RadButton();
            this.rbDecrypt = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.panelCard = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAdd)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel_category)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDecrypt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCancel);
            this.panel1.Controls.Add(this.rbAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 455);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(381, 30);
            this.panel1.TabIndex = 0;
            // 
            // rbCancel
            // 
            this.rbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.rbCancel.Location = new System.Drawing.Point(268, 3);
            this.rbCancel.Name = "rbCancel";
            this.rbCancel.Size = new System.Drawing.Size(110, 24);
            this.rbCancel.TabIndex = 1;
            this.rbCancel.Text = "Cancel";
            this.rbCancel.ThemeName = "Office2013Dark";
            // 
            // rbAdd
            // 
            this.rbAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rbAdd.Location = new System.Drawing.Point(152, 3);
            this.rbAdd.Name = "rbAdd";
            this.rbAdd.Size = new System.Drawing.Size(110, 24);
            this.rbAdd.TabIndex = 0;
            this.rbAdd.Text = "Save";
            this.rbAdd.ThemeName = "Office2013Dark";
            this.rbAdd.Click += new System.EventHandler(this.rbAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.radLabel_category);
            this.panel2.Controls.Add(this.rbEdit);
            this.panel2.Controls.Add(this.rbDecrypt);
            this.panel2.Controls.Add(this.radLabel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 31);
            this.panel2.TabIndex = 2;
            // 
            // radLabel_category
            // 
            this.radLabel_category.Cursor = System.Windows.Forms.Cursors.Hand;
            this.radLabel_category.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.radLabel_category.Location = new System.Drawing.Point(65, 6);
            this.radLabel_category.Name = "radLabel_category";
            this.radLabel_category.Size = new System.Drawing.Size(89, 19);
            this.radLabel_category.TabIndex = 13;
            this.radLabel_category.Text = "uncategorized";
            this.radLabel_category.ThemeName = "Office2013Dark";
            this.radLabel_category.Click += new System.EventHandler(this.radLabel_category_Click);
            // 
            // rbEdit
            // 
            this.rbEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbEdit.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.rbEdit.Location = new System.Drawing.Point(265, 5);
            this.rbEdit.Name = "rbEdit";
            this.rbEdit.Size = new System.Drawing.Size(53, 20);
            this.rbEdit.TabIndex = 12;
            this.rbEdit.Text = "Edit";
            this.rbEdit.ThemeName = "Office2013Dark";
            this.rbEdit.Click += new System.EventHandler(this.rbEdit_Click);
            // 
            // rbDecrypt
            // 
            this.rbDecrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDecrypt.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.rbDecrypt.Location = new System.Drawing.Point(324, 5);
            this.rbDecrypt.Name = "rbDecrypt";
            this.rbDecrypt.Size = new System.Drawing.Size(53, 20);
            this.rbDecrypt.TabIndex = 11;
            this.rbDecrypt.Text = "Decrypt";
            this.rbDecrypt.ThemeName = "Office2013Dark";
            this.rbDecrypt.Click += new System.EventHandler(this.rbDecrypt_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 6);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(56, 19);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "Category";
            this.radLabel1.ThemeName = "Office2013Dark";
            // 
            // panelCard
            // 
            this.panelCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCard.Location = new System.Drawing.Point(0, 31);
            this.panelCard.Name = "panelCard";
            this.panelCard.Size = new System.Drawing.Size(381, 424);
            this.panelCard.TabIndex = 4;
            // 
            // PrivateCardInputForm
            // 
            this.AcceptButton = this.rbAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.rbCancel;
            this.ClientSize = new System.Drawing.Size(381, 485);
            this.Controls.Add(this.panelCard);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrivateCardInputForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PrivateCardInputForm";
            this.ThemeName = "Office2013Dark";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAdd)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel_category)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDecrypt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadButton rbCancel;
        private Telerik.WinControls.UI.RadButton rbAdd;
        private System.Windows.Forms.Panel panel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton rbDecrypt;
        private Telerik.WinControls.UI.RadButton rbEdit;
        private Telerik.WinControls.UI.RadLabel radLabel_category;
        private System.Windows.Forms.Panel panelCard;
    }
}