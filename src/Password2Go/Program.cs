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

using Password2Go.Modules;

namespace Password2Go
{
    static class Program
    {
        public const string KEYS_CONFIG_FILE_NAME = "keys-config.xml";

        public const string PROGRAMM_VERSION = "2.1.0";
        public const string PROGRAMM_DATE = "18.12.2025";

        const string LOCAL_DIRECTORY_CONFIG_FILENAME = "local-directory.xml";
        const string CATEGORY_CONFIG_FILENAME = "category-config.xml";
        const string LOG_FILENAME = "password2go.log";

        const string IMAGES_CONFIG = "images-config.xml";
        const string IMAGES_DIRECTORY = "images";

        // @@@ TODO: move keyHolderService to DI
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
                LayoutDirectory = Path.Combine(root, "layout", PROGRAMM_VERSION),
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

            IHelperLogger logger = new HelperLogger("main", Path.Combine(localDirectory.LogDirectory, LOG_FILENAME));
            logger.Log("Program starting...", eLOG.E_LOGMESSAGE);

            //ICommonXML<Data.Configs.CategoryTreeConfig> categoryXmlAdapter =
            //    new CommonXMLAdapter<Data.Configs.CategoryTreeConfig>(Path.Combine(localDirectory.ConfigDirectory, CATEGORY_CONFIG_FILENAME));
            //DI.Register(categoryXmlAdapter);

            ICommonXML<LocalDirectory> localDirectoryXmlAdapter =
                new CommonXMLAdapter<LocalDirectory>(Path.Combine(localDirectory.ConfigDirectory, LOCAL_DIRECTORY_CONFIG_FILENAME));
            DI.Register(localDirectoryXmlAdapter);

            if (CheckIsConfigExist(localDirectory, KEYS_CONFIG_FILE_NAME) == false)
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

                localDirectoryXmlAdapter.Write(localDirectory);
                SaveConfig(Path.Combine(localDirectory.ConfigDirectory, KEYS_CONFIG_FILE_NAME), keysConfig);

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
                keysConfig                   = LoadConfig<Data.Configs.KeysConfig>(Path.Combine(localDirectory.ConfigDirectory, KEYS_CONFIG_FILE_NAME));
                logger.Log("Configs loaded!", eLOG.E_LOGMESSAGE);
            }

            ICommonXML<Data.Configs.CategoryTreeConfig> categoryXmlAdapter =
                new CommonXMLAdapter<Data.Configs.CategoryTreeConfig>(Path.Combine(localDirectory.DataDirectory, CATEGORY_CONFIG_FILENAME));
            DI.Register(categoryXmlAdapter);

            if (categoryXmlAdapter.IsEmpty())
            {
                var categoryTreeConfig = Modules.CategoryTree.TreeViewModel.CreateMockTree().Map();
                categoryXmlAdapter.Write(categoryTreeConfig);
                logger.Log("new category tree created", eLOG.E_LOGMESSAGE);
            }

            _keyHolderService = new KeyHolderService().Init(keysConfig);
            _passphraseHolderService = new PassphraseHolderService();

            Data.Configs.ImagesConfig imagesConfig = new Data.Configs.ImagesConfig();
            try
            {
                // Try load image config from the same directory as "Exe" file
                imagesConfig = LoadConfig<Data.Configs.ImagesConfig>(IMAGES_CONFIG);
                if (imagesConfig == null)
                {
                    throw new Exception($"Error parsing {IMAGES_CONFIG}");
                }
                Services.Images.LoadImageService loadImageService = new Services.Images.LoadImageService();
                loadImageService.LoadImagesConfig(imagesConfig, IMAGES_DIRECTORY);
                Services.Mappers.CardDataMapper.Site.SiteCardDataTypeExtension.ImageService = loadImageService;
            }
            catch (FileNotFoundException ex)
            {
                logger?.Log($"Error loading {IMAGES_CONFIG}: {ex.Message}", eLOG.E_ERROR);
            }
            catch (Exception ex)
            {
                logger?.Log($"Error loading {IMAGES_CONFIG}: {ex.Message}", eLOG.E_ERROR);
                ex.Display();
            }

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

            try
            {
                mainController.ApplicationRun();
            } catch (Exception ex)
            {
                ex.Display();
            }
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
