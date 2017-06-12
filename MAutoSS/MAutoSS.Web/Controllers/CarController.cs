using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;
using MAutoSS.Web.Models.Car;

namespace MAutoSS.Web.Controllers
{
    public class CarController : Controller
    {
        private readonly ICarFeaturesService carFeaturesService;
        private readonly ICarService carService;
        private readonly ICarBrandsService carBrandsService;
        private readonly ICarModelsService carModelsService;
        private readonly ITransmissionTypesService transmissionTypesService;
        private readonly IFuelTypeService fuelTypesService;
        private readonly IVehicleTypeService vehicleTypesService;
        private readonly IDealershipService dealersipService;

        public CarController(
            ICarFeaturesService carFeaturesService,
            ICarService carService,
            ICarBrandsService carBrandsService,
            ICarModelsService carModelsService,
            ITransmissionTypesService transmissionTypesService,
            IFuelTypeService fuelTypesService,
            IVehicleTypeService vehicleTypesService,
            IDealershipService dealersipService)
        {
            Guard.WhenArgument(carFeaturesService, "carFeaturesService").IsNull().Throw();
            Guard.WhenArgument(carService, "carService").IsNull().Throw();
            Guard.WhenArgument(carBrandsService, "carBrandsService").IsNull().Throw();
            Guard.WhenArgument(carModelsService, "carModelsService").IsNull().Throw();
            Guard.WhenArgument(transmissionTypesService, "transmissionTypesService").IsNull().Throw();
            Guard.WhenArgument(fuelTypesService, "fuelTypesService").IsNull().Throw();
            Guard.WhenArgument(vehicleTypesService, "vehicleTypesService").IsNull().Throw();
            Guard.WhenArgument(dealersipService, "dealersipService").IsNull().Throw();

            this.carFeaturesService = carFeaturesService;
            this.carService = carService;
            this.carBrandsService = carBrandsService;
            this.carModelsService = carModelsService;
            this.transmissionTypesService = transmissionTypesService;
            this.fuelTypesService = fuelTypesService;
            this.vehicleTypesService = vehicleTypesService;
            this.dealersipService = dealersipService;
        }

