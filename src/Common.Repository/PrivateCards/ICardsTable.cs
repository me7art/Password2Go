using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository.PrivateCards
{
    public interface IBaseCardsTable
    {
        void Accept(ICardsTableVisitor visitor);

        void UpdateCategory(int id, string newCategoryID);
        void MarkAsDeleted(int id, bool mark);
        void DeleteMarked();
    }

    public interface ICardsTable<T> : IBaseCardsTable
    {
        long Insert(T item);
        IEnumerable<T> SelectPublic(int? id = null, bool deleted = false);
        IEnumerable<T> SelectPublicByCategory(string[] categories);
        T Select(int id);
        void Update(T item);
    }

    public interface ICardsTableVisitor
    {
        void Visit(ICardsTable<Site.SiteCardDataType> siteCardsTable);
        void Visit(ICardsTable<Note.NoteCardDataType> noteCardsTable);
        void Visit(ICardsTable<Device.DeviceCardDataType> deviceCardsTable);
        void Visit(ICardsTable<DataBase.DatabaseCardDataType> databaseCardsTable);
        void Visit(ICardsTable<CreditCard.CreditCardDataType> creditCardsTable);
    }
}
