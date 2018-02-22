using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using PetaPoco;

namespace Common.Repository.PrivateCards.DataBase
{
    [TableName(DatabaseCardsTableAdapter.sTableName)]
    [PrimaryKey(DatabaseCardsTableAdapter.sID)]
    public class DatabaseCardDataType : IBaseCardData
    {
        [Column(DatabaseCardsTableAdapter.sID)]            public int ID { get; set; }
        [Column(DatabaseCardsTableAdapter.sCategoryID)]    public string CategoryID { get; set; }
        [Column(DatabaseCardsTableAdapter.sImageKey)]      public string ImageKey { get; set; }
        [Column(DatabaseCardsTableAdapter.sTitle)]         public string Title { get; set; }
        [Column(DatabaseCardsTableAdapter.sPublicComment)] public string PublicComment { get; set; }
        [Column(DatabaseCardsTableAdapter.sCreatedDate)]   public DateTime CreatedDate { get; set; }
        [Column(DatabaseCardsTableAdapter.sModifiedDate)]  public DateTime ModifiedDate { get; set; }
        [Column(DatabaseCardsTableAdapter.sAddress)]       public string Address { get; set; }
        [Column(DatabaseCardsTableAdapter.sPort)]          public string Port { get; set; }
        [Column(DatabaseCardsTableAdapter.sLogin)]         public string Login { get; set; }
        [Column(DatabaseCardsTableAdapter.sDatabaseName)]  public string DatabaseName { get; set; }
        [Column(DatabaseCardsTableAdapter.sSiteSecret)]    public string CardSecret { get; set; }
    }

    public class DatabaseCardsTableAdapter : ICardsTable<DatabaseCardDataType>
    {
        public const string sTableName = "private_database_cards";

        public const string
            sAddress = "address",
            sPort = "port",
            sLogin = "login",
            sDatabaseName = "database_name",
            sSiteSecret = "card_secret";

        public const string
            sID = "id",
            sCategoryID = "categoryid",
            sTitle = "title",
            sPublicComment = "public_comment",
            sCreatedDate = "createddate",
            sModifiedDate = "modifieddate",
            sIsMarkAsDeleted = "is_mark_as_deleted",
            sImageKey = "image_key"
            ;

        public void Accept(ICardsTableVisitor visitor) => visitor.Visit(this);

        Database _database;

        public DatabaseCardsTableAdapter(Database database)
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

        public long Insert(DatabaseCardDataType item)
        {
            var result = _database.Insert(sTableName, item);

            return (long)result;
        }

        public IEnumerable<DatabaseCardDataType> SelectPublicByCategory(string[] categories)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sAddress, sLogin, sPublicComment, sCreatedDate, sModifiedDate, sImageKey, sDatabaseName).From(sTableName);

            query.Where($"{sCategoryID} in (@categories) AND {sIsMarkAsDeleted} = @deleted", new { categories = categories, deleted = false });
            

            return _database.Query<DatabaseCardDataType>(query);
        }

        public IEnumerable<DatabaseCardDataType> SelectPublic(int? id = null, bool deleted = false)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sAddress, sPort, sLogin, sPublicComment, sCreatedDate, sModifiedDate, sImageKey, sDatabaseName)
                .From(sTableName);

            if (id != null)
                query.Where($"{sID} = @id", new { id = id });
            else
                query.Where($"{sIsMarkAsDeleted} = @deleted", new { deleted = deleted });

            return _database.Query<DatabaseCardDataType>(query);
        }

        public DatabaseCardDataType Select(int id)
        {
            var query = Sql.Builder.Select("*").From(sTableName).Where($"{sID} = @id", new { id = id });

            return _database.Query<DatabaseCardDataType>(query).FirstOrDefault();
        }

        public void Update(DatabaseCardDataType item)
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
  {sPublicComment} TEXT,
  {sAddress} TEXT,
  {sPort} TEXT,
  {sLogin} TEXT,
  {sDatabaseName} TEXT,
  {sSiteSecret} TEXT,
  {sIsMarkAsDeleted} boolean DEFAULT 0,
  {sCreatedDate} datetime,
  {sModifiedDate} datetime
);
CREATE INDEX {sTableName}_{sAddress}_index ON {sTableName} ({sAddress});
CREATE INDEX {sTableName}_{sCategoryID}_index ON {sTableName} ({sCategoryID});
";
    }
}
