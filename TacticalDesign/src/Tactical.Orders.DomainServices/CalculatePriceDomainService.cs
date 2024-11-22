using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Entities;
using Tactical.Orders.Query.Contract.MenuItems;

namespace Tactical.Orders.DomainServices
{
    public class CalculatePriceDomainService : ICalculatePriceDomainService
    {
        private readonly IMenuItemReadRepository _menuItemReadRepository;
        public CalculatePriceDomainService(IMenuItemReadRepository menuItemReadRepository)
        {
            _menuItemReadRepository = menuItemReadRepository;
        }

        public async Task<long> GetTotalItemPriceAsync(List<OrderItem> items, CancellationToken cancellationToken)
        {
            //var toppingIds = items.Where(x => x.OrderItemToppings != null).Select(x => x.Toppings?.Select(t => new { t.ToppingId, t.Count }).FirstOrDefault()).ToList();

            //var menuItemIds = items.ToDictionary(x => x.MenuItemId, y => y.Count);

            //var itemPriceContracts = await _menuItemReadRepository.GetMenuWithToppingByIdsAsync(menuItemIds.Keys.ToList(), toppingIds.Select(x => x.ToppingId).ToList(), cancellationToken);

            //itemPriceContracts.ForEach(f =>
            //{
            //    var currentTopping = toppingIds.FirstOrDefault(x => x.ToppingId == f.Id);
            //    if (currentTopping is not null)
            //        f.Count = currentTopping.Count;

            //    if (menuItemIds.ContainsKey(f.Id))
            //        f.Count = menuItemIds[f.Id];
            //});

            //var totalItemPrice = itemPriceContracts.Sum(i => i.Price * i.Count);

            //return totalItemPrice;
            return 0;
        }
    }
}
