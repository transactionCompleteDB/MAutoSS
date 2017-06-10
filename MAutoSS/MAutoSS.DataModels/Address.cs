using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels
{
    public class Address
    {
        public int Id { get; set; }
        
        [Required]
        [MinLength(5)]
        [MaxLength(50)]
        public string AddressText { get; set; }

        public virtual Dealership Dealership { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }
    }
}
