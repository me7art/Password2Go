using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PetaPoco;

namespace Common.Repository.Runtime
{
    [TableName(RuntimeTableSQLite.sTableName)]
    [PrimaryKey(RuntimeTableSQLite.sID, AutoIncrement = false)]
    public class RuntimeType
    {
        [Column(RuntimeTableSQLite.sID)]               public string ID { get; set; } = "A";
        [Column(RuntimeTableSQLite.sDBVersion)]        public int DBVersion { get; set; } = 0;
    }

    public interface IRuntimeTable
    {
        RuntimeType FirstOrDefault();
        void Insert(RuntimeType item);
        void Update(RuntimeType item);
    }


    public class RuntimeTableSQLite : IRuntimeTable
    {
        public const string sTableName = "runtime";

        public const string sID = "id",
            sDBVersion = "db_version";

        Database db;

        public RuntimeTableSQLite(Database db)
        {
            this.db = db;
        }

        public RuntimeType FirstOrDefault()
        {
            return db.Query<RuntimeType>(sql: PetaPoco.Sql.Builder.Select("*").From(sTableName)).FirstOrDefault();
        }

        public void Insert(RuntimeType item)
        {
            db.Insert(item);
        }

        public void Update(RuntimeType item)
        {
            db.Update(item);
        }

        public const string CreateSQLScript =
@"CREATE TABLE runtime (
  id TEXT,
  db_version INTEGER
);";


    }
}
