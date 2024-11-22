using Tactical.Framework.Core.Abstractions;

namespace Tactical.Orders.Domain.Orders.Events
{
    public record OrderCreatedEvent : IEvent
    {
        public Guid Id { get; set; }
        public DateTime? PublishedOn { get; set; }
    }
}
