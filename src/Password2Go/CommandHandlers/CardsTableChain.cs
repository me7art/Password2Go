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

using Password2Go.Modules.PrivateCardList;
using Password2Go.CommandHandlers.Visitors.CardsTable;

//using Password2Go.Modules.CategoryTree;

namespace Password2Go.CommandHandlers
{
    public class CardsTableChain
    {
        List<IBaseCardsTable> _baseTables;

        public CardsTableChain(
            ICardsTable<SiteCardDataType> siteCardsTable,
            ICardsTable<NoteCardDataType> noteCardsTable,
            ICardsTable<DeviceCardDataType> deviceCardsTable,
            ICardsTable<DatabaseCardDataType> databaseCardsTable,
            ICardsTable<CreditCardDataType> creditCardsTable)
        {
            _siteCardsTable = siteCardsTable;
            _noteCardsTable = noteCardsTable;
            _deviceCardsTable = deviceCardsTable;
            _databaseCardsTable = databaseCardsTable;
            _creditCardsTable = creditCardsTable;

            _baseTables = new List<IBaseCardsTable>() { _siteCardsTable, _noteCardsTable, _deviceCardsTable, _databaseCardsTable, _creditCardsTable };
        }

        public ICardsTable<SiteCardDataType> SiteCardsTable => _siteCardsTable;
        public ICardsTable<NoteCardDataType> NoteCardsTable => _noteCardsTable;
        public ICardsTable<DeviceCardDataType> DeviceCardsTable => _deviceCardsTable;
        public ICardsTable<DatabaseCardDataType> DatabaseCardsTable => _databaseCardsTable;
        public ICardsTable<CreditCardDataType> CreditCardsTable => _creditCardsTable;

        public void DeleteMarked()
        {
            _baseTables.ForEach(x => x.DeleteMarked());
        }

        //public void SelectPublic(BindingList<PrivateCardListViewModel> result, bool deleted = false)
        public void SelectPublic(List<PrivateCardListViewModel> result, bool deleted = false)
        {
            SelectPublicCardsTableVisitor selectPublicCardsTableVisitor = new SelectPublicCardsTableVisitor(result, deleted);
            _baseTables.ForEach(x => x.Accept(selectPublicCardsTableVisitor));
        }

        //public void SelectPublicByCategory(BindingList<PrivateCardListViewModel> result, string[] categories)
        public void SelectPublicByCategory(List<PrivateCardListViewModel> result, string[] categories)
        {
            SelectPublicByCategoryVisitor selectPublicByCategoryVisitor = new SelectPublicByCategoryVisitor(result, categories);
            _baseTables.ForEach(x => x.Accept(selectPublicByCategoryVisitor));
        }

        ICardsTable<SiteCardDataType> _siteCardsTable;
        ICardsTable<NoteCardDataType> _noteCardsTable;
        ICardsTable<DeviceCardDataType> _deviceCardsTable;
        ICardsTable<DatabaseCardDataType> _databaseCardsTable;
        ICardsTable<CreditCardDataType> _creditCardsTable;
    }
}
