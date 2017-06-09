using MAutoSS.Services.Contracts;
using MAutoSS.Web.Controllers;
using Moq;
using NUnit.Framework;
using System;

namespace MAutoSS.Tests.ControllerTests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void CreateNewEmployee_ShouldThrow_WhenNoPassedParamIsNull()
        {
            //arrange
            var employeeService = new Mock<IEmployeeService>();
            var dealershipService = new Mock<IDealershipService>();

            var employeeController = new EmployeeController(employeeService.Object, dealershipService.Object);

            //act

            //assert
            Assert.Throws<ArgumentNullException>(delegate { employeeController.CreateNewEmployee(null); });
        }
    }
}
