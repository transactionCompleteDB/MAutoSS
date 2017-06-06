using System.ComponentModel.DataAnnotations;

namespace MAutoSS.Web.Models.Country
{
    public class CountryViewModel
    {
        [Display(Name = "Country")]
        public string Name { get; set; }
    }
}