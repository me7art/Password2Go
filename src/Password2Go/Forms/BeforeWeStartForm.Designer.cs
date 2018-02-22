namespace Password2Go.Forms
{
    partial class BeforeWeStartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BeforeWeStartForm));
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.rbGenerateKeys = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.rbSelectKeys = new Telerik.WinControls.UI.RadButton();
            this.rbSelectDirectory = new Telerik.WinControls.UI.RadButton();
            this.rbDone = new Telerik.WinControls.UI.RadButton();
            this.office2013DarkTheme1 = new Telerik.WinControls.Themes.Office2013DarkTheme();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.labelWeDone = new Telerik.WinControls.UI.RadLabel();
            this.labelGenerating = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.rbGenerateKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSelectKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSelectDirectory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDone)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelWeDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelGenerating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rbGenerateKeys
            // 
            this.rbGenerateKeys.Location = new System.Drawing.Point(46, 162);
            this.rbGenerateKeys.Name = "rbGenerateKeys";
            this.rbGenerateKeys.Size = new System.Drawing.Size(110, 24);
            this.rbGenerateKeys.TabIndex = 0;
            this.rbGenerateKeys.Text = "Generate keys";
            this.rbGenerateKeys.ThemeName = "Office2013Dark";
            this.rbGenerateKeys.Click += new System.EventHandler(this.rbGenerateKeys_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(161, 165);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(21, 18);
            this.radLabel1.TabIndex = 1;
            this.radLabel1.Text = "OR";
            // 
            // rbSelectKeys
            // 
            this.rbSelectKeys.Location = new System.Drawing.Point(189, 162);
            this.rbSelectKeys.Name = "rbSelectKeys";
            this.rbSelectKeys.Size = new System.Drawing.Size(110, 24);
            this.rbSelectKeys.TabIndex = 2;
            this.rbSelectKeys.Text = "Select keys";
            this.rbSelectKeys.ThemeName = "Office2013Dark";
            this.rbSelectKeys.Click += new System.EventHandler(this.rbSelectKeys_Click);
            // 
            // rbSelectDirectory
            // 
            this.rbSelectDirectory.Location = new System.Drawing.Point(46, 242);
            this.rbSelectDirectory.Name = "rbSelectDirectory";
            this.rbSelectDirectory.Size = new System.Drawing.Size(110, 24);
            this.rbSelectDirectory.TabIndex = 5;
            this.rbSelectDirectory.Text = "Select directory";
            this.rbSelectDirectory.ThemeName = "Office2013Dark";
            this.rbSelectDirectory.Click += new System.EventHandler(this.rbSelectDirectory_Click);
            // 
            // rbDone
            // 
            this.rbDone.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.rbDone.Enabled = false;
            this.rbDone.Location = new System.Drawing.Point(212, 6);
            this.rbDone.Name = "rbDone";
            this.rbDone.Size = new System.Drawing.Size(110, 24);
            this.rbDone.TabIndex = 8;
            this.rbDone.Text = "Done!";
            this.rbDone.ThemeName = "Office2013Dark";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.rbDone);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 303);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 35);
            this.panel1.TabIndex = 9;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.GroupBoxStyle = Telerik.WinControls.UI.RadGroupBoxStyle.Office;
            this.radGroupBox1.HeaderText = "Hint";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(344, 95);
            this.radGroupBox1.TabIndex = 10;
            this.radGroupBox1.Text = "Hint";
            this.radGroupBox1.ThemeName = "Office2013Dark";
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radLabel2.Location = new System.Drawing.Point(2, 18);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(340, 75);
            this.radLabel2.TabIndex = 0;
            this.radLabel2.Text = "<html><p>For start using program you need to complite these two step.</p><p>First" +
    " - generate or select public/private keys</p><p>Second - select folder, there da" +
    "tabase will be stored.</p></html>";
            this.radLabel2.ThemeName = "Office2013Dark";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(12, 121);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(326, 35);
            this.radLabel3.TabIndex = 12;
            this.radLabel3.Text = "1. Public and private keys used to encrypt private data.\r\nYou need to generate ne" +
    "w key pair or select existing keys.\r\n";
            this.radLabel3.ThemeName = "Office2013Dark";
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(12, 217);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(293, 19);
            this.radLabel4.TabIndex = 13;
            this.radLabel4.Text = "2. Select place where to store password database file";
            this.radLabel4.ThemeName = "Office2013Dark";
            // 
            // labelWeDone
            // 
            this.labelWeDone.AutoSize = false;
            this.labelWeDone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelWeDone.Location = new System.Drawing.Point(0, 272);
            this.labelWeDone.Name = "labelWeDone";
            this.labelWeDone.Size = new System.Drawing.Size(344, 19);
            this.labelWeDone.TabIndex = 15;
            this.labelWeDone.Text = "We done! Please press \"Done!\" button";
            this.labelWeDone.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWeDone.ThemeName = "Office2013Dark";
            this.labelWeDone.Visible = false;
            // 
            // labelGenerating
            // 
            this.labelGenerating.AutoSize = false;
            this.labelGenerating.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.labelGenerating.Location = new System.Drawing.Point(0, 192);
            this.labelGenerating.Name = "labelGenerating";
            this.labelGenerating.Size = new System.Drawing.Size(344, 19);
            this.labelGenerating.TabIndex = 16;
            this.labelGenerating.Text = "Please wait, generating keys...";
            this.labelGenerating.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGenerating.ThemeName = "Office2013Dark";
            this.labelGenerating.Visible = false;
            // 
            // BeforeWeStartForm
            // 
            this.AcceptButton = this.rbDone;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 338);
            this.Controls.Add(this.labelGenerating);
            this.Controls.Add(this.labelWeDone);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radLabel3);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbSelectDirectory);
            this.Controls.Add(this.rbSelectKeys);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.rbGenerateKeys);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BeforeWeStartForm";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Before We Start";
            this.ThemeName = "Office2013Dark";
            ((System.ComponentModel.ISupportInitialize)(this.rbGenerateKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSelectKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbSelectDirectory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rbDone)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelWeDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelGenerating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadButton rbGenerateKeys;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton rbSelectKeys;
        private Telerik.WinControls.UI.RadButton rbSelectDirectory;
        private Telerik.WinControls.UI.RadButton rbDone;
        private Telerik.WinControls.Themes.Office2013DarkTheme office2013DarkTheme1;
        private System.Windows.Forms.Panel panel1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadLabel labelWeDone;
        private Telerik.WinControls.UI.RadLabel labelGenerating;
    }
}