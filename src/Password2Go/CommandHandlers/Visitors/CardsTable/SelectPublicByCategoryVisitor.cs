using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using Common.Repository.PrivateCards;
using Password2Go.Modules.PrivateCardList;

using Common.Repository.PrivateCards.Site;
using Password2Go.Services.Mappers.CardDataMapper.Site;

using Common.Repository.PrivateCards.Note;
using Password2Go.Services.Mappers.CardDataMapper.Note;

using Common.Repository.PrivateCards.Device;
using Password2Go.Services.Mappers.CardDataMapper.Device;

using Common.Repository.PrivateCards.DataBase;
using Password2Go.Services.Mappers.CardDataMapper.DataBase;

using Common.Repository.PrivateCards.CreditCard;
using Password2Go.Services.Mappers.CardDataMapper.CreditCard;


namespace Password2Go.CommandHandlers.Visitors.CardsTable
{
    public class SelectPublicByCategoryVisitor : ICardsTableVisitor
    {
        string[] _categoriesID;
        //BindingList<PrivateCardListViewModel> _result;
        //public BindingList<PrivateCardListViewModel> Result => _result;

        List<PrivateCardListViewModel> _result;
        public List<PrivateCardListViewModel> Result => _result;


        //public SelectPublicByCategoryVisitor(BindingList<PrivateCardListViewModel> result, string[] categoriesID)
        public SelectPublicByCategoryVisitor(List<PrivateCardListViewModel> result, string[] categoriesID)
        {
            _result = result;
            _categoriesID = categoriesID;
        }

        public void Visit(ICardsTable<SiteCardDataType> siteCardsTable)
        {
            var sitesList = siteCardsTable.SelectPublicByCategory(categories: _categoriesID).ToList();
            sitesList.ForEach(x => _result.Add(x.MapToListItem()));
        }

        public void Visit(ICardsTable<NoteCardDataType> noteCardsTable)
        {
            var notesList = noteCardsTable.SelectPublicByCategory(categories: _categoriesID).ToList();
            notesList.ForEach(x => _result.Add(x.MapToListItem()));
        }

        public void Visit(ICardsTable<DeviceCardDataType> deviceCardsTable)
        {
            var devicesList = deviceCardsTable.SelectPublicByCategory(categories: _categoriesID).ToList();
            devicesList.ForEach(x => _result.Add(x.MapToListItem()));
        }

        public void Visit(ICardsTable<DatabaseCardDataType> databaseCardsTable)
        {
            var list = databaseCardsTable.SelectPublicByCategory(categories: _categoriesID).ToList();
            list.ForEach(x => _result.Add(x.MapToListItem()));
        }

        public void Visit(ICardsTable<CreditCardDataType> databaseCreditcardTable)
        {
            var list = databaseCreditcardTable.SelectPublicByCategory(categories: _categoriesID).ToList();
            list.ForEach(x => _result.Add(x.MapToListItem()));
        }
    }
}
