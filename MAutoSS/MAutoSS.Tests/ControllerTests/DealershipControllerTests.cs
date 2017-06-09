using MAutoSS.Services.Contracts;
using MAutoSS.Web.Controllers;
using MAutoSS.Web.Models.Address;
using MAutoSS.Web.Models.Dealership;
using Moq;
using NUnit.Framework;
using System;
using Telerik.JustMock;

namespace MAutoSS.Tests.ControllerTests
{
    [TestFixture]
    public class DealershipControllerTests
    {
        [Test]
        public void CreateNewDealership_ShouldNotCall_serviceCreateNewDealership_WhenNoPassedParam()
        {
            //arrange
            var dealershipService = new Mock<IDealershipService>();
            var dealershipsController = new DealershipsController(dealershipService.Object);

            //act
            dealershipsController.CreateNewDealership();

            //assert
            dealershipService.Verify(x => x.CreateNewDealership(null, null, null, null), Times.Never);
        }

        [Test]
        public void CreateNewDealership_ShouldThrow_WhenNoPassedParamIsNull()
        {
            //arrange
            var dealershipService = new Mock<IDealershipService>();
            var dealershipsController = new DealershipsController(dealershipService.Object);

            //act & assert
            Assert.Throws<ArgumentNullException>(delegate { dealershipsController.CreateNewDealership(null); });
        }


        //These TESTs requires unconstrained version of a Mocking tool:

        //[Test]
        //public void CreateNewDealership_ShouldNotThrow_WhenNoPassedParamIsNotNull()
        //{
        //    //arrange
        //    var dealershipService = new Mock<IDealershipService>();
        //    var dealershipInputModel = new Mock<DealershipInputModel>();

        //    var dealershipsController = new DealershipsController(dealershipService.Object);

        //    //act

        //    //assert
        //    Assert.DoesNotThrow(delegate { dealershipsController.CreateNewDealership(dealershipInputModel.Object); });
        //}

        //[Test]
        //public void CreateNewDealership_ShouldCall_WhenThePassedParamIsValid()
        //{
        //    //arrange
        //    var dealershipService = Telerik.JustMock.Mock.Create<IDealershipService>();
        //    var dealershipInputModel = Telerik.JustMock.Mock.Create<DealershipInputModel>();
        //    var addressMock = Telerik.JustMock.Mock.Create<AddressViewModel>();

        //    Telerik.JustMock.Mock.Arrange(() => dealershipInputModel.Address).Returns(addressMock);
        //    Telerik.JustMock.Mock.Arrange(() => dealershipInputModel.Address.AddressText).Returns("Basic Addres Text");
        //    Telerik.JustMock.Mock.Arrange(() => dealershipInputModel.Address.City).Returns(new Web.Models.City.CityViewModel());
        //    Telerik.JustMock.Mock.Arrange(() => dealershipInputModel.Address.City.Name).Returns("Basic City Text");
        //    Telerik.JustMock.Mock.Arrange(() => dealershipInputModel.Address.City.Country.Name).Returns("Basic Country name Text");

        //    var dealershipsController = new DealershipsController(dealershipService);

        //    //act
        //    dealershipsController.CreateNewDealership(dealershipInputModel);

        //    //
        //    Telerik.JustMock.Mock.Assert(() => dealershipService.CreateNewDealership(null, null, null, null), Occurs.Once());
        //}
    }
}
