using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;

using MAutoSS.DataModels.SQLite.Models;

namespace MAutoSS.Data.SQLite.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MAutoSS.Data.SQLite.MAutoSSDbContextSQLite>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;

            this.SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(MAutoSSDbContextSQLite context)
        {
            var serviceInof = new ServiceInfo();
            serviceInof.Description = "my Description";

            context.ServiceInfos.Add(serviceInof);
        }

    }
}
