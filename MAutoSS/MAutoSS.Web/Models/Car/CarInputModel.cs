using System.Collections.Generic;
using System.ComponentModel;

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
        public int ManufactureYear { get; set; }

        [DisplayName("Mileage")]
        public int Mileage { get; set; }

        [DisplayName("Selling Dealership")]
        public int DealershipId { get; set; }

        [DisplayName("Car Features")]
        public IList<CarFeatureViewModel> CarFeatures { get; set; }
    }
}
