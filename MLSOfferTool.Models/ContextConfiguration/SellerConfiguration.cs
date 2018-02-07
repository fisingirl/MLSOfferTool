using System.Data.Entity.ModelConfiguration;
using MLSOfferTool.Models;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.ContextConfiguration
{
    internal class SellerConfiguration : EntityTypeConfiguration<Seller>
    {
        public SellerConfiguration()
        {
            this.ToTable("Seller")
                .HasKey(x => x.Id);
        }
    }
}