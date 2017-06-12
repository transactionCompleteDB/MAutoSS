using System.Collections.Generic;

using Bytes2you.Validation;

using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels.Postgre.Models;
using MAutoSS.Services.Contracts;

namespace MAutoSS.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly IGenericRepository<Discount> discountsRepo;

        public DiscountService(IGenericRepository<Discount> discountsRepo)
        {
            Guard.WhenArgument(discountsRepo, "discountsRepo").IsNull().Throw();

            this.discountsRepo = discountsRepo;
        }

        public IEnumerable<Discount> GetAllDiscounts()
        {
            return this.discountsRepo.GetAll();
        }

        public void CreateNewDiscount(decimal discount)
        {
            var newDiscount = new Discount
            {
                DiscountPercentage = discount
            };

            this.discountsRepo.Add(newDiscount);
            this.discountsRepo.SaveChanges();
        }
    }
}