using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopping.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderId);

            // Properties
            this.Property(t => t.OrderStatus)
                .HasMaxLength(50);

            this.Property(t => t.OrderTransactionId)
                .HasMaxLength(200);

            this.Property(t => t.OrderPaymentStatus)
                .HasMaxLength(200);

            this.Property(t => t.OrderUpdated)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("Orders");
            this.Property(t => t.OrderId).HasColumnName("OrderId");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.OrderSubtotal).HasColumnName("OrderSubtotal");
            this.Property(t => t.OrderShippingCharges).HasColumnName("OrderShippingCharges");
            this.Property(t => t.OrderTaxes).HasColumnName("OrderTaxes");
            this.Property(t => t.OrderTotal).HasColumnName("OrderTotal");
            this.Property(t => t.OrderStatus).HasColumnName("OrderStatus");
            this.Property(t => t.OrderTransactionId).HasColumnName("OrderTransactionId");
            this.Property(t => t.OrderPaymentStatus).HasColumnName("OrderPaymentStatus");
            this.Property(t => t.OrderShippedDate).HasColumnName("OrderShippedDate");
            this.Property(t => t.OrderCreated).HasColumnName("OrderCreated");
            this.Property(t => t.OrderUpdated).HasColumnName("OrderUpdated");

            // Relationships
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.CustomerId);

        }
    }
}
