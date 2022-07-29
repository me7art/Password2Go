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

namespace Password2Go.Modules.PrivateCardList
{
    public partial class PrivateCardListUI : UserControl
    {
        BindingList<PrivateCardListViewModel> _bindingList;

        Action<PrivateCardListViewModel> _openAction;
        Action<PrivateCardListViewModel> _selectAction;
        Action<PrivateCardListViewModel> _runPuttyAction;

        public PrivateCardListViewModel CurrentItem => radListView1.CurrentItem?.DataBoundItem as PrivateCardListViewModel;

        public PrivateCardListUI()
        {
            InitializeComponent();

            radListView1.VisualItemCreating += RadListView1_VisualItemCreating;
        }

        private void RadListView1_VisualItemCreating(object sender, ListViewVisualItemCreatingEventArgs e)
        {
            //throw new NotImplementedException();
            e.VisualItem = new PrivateCardListVisualItem(_runPuttyAction);
        }

        public void Bind(BindingList<PrivateCardListViewModel> bindingList)
        {
            _bindingList = bindingList;
            radListView1.DataSource = bindingList;
            radListView1.DisplayMember = nameof(PrivateCardListViewModel.CardName); // "Name";
            radListView1.ValueMember = nameof(PrivateCardListViewModel.ID);         // "ID";
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
