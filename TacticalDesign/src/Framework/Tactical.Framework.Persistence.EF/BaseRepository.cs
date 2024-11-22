using System.Linq.Expressions;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Tactical.Framework.Core.Abstractions;

namespace Tactical.Framework.Persistence.EF
{

    public abstract class BaseRepository<TAggregate, TKey> : IRepository<TAggregate, TKey> where TAggregate : Entity<TKey>
    {
        private readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public TAggregate? GetById(TKey id)
        {
            return _context.Set<TAggregate>().FirstOrDefault(x => x.Id.Equals(id));
        }
        public async Task<TAggregate?> GetByIdAsync(TKey id)
        {
            return await _context.Set<TAggregate>().FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public void SaveChanges(TAggregate aggregate)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(TAggregate aggregate, CancellationToken cancellationToken)
        {
            await _context.Set<TAggregate>().AddAsync(aggregate, cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        //protected virtual Expression<Func<TAggregate, object>>[]? GetIncludeExpressions() => null;

        //private IQueryable<TAggregate> ConvertToAggregate(IQueryable<TAggregate> set)
        //{
        //    var result = set;
        //    var includeExpressions = GetIncludeExpressions();

        //    if (includeExpressions != null)
        //    {
        //        foreach (var expression in includeExpressions)
        //        {
        //            result = result.Include(expression);
        //        }
        //    }

        //    return result;
        //}
    }

    //public interface IRepository { }
    public interface IRepository<TAggregate, TKey> where TAggregate : Entity<TKey>
    {
        void SaveChanges(TAggregate aggregate);
        void Delete();
        TAggregate? GetById(TKey id);

    }
}
