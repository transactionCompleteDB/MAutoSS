using System.Collections.Generic;

using MAutoSS.DataModels;

namespace MAutoSS.Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();

        Car GetCarById(int id);

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

        void DeleteCar(Car car);
    }
}
