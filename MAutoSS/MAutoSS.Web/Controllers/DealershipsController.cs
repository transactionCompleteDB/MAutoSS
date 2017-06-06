using MAutoSS.Services.Contracts;
using MAutoSS.Web.Models.Dealership;
using System.Web.Mvc;

namespace MAutoSS.Web.Controllers
{
    public class DealershipsController : Controller
    {
        private IDealershipService dealershipService;

        public DealershipsController()
        {

        }

        public DealershipsController(IDealershipService dealershipService)
        {
            this.dealershipService = dealershipService;
        }

        public ActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public ActionResult CreateNewDealership()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewDealership(DealershipInputModel model)
        {
            if (!ModelState.IsValid)
            {
                //TODO: think what message to use
                return null;
            }

            this.dealershipService.CreateNewDealership(
                model.Name,
                model.Address.AddressText,
                model.Address.City.Name,
                model.Address.City.Country.Name);


            return null;

        }

        
    }
}
