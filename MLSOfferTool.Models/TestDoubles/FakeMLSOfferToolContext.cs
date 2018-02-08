using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MLSOfferTool.ContextConfiguration;
using MLSOfferTool.Helpers;
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
            this.Buyers = new FakeDbSet<Buyer>();
            this.Offers = new FakeDbSet<Offer>();
            this.OfferStatuses = new FakeDbSet<OfferStatus>();
            this.Properties = new FakeDbSet<Property>();
            this.Sellers = new FakeDbSet<Seller>();
        }

        public IDbSet<Buyer> Buyers { get; set; }
        public IDbSet<Offer> Offers { get; set; }
        public IDbSet<OfferStatus> OfferStatuses { get; set; }
        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Seller> Sellers { get; set; }
    }
}