using MAutoSS.DataModels;
using Newtonsoft.Json.Linq;
using System;
using System.Data.Entity.Migrations;
using System.IO;

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
    }
}
