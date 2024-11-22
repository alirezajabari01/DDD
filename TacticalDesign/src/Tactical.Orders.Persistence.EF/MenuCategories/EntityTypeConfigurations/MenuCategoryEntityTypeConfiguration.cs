using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Orders.Domain.MenuCategories;
using Tactical.Orders.Domain.MenuItems;

namespace Tactical.Orders.Persistence.EF.MenuCategories.EntityTypeConfigurations
{
    public class MenuCategoryEntityTypeConfiguration : IEntityTypeConfiguration<MenuCategory>
    {
        public void Configure(EntityTypeBuilder<MenuCategory> builder)
        {
            builder.ToTable(nameof(MenuCategory));
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.HasMany(typeof(MenuItem)).WithOne().HasForeignKey(nameof(MenuItem.MenuCategoryId));
        }
    }
}
