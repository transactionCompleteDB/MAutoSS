using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAutoSS.DataModels
{
    public class Address
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(10)]
        [MaxLength(70)]
        public string AddressText { get; set; }

        public virtual Dealership Dealership { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
