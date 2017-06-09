using System.Collections.Generic;

namespace MAutoSS.DataModels
{
    public class Sale
    {
        private ICollection<Car> cars;

        public Sale()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
