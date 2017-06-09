using Bytes2you.Validation;
using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;
using System.Collections.Generic;

namespace MAutoSS.Services
{
    public class CarFeaturesService : ICarFeaturesService
    {
        private IGenericRepository<CarFeature> carFeaturesRepo;

        public CarFeaturesService(
           IGenericRepository<CarFeature> carFeaturesRepo)
        {
            Guard.WhenArgument(carFeaturesRepo, "carFeaturesRepo").IsNull().Throw();

            this.carFeaturesRepo = carFeaturesRepo;
        }

        public IEnumerable<CarFeature> GetAllCarFeatures()
        {
            return this.carFeaturesRepo.GetAll();
        }
    }
}
