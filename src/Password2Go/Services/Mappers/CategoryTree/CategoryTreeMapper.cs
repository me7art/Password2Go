using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Modules.CategoryTree;
using Password2Go.Data.Configs;

namespace Password2Go.Services.Mappers.CategoryTree
{
    public static class TreeViewModelExtension
    {
        static CategoryTreeMapper mapper = new CategoryTreeMapper();

        static public CategoryTreeConfig Map(this TreeViewModel treeViewModel) => mapper.Map(treeViewModel);
    }

    public static class CategoryTreeConfigExtension
    {
        static CategoryTreeMapper mapper = new CategoryTreeMapper();
        static public TreeViewModel Map(this CategoryTreeConfig categoryTreeConfig, bool addVirtual = true) => mapper.Map(categoryTreeConfig, addVirtual);
    }

    public class CategoryTreeMapper
    {
        public TreeViewModel Map(CategoryTreeConfig categoryTreeConfig, bool addVirtual = true)
        {
            var tree = new TreeViewModel();

            // Add virual categories
            // @@@ TODO: move virtual categories "config" to another class

            if (addVirtual)
            {
                tree.Add(CategoryTreeConfig.ID_ALL, "All", isVirtual: true);
            }

            foreach(var nodeConfig in categoryTreeConfig.Nodes)
            {
                TreeNodeViewModel node = MapNode(nodeConfig);
                tree.Nodes.Add(node);
            }

            if (addVirtual)
            {
                tree.Add(CategoryTreeConfig.ID_RECYCLEBIN, "Recycle Bin", isVirtual: true);
            }
            return tree;
        }

        private TreeNodeViewModel MapNode(CategoryNode categoryNode)
        {
            var treeNodeView = new TreeNodeViewModel(nodeID: categoryNode.ID, nodeName: categoryNode.Name);
            foreach(var childNode in categoryNode.ChildNodes)
            {
                TreeNodeViewModel node = MapNode(childNode);
                treeNodeView.ChildNodes.Add(node);
            }
            return treeNodeView;
        }

        // MAP VIEW MODEL TO CONFIG
        public CategoryTreeConfig Map(TreeViewModel treeViewModel)
        {
            var tree = new CategoryTreeConfig();
            foreach(var nodeViewModel in treeViewModel.Nodes)
            {
                if (nodeViewModel.IsVirtual)
                    continue; // <--- We don't need virtual categorys in categoryConfig

                CategoryNode node = MapNode(nodeViewModel);
                tree.Nodes.Add(node);
            }

            return tree;
        }

        private CategoryNode MapNode(TreeNodeViewModel nodeViewModel)
        {
            var categoryNode = new CategoryNode()
            {
                ID = nodeViewModel.NodeID,
                Name = nodeViewModel.NodeName
            };

            foreach(var childNode in nodeViewModel.ChildNodes)
            {
                CategoryNode node = MapNode(childNode);
                categoryNode.ChildNodes.Add(node);
            }

            return categoryNode;
        }
    }
}
