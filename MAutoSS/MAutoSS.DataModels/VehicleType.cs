using System.Collections.Generic;

namespace MAutoSS.DataModels
{
    public class VehicleType
    {
        private ICollection<Car> cars;

        public VehicleType()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public string Type { get; set; }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
