using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAutoSS.DataModels
{
    public class Dealership
    {
        private ICollection<Employee> employees;
        private ICollection<Car> cars;

        public Dealership()
        {
            this.employees = new HashSet<Employee>();
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual Address Address { get; set; }

        public virtual ICollection<Employee> Employees
        {
            get { return this.employees; }
            set { this.employees = value; }
        }

        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
