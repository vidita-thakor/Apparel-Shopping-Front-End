using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopping.Models.Mapping
{
    public class ProductImageMap : EntityTypeConfiguration<ProductImage>
    {
        public ProductImageMap()
        {
            // Primary Key
            this.HasKey(t => t.ImageId);

            // Properties
            this.Property(t => t.ImageTitle)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ImageAltText)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ImageName)
                .IsRequired()
                .HasMaxLength(200);

            // Table & Column Mappings
            this.ToTable("ProductImages");
            this.Property(t => t.ImageId).HasColumnName("ImageId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ImageTitle).HasColumnName("ImageTitle");
            this.Property(t => t.ImageAltText).HasColumnName("ImageAltText");
            this.Property(t => t.ImageName).HasColumnName("ImageName");
            this.Property(t => t.ImageIsMain).HasColumnName("ImageIsMain");
            this.Property(t => t.ImageCreated).HasColumnName("ImageCreated");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductImages)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
