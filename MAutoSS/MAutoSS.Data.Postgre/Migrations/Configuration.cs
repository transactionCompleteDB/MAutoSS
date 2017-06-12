using System.Data.Entity.Migrations;

namespace MAutoSS.Data.Postgre.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MAutoSSDbContextPostgre>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MAutoSSDbContextPostgre context)
        {
        }
    }
}
