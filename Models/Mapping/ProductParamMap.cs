using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopping.Models.Mapping
{
    public class ProductParamMap : EntityTypeConfiguration<ProductParam>
    {
        public ProductParamMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductParamId);

            // Properties
            this.Property(t => t.ProductParamName)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("ProductParams");
            this.Property(t => t.ProductParamId).HasColumnName("ProductParamId");
            this.Property(t => t.ProductParamName).HasColumnName("ProductParamName");
            this.Property(t => t.ProductParamDescription).HasColumnName("ProductParamDescription");
        }
    }
}
