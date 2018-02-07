using System.Data.Entity.ModelConfiguration;
using MLSOfferTool.Models;

// ReSharper disable once CheckNamespace
namespace MLSOfferTool.ContextConfiguration
{
    internal class PropertyConfiguration : EntityTypeConfiguration<Property>
    {
        public PropertyConfiguration()
        {
            this.ToTable("Property")
                .HasKey(x => x.Id)
                .HasOptional(x => x.PropertySeller);
        }
    }
}