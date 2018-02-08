using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MLSOfferTool.ContextConfiguration;
using MLSOfferTool.Models;
using NSubstitute;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.TestDoubles
{
    public class FakeMlsOfferToolContext : IMlsOfferToolContext
    {
        public Guid InstanceId = Guid.NewGuid();

        public FakeMlsOfferToolContext()
        {
            IDbSet<Property> propertyDbSet = Substitute.For<IDbSet<Property>>();
            propertyDbSet.Provider.Returns(this.Properties.Provider);
            propertyDbSet.Expression.Returns(this.Properties.Expression);
            propertyDbSet.ElementType.Returns(this.Properties.ElementType);
            propertyDbSet.GetEnumerator().Returns(this.Properties.GetEnumerator());

            //https://blog.learningtree.com/mock-entity-frameworks-dbcontext-unit-testing/
        }

        public IDbSet<Buyer> Buyers { get; set; }
        public IDbSet<Offer> Offers { get; set; }
        public IDbSet<OfferStatus> OfferStatuses { get; set; }
        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Seller> Sellers { get; set; }
    }
}