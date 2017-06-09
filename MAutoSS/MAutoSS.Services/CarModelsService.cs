using Bytes2you.Validation;
using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;
using System.Collections.Generic;

namespace MAutoSS.Services
{
    public class CarModelsService : ICarModelsService
    {
        private IGenericRepository<CarModel> carModelsRepo;

        public CarModelsService(
           IGenericRepository<CarModel> carModelsRepo)
        {
            Guard.WhenArgument(carModelsRepo, "carModelsRepo").IsNull().Throw();

            this.carModelsRepo = carModelsRepo;
        }

        public IEnumerable<CarModel> GetAllCarModels()
        {
            return this.carModelsRepo.GetAll();
        }
    }
}
