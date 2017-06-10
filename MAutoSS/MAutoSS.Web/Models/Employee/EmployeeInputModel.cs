using System.Collections.Generic;
using System.Web.Mvc;

namespace MAutoSS.Web.Models.Employee
{
    public class EmployeeInputModel
    {
        public int EmployeeId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DealershipName { get; set; }

        public IEnumerable<SelectListItem> DealerShips { get; set; }
    }
}