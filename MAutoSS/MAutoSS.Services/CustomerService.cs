using Bytes2you.Validation;
using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.DataModels.Postgre.Models;
using MAutoSS.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace MAutoSS.Services
{
    public class CustomerService : ICustomerService
    {
        private IGenericRepository<Customer> customersRepo;
        private IDiscountService discountService;

        public CustomerService(
            IGenericRepository<Customer> customersRepo,
            IDiscountService discountService)
        {
            Guard.WhenArgument(customersRepo, "customersRepo").IsNull().Throw();
            Guard.WhenArgument(discountService, "discountService").IsNull().Throw();

            this.customersRepo = customersRepo;
            this.discountService = discountService;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return this.customersRepo.GetAll();
        }

        public void CreateNewCustomer(string firstName, string lastName, decimal discount)
        {
            var existingDiscount = this.discountService.GetAllDiscounts().FirstOrDefault(x => x.DiscountPercentage == discount);

            if (existingDiscount == null)
            {
                this.discountService.CreateNewDiscount(discount);
            }

            existingDiscount = this.discountService.GetAllDiscounts().FirstOrDefault(x => x.DiscountPercentage == discount);

            var newCustomer = new Customer
            {
                FirstName = firstName,
                LastName = lastName,
                DiscountId = existingDiscount.Id
            };

            this.customersRepo.Add(newCustomer);
            this.customersRepo.SaveChanges();
        }
    }
}
