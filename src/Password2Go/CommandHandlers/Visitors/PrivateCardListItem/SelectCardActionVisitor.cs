using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Services.Mappers.CardDataMapper.Site;
using Password2Go.Services.Mappers.CardDataMapper.Note;
using Password2Go.Services.Mappers.CardDataMapper.Device;
using Password2Go.Services.Mappers.CardDataMapper.DataBase;
using Password2Go.Services.Mappers.CardDataMapper.CreditCard;

using Password2Go.Modules.PrivateCardList;
using Password2Go.Modules.Preview;


namespace Password2Go.CommandHandlers.Visitors.PrivateCardListItem
{
    public class SelectCardActionVisitor : IPrivateCardListViewVisitor
    {
        CardsTableChain _cardsTableChain;
        Dictionary<PrivateCardTypeEnum, IPreviewUI> _previewUIs;

        public SelectCardActionVisitor(
            CardsTableChain cardsTableChain,
            Dictionary<PrivateCardTypeEnum, IPreviewUI> previewUIs)
        {
            _cardsTableChain = cardsTableChain;
            _previewUIs = previewUIs;
        }

        public void Visit(SiteCardListViewModel siteCardListViewModel)
        {
            var data = _cardsTableChain.SiteCardsTable.SelectPublic(siteCardListViewModel.ID).FirstOrDefault();
            var viewModel = data.MapToPreview();
            _previewUIs[siteCardListViewModel.CardType].Bind(viewModel);
        }

        public void Visit(NoteCardListViewModel noteCardListViewModel)
        {
            var data = _cardsTableChain.NoteCardsTable.SelectPublic(noteCardListViewModel.ID).FirstOrDefault();
            var viewModel = data.MapToPreview();
            _previewUIs[noteCardListViewModel.CardType].Bind(viewModel);
        }

        public void Visit(DeviceCardListViewModel deviceCardListViewModel)
        {
            var data = _cardsTableChain.DeviceCardsTable.SelectPublic(deviceCardListViewModel.ID).FirstOrDefault();
            var viewModel = data.MapToPreview();
            _previewUIs[deviceCardListViewModel.CardType].Bind(viewModel);
        }

        public void Visit(DatabaseCardListViewModel cardListViewModel)
        {
            var data = _cardsTableChain.DatabaseCardsTable.SelectPublic(cardListViewModel.ID).FirstOrDefault();
            var viewModel = data.MapToPreview();
            _previewUIs[cardListViewModel.CardType].Bind(viewModel);
        }

        public void Visit(CreditCardListViewModel creditCardListViewModel)
        {
            var data = _cardsTableChain.CreditCardsTable.SelectPublic(creditCardListViewModel.ID).FirstOrDefault();
            var viewModel = data.MapToPreview();
            _previewUIs[creditCardListViewModel.CardType].Bind(viewModel);
        }
    }
}
