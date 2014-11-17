using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Shopping.Models.Mapping;

namespace Shopping.Models
{
    public partial class ApparelShoppingContext : DbContext
    {
        static ApparelShoppingContext()
        {
            Database.SetInitializer<ApparelShoppingContext>(null);
        }

        public ApparelShoppingContext()
            : base("Name=ApparelShoppingContext")
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Page> Pages { get; set; }
        public DbSet<ParamValue> ParamValues { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductParam> ProductParams { get; set; }
        public DbSet<Product> Products { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new InventoryMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new PageMap());
            modelBuilder.Configurations.Add(new ParamValueMap());
            modelBuilder.Configurations.Add(new ProductImageMap());
            modelBuilder.Configurations.Add(new ProductParamMap());
            modelBuilder.Configurations.Add(new ProductMap());
            
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
