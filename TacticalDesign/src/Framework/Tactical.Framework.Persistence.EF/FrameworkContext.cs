using Microsoft.EntityFrameworkCore;
using System.Linq;
using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Persistence.EF
{
    public class FrameworkContext : DbContext
    {
        public FrameworkContext(DbContextOptions options) : base(options)
        {
            SaveDomainEvent = true;
        }

        public DbSet<OutBoxEventItem> OutBoxEventItem { get; set; }
        protected bool SaveDomainEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (SaveDomainEvent)
                modelBuilder.ApplyConfiguration(new OutBoxEventItemEntityTypeConfiguration());
            else
                modelBuilder.Ignore<OutBoxEventItem>();

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaveChangesActions();

            return base.SaveChangesAsync(cancellationToken);
        }

        private void BeforeSaveChangesActions()
        {
            if (SaveDomainEvent)
            {
                var aggregateRoots = ChangeTracker.Entries<IAggregateRoot>()
                     .Where(x => x.State != EntityState.Detached)
                     .Select(a => a.Entity)
                     .Where(e => e.GetAllQueuedEvents().Any()).ToList();

                var domainEvents = aggregateRoots.SelectMany(a => OutBoxEventItemFactory.Create(a)).ToList();
                Set<OutBoxEventItem>().AddRange(domainEvents);
            }
        }
    }
}
