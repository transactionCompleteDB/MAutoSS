namespace MAutoSS.Data.SQLite.Migrations
{
    using MAutoSS.DataModels.SQLite.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MAutoSS.Data.SQLite.MAutoSSDbContextSQLite>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(MAutoSS.Data.SQLite.MAutoSSDbContextSQLite context)
        {
            var serviceInof = new ServiceInfo();
            serviceInof.Description = "my Description";

            context.ServiceInfos.Add(serviceInof);
        }

    }
}
