using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Orders.Domain.Orders.ValueObjects
{
    public class OrderTracking : ValueObject<OrderTracking>
    {
        private OrderTracking() { }
        public OrderTracking(Guid orderId, string content)
        {
            OrderId = orderId;
            Content = content;
            CreateDate = DateTime.Now;
        }

        public Guid OrderId { get; private set; }
        public string Content { get; private set; }
        public DateTime CreateDate { get; private set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return OrderId;
            yield return Content;
            yield return CreateDate;
        }
    }
}
