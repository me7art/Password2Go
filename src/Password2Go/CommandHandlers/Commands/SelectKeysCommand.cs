using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

using Telerik.WinControls;

using CryptoLibrary.BountyCastleFacade;

using Common.Interfaces;
using Common.Repository;

using Password2Go.Modules;
using Password2Go.Services.Holders;
using Password2Go.Dialogs;

namespace Password2Go.CommandHandlers.Commands
{
    public class SelectDatabaseDirectoryCommand : ICommand
    {
        ICommonXML<LocalDirectory> _localDirectoryXmlAdapter;

        public SelectDatabaseDirectoryCommand(ICommonXML<LocalDirectory> localDirectoryXmlAdapter)
        {
            _localDirectoryXmlAdapter = localDirectoryXmlAdapter;
        }

        public void Execute()
        {
            var localDirectoryConfig = _localDirectoryXmlAdapter.Read();

            using (var infoDialog = new DatabaseInfoDialog())
            {
                infoDialog.UserInput = localDirectoryConfig.DataDirectory;

                var dialogResult = infoDialog.ShowDialog();
                if (DialogResult.OK == dialogResult)
                {
                    localDirectoryConfig.DataDirectory = infoDialog.UserInput;
                    _localDirectoryXmlAdapter.Write(localDirectoryConfig);

                    RadMessageBox.Show("You need to restart the program for the changes to take effect.", "Information", MessageBoxButtons.OK, RadMessageIcon.Info);
                }
            }
        }

        public bool CanExecute() => true;
    }


    public class SelectSaveKeysCommand : ICommand
    {
        LocalDirectory _localDirectory;
        KeyHolderService _keyHolderService;

        public SelectSaveKeysCommand(LocalDirectory localDirectory, KeyHolderService keyHolderService)
        {
            _localDirectory = localDirectory;
            _keyHolderService = keyHolderService;
        }

        public void Execute()
        {
            var keysConfigPath = Path.Combine(_localDirectory.ConfigDirectory, Program.KEYS_CONFIG_FILE_NAME);

            var keysConfig = Common.Helpers.SerializationFile.DeSerializeObject<Data.Configs.KeysConfig>(keysConfigPath);

            var keysPathConfig = keysConfig.Keys.FirstOrDefault();

            var selectKeysCommand = new SelectKeysCommand(_localDirectory, keysPathConfig);
            selectKeysCommand.Execute();
            if (selectKeysCommand.IsKeysOk)
            {
                Data.Configs.KeysConfig newKeysConfig = new Data.Configs.KeysConfig();
                newKeysConfig.Keys.Add(selectKeysCommand.GetKeysPathConfig());
                Common.Helpers.SerializationFile.SerializeObject(newKeysConfig, keysConfigPath);

                _keyHolderService.Init(newKeysConfig);
            }
        }

        public bool CanExecute() => true;
    }

    public class SelectKeysCommand : ICommand
    {
        LocalDirectory _localDirectory;
        Password2Go.Data.Configs.KeysPathConfig _keysPathConfig;

        public bool IsKeysOk;
        public Password2Go.Data.Configs.KeysPathConfig GetKeysPathConfig() => _keysPathConfig;

        public SelectKeysCommand(LocalDirectory localDirectory, Password2Go.Data.Configs.KeysPathConfig keysPathConfig = null)
        {
            _localDirectory = localDirectory;
            _keysPathConfig = keysPathConfig;
        }

        public void Execute()
        {
            // loading config
            if (_keysPathConfig == null)
            {
                _keysPathConfig = new Data.Configs.KeysPathConfig();
            }
            //else
            //{
            //    var keysConfig = Common.Helpers.SerializationFile.DeSerializeObject<Data.Configs.KeysConfig>(
            //        Path.Combine(_localDirectory.ConfigDirectory, Program.KeysConfigFileName));

            //    _keysPathConfig = keysConfig.Keys.FirstOrDefault();
            //}

            using (var keysForm = new Password2Go.Forms.KeysPathForm())
            {
                var keys = new Password2Go.Forms.KeyPathViewModel()
                {
                    PublicKeyPath = _keysPathConfig.PublicKeyPath,
                    PrivateKeyPath = _keysPathConfig.PrivateKeyPath
                };

                keysForm.FormClosing += (object sender, FormClosingEventArgs e) =>
                {
                    try
                    {
                        if (keysForm.DialogResult == DialogResult.OK)
                        {
                            //e.CloseReason == CloseReason.UserClosing
                            EncryptFacade encrypt = new EncryptFacade(File.ReadAllBytes(keys.PublicKeyPath));
                            encrypt.Init();
                            Password2Go.Services.Holders.PassphraseHolderService keyHolderService = new Services.Holders.PassphraseHolderService();
                            var passphrase = keyHolderService.GetPassword(encrypt.PublicKeyID);
                            DecryptFacade decrypt = new DecryptFacade(File.ReadAllBytes(keys.PrivateKeyPath), passphrase);
                            decrypt.Init();

                            if (encrypt.PublicKeyID != decrypt.PrivateKeyID)
                            {
                                e.Cancel = true;
                                //throw new Exception("Public and private keys do not match!");
                                RadMessageBox.Show("Public and private keys do not match!");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        e.Cancel = true;
                        ex.Display();
                    }

                };

                keysForm.Bind(keys);
                var dialogResult = keysForm.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    EncryptFacade encrypt = new EncryptFacade(File.ReadAllBytes(keys.PublicKeyPath));
                    encrypt.Init();

                    _keysPathConfig.KeyID = encrypt.PublicKeyID;
                    _keysPathConfig.PublicKeyPath = keys.PublicKeyPath;
                    _keysPathConfig.PrivateKeyPath = keys.PrivateKeyPath;

                    IsKeysOk = true;
                }
            }
        }

        public bool CanExecute() => true;
    }

}
