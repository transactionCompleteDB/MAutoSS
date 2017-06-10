using MAutoSS.DataModels;
using System.Collections.Generic;

namespace MAutoSS.Services.Contracts
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();

        Employee GetEmployeeById(int id);

        void CreateNewEmployee(string firstName, string lastName, string dealershipName);

        void EditEmployee(int employeeId, string firstName, string lastName, string dealershipName);

        void DeleteEmployee(int employeeId);
    }
}
