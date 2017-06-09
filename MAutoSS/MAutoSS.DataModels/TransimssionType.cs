using System.Collections.Generic;

namespace MAutoSS.DataModels
{
    public class TransimssionType
    {
        private ICollection<Car> cars;

        public TransimssionType()
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
