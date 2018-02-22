using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Password2Go.Dialogs;

namespace Password2Go.Services.Holders
{
    public class PassphraseElement
    {
        public string Password;
        public bool IsLastTrySuccessfull;
    }

    public class PassphraseHolderService
    {
        Dictionary<string, PassphraseElement> _passwordDictionary = new Dictionary<string, PassphraseElement>();

        public string GetPassword(string passwordID)
        {
            // Try check in dictinary. If exist
            if (_passwordDictionary.ContainsKey(passwordID) && _passwordDictionary[passwordID].IsLastTrySuccessfull)
            {
                // @@@ TODO: add time check here, to store password for a specified timeframe
                return _passwordDictionary[passwordID].Password;
            }

            using (var dialog = new PassphraseDialog("Enter password"))
            {
                var dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    if (dialog.RememberPassword)
                    {
                        if (!_passwordDictionary.ContainsKey(passwordID))
                        {
                            _passwordDictionary.Add(passwordID, new PassphraseElement() { IsLastTrySuccessfull = false, Password = dialog.Passphrase } );
                        } 
                    }
                    else
                    {
                        if (_passwordDictionary.ContainsKey(passwordID))
                        {
                            _passwordDictionary.Remove(passwordID);
                        }
                    }

                    return dialog.Passphrase;
                }

                return null;
            }
        }

        public void Ok(string passwordID)
        {
            if (_passwordDictionary.ContainsKey(passwordID))
            {
                _passwordDictionary[passwordID].IsLastTrySuccessfull = true;
            }
        }
    }
}
