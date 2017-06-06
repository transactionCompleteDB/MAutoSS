using MAutoSS.Web.Models.Address;
using System.ComponentModel.DataAnnotations;

namespace MAutoSS.Web.Models.Dealership
{
    public class DealershipInputModel
    {
        [Display(Name = "Dealership name")]
        public string Name { get; set; }

        public AddressViewModel Address { get; set; }
    }
}