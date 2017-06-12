using MAutoSS.DataModels.SQLite.Models;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts.SQLiteContracts
{
    public interface ICarService
    {
        Car GetCarById(int id);

        Car GetCarByVIN(int VIN);

        IEnumerable<Car> GetAllCars();

        void AddNewCar(int VIN);

        void AddServiceDescriptionToCar(int VIN, string serviceInfo);

        IEnumerable<ServiceInfo> GetServiceDescriptionForCar(int VIN);

        void DeleteCar(Car car);
    }
}
