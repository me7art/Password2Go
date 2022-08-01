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

using Telerik.WinControls.Layouts;
using Telerik.WinControls.Data;

namespace Password2Go.Modules.PrivateCardList
{
    public partial class PrivateCardListUI : UserControl
    {
        BindingList<PrivateCardListViewModel> _bindingList;

        Action<PrivateCardListViewModel> _openAction;
        Action<PrivateCardListViewModel> _selectAction;
        Action<PrivateCardListViewModel> _runPuttyAction;

        Dictionary<string, string> _categoriesLookup;

        public PrivateCardListViewModel CurrentItem => radListView1.CurrentItem?.DataBoundItem as PrivateCardListViewModel;

        public PrivateCardListUI()
        {
            InitializeComponent();

            radListView1.VisualItemCreating += RadListView1_VisualItemCreating;
        }

        public void SetFilter(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                radListView1.FilterDescriptors.Clear();
                radListView1.EnableFiltering = false;

                radListView1.Groups.Clear();
                UpdateGroups();

                return;
            }

            radListView1.EnableFiltering = true;
            var typeFilter = new FilterDescriptor("CardName", FilterOperator.Contains, text);
            radListView1.FilterDescriptors.Clear();
            radListView1.FilterDescriptors.Add(typeFilter);
            //radListView1.ListViewElement.DataView.Refresh();

            radListView1.Groups.Clear();
            UpdateGroups();
        }

        private void RadListView1_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            if (e.DataItem is Telerik.WinControls.UI.ListViewDataItemGroup)
            {
                return;
            }

            e.VisualItem = new PrivateCardListVisualItem(_runPuttyAction);
        }

        public void Bind(BindingList<PrivateCardListViewModel> bindingList, Dictionary<string, string> categoriesLookup)
        {
            _categoriesLookup = categoriesLookup;

            _bindingList = bindingList;
            radListView1.DataSource = bindingList;
            radListView1.DisplayMember = nameof(PrivateCardListViewModel.CardName); // "Name";
            radListView1.ValueMember = nameof(PrivateCardListViewModel.ID);         // "ID";

            // Grouping
            radListView1.EnableCustomGrouping = true;
            radListView1.ShowGroups = true;
            radListView1.Groups.Clear();

            UpdateGroups();
            // //
        }

        private void UpdateGroups()
        {
            Dictionary<string, ListViewDataItemGroup> groups = new Dictionary<string, ListViewDataItemGroup>();
            foreach (var item in radListView1.Items)
            {
                var o = item.DataBoundItem as PrivateCardListViewModel;
                if (o == null)
                {
                    continue;
                }

                if (groups.ContainsKey(o.CategoryID) == false)
                {
                    var groupName = _categoriesLookup.TryGetValue(o.CategoryID, out string categoryName) ? categoryName : o.CategoryID;
                    groups.Add(o.CategoryID, new ListViewDataItemGroup(groupName));
                }

                item.Group = groups[o.CategoryID];
            }

            foreach (var group in groups)
            {
                radListView1.Groups.Add(group.Value);
            }
        }

        public void Init(
            Action<PrivateCardListViewModel> openAction, 
            Action<PrivateCardListViewModel> selectAction,
            Action<PrivateCardListViewModel> runPuttyAction)
        {
            _openAction = openAction;
            _selectAction = selectAction;
            _runPuttyAction = runPuttyAction;
        }

        private void radListView1_ItemDataBound(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            //if (radListView1.ViewType == Telerik.WinControls.UI.ListViewType.ListView)
            //{
            //    e.Item.Image = ((PrivateCardListViewModel)e.Item.DataBoundItem).CardImage;
            //    e.Item.ImageAlignment = ContentAlignment.TopLeft;
            //    e.Item.TextAlignment = ContentAlignment.TopLeft;
            //    //e.Item.TextAlignment = ContentAlignment.MiddleCenter;

            //}
        }

        private void radListView1_ItemMouseDoubleClick(object sender, Telerik.WinControls.UI.ListViewItemEventArgs e)
        {
            try
            {
                if (e.Item?.DataBoundItem is PrivateCardListViewModel item)
                {
                    _openAction?.Invoke(item);
                }
            } catch (Exception ex)
            {
                ex.Display();
            }
        }

        private void radListView1_SelectedItemChanged(object sender, EventArgs e)
        {
            try
            {
                var item = (e as ListViewItemEventArgs)?.Item?.DataBoundItem as PrivateCardListViewModel;
                _selectAction?.Invoke(item); // invoke event null
            } catch (Exception ex)
            {
                ex.Display();
            }
        }
    }




}
