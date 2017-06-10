using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MAutoSS.Web.Models.Employee
{
    public class EmployeeInputModel
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required!")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "First name should be between 1 and 40 chars long")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required!")]
        [StringLength(40, MinimumLength = 1, ErrorMessage = "Last name should be between 1 and 40 chars long")]
        public string LastName { get; set; }

        public string DealershipName { get; set; }

        public IEnumerable<SelectListItem> DealerShips { get; set; }
    }
}