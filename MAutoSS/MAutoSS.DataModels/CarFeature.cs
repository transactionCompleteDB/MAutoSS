using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAutoSS.DataModels
{
    public class CarFeature
    {
        private ICollection<Car> cars; 

        public CarFeature()
        {
            this.cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [MinLength(10)]
        [MaxLength(300)]
        public string Description { get; set; }


        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
    }
}
