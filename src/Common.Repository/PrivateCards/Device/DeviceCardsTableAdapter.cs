using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using PetaPoco;

namespace Common.Repository.PrivateCards.Device
{
    [TableName(DeviceCardsTableAdapter.sTableName)]
    [PrimaryKey(DeviceCardsTableAdapter.sID)]
    public class DeviceCardDataType : IBaseCardData
    {
        [Column(DeviceCardsTableAdapter.sID)]            public int ID { get; set; }
        [Column(DeviceCardsTableAdapter.sCategoryID)]    public string CategoryID { get; set; }
        [Column(DeviceCardsTableAdapter.sImageKey)]      public string ImageKey { get; set; }
        [Column(DeviceCardsTableAdapter.sTitle)]         public string Title { get; set; }
        [Column(DeviceCardsTableAdapter.sPublicComment)] public string PublicComment { get; set; }
        [Column(DeviceCardsTableAdapter.sCreatedDate)]   public DateTime CreatedDate { get; set; }
        [Column(DeviceCardsTableAdapter.sModifiedDate)]  public DateTime ModifiedDate { get; set; }
        [Column(DeviceCardsTableAdapter.sAddress)]       public string Address { get; set; }
        [Column(DeviceCardsTableAdapter.sPort)]          public string Port { get; set; }
        [Column(DeviceCardsTableAdapter.sLogin)]         public string Login { get; set; }
        [Column(DeviceCardsTableAdapter.sSiteSecret)]    public string CardSecret { get; set; }
    }

    public class DeviceCardsTableAdapter : ICardsTable<DeviceCardDataType>
    {
        public const string sTableName = "private_device_cards";

        public const string
            sAddress = "address",
            sPort = "port",
            sLogin = "login",
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

        public DeviceCardsTableAdapter(Database database)
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

        public long Insert(DeviceCardDataType item)
        {
            var result = _database.Insert(sTableName, item);

            return (long)result;
        }

        public IEnumerable<DeviceCardDataType> SelectPublicByCategory(string[] categories)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sAddress, sLogin, sPublicComment, sCreatedDate, sModifiedDate, sImageKey).From(sTableName);

            query.Where($"{sCategoryID} in (@categories) AND {sIsMarkAsDeleted} = @deleted", new { categories = categories, deleted = false });
            

            return _database.Query<DeviceCardDataType>(query);
        }

        public IEnumerable<DeviceCardDataType> SelectPublic(int? id = null, bool deleted = false)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sAddress, sPort, sLogin, sPublicComment, sCreatedDate, sModifiedDate, sImageKey)
                .From(sTableName);

            if (id != null)
                query.Where($"{sID} = @id", new { id = id });
            else
                query.Where($"{sIsMarkAsDeleted} = @deleted", new { deleted = deleted });

            return _database.Query<DeviceCardDataType>(query);
        }

        public DeviceCardDataType Select(int id)
        {
            var query = Sql.Builder.Select("*").From(sTableName).Where($"{sID} = @id", new { id = id });

            return _database.Query<DeviceCardDataType>(query).FirstOrDefault();
        }

        public void Update(DeviceCardDataType item)
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
