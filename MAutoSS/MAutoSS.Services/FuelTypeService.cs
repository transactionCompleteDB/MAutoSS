using System.Collections.Generic;

using Bytes2you.Validation;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;

namespace MAutoSS.Services
{
    public class FuelTypeService : IFuelTypeService
    {
        private readonly IGenericRepository<FuelType> fuelTypeRepo;

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
