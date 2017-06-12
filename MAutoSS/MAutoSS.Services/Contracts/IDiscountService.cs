using MAutoSS.DataModels.Postgre.Models;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface IDiscountService
    {
        IEnumerable<Discount> GetAllDiscounts();

        void CreateNewDiscount(decimal discount);
    }
}