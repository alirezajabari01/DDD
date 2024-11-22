using Microsoft.EntityFrameworkCore;
using Tactical.Orders.Query.DataModel.Models;

namespace Tactical.Orders.Query.Migrations.EF.Contexts
{
    public class OrderReadContext : DbContext
    {
        public OrderReadContext()
        {
        }

        public OrderReadContext(DbContextOptions<OrderReadContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MenuCategory> MenuCategories { get; set; }

        public virtual DbSet<MenuItem> MenuItems { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<OrderItemTopping> OrderItemToppings { get; set; }

        public virtual DbSet<OrderHistory> OrderHistories { get; set; }


        public virtual DbSet<ToppingCategory> ToppingCategories { get; set; }

        public virtual DbSet<Topping> Toppings { get; set; }

        public virtual DbSet<Vendor> Vendors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MenuCategory>().ToTable(nameof(MenuCategory));
            modelBuilder.Entity<MenuItem>().ToTable(nameof(MenuItem));
            modelBuilder.Entity<Order>().ToTable(nameof(Order));
            modelBuilder.Entity<OrderItem>().ToTable(nameof(OrderItem));
            modelBuilder.Entity<OrderHistory>().ToTable(nameof(OrderHistory));
            modelBuilder.Entity<OrderItemTopping>().ToTable(nameof(OrderItemTopping));
            modelBuilder.Entity<Topping>().ToTable(nameof(Topping));
            modelBuilder.Entity<ToppingCategory>().ToTable(nameof(ToppingCategory));
            modelBuilder.Entity<Vendor>().ToTable(nameof(Vendor));
            base.OnModelCreating(modelBuilder);
        }
    }
}
