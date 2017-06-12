using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Bytes2you.Validation;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.ReportGenerator;
using MAutoSS.Services.Contracts;

namespace MAutoSS.Services
{
    public class DealershipService : IDealershipService
    {
        private readonly IGenericRepository<Dealership> dealershipRepo;
        private readonly IGenericRepository<Address> addressRepo;
        private readonly IGenericRepository<City> citiesRepo;
        private readonly IGenericRepository<Country> countriesRepo;

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
            var existingCountry = this.countriesRepo.GetAll().FirstOrDefault(x => x.Name == countryName);
            Guard.WhenArgument(existingCountry, "existingCountry").IsNull().Throw();

            if (existingCountry == null)
            {
                var country = new Country
                {
                    Name = countryName
                };

                this.countriesRepo.Add(country);
                this.countriesRepo.SaveChanges();
            }

            existingCountry = this.countriesRepo.GetAll().First(x => x.Name == countryName);

            var existingCity = this.citiesRepo.GetAll().FirstOrDefault(x => x.Name == cityName);
            Guard.WhenArgument(existingCity, "existingCity").IsNull().Throw();

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

            existingCity = this.citiesRepo.GetAll().First(x => x.Name == cityName);

            var dealership = new Dealership
            {
                Name = dealershipName
            };

            this.dealershipRepo.Add(dealership);
            this.dealershipRepo.SaveChanges();

            var existingAdres = this.addressRepo.GetAll().FirstOrDefault(x => x.AddressText == addressText);
            Guard.WhenArgument(existingAdres, "existingAdres").IsNull().Throw();

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

            Guard.WhenArgument(allDealerships, "allDealerships").IsNull().Throw();

            foreach (var dealer in allDealerships)
            {
                builder.AppendLine($"{dealer.Name}--{dealer.Address.AddressText}--{dealer.Address.City.Name}");
                builder.AppendLine("Employees working in :");
                if (dealer.Employees.Any<Employee>())
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
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory.ToString().Replace("MAutoSS.Web", "PDFReports"));
            pdf.GenerateReport(path, "Information", strInfo);
        }
    }
}
