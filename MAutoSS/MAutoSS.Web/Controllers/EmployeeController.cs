using System.Collections.Generic;
using System.Web.Mvc;

using Bytes2you.Validation;

using MAutoSS.Services.Contracts;
using MAutoSS.Web.Models.Employee;
using System.Linq;

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
            IList<SelectListItem> dealershipNamesDropdown = new List<SelectListItem>();
            IEnumerable<string> dealershipNames = this.dealershipService.GetAllDealershipsNames();

            foreach (var name in dealershipNames)
            {
                dealershipNamesDropdown.Add(new SelectListItem
                {
                    Text = name,
                    Value = name,
                });
            }

            var model = new EmployeeInputModel
            {
                DealerShips = dealershipNamesDropdown
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateNewEmployee(EmployeeInputModel model)
        {
            Guard.WhenArgument(model, "model").IsNull().Throw();

            this.employeeService.CreateNewEmployee(
                model.FirstName,
                model.LastName,
                model.DealershipName);

            return this.RedirectToAction("LoadEmployeesInfo");
        }

        [HttpGet]
        public ActionResult LoadEmployeesInfo()
        {
            var allEmployees = this.employeeService.GetAllEmployees()
                 .Select(x => new EmployeeMainInfoModel
                 {
                     EmployeeId = x.Id,
                     FirstName = x.FirstName,
                     LastName = x.LastName,
                     Dealership = x.Dealership.Name,
                     NumberOfSales = x.Sales.Count
                 })
                 .OrderBy(p => p.Dealership);

            return View(allEmployees);
        }

        [HttpGet]
        public ActionResult EditEmployee(int employeeId)
        {
            var employeeForEdit = this.employeeService.GetEmployeeById(employeeId);

            ICollection<SelectListItem> dealershipNamesDropdown = new List<SelectListItem>();
            IEnumerable<string> dealershipNames = this.dealershipService.GetAllDealershipsNames();

            foreach (var name in dealershipNames)
            {
                var dropDownLithSelectedDealership = new SelectListItem
                {
                    Text = name,
                    Value = name,
                };

                if (name == employeeForEdit.Dealership.Name)
                {
                    dropDownLithSelectedDealership.Selected = true;
                }

                dealershipNamesDropdown.Add(dropDownLithSelectedDealership);
            }

            var model = new EmployeeInputModel
            {
                EmployeeId = employeeForEdit.Id,
                FirstName = employeeForEdit.FirstName,
                LastName = employeeForEdit.LastName,
                DealershipName = employeeForEdit.Dealership.Name,
                DealerShips = dealershipNamesDropdown
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeeInputModel model)
        {
            Guard.WhenArgument(model, "model").IsNull().Throw();

            this.employeeService.EditEmployee(
                model.EmployeeId,
                model.FirstName,
                model.LastName,
                model.DealershipName);

            return this.RedirectToAction("LoadEmployeesInfo");
        }
    }
}