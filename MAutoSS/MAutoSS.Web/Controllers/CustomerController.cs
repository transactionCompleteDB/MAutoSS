using Bytes2you.Validation;
using MAutoSS.Services.Contracts;
using MAutoSS.Web.Models.Customer;
using System.Linq;
using System.Web.Mvc;

namespace MAutoSS.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService customerService;

        public CustomerController(
            ICustomerService customerService)
        {
            Guard.WhenArgument(customerService, "customerService").IsNull().Throw();

            this.customerService = customerService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult CreateNewCustomer()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateNewCustomer(CustomerModel model)
        {
            this.customerService.CreateNewCustomer(
                model.FirstName,
                model.LastName,
                decimal.Parse(model.Discount));

            return this.RedirectToAction("LoadCustomersInfo");
        }

        [HttpGet]
        public ActionResult LoadCustomersInfo()
        {
            var allCustomers = this.customerService
                .GetAllCustomers()
                .Select(x => new CustomerModel
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Discount = x.Discount.DiscountPercentage.ToString()
                });

            return View(allCustomers);
        }
    }
}