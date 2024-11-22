using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Orders.Application.Contract.Orders.AppliactionServices;
using Tactical.Orders.Domain.Orders.Events;

namespace Tactical.Orders.Application.Notifications.EventHandlers
{
    public class SendNotificationEventHandler : IEventHandler<OrderCreatedEvent>
    {
        private readonly INotificationService _notificationService;

        public SendNotificationEventHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task HandleAsync(OrderCreatedEvent @event, CancellationToken cancellationToken)
        {
            _notificationService.Send(@event.Id.ToString());
        }
    }
}
