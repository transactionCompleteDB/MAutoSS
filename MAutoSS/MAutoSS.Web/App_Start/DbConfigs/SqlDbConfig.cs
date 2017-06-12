using System.Data.Entity;

using MAutoSS.Data;
using MAutoSS.Data.Migrations;

namespace MAutoSS.Web.App_Start.DbConfigs
{
    public class SqlDbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MAutoSSDbContext, Configuration>());
        }
    }
}