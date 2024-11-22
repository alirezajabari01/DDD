using Tactical.Orders.Query.DataModel.Models;

namespace Tactical.Orders.Query.Contract.MenuItems
{
    public interface IMenuItemReadRepository
    {
        List<MenuItem> GetByIds(List<Guid> ids);
        Task<List<MenuItem>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);

        Task<List<ItemPriceContract>> GetMenuWithToppingByIdsAsync(List<Guid> menuItemIds, List<Guid>? toppingIds, CancellationToken cancellationToken);
    }
}
