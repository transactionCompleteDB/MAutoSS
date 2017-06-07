using System.Collections.Generic;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;

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
            this.dealershipRepo = dealershipRepo;
            this.addressRepo = addressRepo;
            this.citiesRepo = citiesRepo;
            this.countriesRepo = countriesRepo;
        }

        public IEnumerable<Dealership> GetAllDealerships()
        {
            return this.dealershipRepo.GetAll();
        }

        public void CreateNewDealership(string dealershipName, string addressText, string cityName, string countryName)
        {
            var country = new Country
            {
                Name = countryName
            };

            this.countriesRepo.Add(country);
            this.countriesRepo.SaveChanges();

            var city = new City
            {
                Name = cityName,
                CountryId = country.Id
            };

            this.citiesRepo.Add(city);
            this.citiesRepo.SaveChanges();


            var dealership = new Dealership
            {
                Name = dealershipName
            };

            this.dealershipRepo.Add(dealership);
            this.dealershipRepo.SaveChanges();

            var address = new Address
            {
                Id = dealership.Id,
                AddressText = addressText,
                CityId = city.Id
            };

            this.addressRepo.Add(address);
            this.addressRepo.SaveChanges();
        }
    }
}
