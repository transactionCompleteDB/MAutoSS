using System.Collections.Generic;

namespace MAutoSS.Web.Models.Car
{
    public class FullCarInfo
    {
        public int CarId { get; set; }
        
        public string Brand { get; set; }

        public string Model { get; set; }
        
        public string VehicleType { get; set; }

        public string FuelType { get; set; }
        
        public string TransmissionType { get; set; }
        
        public string ManufactureYear { get; set; }
        
        public string Mileage { get; set; }
        
        public string Dealership { get; set; }
        
        public ICollection<string> CarFeatures { get; set; }
    }
}