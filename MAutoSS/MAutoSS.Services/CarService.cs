using System.Collections.Generic;
using System.Linq;

using Bytes2you.Validation;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;

namespace MAutoSS.Services
{
    public class CarService : ICarService
    {
        private readonly IGenericRepository<Car> carRepo;
        private readonly ICarFeaturesService carFeatureService;

        public CarService(
           IGenericRepository<Car> carRepo,
           ICarFeaturesService carFeatureService)
        {
            Guard.WhenArgument(carRepo, "carRepo").IsNull().Throw();
            Guard.WhenArgument(carFeatureService, "carFeatureService").IsNull().Throw();

            this.carRepo = carRepo;
            this.carFeatureService = carFeatureService;
        }

        public IEnumerable<Car> GetAllCars()
        {
            return this.carRepo.GetAll();
        }

        public Car GetCarById(int id)
        {
            return this.carRepo.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void CreateNewCar(
            int brandId,
            int modelId,
            int vehicleId,
            int manifactureYear,
            int mileage,
            int fuelId,
            int transmissionId,
            int dealershipId,
            IEnumerable<int> selectedCarFeaturesIds)
        {
            var allCarFeaturesFromDB = this.carFeatureService.GetAllCarFeatures();

            var carFeaturesIn = new List<CarFeature>();

            foreach (var featureId in selectedCarFeaturesIds)
            {
                var feature = allCarFeaturesFromDB.FirstOrDefault(x => x.Id == featureId);
                carFeaturesIn.Add(feature);
            }

            var newCar = new Car
            {
                CarBrandId = brandId,
                CarModelId = modelId,
                VehicleTypeId = vehicleId,
                ManufactureYear = manifactureYear,
                Mileage = mileage,
                FuelTypeId = fuelId,
                TransimssionTypeId = transmissionId,
                DealershipId = dealershipId,
                CarFeatures = carFeaturesIn
            };

            this.carRepo.Add(newCar);
            this.carRepo.SaveChanges();          
        }

        public void DeleteCar(Car car)
        {
            this.carRepo.Delete(car);
            this.carRepo.SaveChanges();
        }
    }
}
