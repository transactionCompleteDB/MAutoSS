using System;
using System.Collections.Generic;

namespace MAutoSS.DataModels
{
    public class Car
    {
        private ICollection<CarFeature> carFeatures;

        public Car()
        {
            this.carFeatures = new HashSet<CarFeature>();
        }

        public int Id { get; set; }

        public int ManufactureYear { get; set; }

        public int Mileage{ get; set; }

        public int DealershipId { get; set; }

        public virtual Dealership Dealership { get; set; }

        public int SaleId { get; set; }

        public Sale Sale { get; set; }

        public virtual ICollection<CarFeature> CarFeatures
        {
            get { return this.carFeatures; }
            set { this.carFeatures = value; }
        }

        public int CarBrandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }

        public int CarModelId { get; set; }

        public virtual CarModel CarModel { get; set; }

        public int TransimssionTypeId { get; set; }

        public virtual TransimssionType TransimssionType { get; set; }

        public int VehicleTypeId { get; set; }

        public virtual VehicleType VehicleType { get; set; }

        public int FuelTypeId { get; set; }

        public virtual FuelType FuelType { get; set; }



    }
}
