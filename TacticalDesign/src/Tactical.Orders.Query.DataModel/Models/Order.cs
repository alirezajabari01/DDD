using Tactical.Orders.Domain.Contract.Enums;

namespace Tactical.Orders.Query.DataModel.Models;

public class Order
{
    public Guid Id { get; set; }

    public long VendorId { get; set; }

    public long FinalPrice { get; set; }

    public long CustomerId { get; set; }
    public long CouponAmount { get; set; }

    public DateTime CreateDate { get; set; }
    public OrderStateEnum State { get; set; }
    public Vendor Vendor { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new HashSet<OrderItem>();

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new HashSet<OrderHistory>();
    public virtual ICollection<OrderTracking> OrderTracking { get; set; } = new HashSet<OrderTracking>();
}
