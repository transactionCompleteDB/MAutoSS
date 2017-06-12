using System.ComponentModel.DataAnnotations;
using MAutoSS.Web.Models.City;

namespace MAutoSS.Web.Models.Address
{
    public class AddressViewModel
    {
        [Required]
        [Display(Name = "Address")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Address should be between 1 and 50 chars long")]
        public string AddressText { get; set; }

        [Required]
        public CityViewModel City { get; set; }
    }
}