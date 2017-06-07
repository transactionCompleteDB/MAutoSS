using System.Collections.Generic;

using MAutoSS.DataModels;
using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.Services.Contracts;
using System;

namespace MAutoSS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IGenericRepository<Employee> employeeRepo;
        private IGenericRepository<Dealership> dealershipRepo;
        private IDealershipService dealershipService;

        public EmployeeService(
            IGenericRepository<Employee> employeeRepo, 
            IGenericRepository<Dealership> dealershipRepo,
            IDealershipService dealershipService)
        {
            this.employeeRepo = employeeRepo;
            this.dealershipRepo = dealershipRepo;
            this.dealershipService = dealershipService;
        }

        IEnumerable<Employee> IEmployeeService.GetAllEmployees()
        {
            return this.employeeRepo.GetAll();
        }

        public void CreateNewEmployee(string firstName, string lastName, string dealershipName)
        {
            var dealershipToAssignEmployee = this.dealershipService.GetDealershipIdByName(dealershipName);

            var newEmployee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                DealershipId = dealershipToAssignEmployee.Id
            };

            this.employeeRepo.Add(newEmployee);
            this.employeeRepo.SaveChanges();
        }
    }
}
