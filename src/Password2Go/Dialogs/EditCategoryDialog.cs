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

namespace Password2Go.Dialogs
{
    public partial class EditCategoryDialog : RadForm
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

        public EditCategoryDialog(string title, string okButtonName)
        {
            InitializeComponent();

            this.Text = title;
            this.rbSave.Text = okButtonName;
        }
    }
}