        [HttpGet]
        public ActionResult CreateNewCar()
        {
            ICollection<SelectListItem> carBrandsDropdown = new List<SelectListItem>();
            IEnumerable<CarBrand> carBrandsFromDb = this.carBrandsService.GetAllCarBrands();

            Guard.WhenArgument(carBrandsFromDb, "carBrandsFromDb").IsNull().Throw();

            foreach (var brand in carBrandsFromDb)
            {
                carBrandsDropdown.Add(new SelectListItem
                {
                    Text = brand.Brand,
                    Value = brand.Id.ToString()
                });
            }

            this.ViewBag.CarBrandsDropdown = carBrandsDropdown;

            ICollection<SelectListItem> carModelsDropdown = new List<SelectListItem>();
            IEnumerable<CarModel> carModelsFromDb = this.carModelsService.GetAllCarModels();

            Guard.WhenArgument(carModelsFromDb, "carModelsFromDb").IsNull().Throw();

            foreach (var carModel in carModelsFromDb)
            {
                carModelsDropdown.Add(new SelectListItem
                {
                    Text = carModel.Model,
                    Value = carModel.Id.ToString()
                });
            }

            this.ViewBag.CarModelsDropdown = carModelsDropdown;

            ICollection<SelectListItem> transmissionsDropdown = new List<SelectListItem>();
            IEnumerable<TransimssionType> transmissionsFromDb = this.transmissionTypesService.GetAllTransmissions();

            Guard.WhenArgument(transmissionsFromDb, "transmissionsFromDb").IsNull().Throw();

            foreach (var type in transmissionsFromDb)
            {
                transmissionsDropdown.Add(new SelectListItem
                {
                    Text = type.Type,
                    Value = type.Id.ToString()
                });
            }

            this.ViewBag.TransmissionsDropdown = transmissionsDropdown;

            ICollection<SelectListItem> vehicleTypesDropdown = new List<SelectListItem>();
            IEnumerable<VehicleType> vehicleTypesFromDb = this.vehicleTypesService.GetAllVehicleTypes();

            Guard.WhenArgument(vehicleTypesFromDb, "vehicleTypesFromDb").IsNull().Throw();

            foreach (var type in vehicleTypesFromDb)
            {
                vehicleTypesDropdown.Add(new SelectListItem
                {
                    Text = type.Type,
                    Value = type.Id.ToString()
                });
            }

            this.ViewBag.VehicleTypesDropdown = vehicleTypesDropdown;

            ICollection<SelectListItem> fuelTypesDropdown = new List<SelectListItem>();
            IEnumerable<FuelType> fuelTypesFromDb = this.fuelTypesService.GetAllFuelTypes();

            Guard.WhenArgument(fuelTypesFromDb, "fuelTypesFromDb").IsNull().Throw();

            foreach (var type in fuelTypesFromDb)
            {
                fuelTypesDropdown.Add(new SelectListItem
                {
                    Text = type.Type,
                    Value = type.Id.ToString()
                });
            }

            this.ViewBag.FuelTypesDropdown = fuelTypesDropdown;

            ICollection<SelectListItem> dealershipsDropdown = new List<SelectListItem>();
            IEnumerable<Dealership> dealershipsFromDb = this.dealersipService.GetAllDealerships();

            Guard.WhenArgument(dealershipsFromDb, "dealershipsFromDb").IsNull().Throw();

            foreach (var dealership in dealershipsFromDb)
            {
                dealershipsDropdown.Add(new SelectListItem
                {
                    Text = dealership.Name,
                    Value = dealership.Id.ToString()
                });
            }

            this.ViewBag.DealershipsDropdown = dealershipsDropdown;

            var allFeatures = this.carFeaturesService.GetAllCarFeatures().Select(x => new CarFeatureViewModel
            {
                CarFeatureId = x.Id,
                Name = x.Name,
                IsChecked = false
            })
            .ToList();

            var model = new CarInputModel
            {
                CarFeatures = allFeatures
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult CreateNewCar(CarInputModel model)
        {
            Guard.WhenArgument(model, "model").IsNull().Throw();

            var selectedCarFeaturesIds = model
                .CarFeatures
                .Where(x => x.IsChecked == true)
                .Select(x => x.CarFeatureId);

            this.carService.CreateNewCar(
                model.BrandId,
                model.ModelId,
                model.VehicleTypeId,
                model.ManufactureYear,
                model.Mileage,
                model.FuelTypeId,
                model.TransmissionTypeId,
                model.DealershipId,
                selectedCarFeaturesIds);

            return this.RedirectToAction("LoadCarsInfo");
        }

        [HttpGet]
        public ActionResult LoadCarsInfo()
        {
            var allCars = this.carService.GetAllCars()
                 .Select(x => new MainCarsInfo
                 {
                     CarId = x.Id,
                     Brand = x.CarBrand.Brand,
                     Model = x.CarModel.Model,
                     ManifactureYear = x.ManufactureYear.ToString(),
                     Mileage = x.Mileage.ToString(),
                     Dealership = x.Dealership.Name
                 });

            return this.View(allCars);
        }

        [HttpGet]
        public ActionResult LoadSelectedCarInfo(int carId)
        {
            var specificCar = this.carService.GetCarById(carId);

            var model = new FullCarInfo
            {
                CarId = specificCar.Id,
                Brand = specificCar.CarBrand.Brand,
                Model = specificCar.CarModel.Model,
                VehicleType = specificCar.VehicleType.Type,
                ManufactureYear = specificCar.ManufactureYear.ToString(),
                Mileage = specificCar.Mileage.ToString(),
                TransmissionType = specificCar.TransimssionType.Type,
                FuelType = specificCar.FuelType.Type,
                Dealership = specificCar.Dealership.Name,
                CarFeatures = specificCar.CarFeatures.Select(x => x.Name).ToList()
            };

            return this.View(model);
        }

        [HttpGet]
        public ActionResult DeleteCar(int carId)
        {
            var carForDeleting = this.carService.GetCarById(carId);

            this.carService.DeleteCar(carForDeleting);

            return this.RedirectToAction("LoadCarsInfo");
        }
    }
}