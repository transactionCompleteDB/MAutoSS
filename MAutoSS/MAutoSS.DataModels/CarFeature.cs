using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels
{
    public class CarFeature
    {
        public CarFeature()
        {
            this.Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(100)]
        public string Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
