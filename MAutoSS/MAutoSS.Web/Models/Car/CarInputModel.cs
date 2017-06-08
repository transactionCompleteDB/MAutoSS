using MAutoSS.DataModels.Enums;
using System;
using System.Collections.Generic;

namespace MAutoSS.Web.Models.Car
{
    public class CarInputModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public DateTime ManufactureDate { get; set; }

        public int Mileage { get; set; }

        public FuelType FuelType { get; set; }

        public VehicleType VehicleType { get; set; }

        public TransimssionType TransimssionType { get; set; }

        public string Dealership { get; set; }

        public ICollection<CarFeatureViewModel> CarFeatures { get; set; }
    }
}
