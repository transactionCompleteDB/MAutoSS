using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAutoSS.DataModels
{
    public class CarBrand
    {
        private ICollection<Car> cars;

        private ICollection<CarModel> carModels;

        public CarBrand()
        {
            this.cars = new HashSet<Car>();
            this.carModels = new HashSet<CarModel>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Brand { get; set; }
               
        public virtual ICollection<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        public virtual ICollection<CarModel> CarModels
        {
            get { return this.carModels; }
            set { this.carModels = value; }
        }
    }
}