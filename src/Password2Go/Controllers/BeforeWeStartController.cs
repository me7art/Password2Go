using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

using Telerik.WinControls;

using CryptoLibrary.BountyCastleFacade;
using Password2Go.Modules;
using Password2Go.Forms;

namespace Password2Go.Controllers
{
    public class BeforeWeStartController
    {
        LocalDirectory _localDirectory;
        Data.Configs.KeysPathConfig _keysPathConfig;

        public Data.Configs.KeysPathConfig KeysPath => _keysPathConfig;
        //public string KeyID;
        public string DatabaseDirectory;

        bool _isKeysOk;
        bool _isDatabasePathOk;
        bool _isDone => _isKeysOk && _isDatabasePathOk;

        BeforeWeStartForm _form;

        public BeforeWeStartController(LocalDirectory localDirectory, Data.Configs.KeysPathConfig keysPathConfig)
        {
            _localDirectory = localDirectory;
            _keysPathConfig = keysPathConfig;
        }

        public bool FirstRunConfig()
        {
            using (_form = new BeforeWeStartForm())
            {
                _form.Init(generateKeys: GenerateKeysAction, selectKeys: SelectKeysAction, selectDatabaseDirectory: SelectDirectoryAction);
                _form.DisableStep2(disable: true);
                _form.ShowDialog();
            }

            return _isDone;
        }

        async private Task GenerateKeysAction()
        {
            var passwordDialogResult = Dialogs.PasswordDialog.MyShowDialog("Please, provide password for new key");

            if (passwordDialogResult.DialogResult1 != System.Windows.Forms.DialogResult.OK)
            {
                throw new Exception("Missing passphrase for private key");
            }

            _form.DisableStep1(disable: true);
            _form.IsGeneratingLabelVisible = true;

            KeyRingType keyRing = await GenerateKeysAsync(passwordDialogResult.Password);
            SaveKeys(_keysPathConfig, keyRing);
            _keysPathConfig.KeyID = keyRing.KeyID;
            _isKeysOk = true;
            _form.IsGeneratingLabelVisible = false;
            _form.DisableStep2(disable: false);

            _form.SetDoneEnabled(_isDone);
        }

        private Task<KeyRingType> GenerateKeysAsync(string password)
        {
            var generator = new KeyRingGeneratorFacade($"Password2Go.Desktop.{DateTime.Now}", password);
            generator.Init();
            var keyRing = generator.GenerateKeysAsync();

            return keyRing;
        }

        private void SaveKeys(Data.Configs.KeysPathConfig keysPathConfig, KeyRingType keyRing)
        {
            File.WriteAllBytes(keysPathConfig.PrivateKeyPath, keyRing.PrivateKey);
            File.WriteAllBytes(keysPathConfig.PublicKeyPath, keyRing.PublicKey);
        }

        private void SelectKeysAction()
        {
            var selectKeysCommand = new Password2Go.CommandHandlers.Commands.SelectKeysCommand(_localDirectory, null);
            selectKeysCommand.Execute();
            if (selectKeysCommand.IsKeysOk)
            {
                _keysPathConfig.KeyID = selectKeysCommand.GetKeysPathConfig().KeyID;
                _keysPathConfig.PublicKeyPath = selectKeysCommand.GetKeysPathConfig().PublicKeyPath;
                _keysPathConfig.PrivateKeyPath = selectKeysCommand.GetKeysPathConfig().PrivateKeyPath;
                _form.DisableStep1(disable: true);
                _form.DisableStep2(disable: false);

                _isKeysOk = true;

                _form.SetDoneEnabled(_isDone);
            }
        }

        private void SelectDirectoryAction()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                var dialogResult = dialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    DatabaseDirectory = dialog.SelectedPath;
                    _isDatabasePathOk = true;
                    _form.DisableStep2(disable: true);
                    _form.IsWeDonaLabelVisible = true;
                    _form.SetDoneEnabled(_isDone);
                }
            }
        }
    }
}
