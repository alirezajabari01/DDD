using Microsoft.EntityFrameworkCore;
using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Persistence.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FrameworkContext context;
        public UnitOfWork(FrameworkContext context)
        {
            this.context = context;
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default) => await context.SaveChangesAsync(cancellationToken);
    }
}
