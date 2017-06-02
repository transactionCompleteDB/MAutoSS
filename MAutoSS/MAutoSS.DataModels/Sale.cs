using System.ComponentModel.DataAnnotations;

namespace MAutoSS.DataModels
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }
    }
}
