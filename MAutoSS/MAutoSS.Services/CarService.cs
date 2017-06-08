using System;
using System.Collections.Generic;
using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels;
using MAutoSS.Services.Contracts;
using Bytes2you.Validation;

namespace MAutoSS.Services
{
    public class CarService : ICarService
    {
        private IGenericRepository<Car> carRepo;

        public CarService(
           IGenericRepository<Car> carRepo)
        {
            Guard.WhenArgument(carRepo, "carRepo").IsNull().Throw();

            this.carRepo = carRepo;
        }

        public IEnumerable<Car> GetAllCars()
        {
           return this.carRepo.GetAll();
        }

        public void CreateNewCar(string firstName, string lastName, string dealershipName)
        {
            throw new NotImplementedException();
        }

    
    }
}
