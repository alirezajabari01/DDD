namespace Tactical.Orders.Domain.Orders.Contracts
{
    public interface IOrderRepository
    {
        Task SaveChangesAsync(CancellationToken cancellationToken);
        Task CreateAsync(Order order, CancellationToken cancellationToken);
        Order GetById(Guid id);
        Task<Order?> GetByIdAsync(Guid id);
    }
}
