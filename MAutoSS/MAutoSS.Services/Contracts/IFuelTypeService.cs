using MAutoSS.DataModels;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface IFuelTypeService
    {
        IEnumerable<FuelType> GetAllFuelTypes();
    }
}
