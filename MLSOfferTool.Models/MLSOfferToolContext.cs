using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MLSOfferTool.ContextConfiguration;
using MLSOfferTool.Models;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool
{
    public interface IMlsOfferToolContext
    {
        IDbSet<Buyer> Buyers { get; set; }
        IDbSet<Offer> Offers { get; set; }
        IDbSet<OfferStatus> OfferStatuses { get; set; }
        IDbSet<Property> Properties { get; set; }
        IDbSet<Seller> Sellers { get; set; }
    }

    public class MlsOfferToolContext : DbContext, IMlsOfferToolContext
    {
        public MlsOfferToolContext()
        {
        }

        public IDbSet<Buyer> Buyers { get; set; }
        public IDbSet<Offer> Offers { get; set; }
        public IDbSet<OfferStatus> OfferStatuses { get; set; }
        public IDbSet<Property> Properties { get; set; }
        public IDbSet<Seller> Sellers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<MlsOfferToolContext>(null);

            modelBuilder.Configurations.Add(new BuyerConfiguration());
            modelBuilder.Configurations.Add(new OfferConfiguration());
            modelBuilder.Configurations.Add(new OfferStatusConfiguration());
            modelBuilder.Configurations.Add(new PropertyConfiguration());
            modelBuilder.Configurations.Add(new SellerConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        //public int DeleteProperties()
        //{
        //    return this.Database.ExecuteSqlCommand("DeleteProperties");
        //}
    }
}