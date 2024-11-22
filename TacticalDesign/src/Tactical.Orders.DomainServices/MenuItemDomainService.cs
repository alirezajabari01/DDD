using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Entities;
using Tactical.Orders.Query.Contract.MenuItems;
using Tactical.Orders.Query.Contract.Toppings;

namespace Tactical.Orders.DomainServices
{
    public class MenuItemDomainService : IMenuItemDomainService
    {
        private readonly IMenuItemReadRepository _menuItemReadRepository;
        public MenuItemDomainService(IMenuItemReadRepository menuItemReadRepository)
        {
            _menuItemReadRepository = menuItemReadRepository;
        }

        public async Task<List<OrderItem>> GetOrderItemAsync(List<Guid> ids, CancellationToken cancellationToken)
        {
            var menuItems = await _menuItemReadRepository.GetByIdsAsync(ids, cancellationToken);

            return menuItems.Select(mi => new OrderItem(mi.Id, mi.Title, mi.Price)).ToList();
        }
    }

    public class ToppingDomainService : IToppingDomainService
    {
        private readonly IToppingReadRepository _toppingReadRepository;
        public ToppingDomainService(IToppingReadRepository toppingReadRepository)
        {
            _toppingReadRepository = toppingReadRepository;
        }

        public async Task<List<OrderItemToppingContract>> GetToppingAsync(List<Guid> ids, CancellationToken cancellationToken)
        {
            var toppings = await _toppingReadRepository.GetByIdsAsync(ids, cancellationToken);

            return toppings.Select(mi => new OrderItemToppingContract(mi.Id, mi.Title, mi.Price)).ToList();
        }
    }
}
