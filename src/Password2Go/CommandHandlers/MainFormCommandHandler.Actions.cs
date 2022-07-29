using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.ComponentModel;

using Password2Go.Modules.PrivateCardList;
using Password2Go.Modules.CategoryTree;
using Password2Go.Modules.Preview;
using Password2Go.Services.Mappers.CategoryTree;
using Password2Go.CommandHandlers.Commands;
using Password2Go.CommandHandlers.Visitors.PrivateCardListItem;
using Password2Go.CommandHandlers.Visitors.PreviewItem;

using Password2Go.Services.Decrypt;
using Common.Repository.PrivateCards;
using Password2Go.Data;

namespace Password2Go.CommandHandlers
{
    public partial class MainFormCommandHandler
    {
        public void CopyBasePasswordPreviewAction(BasePreviewViewModel item, PasswordTypeEnum passwordType)
        {
            CopyPasswordPreviewActionVisitor copyPasswordPreviewActionVisitor =
                new CopyPasswordPreviewActionVisitor(
                    _cardsTableChain,
                    _passphraseHolderService,
                    _keyHolderService,
                    passwordType);
            item.Accept(copyPasswordPreviewActionVisitor);
        }

        public void DecryptBasePreviewAction(BasePreviewViewModel item)
        {
            DecryptPreviewActionVisitor decryptPreviewActionVisitor = new DecryptPreviewActionVisitor(
                _cardsTableChain,
                _previewUIs,
                _passphraseHolderService,
                _keyHolderService);

            item.Accept(decryptPreviewActionVisitor);
        }

        public void CategoriesOptionsAction()
        {
            using (var dialog = new Password2Go.Forms.CategoriesConfigForm())
            {
                var categories = _categoryTreeXml.Read();
                var treeViewModel = categories.Map(addVirtual: false);

                dialog.Bind(treeViewModel);

                var dlgResult = dialog.ShowDialog();
                if (DialogResult.OK == dlgResult)
                {
                    string currentCategory = _currentCategory?.NodeID;
                    var viewModel = dialog.Model;
                    var config = viewModel.Map();
                    _categoryTreeXml.Write(config);
                    var newViewModel = config.Map();
                    _mainForm.BindCategory(newViewModel);

                    _mainForm.SelectCategory(
                        newViewModel.Find(currentCategory)?.NodeID ?? Password2Go.Data.Configs.CategoryTreeConfig.ID_ALL);
                }
            }
        }

        public void RunSSHAction(PrivateCardListViewModel item)
        {
            if (item == null)
            {
                return;
            }

            var data = _cardsTableChain.DeviceCardsTable.Select(item.ID);
            var secretData = DecryptService.DecryptData<DeviceEncryptedData, DeviceSecretData>(data, _keyHolderService, _passphraseHolderService);

            System.Diagnostics.Process.Start("putty.exe", $"-pw {secretData.Password} {data.Login}@{data.Address}");
        }

        public void SelectCardAction(PrivateCardListViewModel item)
        {
            if (item == null)
            {
                //if (!_mainForm.IsItemSelected)
                //{
                //    //_mainForm.BindPreview(null);
                //}
                //_currentPreviewUI = PrivateCardTypeEnum.None;
                //_mainForm.ClearPreview();

                _mainForm.DeleteItemCommand = null;
                _mainForm.RestoreItemCommand = null;
                return;
            }

            _mainForm.DeleteItemCommand = new DeleteItemCommand(this, item);
            _mainForm.RestoreItemCommand = new RestoreItemCommand(this, item);

            if (_currentPreviewUI != item.CardType)
            {
                _mainForm.ChangePreview(_previewUIs[item.CardType].ThisUserControl);
                _currentPreviewUI = item.CardType;
            }

            SelectCardActionVisitor selectCardActionVisitor =
                new SelectCardActionVisitor(
                    _cardsTableChain,
                    _previewUIs
                );

            item.Accept(selectCardActionVisitor);
        }

        public void DeleteItemAction(PrivateCardListViewModel item)
        {
            MarkAsDeleted(item, deleted: true);
            if (_currentCategory.NodeID != Password2Go.Data.Configs.CategoryTreeConfig.ID_RECYCLEBIN)
            {
                ClearPreviewInMainWindow();
                _blist.Remove(item);
            }
        }


        public void RestoreItemAction(PrivateCardListViewModel item)
        {
            MarkAsDeleted(item, deleted: false);
            if (_currentCategory.NodeID == Password2Go.Data.Configs.CategoryTreeConfig.ID_RECYCLEBIN)
            {
                ClearPreviewInMainWindow();
                _blist.Remove(item);
            }
        }

        private void MarkAsDeleted(PrivateCardListViewModel item, bool deleted)
        {
            MarkAsDeletedVisitor markAsDeletedVisitor = new MarkAsDeletedVisitor(deleted, _cardsTableChain);
            item.Accept(markAsDeletedVisitor);
        }

        public void EmpteRecycleBinAction()
        {
            _cardsTableChain.DeleteMarked();

            if (_currentCategory.NodeID == Password2Go.Data.Configs.CategoryTreeConfig.ID_RECYCLEBIN)
            {
                _blist.Clear();
                ClearPreviewInMainWindow();
            }
        }

        public void CategoryChangedAction(TreeNodeViewModel newCategoryID)
        {
            //
            // Clear preview in any case
            //
            ClearPreviewInMainWindow();

            _currentCategory = newCategoryID;

            if (newCategoryID == null)
            {
                return;
            }

            var categories = _currentCategory.GetAllChildNodeKeys().ToArray();
            _blist.Clear();
            _blist = new BindingList<PrivateCardListViewModel>();
            LoadMainView(categories, _blist);
            _mainForm.Bind(_blist);

            //if (_currentCategory.NodeID == Password2Go.Data.Configs.CategoryTreeConfig.ID_RECYCLEBIN)
            //{

            //}
        }

        private void LoadMainView(string[] categoriesID, BindingList<PrivateCardListViewModel> blist)
        {
            if (_currentCategory.NodeID == Password2Go.Data.Configs.CategoryTreeConfig.ID_ALL)
            {
                _cardsTableChain.SelectPublic(blist, deleted: false);
            }
            else if (_currentCategory.NodeID == Password2Go.Data.Configs.CategoryTreeConfig.ID_RECYCLEBIN)
            {
                _cardsTableChain.SelectPublic(blist, deleted: true);
            }
            else
            {
                _cardsTableChain.SelectPublicByCategory(blist, categories: categoriesID);
            }
        }

        public void OpenPrivateCardAction(PrivateCardListViewModel item)
        {
            var openPrivateCardActionVisitor =
                new OpenActionVisitor(
                    _internalDI,
                    _passphraseHolderService,
                    _keyHolderService,
                    _categoryTreeXml,
                    _mainForm.ModelCategory);

            item.Accept(openPrivateCardActionVisitor);
        }
    }
}
