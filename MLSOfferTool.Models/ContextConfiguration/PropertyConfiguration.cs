using System.Data.Entity.ModelConfiguration;
using MLSOfferTool.Models;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.ContextConfiguration
{
    internal class OfferConfiguration : EntityTypeConfiguration<Offer>
    {
        public OfferConfiguration()
        {
            this.ToTable("Offer")
                .HasKey(x => x.Id);
        }
    }
}