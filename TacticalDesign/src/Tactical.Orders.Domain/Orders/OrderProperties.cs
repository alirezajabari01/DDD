using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Orders.Entities;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Domain.Orders
{
    public partial class Order
    {
        public List<OrderItem> OrderItems { get; private set; }
        public VendorId VendorId { get; private set; }
        public FinalPrice FinalPrice { get; private set; }
        public CustomerId CustomerId { get; private set; }
        public OrderStateEnum State { get; private set; }
        public CouponAmount CouponAmount { get; private set; }
        public ICollection<OrderHistory> OrderHistories { get; private set; } = new List<OrderHistory>();
        public ICollection<OrderTracking> OrderTrackings { get; private set; } = new List<OrderTracking>();
    }
}
