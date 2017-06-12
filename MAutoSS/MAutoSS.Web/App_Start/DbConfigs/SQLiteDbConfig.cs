using System.Data.Entity;

using MAutoSS.Data.SQLite;
using MAutoSS.Data.SQLite.Migrations;

namespace MAutoSS.Web.App_Start.DbConfigs
{
    public class SQLiteDbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MAutoSSDbContextSQLite, Configuration>());
        }
    }
}