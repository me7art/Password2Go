namespace Password2Go.Forms
{
    partial class OkCancelUIContainerForm
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
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCancel = new Telerik.WinControls.UI.RadButton();
            this.rbOk = new Telerik.WinControls.UI.RadButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.rbCancel);
            this.panel1.Controls.Add(this.rbOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 206);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 35);
            this.panel1.TabIndex = 24;
            // 
            // rbCancel
            // 
            this.rbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.rbCancel.Location = new System.Drawing.Point(302, 6);
            this.rbCancel.Name = "rbCancel";
            this.rbCancel.Size = new System.Drawing.Size(90, 24);
            this.rbCancel.TabIndex = 4;
            this.rbCancel.Text = "Cancel";
            this.rbCancel.ThemeName = "Office2013Dark";
            // 
            // rbOk
            // 
            this.rbOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rbOk.Location = new System.Drawing.Point(206, 6);
            this.rbOk.Name = "rbOk";
            this.rbOk.Size = new System.Drawing.Size(90, 24);
            this.rbOk.TabIndex = 3;
            this.rbOk.Text = "Ok";
            this.rbOk.ThemeName = "Office2013Dark";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 206);
            this.panel2.TabIndex = 25;
            // 
            // OkCancelUIContainerForm
            // 
            this.AcceptButton = this.rbOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.rbCancel;
            this.ClientSize = new System.Drawing.Size(395, 241);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "OkCancelUIContainerForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OkCancelUIContainerForm";
            this.ThemeName = "Office2013Dark";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton rbCancel;
        private Telerik.WinControls.UI.RadButton rbOk;
        private System.Windows.Forms.Panel panel2;
    }
}