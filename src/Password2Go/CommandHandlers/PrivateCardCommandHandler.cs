using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;

using Password2Go.Data.Configs;
using Common.Helpers;
using Common.Repository.PrivateCards;
using Common.Repository.PrivateCards.Site;
using Common.Repository.PrivateCards.Note;
using Password2Go.Data;
using Password2Go.Forms;
using Password2Go.Services.Holders;
using Password2Go.Modules.PrivateCard;
using Password2Go.Services.Mappers.CategoryTree;
using Password2Go.Services.Decrypt;
using Common.Repository;

using Password2Go.FluxStores;

namespace Password2Go.CommandHandlers
{
    public class PrivateCardCommandHandler<TPublicModel, TPrivateModel, TCardDataType, TEncryptedData, TSecretData>
        where TPublicModel : ICategorized, new()
        where TPrivateModel : new()
        where TCardDataType : IBaseCardData
        where TEncryptedData : BaseEncryptedData
        where TSecretData : SecretBase
    {
        KeyHolderService _keyHolderService;
        PassphraseHolderService _passphraseHolderService;

        IBindableUI<TPublicModel, TPrivateModel> _ui;
        PrivateCardInputForm _form;
        ICardsTable<TCardDataType> _siteCardsTable;

        ICommonXML<Data.Configs.CategoryTreeConfig> _categoryTreeXml;
        CommonStore<ICategorized> _categorizedStore;

        Func<TSecretData, TPrivateModel> _mapper;

        public PrivateCardCommandHandler(PrivateCardInputForm form,
            IBindableUI<TPublicModel, TPrivateModel> ui,
            ICommonXML<Data.Configs.CategoryTreeConfig> categoryTreeXml,
            KeyHolderService keyHolderService, 
            PassphraseHolderService passphraseHolderService, 
            DIContainer di,
            Func<TSecretData, TPrivateModel> mapSecretToPrivateModel
            )
        {
            _form = form;
            _ui = ui;
            _passphraseHolderService = passphraseHolderService;
            _keyHolderService = keyHolderService;
            _categoryTreeXml = categoryTreeXml; 
            _siteCardsTable = di.Resolve<ICardsTable<TCardDataType>>();
            _categorizedStore = di.Resolve<CommonStore<ICategorized>>();
            _mapper = mapSecretToPrivateModel;
        }

        public void CategoryChangeAction()
        {
            var publicVM = _ui.PublicViewModel;
            using (var categoryDialog = new Dialogs.CategoryDialog())
            {
                var categories = _categoryTreeXml.Read();

                var treeViewModel = categories.Map(addVirtual: false);
                categoryDialog.Bind(treeViewModel);

                categoryDialog.SelectNode(publicVM.CategoryID);

                var dialogResult = categoryDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    _siteCardsTable.UpdateCategory(publicVM.ID, categoryDialog.SelectedTreeNode.NodeID);
                    //
                    // Update node in model to new value selected by user
                    //
                    publicVM.CategoryID = categoryDialog.SelectedTreeNode.NodeID;
                    _form.Bind(categoryDialog.SelectedTreeNode);
                    _categorizedStore.Update(this, publicVM);
                }
            }
        }

        public bool DecryptAction()
        {
            var publicVM = _ui.PublicViewModel;
            var data = _siteCardsTable.Select(publicVM.ID);

            var siteData = DecryptService.DecryptData<TEncryptedData, TSecretData>(data, _keyHolderService, _passphraseHolderService);
            if (siteData != null)
            {
                var secretVM = _mapper(siteData);
                _ui.Bind(secretVM);
                return true;
            }
            return false;
        }
    }


}

