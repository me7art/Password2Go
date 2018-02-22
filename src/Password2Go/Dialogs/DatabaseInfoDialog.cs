using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls.UI;

using Password2Go.Modules;

namespace Password2Go.Dialogs
{
    public partial class DatabaseInfoDialog : RadForm
    {
        public string UserInput
        {
            get
            {
                return radTextBoxControl1.Text;
            }
            set
            {
                radTextBoxControl1.Text = value;
            }
        }

        public Action ChangeDirectoryAction;

        public DatabaseInfoDialog()
        {
            InitializeComponent();
        }

        private void rbChangeDirectory_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog() { SelectedPath = UserInput })
            {
                var dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    this.UserInput = dialog.SelectedPath;
                    //RadMessageBox.Show("You need to restart the program for the changes to take effect.", "Information", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
        }
    }
}
