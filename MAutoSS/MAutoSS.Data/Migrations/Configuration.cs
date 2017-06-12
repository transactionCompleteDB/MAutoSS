using System.Data.Entity.Migrations;
using System.Linq;

using MAutoSS.Data.JsonImporter;
using MAutoSS.DataModels;

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
                this.AddTransimssionTypes(context);
            }

            if (context.FuelTypes.Count() == 0)
            {
                this.AddFuelTypes(context);
            }

            if (context.VehicleTypes.Count() == 0)
            {
                this.AddVehicleTypes(context);
            }

            if (context.CarBrands.Count() == 0)
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

            if (context.Dealerships.Count() == 0)
            {
                Importer.ImportDealerships(context);
            }

            if (context.Employees.Count() == 0)
            {
                Importer.ImportEmployees(context);
            }

            if (context.Countries.Count() == 0)
            {
                Importer.ImportCounties(context);
            }

            if (context.Cities.Count() == 0)
            {
                Importer.ImportCities(context);
            }

            if (context.Addresses.Count() == 0)
            {
                Importer.ImportAdresses(context);
            }
        }

        private void AddTransimssionTypes(MAutoSSDbContext context)
        {
            context.TransimssionTypes.Add(new TransimssionType() { Type = "Manual" });
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