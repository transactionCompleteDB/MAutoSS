using System.Web.Mvc;

using Bytes2you.Validation;
using MAutoSS.Services.Contracts;

namespace MAutoSS.Web.Controllers
{
    public class CarController : Controller
    {
        private ICarService carService;
        
        public CarController(ICarService carService)
        {
            Guard.WhenArgument(carService, "carService").IsNull().Throw();

            this.carService = carService;
        }
    }
}