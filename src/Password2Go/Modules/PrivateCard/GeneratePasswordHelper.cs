using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using Telerik.WinControls.UI;

namespace Password2Go.Modules.PrivateCard
{
    public class GeneratePasswordHelper
    {
        readonly Bitmap GENERATE_PASSWORD_IMAGE = Password2Go.Properties.Resources.if_dice_64067_16x16;

        public Func<string> GeneratePasswordAction
        {
            get
            {
                return _generatePasswordAction;
            }
            set
            {
                _generatePasswordAction = value;
            }
        }

        private LightVisualButtonElement _generatePasswordButton;
        private Func<string> _generatePasswordAction;
        private RadTextBoxControl _textBoxControl;

        public GeneratePasswordHelper(RadTextBoxControl textBoxControl)
        {
            _textBoxControl = textBoxControl;
            _generatePasswordButton = _textBoxControl.AddElementToTextBox(GENERATE_PASSWORD_IMAGE, GeneratePassword_Click);
        }

        public void SetVisibility(bool visible)
        {
            _generatePasswordButton.Visibility = 
                visible ? Telerik.WinControls.ElementVisibility.Visible 
                : Telerik.WinControls.ElementVisibility.Collapsed ;
        }

        public void GeneratePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string generatedPassword = _generatePasswordAction();
                if (!string.IsNullOrWhiteSpace(generatedPassword))
                {
                    _textBoxControl.Text = generatedPassword;
                }
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }
    }
}
