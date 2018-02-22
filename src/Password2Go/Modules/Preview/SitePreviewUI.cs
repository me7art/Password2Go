using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Common.Interfaces.Exceptions;

namespace Password2Go.Modules.Preview
{
    public interface IPreviewUI
    {
        UserControl ThisUserControl { get; }
        void Bind(object previewModel, bool updateView = true );
    }

    public partial class SitePreviewUI : UserControl, IPreviewUI
    {
        public UserControl ThisUserControl => this;

        const string HEADER_TEXT = "Selected Item";
        Bitmap _copyImage = Password2Go.Properties.Resources.if_document_copy_14383;
        Bitmap _showPasswordImage = Password2Go.Properties.Resources.if_eye_36031_16x16;
        Bitmap _hidePasswordImage = Password2Go.Properties.Resources.if_ui_web_app_76_2894823;

        SitePreviewViewModel _model;

        public Action<BasePreviewViewModel> DecryptAction;
        public Action<BasePreviewViewModel, PasswordTypeEnum> CopyPasswordAction;

        ShowHideHelper _showHideHelper = new ShowHideHelper("Show", "Hide");

        public SitePreviewUI()
        {
            InitializeComponent();
            
            var lightHidePassword = rtbPassword.AddElementToTextBox(_hidePasswordImage, rbShowPassword_Click);
            lightHidePassword.DataBindings.Add(new Binding("Visibility", _showHideHelper, nameof(_showHideHelper.HideVisibility)));

            var lightShowPassword = rtbPassword.AddElementToTextBox(_showPasswordImage, rbShowPassword_Click);
            lightShowPassword.DataBindings.Add(new Binding("Visibility", _showHideHelper, nameof(_showHideHelper.ShowVisibility)));

            rtbPassword.AddElementToTextBox(_copyImage, rbCopyPassword_Click);
            rtbURL.AddElementToTextBox(_copyImage, rbCopyURL_Click);
            rtbLogin.AddElementToTextBox(_copyImage, rbCopyLogin_Click);
        }

        public void Bind(object previewModel , bool updateView = true)
        {
            var model = previewModel as SitePreviewViewModel;

            _model = model;
            _showHideHelper.Reset();

            if (_model == null)
            {
                radGroupBox1.Text = HEADER_TEXT;
                return;
            }

            if (updateView)
                UpdateView(_model);
        }

        private void UpdateView(SitePreviewViewModel model)
        {
            radGroupBox1.Text = $"{HEADER_TEXT}: {_model.Title}";
            rtbLogin.Text = _model.Login;
            rtbURL.Text = _model.Url;
            rtbComment.Text = $"{_model.PublicComment}";

            if (!_model.IsDecrypted)
            {
                rtbPassword.PasswordChar = '\0';
                rtbPassword.Text = "*** Encrypted password ***";
                rtbComment.Text += "\n*** Encrypted comment ***";
            }
            else
            {
                rtbPassword.PasswordChar = '*';
                rtbPassword.Text = _model.Password.Replace(' ', '_');
                rtbComment.Text += $"\n\n***\n{_model.PrivateComment}\n***";
            }
        }

        private void rbDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_model.IsDecrypted)
                {
                    DecryptAction?.Invoke(_model);
                } 
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

        private void rbCopyURL_Click(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Clipboard.SetText(_model?.Url);
                rtbURL.Blink(Color.White, 120);
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }
    }

    public class SitePreviewViewModel : BasePreviewViewModel
    {
        public bool IsDecrypted;
        public int ID;
        public string Title;
        public string Url { get; set; }
        public string Login { get; set; }
        public string PublicComment { get; set; }
        public string Password { get; set; }
        public string PrivateComment { get; set; }

        public override void Accept(IPreviewViewVisitor visitor) => visitor.Visit(this);
    }
}
