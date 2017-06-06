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
        private IDealershipService dealershipService;
        private IUnitOfWork unitOfWork;

        public DealershipService(
            IGenericRepository<Dealership> dealershipRepo,
            IGenericRepository<Address> addressRepo,
            IGenericRepository<City> citiesRepo,
            IGenericRepository<Country> countriesRepo,
            IDealershipService dealershipService,
            IUnitOfWork unitOfWork)
        {
            this.dealershipRepo = dealershipRepo;
            this.addressRepo = addressRepo;
            this.citiesRepo = citiesRepo;
            this.countriesRepo = countriesRepo;
            this.dealershipService = dealershipService;
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

            var city = new City
            {
                Name = cityName,
                CountryId = country.Id
            };

            var address = new Address
            {
                AddressText = addressText,
                CityId = city.Id
            };

            var dealership = new Dealership
            {
                Name = dealershipName,
                AddressId = address.Id
            };


            using (IUnitOfWork unitOfWork = this.unitOfWork)
            {
                this.countriesRepo.Add(country);
                this.citiesRepo.Add(city);
                this.addressRepo.Add(address);
                this.dealershipRepo.Add(dealership);
                this.unitOfWork.Commit();
            }
        }
    }
}
