using System.Data.Entity;

using MAutoSS.Data.Postgre;
using MAutoSS.Data.Postgre.Migrations;

namespace MAutoSS.Web.App_Start.DbConfigs
{
    public class PostgreDbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MAutoSSDbContextPostgre, Configuration>());
        }
    }
}