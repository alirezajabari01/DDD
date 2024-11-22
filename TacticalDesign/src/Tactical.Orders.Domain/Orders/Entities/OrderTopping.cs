using Tactical.Framework.Core.Abstractions;

namespace Tactical.Orders.Domain.Orders.Entities
{
    public class OrderItemTopping : Entity<long>
    {
        public OrderItemTopping(Guid toppingId, string title, long price, int count)
        {
            ToppingId = toppingId;
            Title = title;
            Price = price;
            Count = count;
        }

        public long OrderItemId { get; private set; }
        public Guid ToppingId { get;private set; }
        public string Title { get; private set; } = null!;
        public long Price { get; private  set; }
        public int Count { get; private set; }
    }
}
