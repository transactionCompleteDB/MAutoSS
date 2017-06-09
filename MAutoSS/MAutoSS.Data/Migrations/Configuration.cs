using MAutoSS.Data.JsonImporter;
using MAutoSS.DataModels;
using System.Data.Entity.Migrations;
using System.Linq;

namespace MAutoSS.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<MAutoSSDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(MAutoSSDbContext context)
        {
            if (context.TransimssionTypes.Count() == 0)
            {
                AddTransimssionTypes(context);
            }

            if (context.FuelTypes.Count() == 0)
            {
                AddFuelTypes(context);
            }

            if (context.VehicleTypes.Count() == 0)
            {
                AddVehicleTypes(context);
            }
            if(context.CarBrands.Count()==0)
            {
                Importer.ImportBrands(context);
            }
            if (context.CarModels.Count() == 0)
            {
                Importer.ImportModels(context);
            }
            if (context.CarFeatures.Count() == 0)
            {
                Importer.ImportCarFeature(context);
            }
        }

        private void AddTransimssionTypes(MAutoSSDbContext context)
        {
            context.TransimssionTypes.Add(new TransimssionType () { Type = "Manual" });
            context.TransimssionTypes.Add(new TransimssionType() { Type = "Automatic" });
            context.TransimssionTypes.Add(new TransimssionType() { Type = "Semi-Automatic" });
        }

        private void AddFuelTypes(MAutoSSDbContext context)
        {
            context.FuelTypes.Add(new FuelType() { Type = "Diesel" });
            context.FuelTypes.Add(new FuelType() { Type = "Petrol" });
            context.FuelTypes.Add(new FuelType() { Type = "Hybrid" });
        }

        private void AddVehicleTypes(MAutoSSDbContext context)
        {
            context.VehicleTypes.Add(new VehicleType() { Type = "Saloon" });
            context.VehicleTypes.Add(new VehicleType() { Type = "Touring" });
            context.VehicleTypes.Add(new VehicleType() { Type = "Cabriolet" });
            context.VehicleTypes.Add(new VehicleType() { Type = "Coupe" });
            context.VehicleTypes.Add(new VehicleType() { Type = "Van" });
            context.VehicleTypes.Add(new VehicleType() { Type = "Suv" });
        }
    }
}