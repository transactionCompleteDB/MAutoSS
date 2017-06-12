using MAutoSS.DataModels.Postgre.Models;

using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomers();

        void CreateNewCustomer(string firstName, string lastName, decimal discount);
    }
}