using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Common.Repository.PrivateCards;
using Common.Repository.PrivateCards.Site;
using Common.Repository.PrivateCards.Note;
using Common.Repository.PrivateCards.Device;
using Common.Repository.PrivateCards.DataBase;
using Common.Repository.PrivateCards.CreditCard;
using Password2Go.Services.Mappers.CardDataMapper.Site;
using Password2Go.Services.Mappers.CardDataMapper.Note;
using Password2Go.Services.Mappers.CardDataMapper.Device;
using Password2Go.Services.Mappers.CardDataMapper.DataBase;
using Password2Go.Services.Mappers.CardDataMapper.CreditCard;
using Password2Go.Modules.PrivateCardList;


namespace Password2Go.CommandHandlers.Visitors.CardsTable
{
    public class SelectPublicCardsTableVisitor : ICardsTableVisitor
    {
        bool _deleted;
        BindingList<PrivateCardListViewModel> _result;
        public BindingList<PrivateCardListViewModel> Result => _result;

        public SelectPublicCardsTableVisitor(BindingList<PrivateCardListViewModel> result, bool deleted)
        {
            _deleted = deleted;
            _result = result;
        }

        public void Visit(ICardsTable<SiteCardDataType> siteCardsTable)
        {
            var sitesList = siteCardsTable.SelectPublic(deleted: _deleted).ToList();
            sitesList.ForEach(x => _result.Add(x.MapToListItem()));
        }

        public void Visit(ICardsTable<NoteCardDataType> noteCardsTable)
        {
            var notesList = noteCardsTable.SelectPublic(deleted: _deleted).ToList();
            notesList.ForEach(x => _result.Add(x.MapToListItem()));
        }

        public void Visit(ICardsTable<DeviceCardDataType> deviceCardsTable)
        {
            var devicesList = deviceCardsTable.SelectPublic(deleted: _deleted).ToList();
            devicesList.ForEach(x => _result.Add(x.MapToListItem()));
        }

        public void Visit(ICardsTable<DatabaseCardDataType> databaseCardsTable)
        {
            var list = databaseCardsTable.SelectPublic(deleted: _deleted).ToList();
            list.ForEach(x => _result.Add(x.MapToListItem()));
        }

        public void Visit(ICardsTable<CreditCardDataType> databaseCreditcardsTable)
        {
            var list = databaseCreditcardsTable.SelectPublic(deleted: _deleted).ToList();
            list.ForEach(x => _result.Add(x.MapToListItem()));
        }
    }
}
