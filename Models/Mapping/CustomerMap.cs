using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopping.Models.Mapping
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            // Primary Key
            this.HasKey(t => t.CustomerId);

            // Properties
            this.Property(t => t.CustomerFirstName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CustomerLastName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.CustomerEmail)
                .IsRequired()
                .HasMaxLength(160);

            this.Property(t => t.CustomerPhone)
                .HasMaxLength(50);

            this.Property(t => t.CustomerHomePhone)
                .HasMaxLength(50);

            this.Property(t => t.CustomerAddress)
                .HasMaxLength(200);

            this.Property(t => t.CustomerCity)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CustomerState)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CustomerZip)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CustomerCountry)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShippingAddress)
                .IsRequired();

            this.Property(t => t.ShippingCity)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShippingState)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShippingZip)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.ShippingCountry)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.CustomerUpdated)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("Customers");
            this.Property(t => t.CustomerId).HasColumnName("CustomerId");
            this.Property(t => t.UserId).HasColumnName("UserId");
            this.Property(t => t.CustomerFirstName).HasColumnName("CustomerFirstName");
            this.Property(t => t.CustomerLastName).HasColumnName("CustomerLastName");
            this.Property(t => t.CustomerEmail).HasColumnName("CustomerEmail");
            this.Property(t => t.CustomerPhone).HasColumnName("CustomerPhone");
            this.Property(t => t.CustomerHomePhone).HasColumnName("CustomerHomePhone");
            this.Property(t => t.CustomerAddress).HasColumnName("CustomerAddress");
            this.Property(t => t.CustomerCity).HasColumnName("CustomerCity");
            this.Property(t => t.CustomerState).HasColumnName("CustomerState");
            this.Property(t => t.CustomerZip).HasColumnName("CustomerZip");
            this.Property(t => t.CustomerCountry).HasColumnName("CustomerCountry");
            this.Property(t => t.ShippingAddress).HasColumnName("ShippingAddress");
            this.Property(t => t.ShippingCity).HasColumnName("ShippingCity");
            this.Property(t => t.ShippingState).HasColumnName("ShippingState");
            this.Property(t => t.ShippingZip).HasColumnName("ShippingZip");
            this.Property(t => t.ShippingCountry).HasColumnName("ShippingCountry");
            this.Property(t => t.CustomerCreated).HasColumnName("CustomerCreated");
            this.Property(t => t.CustomerUpdated).HasColumnName("CustomerUpdated");

            // Relationships
            this.HasRequired(t => t.UserProfile)
                .WithMany(t => t.Customers)
                .HasForeignKey(d => d.UserId);

        }
    }
}
