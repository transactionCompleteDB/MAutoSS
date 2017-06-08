﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using MAutoSS.DataModels.Enums;
using System.ComponentModel.DataAnnotations.Schema;

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

        public DateTime ManufactureDate { get; set; }

        public int Mileage{ get; set; }

        [Required]
        public FuelType FuelType { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        [Required]
        public TransimssionType TransimssionType { get; set; }

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

    }
}
