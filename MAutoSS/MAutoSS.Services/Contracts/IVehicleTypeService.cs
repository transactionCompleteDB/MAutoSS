using MAutoSS.DataModels;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface IVehicleTypeService
    {
        IEnumerable<VehicleType> GetAllVehicleTypes();
    }
}
