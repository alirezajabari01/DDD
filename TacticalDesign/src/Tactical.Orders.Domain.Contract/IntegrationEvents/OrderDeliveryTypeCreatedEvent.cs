using Tactical.Framework.Core.Abstractions;

namespace Tactical.Orders.Domain.Contract.IntegrationEvents
{
    public record OrderDeliveryTypeCreatedEvent : IIntegrationEvent
    {
        public OrderDeliveryTypeCreatedEvent()
        {
            PublishedOn = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public DateTime? PublishedOn { get; set; }
    }
}
