using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

using PetaPoco;

namespace Common.Repository.PrivateCards.Site
{
    [TableName(SiteCardsTableAdapter.sTableName)]
    [PrimaryKey(SiteCardsTableAdapter.sID)]
    public class SiteCardDataType : IBaseCardData
    {
        [Column(SiteCardsTableAdapter.sID)]            public int ID { get; set; }
        [Column(SiteCardsTableAdapter.sCategoryID)]    public string CategoryID { get; set; }
        [Column(SiteCardsTableAdapter.sImageKey)]      public string ImageKey { get; set; }
        [Column(SiteCardsTableAdapter.sTitle)]         public string Title { get; set; }
        [Column(SiteCardsTableAdapter.sPublicComment)] public string PublicComment { get; set; }
        [Column(SiteCardsTableAdapter.sCreatedDate)]   public DateTime CreatedDate { get; set; }
        [Column(SiteCardsTableAdapter.sModifiedDate)]  public DateTime ModifiedDate { get; set; }
        [Column(SiteCardsTableAdapter.sSite)]          public string Site { get; set; }
        [Column(SiteCardsTableAdapter.sLogin)]         public string Login { get; set; }
        [Column(SiteCardsTableAdapter.sSiteSecret)]    public string CardSecret { get; set; }
    }

    public class SiteCardsTableAdapter :  ICardsTable<SiteCardDataType>
    {
        public const string sTableName = "private_site_cards";

        public const string
            sSite = "site",
            sLogin = "login",
            sSiteSecret = "site_secret";

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

        public SiteCardsTableAdapter(Database database)
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

        public long Insert(SiteCardDataType item)
        {
            var result = _database.Insert(sTableName, item);

            return (long)result;
        }

        public IEnumerable<SiteCardDataType> SelectPublicByCategory(string[] categories)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sSite, sLogin, sPublicComment, sCreatedDate, sModifiedDate, sImageKey).From(sTableName);

            query.Where($"{sCategoryID} in (@categories) AND {sIsMarkAsDeleted} = @deleted", new { categories = categories, deleted = false });
            

            return _database.Query<SiteCardDataType>(query);
        }

        public IEnumerable<SiteCardDataType> SelectPublic(int? id = null, bool deleted = false)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sSite, sLogin, sPublicComment, sCreatedDate, sModifiedDate, sImageKey)
                .From(sTableName);

            if (id != null)
                query.Where($"{sID} = @id", new { id = id });
            else
                query.Where($"{sIsMarkAsDeleted} = @deleted", new { deleted = deleted });

            return _database.Query<SiteCardDataType>(query);
        }

        public SiteCardDataType Select(int id)
        {
            var query = Sql.Builder.Select("*").From(sTableName).Where($"{sID} = @id", new { id = id });

            return _database.Query<SiteCardDataType>(query).FirstOrDefault();
        }

        public void Update(SiteCardDataType item)
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
  {sSite} TEXT,
  {sLogin} TEXT,
  {sSiteSecret} TEXT,
  {sIsMarkAsDeleted} boolean DEFAULT 0,
  {sCreatedDate} datetime,
  {sModifiedDate} datetime
);
CREATE INDEX {sTableName}_site_index ON {sTableName} ({sSite});
CREATE INDEX {sTableName}_category_index ON {sTableName} ({sCategoryID});
";
    }
}
