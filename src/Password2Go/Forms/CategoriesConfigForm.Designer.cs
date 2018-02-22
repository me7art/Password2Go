namespace Password2Go.Forms
{
    partial class CategoriesConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoriesConfigForm));
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.categoryTreeUI1 = new Password2Go.Modules.CategoryTree.CategoryTreeUI();
            this.rbAddCategory = new Telerik.WinControls.UI.RadButton();
            this.rbAddSubCategory = new Telerik.WinControls.UI.RadButton();
            this.rbDeleteCategory = new Telerik.WinControls.UI.RadButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCancel = new Telerik.WinControls.UI.RadButton();
            this.rbSave = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rbAddCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAddSubCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDeleteCategory)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // categoryTreeUI1
            // 
            this.categoryTreeUI1.AllowDragDrop = true;
            this.categoryTreeUI1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categoryTreeUI1.Location = new System.Drawing.Point(0, 38);
            this.categoryTreeUI1.Name = "categoryTreeUI1";
            this.categoryTreeUI1.Size = new System.Drawing.Size(313, 418);
            this.categoryTreeUI1.TabIndex = 15;
            this.categoryTreeUI1.ToggleMode = Telerik.WinControls.UI.ToggleMode.DoubleClick;
            // 
            // rbAddCategory
            // 
            this.rbAddCategory.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.rbAddCategory.Location = new System.Drawing.Point(0, 12);
            this.rbAddCategory.Name = "rbAddCategory";
            this.rbAddCategory.Size = new System.Drawing.Size(94, 20);
            this.rbAddCategory.TabIndex = 20;
            this.rbAddCategory.Text = "Add category";
            this.rbAddCategory.ThemeName = "Office2013Dark";
            this.rbAddCategory.Click += new System.EventHandler(this.rbAddCategory_Click);
            // 
            // rbAddSubCategory
            // 
            this.rbAddSubCategory.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.rbAddSubCategory.Location = new System.Drawing.Point(100, 12);
            this.rbAddSubCategory.Name = "rbAddSubCategory";
            this.rbAddSubCategory.Size = new System.Drawing.Size(94, 20);
            this.rbAddSubCategory.TabIndex = 21;
            this.rbAddSubCategory.Text = "Add sub-category";
            this.rbAddSubCategory.ThemeName = "Office2013Dark";
            this.rbAddSubCategory.Click += new System.EventHandler(this.rbAddSubCategory_Click);
            // 
            // rbDeleteCategory
            // 
            this.rbDeleteCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbDeleteCategory.Font = new System.Drawing.Font("Segoe UI", 7F);
            this.rbDeleteCategory.Location = new System.Drawing.Point(219, 12);
            this.rbDeleteCategory.Name = "rbDeleteCategory";
            this.rbDeleteCategory.Size = new System.Drawing.Size(94, 20);
            this.rbDeleteCategory.TabIndex = 22;
            this.rbDeleteCategory.Text = "Delete category";
            this.rbDeleteCategory.ThemeName = "Office2013Dark";
            this.rbDeleteCategory.Click += new System.EventHandler(this.rbDeleteCategory_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.rbCancel);
            this.panel1.Controls.Add(this.rbSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 459);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 35);
            this.panel1.TabIndex = 23;
            // 
            // rbCancel
            // 
            this.rbCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.rbCancel.Location = new System.Drawing.Point(220, 6);
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
            this.rbSave.Location = new System.Drawing.Point(124, 6);
            this.rbSave.Name = "rbSave";
            this.rbSave.Size = new System.Drawing.Size(90, 24);
            this.rbSave.TabIndex = 3;
            this.rbSave.Text = "Save";
            this.rbSave.ThemeName = "Office2013Dark";
            this.rbSave.Click += new System.EventHandler(this.rbSave_Click);
            // 
            // CategoriesConfigForm
            // 
            this.AcceptButton = this.rbSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.rbCancel;
            this.ClientSize = new System.Drawing.Size(313, 494);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbDeleteCategory);
            this.Controls.Add(this.rbAddSubCategory);
            this.Controls.Add(this.rbAddCategory);
            this.Controls.Add(this.categoryTreeUI1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(321, 525);
            this.Name = "CategoriesConfigForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " Categories";
            this.ThemeName = "Office2013Dark";
            ((System.ComponentModel.ISupportInitialize)(this.rbAddCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbAddSubCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDeleteCategory)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rbCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
        private Modules.CategoryTree.CategoryTreeUI categoryTreeUI1;
        private Telerik.WinControls.UI.RadButton rbAddCategory;
        private Telerik.WinControls.UI.RadButton rbAddSubCategory;
        private Telerik.WinControls.UI.RadButton rbDeleteCategory;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadButton rbCancel;
        private Telerik.WinControls.UI.RadButton rbSave;
    }
}