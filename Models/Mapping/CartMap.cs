using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopping.Models.Mapping
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            // Primary Key
            this.HasKey(t => t.CartSerialId);

            // Properties
            this.Property(t => t.Cart_id)
                .IsRequired()
                .HasMaxLength(250);

            // Table & Column Mappings
            this.ToTable("Cart");
            this.Property(t => t.CartSerialId).HasColumnName("CartSerialId");
            this.Property(t => t.Cart_id).HasColumnName("Cart_id");
            this.Property(t => t.InventoryId).HasColumnName("InventoryId");
            this.Property(t => t.Count).HasColumnName("Count");

            // Relationships
            this.HasRequired(t => t.Inventory)
                .WithMany(t => t.Carts)
                .HasForeignKey(d => d.InventoryId);

        }
    }
}
