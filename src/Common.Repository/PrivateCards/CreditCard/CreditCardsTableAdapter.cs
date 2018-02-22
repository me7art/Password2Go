using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using PetaPoco;

namespace Common.Repository.PrivateCards.CreditCard
{
    [PrimaryKey(CreditCardsTableAdapter.sID)]
    [TableName(CreditCardsTableAdapter.sTableName)]
    public class CreditCardDataType : IBaseCardData
    {
        [Column(CreditCardsTableAdapter.sID)]            public int ID { get; set; }
        [Column(CreditCardsTableAdapter.sCategoryID)]    public string CategoryID { get; set; }
        [Column(CreditCardsTableAdapter.sImageKey)]      public string ImageKey { get; set; }
        [Column(CreditCardsTableAdapter.sCreatedDate)]   public DateTime CreatedDate { get; set; }
        [Column(CreditCardsTableAdapter.sModifiedDate)]  public DateTime ModifiedDate { get; set; }

        [Column(CreditCardsTableAdapter.sTitle)]         public string Title { get; set; }
        [Column(CreditCardsTableAdapter.sBank)]          public string Bank { get; set; }
        [Column(CreditCardsTableAdapter.sLast4Digits)]   public string Last4Digit { get; set; }
        [Column(CreditCardsTableAdapter.sPublicComment)] public string PublicComment { get; set; }
        [Column(CreditCardsTableAdapter.sCardSecret)]    public string CardSecret { get; set; }
    }

    public class CreditCardsTableAdapter : ICardsTable<CreditCardDataType>
    {
        public const string sTableName = "creditcard_database_cards";

        public const string
            sTitle = "title",
            sBank = "bank",
            sLast4Digits = "last4digits",
            sPublicComment = "public_comment",
            sCardSecret = "card_secret";

        public const string
            sID = "id",
            sCategoryID = "categoryid",
            sCreatedDate = "createddate",
            sModifiedDate = "modifieddate",
            sIsMarkAsDeleted = "is_mark_as_deleted", // don't presented in dataType
            sImageKey = "image_key"
            ;

        public void Accept(ICardsTableVisitor visitor) => visitor.Visit(this);

        Database _database;

        public CreditCardsTableAdapter(Database database)
        {
            _database = database;
        }

        public void DeleteMarked()
        {
            var query = new Sql().Append($"DELETE FROM {sTableName} WHERE {sIsMarkAsDeleted} = @0", true);
            _database.Execute(query);
        }

        public void MarkAsDeleted(int id, bool mark)
        {
            var query = new Sql().Append($"UPDATE {sTableName} SET {sIsMarkAsDeleted} = @0 WHERE {sID} = @1", mark, id);
            _database.Execute(query);
        }

        public long Insert(CreditCardDataType item)
        {
            var result = _database.Insert(sTableName, item);

            return (long)result;
        }

        public IEnumerable<CreditCardDataType> SelectPublicByCategory(string[] categories)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sBank, sLast4Digits, sPublicComment, sCreatedDate, sModifiedDate, sImageKey).From(sTableName);

            query.Where($"{sCategoryID} in (@categories) AND {sIsMarkAsDeleted} = @deleted", new { categories = categories, deleted = false });
            

            return _database.Query<CreditCardDataType>(query);
        }

        public IEnumerable<CreditCardDataType> SelectPublic(int? id = null, bool deleted = false)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sBank, sLast4Digits, sPublicComment, sCreatedDate, sModifiedDate, sImageKey)
                .From(sTableName);

            if (id != null)
                query.Where($"{sID} = @id", new { id = id });
            else
                query.Where($"{sIsMarkAsDeleted} = @deleted", new { deleted = deleted });

            return _database.Query<CreditCardDataType>(query);
        }

        public CreditCardDataType Select(int id)
        {
            var query = Sql.Builder.Select("*").From(sTableName).Where($"{sID} = @id", new { id = id });

            return _database.Query<CreditCardDataType>(query).FirstOrDefault();
        }

        public void Update(CreditCardDataType item)
        {
            _database.Update(sTableName, sID, item);
        }

        public void UpdateCategory(int id, string newCategoryID)
        {
            var query = new Sql().Append($"UPDATE {sTableName} SET {sCategoryID} = @0 WHERE {sID} = @1", newCategoryID, id);
            _database.Execute(query);
        }

        public static readonly string CreateSQLScript =
$@"CREATE TABLE {sTableName} (
  {sID} INTEGER PRIMARY KEY AUTOINCREMENT,
  {sCategoryID} TEXT,
  {sImageKey} TEXT,
  {sTitle} TEXT,
  {sBank} TEXT,
  {sLast4Digits} TEXT,
  {sPublicComment} TEXT,
  {sCardSecret} TEXT,
  {sIsMarkAsDeleted} boolean DEFAULT 0,
  {sCreatedDate} datetime,
  {sModifiedDate} datetime
);
CREATE INDEX {sTableName}_{sTitle}_index ON {sTableName} ({sTitle});
CREATE INDEX {sTableName}_{sCategoryID}_index ON {sTableName} ({sCategoryID});
";
    }
}
