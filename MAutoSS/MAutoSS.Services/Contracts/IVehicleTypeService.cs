using System.Collections.Generic;

using MAutoSS.DataModels;

namespace MAutoSS.Services.Contracts
{
    public interface IVehicleTypeService
    {
        IEnumerable<VehicleType> GetAllVehicleTypes();
    }
}
