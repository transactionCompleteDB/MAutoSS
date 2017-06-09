using Bytes2you.Validation;
using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;
using System.Collections.Generic;

namespace MAutoSS.Services
{
    public class CarBrandsService : ICarBrandsService
    {
        private IGenericRepository<CarBrand> carBrandsRepo;

        public CarBrandsService(
           IGenericRepository<CarBrand> carBrandsRepo)
        {
            Guard.WhenArgument(carBrandsRepo, "carBrandsRepo").IsNull().Throw();

            this.carBrandsRepo = carBrandsRepo;
        }

        public IEnumerable<CarBrand> GetAllCarBrands()
        {
            return this.carBrandsRepo.GetAll();
        }
    }
}
