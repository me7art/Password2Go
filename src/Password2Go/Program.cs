using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using System.IO;

using Telerik.WinControls;

using Password2Go.Services.Mappers.CategoryTree;
using Password2Go.Services.Holders;
using Common.Helpers;
using Common.Interfaces;
using Common.Repository;


namespace Password2Go
{
    static class Program
    {
        const string ProgrammVersion = "0.1";
        public const string KeysConfigFileName = "keys-config.xml";
        const string LocalDirectoryConfigFileName = "local-directory.xml";
        const string CategoryConfigFileName = "category-config.xml";
        const string logfileName = "password2go.log";

        // @@@ TODO: moce keyHolderService to DI
        public static KeyHolderService _keyHolderService;
        public static PassphraseHolderService _passphraseHolderService;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            RadMessageBox.SetThemeName("Office2013Dark");

            DIContainer DI = new DIContainer();

            // Initialize directories
            var root = Path.Combine(
                Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData),
                "2go.space",
                "Password.2go");

            var localDirectory = new LocalDirectory
            {
                DataDirectory = Path.Combine(root, "data"),
                LogDirectory = Path.Combine(root, "log", DateTime.Now.ToShortDateString()),
                LayoutDirectory = Path.Combine(root, "layout", ProgrammVersion),
                TempDirectory = Path.Combine(root, "temp"),
                ConfigDirectory = Path.Combine(root, "config"),
                KeysDirectory = Path.Combine(root, "keys")
            };

            Data.Configs.KeysConfig keysConfig = new Data.Configs.KeysConfig();

            try
            {
                Directory.CreateDirectory(localDirectory.DataDirectory);
                Directory.CreateDirectory(localDirectory.LogDirectory);
                Directory.CreateDirectory(localDirectory.LayoutDirectory);
                Directory.CreateDirectory(localDirectory.TempDirectory);
                Directory.CreateDirectory(localDirectory.ConfigDirectory);
                Directory.CreateDirectory(localDirectory.KeysDirectory);
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Can't create config directories:\n{ex.Message}", "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            IHelperLogger logger = new HelperLogger("main", Path.Combine(localDirectory.LogDirectory, logfileName));
            logger.Log("Program starting...", eLOG.E_LOGMESSAGE);

            ICommonXML<Data.Configs.CategoryTreeConfig> categoryXmlAdapter = 
                new CommonXMLAdapter<Data.Configs.CategoryTreeConfig>(Path.Combine(localDirectory.ConfigDirectory, CategoryConfigFileName));
            DI.Register(categoryXmlAdapter);

            ICommonXML<LocalDirectory> localDirectoryXmlAdapter =
                new CommonXMLAdapter<LocalDirectory>(Path.Combine(localDirectory.ConfigDirectory, LocalDirectoryConfigFileName));
            DI.Register(localDirectoryXmlAdapter);

            if (CheckIsConfigExist(localDirectory, KeysConfigFileName) == false)
            {
                logger.Log("BEGIN INITIALIZATION. Generating public/private keys, init database, create dummy config files", eLOG.E_LOGMESSAGE);
                // First run - initialize config
                string guid = Guid.NewGuid().ToString();
                var keysPathConfig = new Data.Configs.KeysPathConfig()
                {
                    PrivateKeyPath = Path.Combine(localDirectory.KeysDirectory, $"{guid}.2go-private"),
                    PublicKeyPath = Path.Combine(localDirectory.KeysDirectory, $"{guid}.2go-public"),
                };
                var beforeWeStartController = new Controllers.BeforeWeStartController(localDirectory, keysPathConfig);
                var configResult = beforeWeStartController.FirstRunConfig();

                if (!configResult)
                    return;

                localDirectory.DataDirectory = beforeWeStartController.DatabaseDirectory;
                keysConfig.Keys.Add(beforeWeStartController.KeysPath);
                var categoryTreeConfig = Modules.CategoryTree.TreeViewModel.CreateMockTree().Map();

                //SaveConfig(Path.Combine(localDirectory.ConfigDirectory, LocalDirectoryConfigFileName), localDirectory);
                localDirectoryXmlAdapter.Write(localDirectory);
                SaveConfig(Path.Combine(localDirectory.ConfigDirectory, KeysConfigFileName), keysConfig);
                categoryXmlAdapter.Write(categoryTreeConfig);

                logger.Log("INITIALIZATION COMPLETE!", eLOG.E_LOGMESSAGE);
                RadMessageBox.Show("Initialization complete!", "Message", MessageBoxButtons.OK, RadMessageIcon.Info);
            } else
            {
                // Load config here...
                logger.Log("Loading configs...", eLOG.E_LOGMESSAGE);
                //var savedLocalDirectory      = LoadConfig<LocalDirectory>(Path.Combine(localDirectory.ConfigDirectory, LocalDirectoryConfigFileName));
                var savedLocalDirectory      = localDirectoryXmlAdapter.Read();
                localDirectory.DataDirectory = savedLocalDirectory.DataDirectory;
                localDirectory.KeysDirectory = savedLocalDirectory.KeysDirectory;
                keysConfig                   = LoadConfig<Data.Configs.KeysConfig>(Path.Combine(localDirectory.ConfigDirectory, KeysConfigFileName));
                logger.Log("Configs loaded!", eLOG.E_LOGMESSAGE);
            }

            _keyHolderService = new KeyHolderService().Init(keysConfig);
            _passphraseHolderService = new PassphraseHolderService();

            //
            // Registering flux-stores in DI
            //
            DI.Register(new FluxStores.CommonStore<Modules.PrivateCard.ICategorized>());
            DI.Register(new FluxStores.CommonStore<Common.Repository.PrivateCards.Site.SiteCardDataType>());
            DI.Register(new FluxStores.CommonStore<Common.Repository.PrivateCards.Note.NoteCardDataType>());
            DI.Register(new FluxStores.CommonStore<Common.Repository.PrivateCards.Device.DeviceCardDataType>());
            DI.Register(new FluxStores.CommonStore<Common.Repository.PrivateCards.DataBase.DatabaseCardDataType>());
            DI.Register(new FluxStores.CommonStore<Common.Repository.PrivateCards.CreditCard.CreditCardDataType>());
            //
            // Runing app
            //
            var mainController = new Controllers.MainController(localDirectory, _keyHolderService, _passphraseHolderService, DI, logger);
            mainController.ApplicationRun();
        }

        public static bool CheckIsConfigExist(LocalDirectory localDirectory, string configFileName)
        {
            return File.Exists(Path.Combine(localDirectory.ConfigDirectory, configFileName));
        }

        static void SaveConfig(string path, object obj)
        {
            Common.Helpers.SerializationFile.SerializeObject(obj, path);
        }

        static T LoadConfig<T>(string path)
        {
            return Common.Helpers.SerializationFile.DeSerializeObject<T>(path);
        }
    }
}
