using MAutoSS.Web.Models.Country;

namespace MAutoSS.Web.Models.City
{
    public class CityViewModel
    {
        public string Name { get; set; }

        public CountryViewModel Country { get; set; }
    }
}