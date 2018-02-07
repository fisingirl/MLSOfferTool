using System.Data.Entity.ModelConfiguration;
using MLSOfferTool.Models;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.ContextConfiguration
{
    internal class OfferStatusConfiguration : EntityTypeConfiguration<OfferStatus>
    {
        public OfferStatusConfiguration()
        {
            this.ToTable("OfferStatus")
                .HasKey(x => x.Id);
        }
    }
}