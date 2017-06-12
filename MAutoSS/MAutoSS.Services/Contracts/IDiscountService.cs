using System.Collections.Generic;

using MAutoSS.DataModels.Postgre.Models;

namespace MAutoSS.Services.Contracts
{
    public interface IDiscountService
    {
        IEnumerable<Discount> GetAllDiscounts();

        void CreateNewDiscount(decimal discount);
    }
}