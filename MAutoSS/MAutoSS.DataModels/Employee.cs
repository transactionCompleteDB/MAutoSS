using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels
{
    public class Employee
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
        public int DealershipId { get; set; }

        [Required]
        public Dealership Dealership { get; set; }
    }
}
