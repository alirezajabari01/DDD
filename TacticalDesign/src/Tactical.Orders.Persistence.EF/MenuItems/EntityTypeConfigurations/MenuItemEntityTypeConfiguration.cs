using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Orders.Domain.MenuItems;

namespace Tactical.Orders.Persistence.EF.MenuItems.EntityTypeConfigurations
{
    public class MenuItemEntityTypeConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.ToTable(nameof(MenuItem));
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id);
        }
    }
}
