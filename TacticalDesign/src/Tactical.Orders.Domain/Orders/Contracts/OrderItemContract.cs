namespace Tactical.Orders.Domain.Orders.Contracts
{
    public class OrderItemContract
    {
        public Guid ItemId { get; set; }
        public int Count { get; set; }
        public List<OrderToppingContract>? Toppings { get; set; }
    }
    public record OrderToppingContract()
    {
        public Guid ToppingId { get; set; }
        public int Count { get; set; }
    }
}