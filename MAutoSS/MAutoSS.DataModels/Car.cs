using MAutoSS.DataModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels
{
    public class Car
    {
        public int Id { get; set; }


        [Required]
        [MinLength(1)]
        [MaxLength(15)]
        public string Brand { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(15)]
        public string Model { get; set; }

        public DateTime ManufactureDate { get; set; }

        public int Mileage{ get; set; }

        [Required]
        public virtual FuelType FuelType { get; set; }

        [Required]
        public virtual VehicleType VehicleType { get; set; }

        [Required]
        public virtual TransimssionType TransimssionType { get; set; }

        public int SaleId { get; set; }

        public Sale Sale { get; set; }

        public virtual ICollection<Cars_CarFeatures> Cars_CarFeatures { get; set; }

    }
}
