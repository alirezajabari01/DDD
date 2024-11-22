using Microsoft.EntityFrameworkCore;
using Tactical.Orders.Query.Contract.Toppings;
using Tactical.Orders.Query.DataModel.Models;
using Tactical.Orders.Query.Migrations.EF.Contexts;

namespace Tactical.Orders.Query.Retrieval.Toppings
{
    public class ToppingReadRepository : IToppingReadRepository
    {
        private readonly OrderReadContext _context;
        public ToppingReadRepository(OrderReadContext context)
        {
            _context = context;
        }

        public Task<List<Topping>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken)
        {
            return _context.Toppings.Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);
        }
    }
}