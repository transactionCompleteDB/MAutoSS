using System.Collections.Generic;
using System.Web.Mvc;

using Bytes2you.Validation;

using MAutoSS.Services.Contracts;
using MAutoSS.Web.Models.Employee;

namespace MAutoSS.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private IEmployeeService employeeService;
        private IDealershipService dealershipService;

        public EmployeeController(IEmployeeService employeeService, IDealershipService dealershipService)
        {
            Guard.WhenArgument(employeeService, "employeeService").IsNull().Throw();
            Guard.WhenArgument(dealershipService, "dealershipService").IsNull().Throw();

            this.employeeService = employeeService;
            this.dealershipService = dealershipService;
        }

        [HttpGet]
        public ActionResult CreateNewEmployee()
        {
            ICollection<SelectListItem> dealershipNamesDropdown = new List<SelectListItem>();
            IEnumerable<string> dealershipNames = this.dealershipService.GetAllDealershipsNames();

            foreach (var name in dealershipNames)
            {
                dealershipNamesDropdown.Add(new SelectListItem
                {
                    Text = name,
                    Value = name
                });
            }

            this.ViewBag.DealershipNamesDropdown = dealershipNamesDropdown;
            
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewEmployee(EmployeeInputModel model)
        {
            Guard.WhenArgument(model, "model").IsNull().Throw();

            this.employeeService.CreateNewEmployee(
                model.FirstName,
                model.LastName,
                model.DealershipName);

            return null;

        }
    }
}