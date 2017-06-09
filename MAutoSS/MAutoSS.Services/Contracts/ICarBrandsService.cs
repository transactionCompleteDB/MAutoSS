using MAutoSS.DataModels;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface ICarBrandsService
    {
        IEnumerable<CarBrand> GetAllCarBrands();
    }
}
