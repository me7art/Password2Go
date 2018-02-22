using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Telerik.WinControls.UI;

namespace Password2Go.Modules.CategoryTree
{
    public partial class CategoryTreeUI : UserControl
    {
        Action<TreeNodeViewModel> _nodeDoubleClicked;
        Action<TreeNodeViewModel> _selectedNodeChanged;
        TreeViewModel _treeViewModel;

        public TreeViewModel Model => _treeViewModel;

        public string SelectedNodeID => radTreeView1.SelectedNode?.Tag?.ToString();

        private List<TreeNodeViewModel> _addedTreeNodes = new List<TreeNodeViewModel>();

        public ToggleMode ToggleMode
        {
            get
            {
                return radTreeView1.ToggleMode;
            }
            set
            {
                radTreeView1.ToggleMode = value;
            }
        }

        

        public bool AllowDragDrop
        {
            get { return radTreeView1.AllowDragDrop; }
            set { radTreeView1.AllowDragDrop = value; }
        }

        public CategoryTreeUI()
        {
            InitializeComponent();
        }

        public void Init(Action<TreeNodeViewModel> selectedNodeChanged, Action<TreeNodeViewModel> nodeDoubleClicked)
        {
            _selectedNodeChanged = selectedNodeChanged;
            _nodeDoubleClicked = nodeDoubleClicked;
        }

        public void ApplyChanges()
        {
            _treeViewModel.Nodes.Clear();

            foreach(var radNode in radTreeView1.Nodes)
            {
                _treeViewModel.Nodes.Add(GetViewModelNode(radNode));
            }
        }

        public TreeNodeViewModel GetViewModelNode(RadTreeNode radNode)
        {
            var node = new TreeNodeViewModel(radNode.Tag.ToString(), radNode.Text);
            foreach (var childRadNode in radNode.Nodes)
            {
                node.ChildNodes.Add(GetViewModelNode(childRadNode));
            }
            return node;
        }
        

        public bool SelectNode(string nodeID, RadTreeNodeCollection initNodes = null)
        {
            var node = radTreeView1.FindNodes(x => x.Tag.ToString() == nodeID).FirstOrDefault();
            if (node != null)
                node.Selected = true;

            return true;
            //if (string.IsNullOrWhiteSpace(nodeID)) return false;

            //RadTreeNodeCollection nodes
            //    = initNodes ?? radTreeView1.Nodes;

            //foreach(var node in nodes)
            //{
            //    if (node.Tag.ToString() == nodeID)
            //    {
            //        node.Selected = true;
            //        return true;
            //    }

            //    if (SelectNode(nodeID, node.Nodes))
            //        return true;
            //}

            //return false;
        }

        public void BindTree(TreeViewModel treeViewModel)
        {
            radTreeView1.Nodes.Clear();

            _treeViewModel = treeViewModel;

            foreach (var node in treeViewModel.Nodes)
            {
                AddNode(radTreeView1.Nodes, node);
            }
        }

        public void AddSubNode(string rootNodeID, TreeNodeViewModel nodeViewModel)
        {
            var radTreeNode = radTreeView1.FindNodes(x => x.Tag.ToString() == rootNodeID).FirstOrDefault();
            if (radTreeNode == null)
            {
                throw new ArgumentException("Node not selected");
            }

            radTreeNode.Nodes.Add(Map(nodeViewModel));
            _addedTreeNodes.Add(nodeViewModel);
        }

        public void AddNode(string selectedNodeID, TreeNodeViewModel nodeViewModel)
        {
            var radTreeNode = radTreeView1.FindNodes(x => x.Tag.ToString() == selectedNodeID)?.FirstOrDefault();
            if (radTreeNode != null)
            {
                var nodes = radTreeNode.Parent?.Nodes ?? radTreeView1.Nodes;
                int index = nodes.IndexOf(radTreeNode);
                nodes.Insert(index + 1, Map(nodeViewModel));
            } else
            {
                radTreeView1.Nodes.Add(Map(nodeViewModel));
            }
            _addedTreeNodes.Add(nodeViewModel);
        }

        public void UpdateNode(string nodeID, string nodeText)
        {
            var radNode = radTreeView1.FindNodes(x => x.Tag.ToString() == nodeID).FirstOrDefault();
            if (radNode == null)
                throw new ArgumentException("Node not found");

            var nodeViewModel = _treeViewModel.Find(nodeID);
            if (nodeViewModel == null) nodeViewModel = _addedTreeNodes.FirstOrDefault(x => x.NodeID == nodeID);

            radNode.Text = nodeViewModel.NodeName = nodeText;
        }

