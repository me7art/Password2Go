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
    public partial class CreditCardPreviewUI : UserControl, IPreviewUI
    {
        public UserControl ThisUserControl => this;

        const string HEADER_TEXT = "Selected Item";
        Bitmap _copyImage = Password2Go.Properties.Resources.if_document_copy_14383;
        Bitmap _showPasswordImage = Password2Go.Properties.Resources.if_eye_36031_16x16;
        Bitmap _hidePasswordImage = Password2Go.Properties.Resources.if_ui_web_app_76_2894823;

        CreditCardPreviewViewModel _model;

        public Action<BasePreviewViewModel> DecryptAction;
        public Action<BasePreviewViewModel, PasswordTypeEnum> CopyPasswordAction;

        ShowHideHelper _showHideHelper = new ShowHideHelper("Show", "Hide");

        public CreditCardPreviewUI()
        {
            InitializeComponent();

            rtbNumber.AddElementToTextBox(_copyImage, rbCopyNumber_Click);
            rtbCVV.AddElementToTextBox(_copyImage, rbCopyCVV_Click);
        }

        public void Bind(object previewModel, bool updateView = true)
        {
            _showHideHelper.Reset();

            CreditCardPreviewViewModel model = previewModel as CreditCardPreviewViewModel;

            _model = model;

            if (model == null)
            {
                radGroupBox1.Text = HEADER_TEXT;
                return;
            }

            if (updateView) UpdateView(_model);
        }

        private void UpdateView(CreditCardPreviewViewModel model)
        {
            radGroupBox1.Text = $"{HEADER_TEXT}: {model.Title}";
            
            
            rtbBank.Text = model.Bank;
            rtbLast4Digits.Text = model.Last4Digits;

            if (!model.IsDecrypted)
            {
                rtbNumber.Text = "*** Encrypted number ***";
                rtbHolder.Text = "*** Encrypted holder ***";
                rtbValidTill.Text = "xxxxxx xxxxxx";
                rtbCVV.Text = "xxx";
                rtbPin.Text = "xxxx";
            }
            else
            {
                rtbNumber.Text = model.Number;
                rtbHolder.Text = model.Holder;
                rtbValidTill.Text = model.ValidTill;

                rtbCVV.Text = model.CVV;
                rtbPin.Text = model.Pin;
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

        //private void rbShowPassword_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (_showHideHelper.IsHideWhatever)
        //        {
        //            HidePassword();
        //            _showHideHelper.Reverse();
        //        }
        //        else
        //        {
        //            if (!_model.IsDecrypted)
        //            {
        //                DecryptAction?.Invoke(_model);
        //            }
        //            ShowPassword();
        //            _showHideHelper.Reverse();
        //        }
        //    }
        //    catch (DecryptionCanceledByUserException)
        //    {
        //        // do nothing
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Display();
        //    }
        //}

        //private void HidePassword()
        //{
        //    rtbValidTill.PasswordChar = '*';
        //    rtbValidTill.Text = _model.Password.Replace(' ', '_');
        //    rtbValidTill.Refresh();
        //}

        //private void ShowPassword()
        //{
        //    rtbValidTill.PasswordChar = '\0';
        //    rtbValidTill.Text = _model.Password;
        //    rtbValidTill.Refresh();
        //}

        //private void rbCopyPassword_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CopyPasswordAction?.Invoke(_model);
        //        rtbValidTill.Blink(Color.White, 120);
        //    }
        //    catch (DecryptionCanceledByUserException)
        //    {
        //        // do nothing
        //    }
        //    catch (Exception ex)
        //    {
        //        ex.Display();
        //    }
        //}

        private void rbCopyNumber_Click(object sender, EventArgs e)
        {
            try
            {
                CopyPasswordAction?.Invoke(_model, PasswordTypeEnum.Number);
                rtbNumber.Blink(Color.White, 120);
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

        private void rbCopyCVV_Click(object sender, EventArgs e)
        {
            try
            {
                CopyPasswordAction?.Invoke(_model, PasswordTypeEnum.CVV);
                rtbCVV.Blink(Color.White, 120);
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


    }

    public class CreditCardPreviewViewModel : BasePreviewViewModel
    {
        public bool IsDecrypted;
        public int ID;
        public string Title;
        public string Bank { get; set; }
        public string Last4Digits { get; set; }

        public string Number { get; set; }
        public string Holder { get; set; }
        public string ValidTill { get; set; }
        public string CVV { get; set; }
        public string Pin { get; set; }

        public override void Accept(IPreviewViewVisitor visitor) => visitor.Visit(this);
    }
}
