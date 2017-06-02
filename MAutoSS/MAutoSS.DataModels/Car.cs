using MAutoSS.DataModels.Enums;
using System;
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
        public FuelType FuelType { get; set; }

        [Required]
        public VehicleType VehicleType { get; set; }

        [Required]
        public TransimssionType TransimssionType { get; set; }

        public int SaleId { get; set; }



    }
}
