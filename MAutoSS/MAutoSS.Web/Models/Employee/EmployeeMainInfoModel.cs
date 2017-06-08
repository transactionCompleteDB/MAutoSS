using MAutoSS.Web.Models.Dealership;

namespace MAutoSS.Web.Models.Employee
{
    public class EmployeeMainInfoModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Dealership { get; set; }

        public int NumberOfSales { get; set; }
    }
}