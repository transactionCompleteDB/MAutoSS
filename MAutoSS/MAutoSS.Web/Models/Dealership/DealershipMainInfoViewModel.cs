using MAutoSS.Web.Models.Address;

namespace MAutoSS.Web.Models.Dealership
{
    public class DealershipMainInfoViewModel
    {
        public string Name { get; set; }

        public int NumberOfEmployees { get; set; }

        public int NumberOfCars { get; set; }

        public AddressViewModel Address { get; set; }
    }
}