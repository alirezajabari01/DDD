namespace Tactical.Orders.Query.DataModel.Models;

public class OrderTracking
{
    public long Id { get; set; }
    public Guid OrderId { get; private set; }
    public string Content { get; private set; }
    public DateTime CreateDate { get; private set; }
    public Order Order { get; private set; }
}
