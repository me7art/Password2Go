using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using Password2Go.Data;
using Password2Go.Forms;
using Password2Go.Modules.PrivateCard;
using Common.Helpers;
using Common.Repository.PrivateCards;

using Common.Repository.PrivateCards.Site;
using Common.Repository.PrivateCards.Note;
using Common.Repository.PrivateCards.Device;
using Common.Repository.PrivateCards.DataBase;
using Common.Repository.PrivateCards.CreditCard;

using Password2Go.Services.Mappers.CardDataMapper.Device;
using Password2Go.Services.Mappers.CardDataMapper.Note;
using Password2Go.Services.Mappers.CardDataMapper.Site;
using Password2Go.Services.Mappers.CardDataMapper.DataBase;
using Password2Go.Services.Mappers.CardDataMapper.CreditCard;

using Password2Go.Modules.PrivateCardList;
using Password2Go.Modules.CategoryTree;
using Password2Go.Services.Holders;
using Password2Go.FluxStores;
using Common.Repository;

namespace Password2Go.CommandHandlers.Visitors.PrivateCardListItem
{
    public class OpenActionVisitor : IPrivateCardListViewVisitor
    {
        DIContainer _internalDI;
        PassphraseHolderService _passphraseHolderService;
        KeyHolderService _keyHolderService;
        ICommonXML<Data.Configs.CategoryTreeConfig> _categoryTreeXml;
        TreeViewModel _treeViewModel;

        SiteCardDataMapper _siteCardDataMapper;
        NoteCardDataMapper _noteCardDataMapper;
        DeviceCardDataMapper _deviceCardDataMapper;
        DatabaseCardDataMapper _databaseCardDataMapper;
        CreditCardDataMapper _creditcardDataMapper;

        public OpenActionVisitor(
            DIContainer internalDI,
            PassphraseHolderService passphraseHolderService,
            KeyHolderService keyHolderService,
            ICommonXML<Data.Configs.CategoryTreeConfig> categoryTreeXml,
            TreeViewModel treeViewModel)
        {
            _internalDI = internalDI;
            _passphraseHolderService = passphraseHolderService;
            _keyHolderService = keyHolderService;
            _categoryTreeXml = categoryTreeXml;
            _treeViewModel = treeViewModel;

            _siteCardDataMapper = new SiteCardDataMapper(_keyHolderService);
            _noteCardDataMapper = new NoteCardDataMapper(_keyHolderService);
            _deviceCardDataMapper = new DeviceCardDataMapper(_keyHolderService);
            _databaseCardDataMapper = new DatabaseCardDataMapper(_keyHolderService);
            _creditcardDataMapper = new CreditCardDataMapper(_keyHolderService);
        }

        public void Visit(CreditCardListViewModel creditcardListViewModel)
        {
            OpenPrivateCardTemplate
                <CreditCardUI,
                CreditCardPublicViewModel,
                CreditCardPrivateViewModel,
                CreditCardDataType,
                CreditCardEncryptedData,
                CreditCardSecretData>
                (
                    "Credit Card",
                    Password2Go.Properties.Resources.if_credit_card_49367,
                    creditcardListViewModel, 
                    _creditcardDataMapper.Map,
                    CreditCardDataTypeExtension.MapToPublicItem,
                    CreditCardSecretDataExtension.MapToCreditcardPrivateViewModel
                );
        }

        public void Visit(SiteCardListViewModel siteCardListViewModel)
        {
            OpenPrivateCardTemplate
                <SiteCardUI,
                SiteCardPublicViewModel,
                SiteCardPrivateViewModel,
                SiteCardDataType,
                SiteEncryptedData,
                SiteSecretData>
                (
                    "Site",
                    Password2Go.Properties.Resources.if_chrome_317753,
                    siteCardListViewModel, 
                    _siteCardDataMapper.Map,
                    SiteCardDataTypeExtension.MapToPublicItem,
                    SiteSecretDataExtension.MapToSiteCardPrivateViewModel
                );
        }

