using System.Collections.Generic;

using Bytes2you.Validation;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;

namespace MAutoSS.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private readonly IGenericRepository<VehicleType> vehicleTypeRepo;

        public VehicleTypeService(
           IGenericRepository<VehicleType> vehicleTypeRepo)
        {
            Guard.WhenArgument(vehicleTypeRepo, "vehicleTypeRepo").IsNull().Throw();

            this.vehicleTypeRepo = vehicleTypeRepo;
        }

        public IEnumerable<VehicleType> GetAllVehicleTypes()
        {
            return this.vehicleTypeRepo.GetAll();
        }
    }
}
