using MAutoSS.Data;
using MAutoSS.Data.Migrations;
using System.Data.Entity;

namespace MAutoSS.Web.App_Start
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MAutoSSDbContext, Configuration>());
        }
    }
}