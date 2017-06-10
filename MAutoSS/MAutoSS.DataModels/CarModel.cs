using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels
{
    public class CarModel
    {        
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(40)]
        public string Model { get; set; }

        public int CarBrandId { get; set; }

        public virtual CarBrand CarBrand { get; set; }        
    }
}
