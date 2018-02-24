using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;

using PetaPoco;
using Telerik.WinControls;

using Common.Interfaces;
using Common.Helpers;
using Common.Repository;
using Common.Repository.Runtime;
using Common.Repository.PrivateCards.Site;
using Common.Repository.PrivateCards.Note;
using Common.Repository.PrivateCards.Device;
using Common.Repository.PrivateCards.DataBase;
using Common.Repository.PrivateCards.CreditCard;

using Password2Go.CommandHandlers;
using Password2Go.CommandHandlers.Commands;
using Password2Go.Services.Holders;
using Password2Go.Services.Mappers.CategoryTree;
using Password2Go.FluxStores;
using Password2Go.Modules.PrivateCard;

using Password2Go.Modules;

namespace Password2Go.Controllers
{

    public class MainController
    {
        const string DATABASE_NAME = "password2go.db";

        Forms.MainForm _mainAppForm;
        IHelperLogger  _logger;

        Database _db;
        MainFormCommandHandler  _commandHandler;
        LocalDirectory          _localDirectory;
        KeyHolderService        _keyHolderService;
        PassphraseHolderService _passphraseHolderService;
        
        ICommonXML<Data.Configs.CategoryTreeConfig> _categoryTreeXml;
        ICommonXML<LocalDirectory> _localDirectoryXmlAdapter;

        CommonStore<ICategorized>         _categorizedStore;
        CommonStore<SiteCardDataType>     _siteCardDataStore;
        CommonStore<NoteCardDataType>     _noteCardDataStore;
        CommonStore<DeviceCardDataType>   _deviceCardDataStore;
        CommonStore<DatabaseCardDataType> _databaseCardDataStore;
        CommonStore<CreditCardDataType>   _creditCardDataStore;

        DIContainer _di;

        public MainController(
            LocalDirectory          localDirectory, 
            KeyHolderService        keyHolderService, 
            PassphraseHolderService passphraseHolderService,
            DIContainer             di,
            IHelperLogger           logger)
        {
            _localDirectory           = localDirectory;
            _keyHolderService         = keyHolderService;
            _passphraseHolderService  = passphraseHolderService;
            _categoryTreeXml          = di.Resolve<ICommonXML<Data.Configs.CategoryTreeConfig>>();
            _localDirectoryXmlAdapter = di.Resolve<ICommonXML<LocalDirectory>>();
            _categorizedStore         = di.Resolve<CommonStore<ICategorized>>();
            _siteCardDataStore        = di.Resolve<CommonStore<SiteCardDataType>>();
            _noteCardDataStore        = di.Resolve<CommonStore<NoteCardDataType>>();
            _deviceCardDataStore      = di.Resolve<CommonStore<DeviceCardDataType>>();
            _databaseCardDataStore    = di.Resolve<CommonStore<DatabaseCardDataType>>();
            _creditCardDataStore      = di.Resolve<CommonStore<CreditCardDataType>>();
            _logger = logger;
            _di = di;
        }

        public void ApplicationRun()
        {
            _db = LocalDatabase.InitDatabase(Path.Combine(_localDirectory.DataDirectory, DATABASE_NAME), _logger);

            if (_db == null)
            {
                return;
            }

            _mainAppForm = new Forms.MainForm() {
                               SelectKeysCommand     = new SelectSaveKeysCommand(_localDirectory, _keyHolderService),
                               SelectDatabaseCommand = new SelectDatabaseDirectoryCommand(_localDirectoryXmlAdapter)
                               };

            _commandHandler = new CommandHandlers.MainFormCommandHandler(_mainAppForm, _db, _keyHolderService, _passphraseHolderService, _di);

            _categorizedStore.Subscribe     (_commandHandler);
            _siteCardDataStore.Subscribe    (_commandHandler);
            _noteCardDataStore.Subscribe    (_commandHandler);
            _deviceCardDataStore.Subscribe  (_commandHandler);
            _databaseCardDataStore.Subscribe(_commandHandler);
            _creditCardDataStore.Subscribe  (_commandHandler);

            var categoryTreeConfig = _categoryTreeXml.Read();

            _mainAppForm.BindCategory(categoryTreeConfig.Map());
            
            _mainAppForm.Init(
                _commandHandler.AddSiteCardAction,
                _commandHandler.AddNoteCardAction,
                _commandHandler.AddDeviceCardAction,
                _commandHandler.AddDatabaseCardAction,
                _commandHandler.AddCreditcardCardAction,
                _commandHandler.CategoryChangedAction,
                _commandHandler.OpenPrivateCardAction,
                _commandHandler.SelectCardAction,
                _commandHandler.EmpteRecycleBinAction,
                _commandHandler.CategoriesOptionsAction
                );

            RuntimeType runtime;
            IRuntimeTable runtimeTable;

            try
            {
                runtimeTable = LocalDatabase.InitRuntime(_db, out runtime);
                if (runtime == null || runtimeTable == null) throw new Exception("Initialization error");
            }
            catch (Exception ex)
            {
                ex.Display();
                _logger.Log("Error updating database, exiting...", eLOG.E_CRITICAL_ERROR);
                return;
            }

            bool success = LocalDatabase.UpdateDB(_db, runtime.DBVersion, _logger);

            if (success)
            {
                //runtime.DBVersion = // @@@ TODO: version of update
                //runtimeTable.Update(runtime);
            }
            else
            {
                _logger.Log("Error updating database to new version", eLOG.E_CRITICAL_ERROR);
                return;
            }

            _logger.Log("Program started", eLOG.E_LOGMESSAGE);


            Application.Run(_mainAppForm);

            _categorizedStore.Unsubscripbe     (_commandHandler);
            _siteCardDataStore.Unsubscripbe    (_commandHandler);
            _noteCardDataStore.Unsubscripbe    (_commandHandler);
            _deviceCardDataStore.Unsubscripbe  (_commandHandler);
            _databaseCardDataStore.Unsubscripbe(_commandHandler);
            _creditCardDataStore.Unsubscripbe  (_commandHandler);

            _logger.Log("Завершение работы", eLOG.E_LOGMESSAGE);
            _db.Dispose();
        }
    }
}
