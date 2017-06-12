using System.Linq;
using System.Web.Mvc;

using Bytes2you.Validation;

using MAutoSS.Services.Contracts;
using MAutoSS.Web.Models.Address;
using MAutoSS.Web.Models.City;
using MAutoSS.Web.Models.Country;
using MAutoSS.Web.Models.Dealership;

namespace MAutoSS.Web.Controllers
{
    public class DealershipsController : Controller
    {
        private readonly IDealershipService dealershipService;

        public DealershipsController(IDealershipService dealershipService)
        {
            Guard.WhenArgument(dealershipService, "projectService").IsNull().Throw();

            this.dealershipService = dealershipService;
        }

        public ActionResult Index()
        {
            return this.View();
        }
                
        [HttpGet]
        public ActionResult CreateNewDealership()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult CreateNewDealership(DealershipInputModel model)
        {
            Guard.WhenArgument(model, "model").IsNull().Throw();

            this.dealershipService.CreateNewDealership(
                model.Name,
                model.Address.AddressText,
                model.Address.City.Name,
                model.Address.City.Country.Name);

            return this.RedirectToAction("LoadDealershipInfo");
        }

        [HttpGet]
        public ActionResult LoadDealershipInfo()
        {
            var allDealerships = this.dealershipService.GetAllDealerships()
                 .Select(x => new DealershipMainInfoModel
                 {
                     Name = x.Name,
                     Address = new AddressViewModel
                     {
                         AddressText = x.Address.AddressText,
                         City = new CityViewModel
                         {
                             Name = x.Address.City.Name,
                             Country = new CountryViewModel
                             {
                                 Name = x.Address.City.Country.Name
                             }
                         }
                     },
                     NumberOfCars = x.Cars.Count,
                     NumberOfEmployees = x.Employees.Count
                 });

            return this.View(allDealerships);
        }

        [HttpGet]
        public ActionResult ExportInfoDealer()
        {
            this.dealershipService.Export();

            return this.View();
        }
    }
}
