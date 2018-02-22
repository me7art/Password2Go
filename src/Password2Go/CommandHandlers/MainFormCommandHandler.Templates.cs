using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using Password2Go.Data;
using Password2Go.Forms;
using Password2Go.Modules.PrivateCard;

using Common.Repository.PrivateCards;
using Password2Go.Modules.PrivateCardList;
using Password2Go.FluxStores;

namespace Password2Go.CommandHandlers
{
    public partial class MainFormCommandHandler
    {
        public void AddCard
			<TCardUI, TPublicModel, TPrivateModel, TCardDataType>
			(
				string cardTitle,
				Icon cardIcon,
				Func<TPublicModel, TPrivateModel, DateTime, TCardDataType> mapVMToData
			)
			where TCardUI : UserControl, ICardUI, IBindableUI<TPublicModel, TPrivateModel>, new()
			where TPublicModel : ICategorized, new()
			where TPrivateModel : new()
        {
            var siteCardUI = new TCardUI() { Dock = DockStyle.Fill };
            var categoryVM = GetCategoryIdForCard();

            if (categoryVM == null)
                return;

            using (var privateCardForm = new PrivateCardInputForm(siteCardUI, cardTitle, cardIcon))
            {
                TPublicModel siteCardPublicVM = new TPublicModel() { CategoryID = categoryVM.NodeID };
                TPrivateModel siteCardPrivateVM = new TPrivateModel();

                siteCardUI.Bind(siteCardPublicVM);
                siteCardUI.Bind(siteCardPrivateVM);
                privateCardForm.Bind(categoryVM);

                var dlgResult = privateCardForm.ShowDialog();
                if (dlgResult == DialogResult.OK)
                {
                    var table = _internalDI.Resolve<ICardsTable<TCardDataType>>();
                    var store = _internalDI.Resolve<CommonStore<TCardDataType>>();

                    var data = mapVMToData.Invoke(siteCardPublicVM, siteCardPrivateVM, DateTime.Now);
                    table.Insert(data);
                    store.Add(this, new TCardDataType[] { data });
                }
            }
        }


        public void CommonStoreUpdateHandler<TCardDataType, TPreviewViewModel>(
			object sender,
			UpdatedArgs<TCardDataType> a,
			PrivateCardTypeEnum cardType,
			Func<TCardDataType, PrivateCardListViewModel> mapToListItem,
			Func<TCardDataType, TPreviewViewModel> mapToPreview
			)
			where TCardDataType : IBaseCardData
        {
            if (a.UpdatedAction == UpdatedActionEnum.Update)
            {
                foreach (var item in a.Items)
                {
                    var listItem = _blist?.FirstOrDefault(x => x.ID == item.ID && x.CardType == cardType);

                    if (listItem != null)
                    {
                        var newListItem = mapToListItem.Invoke(item); //.MapToListItem();
                        listItem.UpdateView(newListItem);
                        _previewUIs[cardType].Bind(mapToPreview(item)); //.Bind(item.MapToPreview());
                    }
                }
            }
            else if (a.UpdatedAction == UpdatedActionEnum.Add)
            {
                foreach (var item in a.Items)
                {
                    var newListItem = mapToListItem(item); //item.MapToListItem();
                    _blist.Add(newListItem);
                }
            }
        }

    }
}
