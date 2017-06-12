using System.Collections.Generic;

using MAutoSS.DataModels.Postgre.Models;

namespace MAutoSS.Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();

        void CreateNewCustomer(string firstName, string lastName, decimal discount);
    }
}