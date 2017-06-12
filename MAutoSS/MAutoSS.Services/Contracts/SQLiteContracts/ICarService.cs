using MAutoSS.DataModels.SQLite.Models;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts.SQLiteContracts
{
    public interface ICarService
    {
        IEnumerable<Car> GetAllCars();
    }
}
