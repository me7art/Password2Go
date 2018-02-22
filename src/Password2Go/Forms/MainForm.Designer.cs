namespace Password2Go.Forms
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.radCommandBar1 = new Telerik.WinControls.UI.RadCommandBar();
            this.commandBarRowElement1 = new Telerik.WinControls.UI.CommandBarRowElement();
            this.commandBarStripElement1 = new Telerik.WinControls.UI.CommandBarStripElement();
            this.cbbAddSite = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbAddDevice = new Telerik.WinControls.UI.CommandBarButton();
            this.cbbAddNote = new Telerik.WinControls.UI.CommandBarButton();
            this.cbddbMore = new Telerik.WinControls.UI.CommandBarDropDownButton();
            this.rmiAddDatabase = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiAddCreditCard = new Telerik.WinControls.UI.RadMenuItem();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.radMenuItem1 = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiRestore = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiDeleteEntry = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiEmptyRecycleBin = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem1 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.rmiExit = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuItem3 = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiAbout = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenu1 = new Telerik.WinControls.UI.RadMenu();
            this.rmiOptions = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiDatabaseOptions = new Telerik.WinControls.UI.RadMenuItem();
            this.rmiKeysOptions = new Telerik.WinControls.UI.RadMenuItem();
            this.radMenuSeparatorItem2 = new Telerik.WinControls.UI.RadMenuSeparatorItem();
            this.rmiCategoriesOptions = new Telerik.WinControls.UI.RadMenuItem();
            this.privateCardListUI1 = new Password2Go.Modules.PrivateCardList.PrivateCardListUI();
            this.categoryTreeUI1 = new Password2Go.Modules.CategoryTree.CategoryTreeUI();
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radCommandBar1
            // 
            this.radCommandBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.radCommandBar1.Location = new System.Drawing.Point(0, 19);
            this.radCommandBar1.Name = "radCommandBar1";
            this.radCommandBar1.Rows.AddRange(new Telerik.WinControls.UI.CommandBarRowElement[] {
            this.commandBarRowElement1});
            this.radCommandBar1.Size = new System.Drawing.Size(742, 33);
            this.radCommandBar1.TabIndex = 8;
            this.radCommandBar1.Text = "radCommandBar1";
            this.radCommandBar1.ThemeName = "Office2013Dark";
            // 
            // commandBarRowElement1
            // 
            this.commandBarRowElement1.MinSize = new System.Drawing.Size(25, 25);
            this.commandBarRowElement1.Strips.AddRange(new Telerik.WinControls.UI.CommandBarStripElement[] {
            this.commandBarStripElement1});
            // 
            // commandBarStripElement1
            // 
            this.commandBarStripElement1.DisplayName = "commandBarStripElement1";
            this.commandBarStripElement1.Items.AddRange(new Telerik.WinControls.UI.RadCommandBarBaseItem[] {
            this.cbbAddSite,
            this.cbbAddDevice,
            this.cbbAddNote,
            this.cbddbMore});
            this.commandBarStripElement1.Name = "commandBarStripElement1";
            // 
            // 
            // 
            this.commandBarStripElement1.OverflowButton.Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            ((Telerik.WinControls.UI.RadCommandBarOverflowButton)(this.commandBarStripElement1.GetChildAt(2))).Visibility = Telerik.WinControls.ElementVisibility.Collapsed;
            // 
            // cbbAddSite
            // 
            this.cbbAddSite.DisplayName = "commandBarButton1";
            this.cbbAddSite.DrawText = true;
            this.cbbAddSite.Image = global::Password2Go.Properties.Resources.if_chrome_317753_16x16;
            this.cbbAddSite.Name = "cbbAddSite";
            this.cbbAddSite.Text = "Add Site";
            this.cbbAddSite.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbbAddSite.Click += new System.EventHandler(this.cbbAddSite_Click);
            // 
            // cbbAddDevice
            // 
            this.cbbAddDevice.DisplayName = "commandBarButton2";
            this.cbbAddDevice.DrawText = true;
            this.cbbAddDevice.Image = global::Password2Go.Properties.Resources.if_gnome_fs_server_21123_16x16;
            this.cbbAddDevice.Name = "cbbAddDevice";
            this.cbbAddDevice.Text = "Add Device";
            this.cbbAddDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbbAddDevice.Click += new System.EventHandler(this.cbbAddDevice_Click);
            // 
            // cbbAddNote
            // 
            this.cbbAddNote.DisplayName = "commandBarButton5";
            this.cbbAddNote.DrawText = true;
            this.cbbAddNote.Image = global::Password2Go.Properties.Resources.if_page_white_text_36305_16x16;
            this.cbbAddNote.Name = "cbbAddNote";
            this.cbbAddNote.Text = "Add Note";
            this.cbbAddNote.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbbAddNote.Click += new System.EventHandler(this.cbbAddNote_Click);
            // 
            // cbddbMore
            // 
            this.cbddbMore.DisplayName = "...more";
            this.cbddbMore.DrawImage = false;
            this.cbddbMore.DrawText = true;
            this.cbddbMore.Image = ((System.Drawing.Image)(resources.GetObject("cbddbMore.Image")));
            this.cbddbMore.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rmiAddDatabase,
            this.rmiAddCreditCard});
            this.cbddbMore.Name = "cbddbMore";
            this.cbddbMore.Text = "...more";
            this.cbddbMore.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.cbddbMore.Click += new System.EventHandler(this.cbddbMore_Click);
            // 
            // rmiAddDatabase
            // 
            this.rmiAddDatabase.Image = global::Password2Go.Properties.Resources.if_database_35948_16x16;
            this.rmiAddDatabase.Name = "rmiAddDatabase";
            this.rmiAddDatabase.Text = "Add Database";
            // 
            // rmiAddCreditCard
            // 
            this.rmiAddCreditCard.Image = global::Password2Go.Properties.Resources.if_credit_card_49367_16x16;
            this.rmiAddCreditCard.Name = "rmiAddCreditCard";
            this.rmiAddCreditCard.Text = "Add Credit Card";
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelPreview.Location = new System.Drawing.Point(197, 371);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(545, 224);
            this.panelPreview.TabIndex = 11;
            // 
            // radMenuItem1
            // 
            this.radMenuItem1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rmiRestore,
            this.rmiDeleteEntry,
            this.rmiEmptyRecycleBin,
            this.radMenuSeparatorItem1,
            this.rmiExit});
            this.radMenuItem1.Name = "radMenuItem1";
            this.radMenuItem1.Text = "File";
            // 
            // rmiRestore
            // 
            this.rmiRestore.Image = global::Password2Go.Properties.Resources.if_Redo_105223;
            this.rmiRestore.Name = "rmiRestore";
            this.rmiRestore.Text = "Restore item";
            this.rmiRestore.Click += new System.EventHandler(this.rmiRestore_Click);
            // 
            // rmiDeleteEntry
            // 
            this.rmiDeleteEntry.Image = global::Password2Go.Properties.Resources.if_Delete_1493279;
            this.rmiDeleteEntry.Name = "rmiDeleteEntry";
            this.rmiDeleteEntry.Text = "Delete Item";
            this.rmiDeleteEntry.Click += new System.EventHandler(this.rmiDeleteEntry_Click);
            // 
            // rmiEmptyRecycleBin
            // 
            this.rmiEmptyRecycleBin.Image = global::Password2Go.Properties.Resources.if_trash_can_delete_84177;
            this.rmiEmptyRecycleBin.Name = "rmiEmptyRecycleBin";
            this.rmiEmptyRecycleBin.Text = "Empty Recycle Bin";
            this.rmiEmptyRecycleBin.Click += new System.EventHandler(this.rmiEmptyRecycleBin_Click);
            // 
            // radMenuSeparatorItem1
            // 
            this.radMenuSeparatorItem1.Name = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.Text = "radMenuSeparatorItem1";
            this.radMenuSeparatorItem1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rmiExit
            // 
            this.rmiExit.Name = "rmiExit";
            this.rmiExit.Text = "Exit";
            this.rmiExit.Click += new System.EventHandler(this.rmiExit_Click);
            // 
            // radMenuItem3
            // 
            this.radMenuItem3.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rmiAbout});
            this.radMenuItem3.Name = "radMenuItem3";
            this.radMenuItem3.Text = "Help";
            // 
            // rmiAbout
            // 
            this.rmiAbout.Name = "rmiAbout";
            this.rmiAbout.Text = "About";
            this.rmiAbout.Click += new System.EventHandler(this.rmiAbout_Click);
            // 
            // radMenu1
            // 
            this.radMenu1.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.radMenuItem1,
            this.rmiOptions,
            this.radMenuItem3});
            this.radMenu1.Location = new System.Drawing.Point(0, 0);
            this.radMenu1.Name = "radMenu1";
            this.radMenu1.Size = new System.Drawing.Size(742, 19);
            this.radMenu1.TabIndex = 12;
            this.radMenu1.Text = "radMenu1";
            this.radMenu1.ThemeName = "Office2013Dark";
            // 
            // rmiOptions
            // 
            this.rmiOptions.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.rmiDatabaseOptions,
            this.rmiKeysOptions,
            this.radMenuSeparatorItem2,
            this.rmiCategoriesOptions});
            this.rmiOptions.Name = "rmiOptions";
            this.rmiOptions.Text = "Options";
            // 
            // rmiDatabaseOptions
            // 
            this.rmiDatabaseOptions.Image = global::Password2Go.Properties.Resources.if_database_35948_16x16;
            this.rmiDatabaseOptions.Name = "rmiDatabaseOptions";
            this.rmiDatabaseOptions.Text = "Database";
            this.rmiDatabaseOptions.Click += new System.EventHandler(this.rmiDatabaseOptions_Click);
            // 
            // rmiKeysOptions
            // 
            this.rmiKeysOptions.Image = global::Password2Go.Properties.Resources.if_key_36132;
            this.rmiKeysOptions.Name = "rmiKeysOptions";
            this.rmiKeysOptions.Text = "Keys";
            this.rmiKeysOptions.Click += new System.EventHandler(this.rmiKeysOptions_Click);
            // 
            // radMenuSeparatorItem2
            // 
            this.radMenuSeparatorItem2.Name = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.Text = "radMenuSeparatorItem2";
            this.radMenuSeparatorItem2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rmiCategoriesOptions
            // 
            this.rmiCategoriesOptions.Image = global::Password2Go.Properties.Resources.if_node_tree_64498;
            this.rmiCategoriesOptions.Name = "rmiCategoriesOptions";
            this.rmiCategoriesOptions.Text = "Categories";
            this.rmiCategoriesOptions.Click += new System.EventHandler(this.rmiCategoriesOptions_Click);
            // 
            // privateCardListUI1
            // 
            this.privateCardListUI1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.privateCardListUI1.Location = new System.Drawing.Point(197, 56);
            this.privateCardListUI1.Name = "privateCardListUI1";
            this.privateCardListUI1.Size = new System.Drawing.Size(545, 309);
            this.privateCardListUI1.TabIndex = 10;
            // 
            // categoryTreeUI1
            // 
            this.categoryTreeUI1.AllowDragDrop = false;
            this.categoryTreeUI1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.categoryTreeUI1.Location = new System.Drawing.Point(1, 56);
            this.categoryTreeUI1.Name = "categoryTreeUI1";
            this.categoryTreeUI1.Size = new System.Drawing.Size(190, 540);
            this.categoryTreeUI1.TabIndex = 9;
            this.categoryTreeUI1.ToggleMode = Telerik.WinControls.UI.ToggleMode.DoubleClick;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 597);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.privateCardListUI1);
            this.Controls.Add(this.categoryTreeUI1);
            this.Controls.Add(this.radCommandBar1);
            this.Controls.Add(this.radMenu1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(750, 628);
            this.Name = "MainForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Password.2Go";
            this.ThemeName = "Office2013Dark";
            ((System.ComponentModel.ISupportInitialize)(this.radCommandBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radMenu1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadCommandBar radCommandBar1;
        private Telerik.WinControls.UI.CommandBarRowElement commandBarRowElement1;
        private Telerik.WinControls.UI.CommandBarStripElement commandBarStripElement1;
        private Telerik.WinControls.UI.CommandBarButton cbbAddSite;
        private Telerik.WinControls.UI.CommandBarButton cbbAddDevice;
        private Modules.CategoryTree.CategoryTreeUI categoryTreeUI1;
        private Modules.PrivateCardList.PrivateCardListUI privateCardListUI1;
        private Telerik.WinControls.UI.CommandBarButton cbbAddNote;
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
        private System.Windows.Forms.Panel panelPreview;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem1;
        private Telerik.WinControls.UI.RadMenuItem rmiExit;
        private Telerik.WinControls.UI.RadMenuItem radMenuItem3;
        private Telerik.WinControls.UI.RadMenuItem rmiAbout;
        private Telerik.WinControls.UI.RadMenuItem rmiDeleteEntry;
        private Telerik.WinControls.UI.RadMenuItem rmiEmptyRecycleBin;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem1;
        private Telerik.WinControls.UI.RadMenu radMenu1;
        private Telerik.WinControls.UI.RadMenuItem rmiRestore;
        private Telerik.WinControls.UI.RadMenuItem rmiOptions;
        private Telerik.WinControls.UI.RadMenuItem rmiDatabaseOptions;
        private Telerik.WinControls.UI.RadMenuItem rmiKeysOptions;
        private Telerik.WinControls.UI.RadMenuSeparatorItem radMenuSeparatorItem2;
        private Telerik.WinControls.UI.RadMenuItem rmiCategoriesOptions;
        private Telerik.WinControls.UI.CommandBarDropDownButton cbddbMore;
        private Telerik.WinControls.UI.RadMenuItem rmiAddCreditCard;
        private Telerik.WinControls.UI.RadMenuItem rmiAddDatabase;
    }
}