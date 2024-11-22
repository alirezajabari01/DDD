using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Orders.Domain.ToppingCategories;
using Tactical.Orders.Domain.Toppings;

namespace Tactical.Orders.Persistence.EF.ToppingCategories.EntityTypeConfigurations
{
    public class ToppingCategoryEntityTypeConfiguration : IEntityTypeConfiguration<ToppingCategory>
    {
        public void Configure(EntityTypeBuilder<ToppingCategory> builder)
        {
            builder.ToTable(nameof(ToppingCategory));
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();

            builder.HasMany(typeof(Topping)).WithOne().HasForeignKey(nameof(Topping.ToppingCategoryId));
        }
    }
}
