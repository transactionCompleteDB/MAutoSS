using MAutoSS.DataModels;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();

        void CreateNewEmployee(string firstName, string lastName, string dealershipName);
    }
}
