using System.Collections.Generic;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;
using System.Linq;
using Bytes2you.Validation;
using System.Text;
using MAutoSS.ReportGenerator;
using System.IO;
using System;

namespace MAutoSS.Services
{
    public class DealershipService : IDealershipService
    {
        private IGenericRepository<Dealership> dealershipRepo;
        private IGenericRepository<Address> addressRepo;
        private IGenericRepository<City> citiesRepo;
        private IGenericRepository<Country> countriesRepo;


        public DealershipService(
            IGenericRepository<Dealership> dealershipRepo,
            IGenericRepository<Address> addressRepo,
            IGenericRepository<City> citiesRepo,
            IGenericRepository<Country> countriesRepo)
        {
            Guard.WhenArgument(dealershipRepo, "dealershipRepo").IsNull().Throw();
            Guard.WhenArgument(addressRepo, "addressRepo").IsNull().Throw();
            Guard.WhenArgument(citiesRepo, "citiesRepo").IsNull().Throw();
            Guard.WhenArgument(countriesRepo, "countriesRepo").IsNull().Throw();

            this.dealershipRepo = dealershipRepo;
            this.addressRepo = addressRepo;
            this.citiesRepo = citiesRepo;
            this.countriesRepo = countriesRepo;
        }

        public IEnumerable<Dealership> GetAllDealerships()
        {
            return this.dealershipRepo.GetAll();
        }

        public IEnumerable<string> GetAllDealershipsNames()
        {
            return this.dealershipRepo.GetAll().Select(x => x.Name);
        }

        public Dealership GetAllDealershipById(int id)
        {
            return this.dealershipRepo.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Dealership GetDealershipByName(string name)
        {
            return this.dealershipRepo.GetAll().FirstOrDefault(x => x.Name == name);
        }


        public void CreateNewDealership(string dealershipName, string addressText, string cityName, string countryName)
        {
            var existingCountry = countriesRepo.GetAll().FirstOrDefault(x => x.Name == countryName);
            if (existingCountry == null)
            {
                var country = new Country
                {
                    Name = countryName
                };
                this.countriesRepo.Add(country);
                this.countriesRepo.SaveChanges();
            }
            existingCountry = countriesRepo.GetAll().First(x => x.Name == countryName);


            var existingCity = citiesRepo.GetAll().FirstOrDefault(x => x.Name == cityName);
            if (existingCity == null)
            {
                var city = new City
                {
                    Name = cityName,
                    CountryId = existingCountry.Id
                };

                this.citiesRepo.Add(city);
                this.citiesRepo.SaveChanges();
            }
            existingCity = citiesRepo.GetAll().First(x => x.Name == cityName);

            var dealership = new Dealership
            {
                Name = dealershipName
            };

            this.dealershipRepo.Add(dealership);
            this.dealershipRepo.SaveChanges();

            var existingAdres = addressRepo.GetAll().FirstOrDefault(x => x.AddressText == addressText);
            if (existingAdres == null)
            {
                var address = new Address
                {
                    Id = dealership.Id,
                    AddressText = addressText,
                    CityId = existingCity.Id
                };

                this.addressRepo.Add(address);
                this.addressRepo.SaveChanges();
            }
        }
        public void Export()
        {
            var builder = new StringBuilder();
            var allDealerships = this.GetAllDealerships();

            foreach (var dealer in allDealerships)
            {
                builder.AppendLine($"{dealer.Name}--{dealer.Address.AddressText}--{dealer.Address.City.Name}");
                builder.AppendLine("Employees working in :");
                if (dealer.Employees != null || dealer.Employees.Count != 0)
                {
                    foreach (var empl in dealer.Employees)
                    {
                        builder.AppendLine($"-----{empl.FirstName} {empl.LastName}");
                    }
                }
                else
                {
                    builder.AppendLine("Nobody is working here!!");
                }
                builder.AppendLine("----------------------");
            }

            var strInfo = builder.ToString();
            var pdf = new PDFReportGenerator();
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("MAutoSS.Web", "PDFreport"));
            pdf.GenerateReport(path, "Information", strInfo);
        }
    }
}
