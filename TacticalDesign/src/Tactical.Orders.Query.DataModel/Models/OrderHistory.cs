using Tactical.Orders.Domain.Contract.Enums;

namespace Tactical.Orders.Query.DataModel.Models;

public class OrderHistory
{
    public long Id { get; set; }
    public OrderStateEnum State { get; set; }
    public Guid OrderId { get;  set; }
    public Order Order { get;  set; }
    public DateTime CreateDate { get; set; }
}
