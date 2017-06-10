using System.Collections.Generic;

using MAutoSS.DataModels;
using MAutoSS.Data.Repositories.Contracts;
using MAutoSS.Services.Contracts;
using Bytes2you.Validation;
using System.Linq;
using System;

namespace MAutoSS.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IGenericRepository<Employee> employeeRepo;
        private IDealershipService dealershipService;

        public EmployeeService(
            IGenericRepository<Employee> employeeRepo,
            IDealershipService dealershipService)
        {
            Guard.WhenArgument(employeeRepo, "employeeRepo").IsNull().Throw();
            Guard.WhenArgument(dealershipService, "dealershipService").IsNull().Throw();
            
            this.employeeRepo = employeeRepo;
            this.dealershipService = dealershipService;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return this.employeeRepo.GetAll();
        }

        public Employee GetEmployeeById(int id)
        {
            return this.employeeRepo.GetAll().FirstOrDefault(x => x.Id == id);
        }

        public void CreateNewEmployee(string firstName, string lastName, string dealershipName)
        {
            var dealershipToAssignEmployee = this.dealershipService.GetDealershipByName(dealershipName);

            var newEmployee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                DealershipId = dealershipToAssignEmployee.Id
            };
            
            this.employeeRepo.Add(newEmployee);
            this.employeeRepo.SaveChanges();        
        }

        public void EditEmployee(int employeeId, string firstName, string lastName, string dealershipName)
        {
            var employeeForEdit = this.GetEmployeeById(employeeId);

            var dealershipAttachTo = this.dealershipService.GetDealershipByName(dealershipName);

            employeeForEdit.FirstName = firstName;
            employeeForEdit.LastName = lastName;
            employeeForEdit.Dealership= dealershipAttachTo;

            this.employeeRepo.Update(employeeForEdit);
            this.employeeRepo.SaveChanges();
        }
    }
}
