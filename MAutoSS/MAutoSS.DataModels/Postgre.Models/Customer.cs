using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels.Postgre.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(20)]
        public string LastName { get; set; }

        [Required]
        public int DiscountId { get; set; }

        [Required]
        public Discount Discount { get; set; }
    }
}
