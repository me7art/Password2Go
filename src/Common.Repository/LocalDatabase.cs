using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PetaPoco;
using System.IO;
using System.Data.SQLite;

using Common.Repository.Runtime;
using Common.Interfaces;

namespace Common.Repository
{
    public static class LocalDatabase
    {
        const int INITIAL_DB_VERSION = 1;

        private static string GetConnectionString(string databaseFile)
        {
            return $"Data Source=\"{databaseFile}\";New=True;Version=3";
        }

        public static IRuntimeTable InitRuntime(Database db, out RuntimeType runtime)
        {
            var runtimeTable = new RuntimeTableSQLite(db);
            runtime = runtimeTable.FirstOrDefault();
            if (runtime == null)
            {
                runtime = new RuntimeType() { ID = Guid.NewGuid().ToString() };
                runtime.DBVersion = INITIAL_DB_VERSION;
                runtimeTable.Insert(runtime);
            }

            return runtimeTable;
        }



        public static Database InitDatabase(string databaseFile, IHelperLogger logger)
        {
            Database db;

            if (!File.Exists(databaseFile))
            {
                SQLiteConnection.CreateFile(databaseFile);
                db = new Database(GetConnectionString(databaseFile), providerName: "System.Data.SQLite");
                try
                {
                    db.BeginTransaction();
                    db.Execute(RuntimeTableSQLite.CreateSQLScript);
                    db.Execute(PrivateCards.Site.SiteCardsTableAdapter.CreateSQLScript);
                    db.Execute(PrivateCards.Note.NoteCardsTableAdapter.CreateSQLScript);
                    db.Execute(PrivateCards.Device.DeviceCardsTableAdapter.CreateSQLScript);
                    db.Execute(PrivateCards.DataBase.DatabaseCardsTableAdapter.CreateSQLScript);
                    db.Execute(PrivateCards.CreditCard.CreditCardsTableAdapter.CreateSQLScript);
                    db.CompleteTransaction();
                }
                catch// (Exception)
                {
                    db.AbortTransaction();
                    throw;
                }

            }
            else
            {
                db = new Database(GetConnectionString(databaseFile), providerName: "System.Data.SQLite");
            }

            return db;
        }

        private static Dictionary<int, List<string>> _updatescripts = new Dictionary<int, List<string>>()
        {
            //{2,
            //    ...
            //}
        };


        public static bool UpdateDB(Database db, int currentDbVersion, IHelperLogger logger)
        {
            //try
            //{
            //    db.BeginTransaction();

            //    db.CompleteTransaction();
            //}
            //catch (Exception ex)
            //{
            //    db.AbortTransaction();
            //    return false;
            //}

            return true;
        }
    }
}
