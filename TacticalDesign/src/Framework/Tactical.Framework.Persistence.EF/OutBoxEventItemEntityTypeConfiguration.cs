using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Tactical.Framework.Persistence.EF
{
    internal class OutBoxEventItemEntityTypeConfiguration : IEntityTypeConfiguration<OutBoxEventItem>
    {
        public void Configure(EntityTypeBuilder<OutBoxEventItem> builder)
        {
            builder.ToTable(nameof(OutBoxEventItem));

            builder.HasKey(e => e.Id);
            builder.Property(p => p.EventName).HasMaxLength(256);
            builder.Property(p => p.EventType).HasMaxLength(256);
            builder.Property(p => p.AggregateName).HasMaxLength(256);
            builder.Property(p => p.AggregateType).HasMaxLength(256);
        }
    }
}
