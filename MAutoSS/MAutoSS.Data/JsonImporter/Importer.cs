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

        public static void ImportCarFeature(MAutoSSDbContext context)

        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("MAutoSS.Web", "JsonFiles"), "car-feature.json");

            JArray allfeatures = JArray.Parse(File.ReadAllText(path));


            foreach (var feat in allfeatures)
            {
                var name = feat.ToString();
                var newFeat = new CarFeature
                {
                    Name = name
                };
                context.CarFeatures.AddOrUpdate(newFeat);

            }
            context.SaveChanges();
        }

        public static void ImportDealerships(MAutoSSDbContext context)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("MAutoSS.Web", "JsonFiles"), "dealership.json");

            JArray allDealers = JArray.Parse(File.ReadAllText(path));


            foreach (var deal in allDealers)
            {
                var name = deal.ToString();
                var newDealer = new Dealership
                {
                    Name = name
                };
                context.Dealerships.AddOrUpdate(newDealer);

            }
            context.SaveChanges();
        }

        public static void ImportEmployees(MAutoSSDbContext context)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("MAutoSS.Web", "JsonFiles"), "employees.json");

            JArray allEmployyes = JArray.Parse(File.ReadAllText(path));

            foreach (var empl in allEmployyes)
            {
                var firstName = empl["FirstName"].ToString();
                var LastName = empl["LastName"].ToString();
                var allDealerId = context.Dealerships.Select(x => x.Id).ToArray();
                Random dealer = new Random();
                int randomIndex = dealer.Next(0, allDealerId.Length);
                int randomNumber = allDealerId[randomIndex];

                var newEmploy = new Employee
                {
                    FirstName = firstName,
                    LastName = LastName,
                    DealershipId = randomNumber
                };
                context.Employees.AddOrUpdate(newEmploy);
            }

            context.SaveChanges();
        }

        public static void ImportCounties(MAutoSSDbContext context)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("MAutoSS.Web", "JsonFiles"), "countries.json");

            JArray allCountries = JArray.Parse(File.ReadAllText(path));


            foreach (var country in allCountries)
            {
                var name = country.ToString();
                var newCountry = new Country
                {
                    Name = name
                };
                context.Countries.AddOrUpdate(newCountry);

            }
            context.SaveChanges();
        }

        public static void ImportCities(MAutoSSDbContext context)
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("MAutoSS.Web", "JsonFiles"), "cities.json");

            JArray allCities = JArray.Parse(File.ReadAllText(path));
            int DoSwitch(string some)
            {
                switch (some)
                {
                    case "Sofia": return context.Countries.First(x => x.Name == "Bulgaria").Id;
                    case "Paris": return context.Countries.First(x => x.Name == "France").Id;
                    case "Berlin": return context.Countries.First(x => x.Name == "Germany").Id;
                    case "San Francisko": return context.Countries.First(x => x.Name == "USA").Id;
                    case "Madrid": return context.Countries.First(x => x.Name == "Spain").Id;
                    case "Pernik": return context.Countries.First(x => x.Name == "Bulgaria").Id;
                    default: return 0;
                }
            }
               
            foreach (var city in allCities)
            {
                var name = city.ToString();
                var newCity = new City
                {
                    Name = name,
                    CountryId = DoSwitch(name)


                };
                context.Cities.AddOrUpdate(newCity);

            }
            context.SaveChanges();
        }
        
    }
}

