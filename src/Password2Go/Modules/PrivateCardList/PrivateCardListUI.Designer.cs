namespace Password2Go.Modules.PrivateCardList
{
    partial class PrivateCardListUI
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
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // radListView1
            // 
            this.radListView1.AllowEdit = false;
            this.radListView1.AllowRemove = false;
            this.radListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radListView1.FullRowSelect = false;
            this.radListView1.ItemSize = new System.Drawing.Size(160, 48);
            this.radListView1.Location = new System.Drawing.Point(0, 0);
            this.radListView1.Name = "radListView1";
            this.radListView1.Size = new System.Drawing.Size(613, 497);
            this.radListView1.TabIndex = 2;
            this.radListView1.Text = "radListView1";
            this.radListView1.ThemeName = "Office2013Dark";
            this.radListView1.ViewType = Telerik.WinControls.UI.ListViewType.IconsView;
            this.radListView1.SelectedItemChanged += new System.EventHandler(this.radListView1_SelectedItemChanged);
            this.radListView1.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListView1_ItemMouseClick);
            this.radListView1.ItemMouseDoubleClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListView1_ItemMouseDoubleClick);
            this.radListView1.ItemDataBound += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListView1_ItemDataBound);
            // 
            // PrivateCardListUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radListView1);
            this.DoubleBuffered = true;
            this.Name = "PrivateCardListUI";
            this.Size = new System.Drawing.Size(613, 497);
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadListView radListView1;
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
    }
}
