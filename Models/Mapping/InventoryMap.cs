using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopping.Models.Mapping
{
    public class InventoryMap : EntityTypeConfiguration<Inventory>
    {
        public InventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.InventoryId);

            // Properties
            // Table & Column Mappings
            this.ToTable("Inventories");
            this.Property(t => t.InventoryId).HasColumnName("InventoryId");
            this.Property(t => t.ProductId).HasColumnName("ProductId");
            this.Property(t => t.ParamSizeValueId).HasColumnName("ParamSizeValueId");
            this.Property(t => t.ParamColorValueId).HasColumnName("ParamColorValueId");
            this.Property(t => t.Quantity).HasColumnName("Quantity");

            // Relationships
            this.HasRequired(t => t.ParamValue)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.ParamColorValueId);
            this.HasRequired(t => t.ParamValue1)
                .WithMany(t => t.Inventories1)
                .HasForeignKey(d => d.ParamSizeValueId);
            this.HasRequired(t => t.Product)
                .WithMany(t => t.Inventories)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
