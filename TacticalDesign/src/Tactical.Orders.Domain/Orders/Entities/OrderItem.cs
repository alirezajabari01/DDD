using Tactical.Framework.Core.Abstractions;

namespace Tactical.Orders.Domain.Orders.Entities
{
    public class OrderItem : Entity<long>
    {
        public List<OrderItemTopping> _orderItemToppings;
        private OrderItem() { }
        public OrderItem(Guid menuItemId, string title, long price, int count = 1, List<OrderItemTopping>? orderItemToppings = null)
        {
            MenuItemId = menuItemId;
            Price = price;
            Title = title;
            Count = count;
            _orderItemToppings = orderItemToppings;
        }

        public Guid OrderId { get; private set; }
        public Guid MenuItemId { get; private set; }
        public long Price { get; private set; }
        public string Title { get; private set; }
        public int Count { get; private set; }
        public long Discount { get; private set; } = 0;
        public IReadOnlyCollection<OrderItemTopping> OrderItemToppings => _orderItemToppings;

        public void SetOrderId(Guid orderId)
        {
            OrderId = orderId;
        }

        public void SetCount(int count)
        {
            Count = count;
        }

        public void SetToppings(List<OrderItemTopping> orderItemToppings)
        {
            _orderItemToppings = orderItemToppings;
        }
    }
}
