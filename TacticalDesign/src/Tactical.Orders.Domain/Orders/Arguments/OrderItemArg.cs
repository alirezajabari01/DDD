namespace Tactical.Orders.Domain.Orders.Arguments
{
    public record OrderItemArg()
    {
        public Guid ItemId { get; set; }
        public int Count { get; set; }
        public List<OrderToppingArg>? Toppings { get; set; }
    }

    public record OrderToppingArg()
    {
        public Guid ToppingId { get; set; }
        public int Count { get; set; }
    }
}
