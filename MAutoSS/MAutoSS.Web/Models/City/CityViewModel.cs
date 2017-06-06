using MAutoSS.Web.Models.Country;
using System.ComponentModel.DataAnnotations;

namespace MAutoSS.Web.Models.City
{
    public class CityViewModel
    {
        [Display(Name = "City")]
        public string Name { get; set; }

        public CountryViewModel Country { get; set; }
    }
}