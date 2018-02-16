using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLSOfferTool.Controllers;
using MLSOfferTool.Models;
using MLSOfferTool.Services.Fakes;

namespace MLSOfferTool.Web.Tests.Controllers
{
    [TestClass]
    public class PropertyDataControllerTests
    {
        [TestMethod]
        public void GetAll_ReturnsResult()
        {
            //Arrange
            var stubIPropertyDataService = new StubIPropertyDataService()
                                           {
                                               GetAll = () => new List<PropertyDto>()
                                                              {
                                                                  new PropertyDto()
                                                                  {
                                                                      Id = 1,
                                                                      City = "Houston",
                                                                      ZipCode = "78523",
                                                                  }
                                                              }
            };

            //Act
            var sut = new PropertyDataController(stubIPropertyDataService);
            var actual = sut.GetAll();

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreSame(actual.GetType(), typeof(JsonResult));
        }

        [TestMethod]
        public void GetProperty_ValidParameter_ReturnsResult()
        {
            //Arrange
            var stubIPropertyDataService = new StubIPropertyDataService()
                                           {
                                               GetByIdInt32 = (propertyId) => new Property()
                                                                              {
                                                                                  Id = 1,
                                                                                  Address1 = "4567 Lakeshore Dr.",
                                                                                  Address2 = "",
                                                                                  City = "Houston",
                                                                                  State = "Texas",
                                                                                  ZipCode = "78523",
                                                                                  PropertySeller = new Seller()
                                                                                                   {
                                                                                                       Id = 2,
                                                                                                       FirstName = "John",
                                                                                                       LastName = "Doe"
                                                                                                   }
                                                                              }
            };

            //Act
            var sut = new PropertyDataController(stubIPropertyDataService);
            var actual = sut.GetProperty(1);

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreSame(actual.GetType(), typeof(JsonResult));
        }
    }
}
