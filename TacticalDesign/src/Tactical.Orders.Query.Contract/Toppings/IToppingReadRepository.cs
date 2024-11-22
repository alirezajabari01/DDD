using Tactical.Orders.Query.DataModel.Models;

namespace Tactical.Orders.Query.Contract.Toppings
{
    public interface IToppingReadRepository
    {
        Task<List<Topping>> GetByIdsAsync(List<Guid> ids, CancellationToken cancellationToken);
    }
}
