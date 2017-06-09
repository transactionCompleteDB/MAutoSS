using System.Collections.Generic;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;
using MAutoSS.Data.Repositories.Contracts;
using Bytes2you.Validation;

namespace MAutoSS.Services
{
    public class VehicleTypeService : IVehicleTypeService
    {
        private IGenericRepository<VehicleType> vehicleTypeRepo;

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
