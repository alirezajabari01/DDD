namespace Tactical.Orders.Domain.Orders.Contracts
{
    public sealed record OrderItemToppingContract(Guid ToppingId, string Title, long Price);
   
}
