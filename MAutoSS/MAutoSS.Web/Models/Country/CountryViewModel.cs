using System.ComponentModel.DataAnnotations;

namespace MAutoSS.Web.Models.Country
{
    public class CountryViewModel
    {
        [Display(Name = "Country")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Country should be between 1 and 40 chars long")]
        public string Name { get; set; }
    }
}