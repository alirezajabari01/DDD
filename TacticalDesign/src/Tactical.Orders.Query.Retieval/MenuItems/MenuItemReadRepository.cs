using Microsoft.EntityFrameworkCore;
using Tactical.Orders.Query.Contract.MenuItems;
using Tactical.Orders.Query.DataModel.Models;
using Tactical.Orders.Query.Migrations.EF.Contexts;

namespace Tactical.Orders.Query.Retrieval.MenuItems
{
    public class MenuItemReadRepository : IMenuItemReadRepository
    {
        private OrderReadContext _context;
        public MenuItemReadRepository(OrderReadContext context)
        {
            _context = context;
        }

        public List<MenuItem> GetByIds(List<Guid> ids)
        {
            return _context.MenuItems.Where(x => ids.Contains(x.Id)).ToList();
        }

        public Task<List<MenuItem>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken)
        {
            return _context.MenuItems.Where(x => ids.Contains(x.Id)).ToListAsync(cancellationToken);
        }

        public Task<List<ItemPriceContract>> GetMenuWithToppingByIdsAsync(List<Guid> menuItemIds, List<Guid>? toppingIds, CancellationToken cancellationToken)
        {
            var result = _context.MenuItems.Where(x => menuItemIds.Contains(x.Id)).Select(x => new ItemPriceContract
            {
                Id = x.Id,
                Price = x.Price,

            }).Union(
                 _context.Toppings.Where(x => toppingIds != null && toppingIds.Contains(x.Id)).Select(x => new ItemPriceContract
                 {
                     Id = x.Id,
                     Price = x.Price,

                 })
                ).ToListAsync(cancellationToken);


            return result;
        }
    }
}
