using System.ComponentModel.DataAnnotations;
using MAutoSS.Web.Models.Country;

namespace MAutoSS.Web.Models.City
{
    public class CityViewModel
    {
        [Required]
        [Display(Name = "City")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "City should be between 1 and 40 chars long")]
        public string Name { get; set; }

        [Required]
        public CountryViewModel Country { get; set; }
    }
}