        public void DeleteNode(string nodeID)
        {
            var radTreeNode = radTreeView1.FindNodes(x => x.Tag.ToString() == nodeID).FirstOrDefault();
            if (radTreeNode == null)
            {
                throw new ArgumentException("Node not selected");
            }
            var nodes = radTreeNode.Parent?.Nodes ?? radTreeView1.Nodes;
            nodes.Remove(radTreeNode);
        }

        private RadTreeNode Map(TreeNodeViewModel nodeViewModel)
        {
            return new RadTreeNode(nodeViewModel.NodeName) { Tag = nodeViewModel.NodeID /*, Image = Password2Go.Properties.Resources.if_credit_card_49367_16x16 */ };
        }

        private void AddNode(RadTreeNodeCollection nodes, TreeNodeViewModel nodeViewModel)
        {
            var radTreeNode = Map(nodeViewModel);

            if (nodeViewModel.IsVirtual) radTreeNode.ForeColor = Color.Gray;

            nodes.Add(radTreeNode);

            foreach (var node in nodeViewModel.ChildNodes)
            {
                AddNode(radTreeNode.Nodes, node);
            }
        }

        private void radTreeView1_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            if (e.Node?.Tag != null)
            {
                var categoryID = e.Node.Tag as string;
                var a = _treeViewModel.Find(categoryID) ?? _addedTreeNodes.FirstOrDefault(x => x.NodeID == categoryID);
                _selectedNodeChanged?.Invoke(a);
            } else
            {
                _selectedNodeChanged?.Invoke(null);
            }
        }

        private void radTreeView1_NodeMouseDoubleClick(object sender, RadTreeViewEventArgs e)
        {
            var categoryID = e.Node.Tag as string;
            var node = _treeViewModel.Find(categoryID) ?? _addedTreeNodes.FirstOrDefault(x => x.NodeID == categoryID);
            _nodeDoubleClicked?.Invoke(node);
        }
    }

    public class TreeViewModel
    {
        public TreeNodeViewModel Find(string key)
        {
            return Find(key, Nodes);
        }

        TreeNodeViewModel Find(string key, List<TreeNodeViewModel> nodes)
        {
            foreach(var node in nodes)
            {
                if (node.NodeID == key) return node;

                var innerResult = Find(key, node.ChildNodes);

                if (innerResult != null)
                    return innerResult;
            }

            return null;
        }

        public List<TreeNodeViewModel> Nodes = new List<TreeNodeViewModel>();

        public TreeNodeViewModel Add(string id, string name, bool isVirtual = false)
        {
            var item = new TreeNodeViewModel(id, name, isVirtual);
            Nodes.Add(item);

            return item;
        }

        static public TreeViewModel CreateMockTree()
        {
            var tree = new TreeViewModel();
            tree.Add(Password2Go.Data.Configs.CategoryTreeConfig.ID_ALL, "All", isVirtual: true); // virtual category... we don't have it in config file

            var applications = tree.Add("id_applications", "Programs");
            applications.Add("id_games", "Games");

            var network = tree.Add("id_network", "Network");
            var internet = tree.Add("id_internet", "Internet");
            var email = tree.Add("id_email", "eMail");
            var banks = tree.Add("id_banks_and_finance", "Bank and Finance");
            var notes = tree.Add("id_nodes", "Notes");

            return tree;
        }
    }

    public class TreeNodeViewModel
    {
        public string NodeID;
        public string NodeName;
        public bool IsVirtual => _isVirtual;

        private bool _isVirtual;

        public List<TreeNodeViewModel> ChildNodes = new List<TreeNodeViewModel>();

        public IEnumerable<string> GetAllChildNodeKeys()
        {
            yield return NodeID;
            foreach(var node in ChildNodes)
            {
                foreach( var key in  node.GetAllChildNodeKeys())
                {
                    yield return key;
                }
            }
        }

        public TreeNodeViewModel(string nodeID, string nodeName, bool isVirtual = false)
        {
            this.NodeID = nodeID;
            this.NodeName = nodeName;
            _isVirtual = isVirtual;
        }

        public TreeNodeViewModel Add(string id, string name)
        {
            var item = new TreeNodeViewModel(id, name);
            ChildNodes.Add(item);
            return item;
        }
    }
}
