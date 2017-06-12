using System.Collections.Generic;
using MAutoSS.DataModels;

namespace MAutoSS.Services.Contracts
{
    public interface ICarBrandsService
    {
        IEnumerable<CarBrand> GetAllCarBrands();
    }
}