        public void Visit(NoteCardListViewModel noteCardListViewModel)
        {
            OpenPrivateCardTemplate
                <NoteCardUI,
                NoteCardPublicViewModel,
                NoteCardPrivateViewModel,
                NoteCardDataType,
                NoteEncryptedData,
                NoteSecretData>
                (
                    "Note",
                    Password2Go.Properties.Resources.if_page_white_text_36305,
                    noteCardListViewModel,
                    _noteCardDataMapper.Map,
                    NoteCardDataTypeExtension.MapToPublicItem,
                    NoteSecretDataExtension.MapToNoteCardPrivateViewModel
                );
        }

        public void Visit(DeviceCardListViewModel deviceCardListViewModel)
        {
            OpenPrivateCardTemplate
                <DeviceCardUI,
                DeviceCardPublicViewModel,
                DeviceCardPrivateViewModel,
                DeviceCardDataType,
                DeviceEncryptedData,
                DeviceSecretData>
                (
                    "Device",
                    Password2Go.Properties.Resources.if_gnome_fs_server_211231,
                    deviceCardListViewModel, 
                    _deviceCardDataMapper.Map,
                    DeviceCardDataTypeExtension.MapToPublicItem,
                    DeviceSecretDataExtension.MapToDeviceCardPrivateViewModel
                );
        }

        public void Visit(DatabaseCardListViewModel cardListViewModel)
        {
            OpenPrivateCardTemplate
                <DatabaseCardUI,
                DatabaseCardPublicViewModel,
                DatabaseCardPrivateViewModel,
                DatabaseCardDataType,
                DatabaseEncryptedData,
                DatabaseSecretData>
                (
                    "Database",
                    Password2Go.Properties.Resources.if_database_35948_icon,
                    cardListViewModel, 
                    _databaseCardDataMapper.Map,
                    DatabaseCardDataTypeExtension.MapToPublicItem,
                    DatabaseSecretDataExtension.MapToDeviceCardPrivateViewModel
                );
        }

        public void OpenPrivateCardTemplate<TCardUI, TPublicModel, TPrivateModel, TCardDataType, TEncryptedData, TSecretData>
            (
                string cardTitle,
                Icon cardIcon,
                PrivateCardListViewModel item,
                Func<TPublicModel, TPrivateModel, DateTime, TCardDataType> mapVMToData,
                Func<TCardDataType, TPublicModel> mapDataToPublicVM,
                Func<TSecretData, TPrivateModel> mapSecretDataToPrivateVM
            )
            where TCardUI : UserControl, ICardUI, IBindableUI<TPublicModel, TPrivateModel>, new()
            where TPublicModel : ICategorized, new()
            where TPrivateModel : new()
            where TCardDataType : IBaseCardData
            where TEncryptedData : BaseEncryptedData
            where TSecretData : SecretBase
        {
            var table         = _internalDI.Resolve<ICardsTable<TCardDataType>>();
            var data          = table.SelectPublic(item.ID).FirstOrDefault();
            var publicVM      = mapDataToPublicVM(data);
            var treeNodeModel = _treeViewModel.Find(data.CategoryID);
            var siteCardUI    = new TCardUI() { Dock = DockStyle.Fill };

            using (var privateCardForm = new PrivateCardInputForm(siteCardUI, cardTitle, cardIcon, isReadOnly: true))
            {
                privateCardForm.Bind(treeNodeModel);

                var privateCardCommandHandler =
                    new PrivateCardCommandHandler<TPublicModel, TPrivateModel, TCardDataType, TEncryptedData, TSecretData>
                    (privateCardForm, siteCardUI, _categoryTreeXml, _keyHolderService, _passphraseHolderService, _internalDI,
                    mapSecretDataToPrivateVM);

                siteCardUI.Bind(publicVM);

                privateCardForm.Init(privateCardCommandHandler.DecryptAction, privateCardCommandHandler.CategoryChangeAction);
                var dialogResult = privateCardForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {

                    var store = _internalDI.Resolve<CommonStore<TCardDataType>>();

                    var newData = mapVMToData.Invoke(siteCardUI.PublicViewModel, siteCardUI.PrivateViewModel, siteCardUI.PublicViewModel.CreatedDate);
                    table.Update(newData);
                    store.Update(this, newData);
                }
            }
        }
    }
}
