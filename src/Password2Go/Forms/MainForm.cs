﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls;
using Telerik.WinControls.UI;

using Common.Interfaces;

using Password2Go.Modules;
using Password2Go.Modules.CategoryTree;
using Password2Go.Modules.PrivateCardList;

namespace Password2Go.Forms
{
    public partial class MainForm : RadForm
    {
        Action _addSiteAction;
        Action _addNoteAction;
        Action _addDeviceAction;
        Action _addDatabaseAction;
        Action _addCreditcardAction;
        Action _emptyRecycleBinAction;
        Action _categorisOptionsAction;
        ICommand _deleteItemCommand;

        public ICommand DeleteItemCommand
        {
            get { return _deleteItemCommand; }
            set
            {
                _deleteItemCommand = value;
                rmiDeleteEntry.Enabled = _deleteItemCommand?.CanExecute() ?? false;
            }
        }

        ICommand _restoreItemCommand;
        public ICommand RestoreItemCommand
        {
            get { return _restoreItemCommand; }
            set
            {
                _restoreItemCommand = value;
                rmiRestore.Enabled = _restoreItemCommand?.CanExecute() ?? false;
            }
        }

        ICommand _selectKeysCommand;
        public ICommand SelectKeysCommand
        {
            get { return _selectKeysCommand; }
            set
            {
                _selectKeysCommand = value;
                rmiKeysOptions.Enabled = _selectKeysCommand?.CanExecute() ?? false;
            }
        }

        ICommand _selectDatabaseCommand;
        public ICommand SelectDatabaseCommand
        {
            get { return _selectDatabaseCommand; }
            set { _selectDatabaseCommand = value; }
        }

        public MainForm()
        {
            InitializeComponent();

            var mockModel = TreeViewModel.CreateMockTree();

            DeleteItemCommand  = null;
            RestoreItemCommand = null;
            SelectKeysCommand  = null;

            rmiAddDatabase.Click   += RmiAddDatabase_Click;
            rmiAddCreditCard.Click += RmiAddCreditCard_Click;
        }


        public ContextMenuStrip NotifyContextMenu => contextMenuStrip1;

        private void RmiAddCreditCard_Click(object sender, EventArgs e)
        {
            try
            {
                _addCreditcardAction.Invoke();
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void RmiAddDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                _addDatabaseAction.Invoke();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        public bool IsItemSelected => privateCardListUI1.CurrentItem != null;
        public TreeViewModel ModelCategory => categoryTreeUI1.Model;

        public void BindCategory(TreeViewModel treeViewModel)
        {
            categoryTreeUI1.BindTree(treeViewModel);
        }

        public void ClearPreview()
        {
            panelPreview.Controls.Clear();
        }

        public void ChangePreview(UserControl previewUI)
        {
            ClearPreview();
            panelPreview.Controls.Add(previewUI);
        }

        public void SelectCategory(string categoryID)
        {
            categoryTreeUI1.SelectNode(categoryID);
        }

        public void Init (
            Action addSiteAction, 
            Action addNoteAction,
            Action addDeviceAction,
            Action addDatabaseAction,
            Action addCreditcardAction,
            Action<TreeNodeViewModel> categoryChangeAction, 
            Action<PrivateCardListViewModel> openAction,    
            Action<PrivateCardListViewModel> selectAction,
            Action emptyRecycleBinAction,
            Action categorisOptionsAction
            )
        {
            _addSiteAction       = addSiteAction;
            _addNoteAction       = addNoteAction;
            _addDeviceAction     = addDeviceAction;
            _addDatabaseAction   = addDatabaseAction;
            _addCreditcardAction = addCreditcardAction;

            categoryTreeUI1.Init(categoryChangeAction, nodeDoubleClicked: null);
            privateCardListUI1.Init(openAction, selectAction);

            _emptyRecycleBinAction = emptyRecycleBinAction;
            _categorisOptionsAction = categorisOptionsAction;
        }

        public void Bind(BindingList<PrivateCardListViewModel> bindingList)
        {
            privateCardListUI1.Bind(bindingList);
        }

        private void listUI1_Load(object sender, EventArgs e)
        {

        }

        private void cbbAddSite_Click(object sender, EventArgs e)
        {
            try
            {
                _addSiteAction?.Invoke();
            }
            catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void cbbAddNote_Click(object sender, EventArgs e)
        {
            try
            {
                _addNoteAction?.Invoke();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rmiDeleteEntry_Click(object sender, EventArgs e)
        {
            try
            {
                var currentItem = privateCardListUI1.CurrentItem;

                if (currentItem != null)
                {
                    var dialogResult = RadMessageBox.Show($"Confirm the deletion of the item?\n\n\"{currentItem.Title}\"", "Delete confirmation", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        _deleteItemCommand.Execute();
                    }
                } else
                {
                    RadMessageBox.Show("Please, select item to delete...");
                }
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rmiEmptyRecycleBin_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = RadMessageBox.Show($"Empty Recycle bin?", "Empty recycle bin confirmation", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    _emptyRecycleBinAction?.Invoke();
                }
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rmiRestore_Click(object sender, EventArgs e)
        {
            try
            {
                _restoreItemCommand?.Execute();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rmiExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rmiAbout_Click(object sender, EventArgs e)
        {
            using (var aboutDialog = new Dialogs.AboutDialog())
            {
                aboutDialog.ShowDialog();
            }
        }

        private void rmiKeysOptions_Click(object sender, EventArgs e)
        {
            try
            {
                _selectKeysCommand.Execute();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rmiCategoriesOptions_Click(object sender, EventArgs e)
        {
            try
            {
                _categorisOptionsAction.Invoke();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rmiDatabaseOptions_Click(object sender, EventArgs e)
        {
            try
            {
                _selectDatabaseCommand?.Execute();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void cbbAddDevice_Click(object sender, EventArgs e)
        {
            try
            {
                _addDeviceAction?.Invoke();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void cbddbMore_Click(object sender, EventArgs e)
        {

        }
    }




}
