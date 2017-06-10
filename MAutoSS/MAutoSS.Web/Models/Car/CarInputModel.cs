using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MAutoSS.Web.Models.Car
{
    public class CarInputModel
    {
        [DisplayName("Brand")]
        public int BrandId { get; set; }

        [DisplayName("Model")]
        public int ModelId { get; set; }

        [DisplayName("Vehicle Type")]
        public int VehicleTypeId { get; set; }

        [DisplayName("Fuel")]
        public int FuelTypeId { get; set; }

        [DisplayName("Transmission")]
        public int TransmissionTypeId { get; set; }

        [DisplayName("Manufacture Year")]
        [Range(1980, 2017, ErrorMessage = "Manufacture year should be between 1990 and 2017")]
        public int ManufactureYear { get; set; }

        [DisplayName("Mileage")]
        [Range(0, 4000000, ErrorMessage = "Mileage should be between 0 and 4000000")]
        public int Mileage { get; set; }

        [DisplayName("Selling Dealership")]
        public int DealershipId { get; set; }

        [DisplayName("Car Features")]
        public IList<CarFeatureViewModel> CarFeatures { get; set; }
    }
}
