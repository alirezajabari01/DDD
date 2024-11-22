using Microsoft.EntityFrameworkCore;
using Tactical.Framework.Persistence.EF;
using Tactical.Orders.Domain.Orders;
using Tactical.Orders.Domain.Vendors;
using Tactical.Orders.Persistence.EF.Vendors.EntityTypeConfigurations;

namespace Tactical.Orders.Persistence.EF.Contexts
{
    public class OrderContext : FrameworkContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VendorEntityTypeConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
