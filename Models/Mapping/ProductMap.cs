using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopping.Models.Mapping
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductId);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.ProductShortDescription)
                .HasMaxLength(200);

            this.Property(t => t.ProductUrl)
                .HasMaxLength(256);

            this.Property(t => t.ProductUpdated)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("Products");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.CategoryId).HasColumnName("CategoryId");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.ProductShortDescription).HasColumnName("ProductShortDescription");
            this.Property(t => t.ProductLongDescription).HasColumnName("ProductLongDescription");
            this.Property(t => t.ProductUrl).HasColumnName("ProductUrl");
            this.Property(t => t.ProductPrice).HasColumnName("ProductPrice");
            this.Property(t => t.ProductDeliveryTxt).HasColumnName("ProductDeliveryTxt");
            this.Property(t => t.ProductReturnsTxt).HasColumnName("ProductReturnsTxt");
            this.Property(t => t.ProductInfoCareTxt).HasColumnName("ProductInfoCareTxt");
            this.Property(t => t.ProductCreated).HasColumnName("ProductCreated");
            this.Property(t => t.ProductUpdated).HasColumnName("ProductUpdated");
        }
    }
}
