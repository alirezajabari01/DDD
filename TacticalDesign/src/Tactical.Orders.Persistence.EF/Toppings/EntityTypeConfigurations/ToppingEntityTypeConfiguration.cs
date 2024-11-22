using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tactical.Orders.Domain.Toppings;

namespace Tactical.Orders.Persistence.EF.Toppings.EntityTypeConfigurations
{
    public class ToppingEntityTypeConfiguration : IEntityTypeConfiguration<Topping>
    {
        public void Configure(EntityTypeBuilder<Topping> builder)
        {
            builder.ToTable(nameof(Topping));
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).ValueGeneratedNever();

        }
    }
}
