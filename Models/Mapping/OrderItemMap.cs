using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopping.Models.Mapping
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderItemId);

            // Properties
            // Table & Column Mappings
            this.ToTable("OrderItems");
            this.Property(t => t.OrderItemId).HasColumnName("OrderItemId");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.InventoryId).HasColumnName("InventoryId");
            this.Property(t => t.ItemQuantity).HasColumnName("ItemQuantity");
            this.Property(t => t.ItemUnitPrice).HasColumnName("ItemUnitPrice");
            this.Property(t => t.ItemSubtotal).HasColumnName("ItemSubtotal");

            // Relationships
            this.HasRequired(t => t.Inventory)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(d => d.InventoryId);
            this.HasRequired(t => t.Order)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(d => d.OrderId);

        }
    }
}
