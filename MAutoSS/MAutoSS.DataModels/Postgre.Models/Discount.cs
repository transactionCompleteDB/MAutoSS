using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels.Postgre.Models
{
    public class Discount
    {
        public int Id { get; set; }

        [Required]
        public int DiscountPercentage { get; set; }
    }
}
