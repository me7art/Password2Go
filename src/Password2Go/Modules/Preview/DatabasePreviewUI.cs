using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common.Interfaces.Exceptions;

namespace Password2Go.Modules.Preview
{
    public partial class DatabasePreviewUI : UserControl, IPreviewUI
    {
        public UserControl ThisUserControl => this;

        const string HEADER_TEXT = "Selected Item";
        Bitmap _copyImage = Password2Go.Properties.Resources.if_document_copy_14383;
        Bitmap _showPasswordImage = Password2Go.Properties.Resources.if_eye_36031_16x16;
        Bitmap _hidePasswordImage = Password2Go.Properties.Resources.if_ui_web_app_76_2894823;

        DatabasePreviewViewModel _model;

        public Action<BasePreviewViewModel> DecryptAction;
        public Action<BasePreviewViewModel, PasswordTypeEnum> CopyPasswordAction;

        ShowHideHelper _showHideHelper = new ShowHideHelper("Show", "Hide");

        public DatabasePreviewUI()
        {
            InitializeComponent();

            var lightHidePassword = rtbPassword.AddElementToTextBox(_hidePasswordImage, rbShowPassword_Click);
            lightHidePassword.DataBindings.Add(new Binding("Visibility", _showHideHelper, nameof(_showHideHelper.HideVisibility)));

            var lightShowPassword = rtbPassword.AddElementToTextBox(_showPasswordImage, rbShowPassword_Click);
            lightShowPassword.DataBindings.Add(new Binding("Visibility", _showHideHelper, nameof(_showHideHelper.ShowVisibility)));

            rtbAddress.AddElementToTextBox(_copyImage, rbCopyAddress_Click);
            rtbPort.AddElementToTextBox(_copyImage, rbCopyPort_Click);
            rtbPassword.AddElementToTextBox(_copyImage, rbCopyPassword_Click);
            rtbLogin.AddElementToTextBox(_copyImage, rbCopyLogin_Click);
            rtbDatabase.AddElementToTextBox(_copyImage, rbCopyDatabase_Click);
        }

        public void Bind(object previewModel, bool updateView = true)
        {
            _showHideHelper.Reset();

            DatabasePreviewViewModel model = previewModel as DatabasePreviewViewModel;

            _model = model;

            if (model == null)
            {
                radGroupBox1.Text = HEADER_TEXT;
                return;
            }

            if (updateView) UpdateView(_model);
        }

        private void UpdateView(DatabasePreviewViewModel model)
        {
            radGroupBox1.Text = $"{HEADER_TEXT}: {model.Title}";
            rtbLogin.Text = model.Login;
            rtbDatabase.Text = model.DatabaseName;
            rtbAddress.Text = model.Address;
            rtbPort.Text = model.Port;
            rtbComment.Text = $"{model.PublicComment}";

            if (!model.IsDecrypted)
            {
                rtbPassword.PasswordChar = '\0';
                rtbPassword.Text = "*** Encrypted password ***";
                rtbComment.Text += "\n*** Encrypted comment ***";
            }
            else
            {
                rtbPassword.PasswordChar = '*';
                rtbPassword.Text = model.Password.Replace(' ', '_');
                rtbComment.Text += $"\n\n***\n{model.PrivateComment}\n***";
            }
        }

        private void rbDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                DecryptAction?.Invoke(_model);
                UpdateView(_model);
            }
            catch (DecryptionCanceledByUserException)
            {
                // do nothing
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbShowPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (_showHideHelper.IsHideWhatever)
                {
                    HidePassword();
                    _showHideHelper.Reverse();
                }
                else
                {
                    if (!_model.IsDecrypted)
                    {
                        DecryptAction?.Invoke(_model);
                    }
                    ShowPassword();
                    _showHideHelper.Reverse();
                }
            }
            catch (DecryptionCanceledByUserException)
            {
                // do nothing
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void HidePassword()
        {
            rtbPassword.PasswordChar = '*';
            rtbPassword.Text = _model.Password.Replace(' ', '_');
            rtbPassword.Refresh();
        }

        private void ShowPassword()
        {
            rtbPassword.PasswordChar = '\0';
            rtbPassword.Text = _model.Password;
            rtbPassword.Refresh();
        }

        private void rbCopyPassword_Click(object sender, EventArgs e)
        {
            try
            {
                CopyPasswordAction?.Invoke(_model, PasswordTypeEnum.Password);
                rtbPassword.Blink(Color.White, 120);
            }
            catch (DecryptionCanceledByUserException)
            {
                // do nothing
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbCopyLogin_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText(_model?.Login);
                rtbLogin.Blink(Color.White, 120);
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbCopyAddress_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText($"{_model?.Address}");
                rtbAddress.Blink(Color.White, 120);
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbCopyPort_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText($"{_model.Port}");
                rtbPort.Blink(Color.White, 120);
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbCopyDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText($"{_model.DatabaseName}");
                rtbDatabase.Blink(Color.White, 120);
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }
    }

    public class DatabasePreviewViewModel : BasePreviewViewModel
    {
        public bool IsDecrypted;
        public int ID;
        public string Title;
        public string Address { get; set; }
        public string Port { get; set; }
        public string Login { get; set; }
        public string DatabaseName { get; set; }
        public string PublicComment { get; set; }
        public string Password { get; set; }
        public string PrivateComment { get; set; }

        public override void Accept(IPreviewViewVisitor visitor) => visitor.Visit(this);
    }
}
