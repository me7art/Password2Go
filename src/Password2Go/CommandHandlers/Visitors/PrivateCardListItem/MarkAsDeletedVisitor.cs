using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Password2Go.Modules.PrivateCardList;

namespace Password2Go.CommandHandlers.Visitors.PrivateCardListItem
{
    public class MarkAsDeletedVisitor : IPrivateCardListViewVisitor
    {
        CardsTableChain _cardsTableChain;

        bool _deleted;

        public MarkAsDeletedVisitor(
            bool deleted,
            CardsTableChain cardsTableChain
            )
        {
            _deleted = deleted;
            _cardsTableChain = cardsTableChain;
        }

        public void Visit(SiteCardListViewModel siteCardListViewModel)
        {
            _cardsTableChain.SiteCardsTable.MarkAsDeleted(siteCardListViewModel.ID, _deleted);
        }

        public void Visit(NoteCardListViewModel noteCardListViewModel)
        {
            _cardsTableChain.NoteCardsTable.MarkAsDeleted(noteCardListViewModel.ID, _deleted);
        }

        public void Visit(DeviceCardListViewModel deviceCardListViewModel)
        {
            _cardsTableChain.DeviceCardsTable.MarkAsDeleted(deviceCardListViewModel.ID, _deleted);
        }

        public void Visit(DatabaseCardListViewModel cardListViewModel)
        {
            _cardsTableChain.DatabaseCardsTable.MarkAsDeleted(cardListViewModel.ID, _deleted);
        }

        public void Visit(CreditCardListViewModel creditCardListViewModel)
        {
            _cardsTableChain.CreditCardsTable.MarkAsDeleted(creditCardListViewModel.ID, _deleted);
        }
    }
}
