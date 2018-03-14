using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.ComponentModel;

using System.Drawing;

using PetaPoco;

using Password2Go.Modules.PrivateCard;
using Common.Helpers;
using Common.Repository.PrivateCards;

using Common.Repository.PrivateCards.Site;
using Password2Go.Services.Mappers.CardDataMapper.Site;

using Common.Repository.PrivateCards.Note;
using Password2Go.Services.Mappers.CardDataMapper.Note;

using Common.Repository.PrivateCards.Device;
using Password2Go.Services.Mappers.CardDataMapper.Device;

using Common.Repository.PrivateCards.DataBase;
using Password2Go.Services.Mappers.CardDataMapper.DataBase;

using Common.Repository.PrivateCards.CreditCard;
using Password2Go.Services.Mappers.CardDataMapper.CreditCard;

using Password2Go.Modules.PrivateCardList;
using Password2Go.Modules.CategoryTree;
using Password2Go.Services.Holders;
using Password2Go.FluxStores;
using Password2Go.Modules.Preview;
using Common.Repository;
using Password2Go.Services.Mappers.CategoryTree;
using Password2Go.Forms;
using Password2Go.Modules.PasswordGenerator;


namespace Password2Go.CommandHandlers
{
    public partial class MainFormCommandHandler : 
        IReciever<ICategorized>, // For category updates only

