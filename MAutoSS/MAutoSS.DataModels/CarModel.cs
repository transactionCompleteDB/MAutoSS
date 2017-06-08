using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAutoSS.DataModels
{
    public class CarModel
    {        
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        [Index(IsUnique = true)]
        public string Model { get; set; }

        public int CarBrandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }        
    }
}
