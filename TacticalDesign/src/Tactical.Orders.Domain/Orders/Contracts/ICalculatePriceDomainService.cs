using Tactical.Framework.Domain.DomainAbstractions;
using Tactical.Orders.Domain.Orders.Entities;

namespace Tactical.Orders.Domain.Orders.Contracts
{
    public interface ICalculatePriceDomainService : IDomainService
    {
        Task<long> GetTotalItemPriceAsync(List<OrderItem> items,CancellationToken cancellationToken);
    }

    public interface IMenuItemDomainService : IDomainService
    {
        Task<List<OrderItem>> GetOrderItemAsync(List<Guid> ids, CancellationToken cancellationToken);
    }

    public interface IToppingDomainService : IDomainService
    {
        Task<List<OrderItemToppingContract>> GetToppingAsync(List<Guid> ids, CancellationToken cancellationToken);
    }
}
