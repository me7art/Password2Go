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

using Password2Go.Modules.CategoryTree;

namespace Password2Go.Dialogs
{
    public partial class CategoryDialog : RadForm
    {
        public TreeNodeViewModel SelectedTreeNode { get; private set; }

        public CategoryDialog(string title = null)
        {
            InitializeComponent();

            categoryTreeUI1.Init(CategoryChanged, nodeDoubleClicked: null);

            rbOk.Enabled = false;
            if (!string.IsNullOrWhiteSpace(title)) this.Text = title;
        }

        public void Bind(TreeViewModel treeViewModel)
        {
            categoryTreeUI1.BindTree(treeViewModel);
        }

        public void SelectNode(string nodeID)
        {
            categoryTreeUI1.SelectNode(nodeID);
        }

        public void CategoryChanged(TreeNodeViewModel newTreeNode)
        {
            SelectedTreeNode = newTreeNode;
            rbOk.Enabled = SelectedTreeNode != null;
        }
    }
}
