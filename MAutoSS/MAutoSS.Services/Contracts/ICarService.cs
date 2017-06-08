using MAutoSS.DataModels;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();

        void CreateNewCar(string firstName, string lastName, string dealershipName);
    }
}
