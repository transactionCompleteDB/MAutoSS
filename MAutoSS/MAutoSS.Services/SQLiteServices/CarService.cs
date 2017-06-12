using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels.SQLite.Models;
using MAutoSS.Services.Contracts.SQLiteContracts;

namespace MAutoSS.Services.SQLiteServices
{
    public class CarService : ICarService
    {
        private IGenericRepository<Car> carRepo;

        public CarService(
           IGenericRepository<Car> carRepo, IServiceInfoService serviceInfoService)
        {
            Guard.WhenArgument(carRepo, "carRepo").IsNull().Throw();

            this.carRepo = carRepo;
        }

        public Car GetCarById(int id)
        {
            return this.carRepo.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public Car GetCarByVIN(int VIN)
        {
            return this.carRepo.GetAll().FirstOrDefault(x => x.VIN == VIN);
        }

        public IEnumerable<Car> GetAllCars()
        {
            return this.carRepo.GetAll();
        }

        public void AddNewCar(int VIN)
        {
            var carServiceInfo = new List<ServiceInfo>();

            var newCar = new Car
            {
                VIN = VIN,
                ServiceInfo = carServiceInfo
            };

            this.carRepo.Add(newCar);
            this.carRepo.SaveChanges();
        }

        public void AddServiceDescriptionToCar(int VIN, string serviceInfo)
        {
            var carServiceInfo = serviceInfo;

            var car = this.GetCarByVIN(VIN);

            car.ServiceInfo.Add(new ServiceInfo
            {
                Description = serviceInfo
            });

            this.carRepo.SaveChanges();
        }

        public IEnumerable<ServiceInfo> GetServiceDescriptionForCar(int VIN)
        {
            var car = this.GetCarByVIN(VIN);
            return car.ServiceInfo;
        }

        public void DeleteCar(Car car)
        {
            this.carRepo.Delete(car);
            this.carRepo.SaveChanges();
        }
    }
}
