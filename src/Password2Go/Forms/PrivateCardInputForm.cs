using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls.UI;

using Password2Go.Modules;
using Password2Go.Modules.PrivateCard;
using Password2Go.Modules.CategoryTree;

namespace Password2Go.Forms
{
    public partial class PrivateCardInputForm : RadForm
    {
        Func<bool> _decryptAction;
        Action _categoryChangeAction;
        TreeNodeViewModel _categoryModel;
        ICardUI _cardUI;

        public TreeNodeViewModel CategoryModel;
        public bool IsDecrypted => _cardUI.IsDecrypted;

        public PrivateCardInputForm(ICardUI cardUI, string title, Icon cardIcon, bool isReadOnly = false)
        {
            InitializeComponent();

            if (cardIcon != null)
                this.Icon = cardIcon;

            AddControl(cardUI);

            this.Text = title;
            _cardUI.IsReadOnly = isReadOnly;

            if (_cardUI.IsReadOnly)
            {
                rbAdd.Enabled = false;
                rbCancel.Text = "Close";
            } else
            {
                rbEdit.Enabled = false;
                rbDecrypt.Enabled = false;
                radLabel_category.Enabled = false;
            }
        }

        public void Init(
            Func<bool> decryptAction, 
            Action categoryChangeAction)
        {
            _decryptAction = decryptAction;
            _categoryChangeAction = categoryChangeAction;
        }

        private void AddControl(ICardUI cardUI) 
        {
            _cardUI = cardUI;
            panelCard.Controls.Add(cardUI.ThisUserControl);
        }

        public void Bind(TreeNodeViewModel treeNode)
        {
            _categoryModel = treeNode;
            UpdateView(treeNode);
        }

        private void UpdateView(TreeNodeViewModel treeNode)
        {
            radLabel_category.Text = treeNode?.NodeName ?? "***";
        }

        private bool Decrypt()
        {
            var success = _decryptAction?.Invoke() ?? false;
            if (success) rbDecrypt.Enabled = false;

            return success;
        }

        private void rbDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                Decrypt();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsDecrypted)
                {
                    var isSuccessful = Decrypt(); // change IsDecrypted after success firing
                }

                if (IsDecrypted)
                {
                    _cardUI.IsReadOnly = false;
                    rbEdit.Enabled = false;
                    rbAdd.Enabled = true;
                }

            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbAdd_Click(object sender, EventArgs e)
        {

        }

        private void radLabel_category_Click(object sender, EventArgs e)
        {
            try
            {
                _categoryChangeAction?.Invoke();
            } catch (Exception ex)
            {
                ex.Display();
            }
        }
    }


}
