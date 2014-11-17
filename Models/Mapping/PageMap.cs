using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Shopping.Models.Mapping
{
    public class PageMap : EntityTypeConfiguration<Page>
    {
        public PageMap()
        {
            // Primary Key
            this.HasKey(t => t.PageId);

            // Properties
            this.Property(t => t.PageTitle)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.PageUpdated)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion();

            // Table & Column Mappings
            this.ToTable("Pages");
            this.Property(t => t.PageId).HasColumnName("PageId");
            this.Property(t => t.PageTitle).HasColumnName("PageTitle");
            this.Property(t => t.PageDescription).HasColumnName("PageDescription");
            this.Property(t => t.PageCreated).HasColumnName("PageCreated");
            this.Property(t => t.PageUpdated).HasColumnName("PageUpdated");
        }
    }
}
