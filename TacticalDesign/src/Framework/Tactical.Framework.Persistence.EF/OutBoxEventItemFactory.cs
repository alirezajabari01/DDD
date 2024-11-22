using Newtonsoft.Json;
using Tactical.Framework.Core.Abstractions;
using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Framework.Persistence.EF
{
    public static class OutBoxEventItemFactory
    {
        public static List<OutBoxEventItem> Create(IAggregateRoot aggregateRoot)
        {
            var domainEvents = aggregateRoot.GetAllQueuedEvents().ToList();
            return domainEvents.Select(domainEvent => new OutBoxEventItem
            {
                CreatedDate = DateTime.UtcNow,
                EventName = domainEvent.GetType().Name,
                EventType = domainEvent.GetType().FullName,
                AggregateName = aggregateRoot.GetType().Name,
                AggregateType = aggregateRoot.GetType().FullName!,
                IsPublished = false,
                Payload = JsonConvert.SerializeObject(domainEvent)
            }).ToList();
        }
    }
}

