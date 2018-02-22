using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PetaPoco;

namespace Common.Repository.PrivateCards.Note
{
    [TableName(NoteCardsTableAdapter.sTableName)]
    [PrimaryKey(NoteCardsTableAdapter.sID)]
    public class NoteCardDataType : IBaseCardData
    {
        [Column(NoteCardsTableAdapter.sID)]           public int ID { get; set; }
        [Column(NoteCardsTableAdapter.sCategoryID)]   public string CategoryID { get; set; }
        [Column(NoteCardsTableAdapter.sImageKey)]     public string ImageKey { get; set; }
        [Column(NoteCardsTableAdapter.sTitle)]        public string Title { get; set; }
        [Column(NoteCardsTableAdapter.sCreatedDate)]  public DateTime CreatedDate { get; set; }
        [Column(NoteCardsTableAdapter.sModifiedDate)] public DateTime ModifiedDate { get; set; }
        [Column(NoteCardsTableAdapter.sNoteSecret)]   public string CardSecret { get; set; }
    }

    public class NoteCardsTableAdapter : ICardsTable<NoteCardDataType>
    {
        public const string sTableName = "private_note_cards";

        public const string
            sID = "id",
            sCategoryID = "categoryid",
            sTitle = "title",
            sCreatedDate = "createddate",
            sModifiedDate = "modifieddate",
            sIsMarkAsDeleted = "is_mark_as_deleted",
            sImageKey = "image_key";

        public const string
            sNoteSecret = "note_secret";

        public void Accept(ICardsTableVisitor visitor) => visitor.Visit(this);

        Database _database;

        public NoteCardsTableAdapter(Database database)
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

        public long Insert(NoteCardDataType item)
        {
            var result = _database.Insert(sTableName, item);

            return (long)result;
        }

        public IEnumerable<NoteCardDataType> SelectPublicByCategory(string[] categories)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sCreatedDate, sModifiedDate, sImageKey, sImageKey).From(sTableName);

            query.Where($"{sCategoryID} in (@categories) AND {sIsMarkAsDeleted} = @deleted", new { categories = categories, deleted = false });

            return _database.Query<NoteCardDataType>(query);
        }

        public IEnumerable<NoteCardDataType> SelectPublic(int? id = null, bool deleted = false)
        {
            var query = Sql.Builder.Select(sID, sCategoryID, sTitle, sCreatedDate, sModifiedDate, sImageKey).From(sTableName);

            if (id != null) query.Where($"{sID} = @id", new { id = id });
            else query.Where($"{sIsMarkAsDeleted} = @deleted", new { deleted = deleted });

            return _database.Query<NoteCardDataType>(query);
        }

        public NoteCardDataType Select(int id)
        {
            var query = Sql.Builder.Select("*").From(sTableName).Where($"{sID} = @id", new { id = id });

            return _database.Query<NoteCardDataType>(query).FirstOrDefault();
        }

        public void Update(NoteCardDataType item)
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
  {sNoteSecret} TEXT,
  {sIsMarkAsDeleted} boolean DEFAULT 0,
  {sCreatedDate} datetime,
  {sModifiedDate} datetime
);
CREATE INDEX {sTableName}_category_index ON {sTableName} ({sCategoryID});
";
    }
}
