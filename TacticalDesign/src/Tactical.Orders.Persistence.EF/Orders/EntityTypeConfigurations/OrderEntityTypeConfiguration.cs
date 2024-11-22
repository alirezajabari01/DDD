using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Orders;
using Tactical.Orders.Domain.Orders.Entities;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Persistence.EF.Orders.EntityTypeConfigurations
{
    public class OrderEntityTypeConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.Property(p => p.State).HasDefaultValue(OrderStateEnum.Submitted).IsRequired();

            builder.OwnsOne(o => o.VendorId, p =>
            {
                p.Property(v => v.Value).HasColumnName(nameof(VendorId));
            });

            builder.OwnsOne(o => o.CustomerId, p =>
            {
                p.Property(v => v.Value).HasColumnName(nameof(CustomerId));
            });

            builder.OwnsOne(o => o.FinalPrice, p =>
            {
                p.Property(v => v.Value).HasColumnName(nameof(FinalPrice));
            });

            builder.OwnsOne(o => o.CouponAmount, p =>
            {
                p.Property(v => v.Value).HasColumnName(nameof(CouponAmount));
            });

            ConfigOrderItem(builder);

            ConfigHistory(builder);

            builder.OwnsMany(o => o.OrderTrackings, p =>
            {
                p.ToTable(nameof(OrderTracking));
                p.WithOwner().HasForeignKey(x => x.OrderId);
            });
        }

        private static void ConfigOrderItem(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsMany(o => o.OrderItems, p =>
            {
                p.ToTable(nameof(OrderItem));
                p.HasKey(k => k.Id);
                p.Property(p => p.Id);
                p.WithOwner().HasForeignKey(x => x.OrderId);

                p.OwnsMany(o => o.OrderItemToppings, z =>
                {
                    z.ToTable(nameof(OrderItemTopping));
                    z.HasKey(k => k.Id);
                    z.Property(p => p.Id);
                    z.WithOwner().HasForeignKey(x => x.OrderItemId);
                });
            });
        }

        private static void ConfigHistory(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsMany(o => o.OrderHistories, p =>
            {
                p.ToTable(nameof(OrderHistory));
                p.HasKey(k => k.Id);
                p.Property(p => p.Id);
                p.WithOwner().HasForeignKey(x => x.OrderId);

                p.OwnsOne(o => o.State, p =>
                {
                    p.Property(v => v.State).HasColumnName(nameof(OrderState.State));
                });
            });
        }
    }
}
