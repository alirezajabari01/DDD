using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Orders.Domain.Orders;
using Tactical.Orders.Domain.Vendors;

namespace Tactical.Orders.Persistence.EF.Vendors.EntityTypeConfigurations
{
    internal class VendorEntityTypeConfiguration : IEntityTypeConfiguration<Vendor>
    {
        public void Configure(EntityTypeBuilder<Vendor> builder)
        {
            builder.ToTable(nameof(Vendor));

            builder.Property(p => p.Id).ValueGeneratedNever();

           // builder.HasMany(typeof(Order)).WithOne().HasForeignKey(nameof(Order.VendorId));
        }
    }
}
