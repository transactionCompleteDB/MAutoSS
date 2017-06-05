using MAutoSS.Web.Models.Address;

namespace MAutoSS.Web.Models.Dealership
{
    public class DealershipViewModel
    {
        public string Name { get; set; }

        public int NumberOfEmployees { get; set; }

        public int NumberOfCars { get; set; }

        public int NumberOfSales { get; set; }

        public AddressViewModel Address { get; set; }
    }
}