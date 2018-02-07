using System.Data.Entity.ModelConfiguration;
using MLSOfferTool.Models;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.ContextConfiguration
{
    internal class BuyerConfiguration : EntityTypeConfiguration<Buyer>
    {
        public BuyerConfiguration()
        {
            this.ToTable("Buyer")
                .HasKey(x => x.Id);
        }
    }
}