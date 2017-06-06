using MAutoSS.Web.Models.City;
using System.ComponentModel.DataAnnotations;

namespace MAutoSS.Web.Models.Address
{
    public class AddressViewModel
    {
        [Display(Name ="Address")]
        public string AddressText { get; set; }

        public CityViewModel City { get; set; }
    }
}