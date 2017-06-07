using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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


        public Employee Employee { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
