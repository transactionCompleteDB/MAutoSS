using MAutoSS.Web.Models.Address;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MAutoSS.Web.Models.Dealership
{
    public class DealershipInputModel
    {
        [Required]
        [Display(Name = "Dealership name")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Dealership should be between 1 and 40 chars long")]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public AddressViewModel Address { get; set; }
    }
}