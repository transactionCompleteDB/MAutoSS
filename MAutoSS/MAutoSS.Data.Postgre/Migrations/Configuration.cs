namespace MAutoSS.Data.Postgre.Migrations
{
    using MAutoSS.DataModels.Postgre.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MAutoSS.Data.Postgre.MAutoSSDbContextPostgre>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MAutoSS.Data.Postgre.MAutoSSDbContextPostgre context)
        {
            var discount = new Discount();
            discount.DiscountPercentage = 5;

            context.Discounts.Add(discount);
        }
    }
}
