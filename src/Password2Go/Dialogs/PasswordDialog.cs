using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;
using Password2Go.Modules;

namespace Password2Go.Dialogs
{
    public partial class PasswordDialog : RadForm
    {
        PasswordViewModel _passwordVM = new PasswordViewModel();

        public PasswordDialog()
        {
            InitializeComponent();

            rtbPassword1.AddBindingToText(_passwordVM, nameof(_passwordVM.Password1));
            rtbPassword2.AddBindingToText(_passwordVM, nameof(_passwordVM.Password2));
        }

        public static PasswordDialogResult MyShowDialog(string description)
        {
            using (var form = new PasswordDialog())
            {
                form.radLabel3.Text = description;

                var result = new PasswordDialogResult();

                result.DialogResult1 = form.ShowDialog();
                result.Password = form._passwordVM.Password1;

                return result;
            }
        }

        private void rbOk_Click(object sender, EventArgs e)
        {
            if (_passwordVM.IsValid)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            } else
            {
                RadMessageBox.Show("Password mismatch!", "Error!", MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        
    }

    public class PasswordViewModel
    {
        public string Password1 { get; set; }
        public string Password2 { get; set; }

        public bool IsValid
        {
            get
            {
                return
                    !string.IsNullOrEmpty(Password1) 
                    && Password1 == Password2;
            }
        }
    }

    public class PasswordDialogResult
    {
        public DialogResult DialogResult1;
        public string Password;
    }
    
}