        IReciever<SiteCardDataType>,        // For whole site card update and add action (self raisign update)
        IReciever<NoteCardDataType>,
        IReciever<DeviceCardDataType>,
        IReciever<DatabaseCardDataType>,
        IReciever<CreditCardDataType>
    {
        public TreeNodeViewModel CurrentCategory => _currentCategory;

        PassphraseHolderService _passphraseHolderService;
        KeyHolderService _keyHolderService;
        CardsTableChain _cardsTableChain;
        Forms.MainForm _mainForm;
        TreeNodeViewModel _currentCategory = null;
        DIContainer _di;
        DIContainer _internalDI = new DIContainer();

        // Stores for viewModel
        CommonStore<ICategorized> _categorizedCardVMStore;
        //CommonStore<PrivateCardListViewModel> _listVMStore;

        ICommonXML<Data.Configs.CategoryTreeConfig> _categoryTreeXml;

        BindingList<PrivateCardListViewModel> _blist = new BindingList<PrivateCardListViewModel>();

        PrivateCardTypeEnum _currentPreviewUI;
        Dictionary<PrivateCardTypeEnum, IPreviewUI> _previewUIs; 

        public MainFormCommandHandler(Forms.MainForm mainForm, 
            Database db, 
            KeyHolderService keyHolderService, 
            PassphraseHolderService passphraseHolderService,
            DIContainer di)
        {
            InitPreviewUI();

            _di = di;
            _mainForm = mainForm;
            _keyHolderService = keyHolderService;
            _passphraseHolderService = passphraseHolderService;
            
            _categoryTreeXml = _di.Resolve<ICommonXML<Data.Configs.CategoryTreeConfig>>();
            _categorizedCardVMStore = _di.Resolve<CommonStore<ICategorized>>();

            // Common stores
            _internalDI.Register(_categorizedCardVMStore);

            // Configuring SiteCards
            _siteCardDataStore = _di.Resolve<CommonStore<SiteCardDataType>>();
            _siteCardsTable = new SiteCardsTableAdapter(db);
            _siteCardDataMapper = new SiteCardDataMapper(_keyHolderService);
            _internalDI.Register<ICardsTable<SiteCardDataType>>(_siteCardsTable);
            _internalDI.Register<CommonStore<SiteCardDataType>>(_siteCardDataStore);

            // Configuring NoteCards
            _noteCardDataStore = _di.Resolve<CommonStore<NoteCardDataType>>();
            _noteCardsTable = new NoteCardsTableAdapter(db);
            _noteCardDataMapper = new NoteCardDataMapper(_keyHolderService);
            _internalDI.Register<ICardsTable<NoteCardDataType>>(_noteCardsTable);
            _internalDI.Register<CommonStore<NoteCardDataType>>(_noteCardDataStore);

            // Configuring DeviceCards
            _deviceCardDataStore = _di.Resolve<CommonStore<DeviceCardDataType>>();
            _deviceCardsTable = new DeviceCardsTableAdapter(db);
            _deviceCardDataMapper = new DeviceCardDataMapper(_keyHolderService);
            _internalDI.Register<ICardsTable<DeviceCardDataType>>(_deviceCardsTable);
            _internalDI.Register<CommonStore<DeviceCardDataType>>(_deviceCardDataStore);

            // Configuring DatabaseCards
            _databaseCardDataStore = _di.Resolve<CommonStore<DatabaseCardDataType>>();
            _databaseCardsTable = new DatabaseCardsTableAdapter(db);
            _databaseCardDataMapper = new DatabaseCardDataMapper(_keyHolderService);
            _internalDI.Register<ICardsTable<DatabaseCardDataType>>(_databaseCardsTable);
            _internalDI.Register<CommonStore<DatabaseCardDataType>>(_databaseCardDataStore);

            // Configuring CreditCards
            _creditCardDataStore = _di.Resolve<CommonStore<CreditCardDataType>>();
            _creditCardsTable = new CreditCardsTableAdapter(db);
            _creditCardDataMapper = new CreditCardDataMapper(_keyHolderService);
            _internalDI.Register<ICardsTable<CreditCardDataType>>(_creditCardsTable);
            _internalDI.Register<CommonStore<CreditCardDataType>>(_creditCardDataStore);

            // Configuring CardsTableChain
            _cardsTableChain = new CardsTableChain(_siteCardsTable, _noteCardsTable, _deviceCardsTable, _databaseCardsTable, _creditCardsTable);
        }

        //
        // PREVIEW INIT
        //
        private void InitPreviewUI()
        {
            _previewUIs = new Dictionary<PrivateCardTypeEnum, IPreviewUI>()
                {
                    {PrivateCardTypeEnum.Site, new SitePreviewUI() { Dock = DockStyle.Fill, DecryptAction = DecryptBasePreviewAction, CopyPasswordAction = CopyBasePasswordPreviewAction } },
                    {PrivateCardTypeEnum.Note, new NotePreviewUI() { Dock = DockStyle.Fill, DecryptAction = DecryptBasePreviewAction } },
                    {PrivateCardTypeEnum.Device, new DevicePreviewUI() { Dock = DockStyle.Fill, DecryptAction = DecryptBasePreviewAction, CopyPasswordAction = CopyBasePasswordPreviewAction } },
                    {PrivateCardTypeEnum.Database, new DatabasePreviewUI() { Dock = DockStyle.Fill, DecryptAction = DecryptBasePreviewAction, CopyPasswordAction = CopyBasePasswordPreviewAction } },
                    {PrivateCardTypeEnum.CreditCard, new CreditCardPreviewUI() { Dock = DockStyle.Fill, DecryptAction = DecryptBasePreviewAction, CopyPasswordAction = CopyBasePasswordPreviewAction } }
                };
        }

        //
        // SITE CARD
        //
        ICardsTable<SiteCardDataType> _siteCardsTable;
        SiteCardDataMapper _siteCardDataMapper;
        CommonStore<SiteCardDataType> _siteCardDataStore;

        public void AddSiteCardAction()
        {
            AddCard<SiteCardUI, SiteCardPublicViewModel, SiteCardPrivateViewModel, SiteCardDataType>("Add Site",
                Password2Go.Properties.Resources.if_chrome_317753,
                _siteCardDataMapper.Map);
        }

        public void StoreUpdateHandler(object sender, UpdatedArgs<SiteCardDataType> a)
        {
            CommonStoreUpdateHandler<SiteCardDataType, SitePreviewViewModel>(sender, a, PrivateCardTypeEnum.Site,
                SiteCardDataTypeExtension.MapToListItem, SiteCardDataTypeExtension.MapToPreview);
        }

        //
        // NOTE CARD
        //
        ICardsTable<NoteCardDataType> _noteCardsTable;
        NoteCardDataMapper _noteCardDataMapper;
        CommonStore<NoteCardDataType> _noteCardDataStore;

        public void AddNoteCardAction()
        {
            AddCard<NoteCardUI, NoteCardPublicViewModel, NoteCardPrivateViewModel, NoteCardDataType>("Add Note",
                Password2Go.Properties.Resources.if_page_white_text_36305, _noteCardDataMapper.Map);
        }

        public void StoreUpdateHandler(object sender, UpdatedArgs<NoteCardDataType> a)
        {
            CommonStoreUpdateHandler<NoteCardDataType, NotePreviewViewModel>(sender, a, PrivateCardTypeEnum.Note,
                NoteCardDataTypeExtension.MapToListItem, NoteCardDataTypeExtension.MapToPreview);
        }

        //
        // DEVICE CARD
        //
        ICardsTable<DeviceCardDataType> _deviceCardsTable;
        DeviceCardDataMapper _deviceCardDataMapper;
        CommonStore<DeviceCardDataType> _deviceCardDataStore;

        public void AddDeviceCardAction()
        {
            AddCard<DeviceCardUI, DeviceCardPublicViewModel, DeviceCardPrivateViewModel, DeviceCardDataType>("Add Device",
                Password2Go.Properties.Resources.if_gnome_fs_server_211231,
                _deviceCardDataMapper.Map);
        }

        public void StoreUpdateHandler(object sender, UpdatedArgs<DeviceCardDataType> a)
        {
            CommonStoreUpdateHandler<DeviceCardDataType, DevicePreviewViewModel>(sender, a, PrivateCardTypeEnum.Device,
                DeviceCardDataTypeExtension.MapToListItem, DeviceCardDataTypeExtension.MapToPreview);
        }

        //
        // DATABASE CARD
        //
        ICardsTable<DatabaseCardDataType> _databaseCardsTable;
        DatabaseCardDataMapper _databaseCardDataMapper;
        CommonStore<DatabaseCardDataType> _databaseCardDataStore;

        public void AddDatabaseCardAction()
        {
            AddCard<DatabaseCardUI, DatabaseCardPublicViewModel, DatabaseCardPrivateViewModel, DatabaseCardDataType>("Add Database",
                Password2Go.Properties.Resources.if_database_35948_icon,
                _databaseCardDataMapper.Map);
        }

        public void StoreUpdateHandler(object sender, UpdatedArgs<DatabaseCardDataType> a)
        {
            CommonStoreUpdateHandler<DatabaseCardDataType, DatabasePreviewViewModel>(sender, a, PrivateCardTypeEnum.Database,
                DatabaseCardDataTypeExtension.MapToListItem, DatabaseCardDataTypeExtension.MapToPreview);
        }

        // 
        // CREDIT CARD
        //
        ICardsTable<CreditCardDataType> _creditCardsTable;
        CreditCardDataMapper _creditCardDataMapper;
        CommonStore<CreditCardDataType> _creditCardDataStore;

        public void AddCreditcardCardAction()
        {
            AddCard<CreditCardUI, CreditCardPublicViewModel, CreditCardPrivateViewModel, CreditCardDataType>("Add Creditcard",
                Password2Go.Properties.Resources.if_database_35948_icon,
                _creditCardDataMapper.Map);
        }

        public void StoreUpdateHandler(object sender, UpdatedArgs<CreditCardDataType> a)
        {
            CommonStoreUpdateHandler<CreditCardDataType, CreditCardPreviewViewModel>(sender, a, PrivateCardTypeEnum.CreditCard,
                CreditCardDataTypeExtension.MapToListItem, CreditCardDataTypeExtension.MapToPreview);
        }

        //
        // ICategorized update handler
        //
        public void StoreUpdateHandler(object sender, UpdatedArgs<ICategorized> a)
        {
            if (a.UpdatedAction == UpdatedActionEnum.Update || a.UpdatedAction == UpdatedActionEnum.Add)
            {
                foreach (var item in a.Items)
                {
                    var listItem = _blist?.FirstOrDefault(x => x.ID == item.ID && x.CardType == item.CardType);
                    if (listItem != null)
                    {
                        if (item.CategoryID != _currentCategory.NodeID // if category changed
                            && _currentCategory.GetAllChildNodeKeys().Contains(item.CategoryID) == false // and new category not in child of current categorys
                            && _currentCategory.IsVirtual == false // and current categorys is not virtual category (@@@ TODO: need proper way to determine content of virtual category)
                            )
                        {
                            // Category changed. Just remove item from current view
                            _mainForm.ClearPreview();
                            _blist.Remove(listItem);
                        }
                    }
                }
            } else if (a.UpdatedAction == UpdatedActionEnum.Delete)
            {

            }
        }

        private TreeNodeViewModel GetCategoryIdForCard()
        {
            var category =
                    _currentCategory?.IsVirtual == true
                    ? SelectCategoryDialog()
                    : (_currentCategory ?? SelectCategoryDialog());

            //if (null == category)
            //{
            //    throw new Exception("Category not specified");
            //}

            return category;
        }

        private TreeNodeViewModel SelectCategoryDialog()
        {
            using (var categoryDialog = new Dialogs.CategoryDialog("Select Category"))
            {
                var categories = _categoryTreeXml.Read();
                var treeViewModel = categories.Map(addVirtual: false);

                categoryDialog.Bind(treeViewModel);

                if (DialogResult.OK == categoryDialog.ShowDialog())
                {
                    return categoryDialog.SelectedTreeNode;
                }
            }

            return null;
        }

        private void ClearPreviewInMainWindow()
        {
            _currentPreviewUI = PrivateCardTypeEnum.None;
            _mainForm.ClearPreview();
        }

        private string GeneratePasswordAction()
        {
            var control = new PasswordGeneratorUI();
            using (
                var form = new OkCancelUIContainerForm(title: " Generate Password", control: control, formSize: new Size(290, 220))
                {
                    Icon = Password2Go.Properties.Resources.if_dice_64067,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MinimizeBox = false,
                    MaximizeBox = false
                }
                )
            {
                var dlgResult = form.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    return control.PasswordInput;
                }

                return null;
            }
        }
    }
}
