using System;
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

using Password2Go.Modules;
using Password2Go.Modules.CategoryTree;

namespace Password2Go.Forms
{
    public partial class CategoriesConfigForm : RadForm
    {
        TreeViewModel _treeViewModel;
        TreeNodeViewModel _currentNode;

        public TreeViewModel Model => _treeViewModel;

        public CategoriesConfigForm()
        {
            InitializeComponent();

            categoryTreeUI1.Init(SelectedNodeChanged, NodeDoubleClicked);

            rbAddSubCategory.Enabled = false;
            rbDeleteCategory.Enabled = false;

            categoryTreeUI1.ToggleMode = ToggleMode.None;
        }

        private void NodeDoubleClicked(TreeNodeViewModel node)
        {
            try
            {
                using (var prompt = new Password2Go.Dialogs.EditCategoryDialog("Edit category", "Save") { UserInput = node.NodeName })
                {
                    var dialogResult = prompt.ShowDialog();
                    if (DialogResult.OK == dialogResult)
                    {
                        categoryTreeUI1.UpdateNode(node.NodeID, prompt.UserInput);
                    }
                }
            } catch ( Exception ex )
            {
                ex.Display();
            }
        }

        private void SelectedNodeChanged(TreeNodeViewModel currentNode)
        {
            _currentNode = currentNode;

            rbAddSubCategory.Enabled =  _currentNode != null;
            rbDeleteCategory.Enabled = _currentNode != null; 
        }

        public void Bind(TreeViewModel treeViewModel)
        {
            _treeViewModel = treeViewModel;
            categoryTreeUI1.BindTree(_treeViewModel);
        }

        // Add root category
        private void rbAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                using (var prompt = new Password2Go.Dialogs.EditCategoryDialog("Add new category", "Add"))
                {
                    var dialogResult = prompt.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        if (string.IsNullOrWhiteSpace(prompt.UserInput))
                            throw new Exception("Category name can not be empty");

                        var newNode = new TreeNodeViewModel(Guid.NewGuid().ToString(), prompt.UserInput);
                        categoryTreeUI1.AddNode(categoryTreeUI1.SelectedNodeID, newNode);
                        categoryTreeUI1.SelectNode(newNode.NodeID);
                    }
                }
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbAddSubCategory_Click(object sender, EventArgs e)
        {
            try
            {
                using (var prompt = new Password2Go.Dialogs.EditCategoryDialog("Add new sub-category", "Add"))
                {
                    var dialogResult = prompt.ShowDialog();
                    if (dialogResult == DialogResult.OK)
                    {
                        if (string.IsNullOrWhiteSpace(prompt.UserInput))
                            throw new Exception("Category name can not be empty");

                        var newNode = new TreeNodeViewModel(Guid.NewGuid().ToString(), prompt.UserInput);
                        categoryTreeUI1.AddSubNode(categoryTreeUI1.SelectedNodeID, newNode);
                        categoryTreeUI1.SelectNode(newNode.NodeID);
                    }
                }
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                var dialogResult = RadMessageBox.Show($"Delete category \"{_currentNode.NodeName}\" and all sub-categories?", "Confirmation", MessageBoxButtons.YesNo, RadMessageIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    var currendID = _currentNode.NodeID; //categoryTreeUI1.SelectedNodeID;
                    categoryTreeUI1.DeleteNode(currendID);
                }
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void rbSave_Click(object sender, EventArgs e)
        {
            try
            {
                categoryTreeUI1.ApplyChanges();
            } catch(Exception ex)
            {
                ex.Display();
            }
        }
    }
}
