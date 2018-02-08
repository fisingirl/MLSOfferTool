using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MLSOfferTool.Models;
using MLSOfferTool.TestDoubles;
using Should;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.Services.Tests
{
    [TestClass]
    public class PropertyDataServiceTests
    {
        [TestMethod]
        public void GetAll_ReturnsRecords()
        {
            var fakeContext = new FakeMlsOfferToolContext();
            fakeContext.Properties.Add(new Property()
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
                                       });

            var sut = new PropertyDataService(fakeContext);
            var actual = sut.GetAll();
            actual.ShouldNotBeNull();
            actual.Count().ShouldEqual(1);
        }
    }
}
