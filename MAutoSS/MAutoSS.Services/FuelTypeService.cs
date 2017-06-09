using MAutoSS.Services.Contracts;
using System.Collections.Generic;
using MAutoSS.DataModels;
using MAutoSS.Data.Repositories.Contracts;
using Bytes2you.Validation;
using System.Linq;

namespace MAutoSS.Services
{
    public class FuelTypeService : IFuelTypeService
    {
        private IGenericRepository<FuelType> fuelTypeRepo;

        public FuelTypeService(
           IGenericRepository<FuelType> fuelTypeRepo)
        {
            Guard.WhenArgument(fuelTypeRepo, "fuelTypeRepo").IsNull().Throw();

            this.fuelTypeRepo = fuelTypeRepo;
        }

        public IEnumerable<FuelType> GetAllFuelTypes()
        {
            return this.fuelTypeRepo.GetAll();
        }
    }
}
