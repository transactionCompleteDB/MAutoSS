using MAutoSS.DataModels;
using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;

namespace MAutoSS.Data.JsonImporter
{
    public static class Importer
    {
        public static void ImportBrands(MAutoSSDbContext context)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("MAutoSS.Web", "JsonFiles"), "car-brands.json");

            JArray allBrands = JArray.Parse(File.ReadAllText(path));


            foreach (var brand in allBrands)
            {
                var name = brand.ToString();
                var newBrand = new CarBrand
                {
                    Brand = name
                };
                context.CarBrands.AddOrUpdate(newBrand);

            }
            context.SaveChanges();
        }

        public static void ImportModels(MAutoSSDbContext context)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("MAutoSS.Web", "JsonFiles"), "car-models.json");

            JArray allModels = JArray.Parse(File.ReadAllText(path));

            foreach (var mod in allModels)
            {
                var model = mod["brand"].ToString();
                var current = context.CarBrands.FirstOrDefault(x => x.Brand == model);

                if (current == null)
                {
                    var newBrand = new CarBrand
                    {
                        Brand = model
                    };
                    context.CarBrands.AddOrUpdate(newBrand);
                    context.SaveChanges();
                    current = context.CarBrands.First(x => x.Brand == model);
                }

                foreach (var modelBrand in mod["models"])
                {
                    var newModel = new CarModel
                    {
                        Model = modelBrand.ToString(),
                        CarBrandId = current.Id
                    };
                    context.CarModels.AddOrUpdate(newModel);
                }
            }
            context.SaveChanges();
        }
    }
}
