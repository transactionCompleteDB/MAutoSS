using MAutoSS.DataModels;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();

        void CreateNewCar(
            int brandId,
            int modelId,
            int vehicleId,
            int manifactureYear,
            int mileage,
            int fuelId,
            int transmissionId,
            int dealershipId,
            IEnumerable<int> selectedCarFeaturesIds);
    }
}
