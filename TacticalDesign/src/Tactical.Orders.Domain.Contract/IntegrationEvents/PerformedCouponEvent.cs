using Tactical.Framework.Core.Abstractions;

namespace Tactical.Orders.Domain.Contract.IntegrationEvents;

public record PerformedCouponEvent : IEvent
{
    public DateTime? PublishedOn { get; set; }
}