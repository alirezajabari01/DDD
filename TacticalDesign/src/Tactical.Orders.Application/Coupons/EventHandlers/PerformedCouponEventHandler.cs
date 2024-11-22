using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Orders.Domain.Contract.IntegrationEvents;
using Tactical.Orders.Domain.Coupons;

namespace Tactical.Orders.Application.Coupons.EventHandlers
{
    public class PerformedCouponEventHandler : IEventHandler<PerformedCouponEvent>
    {
        public async Task HandleAsync(PerformedCouponEvent @event, CancellationToken cancellationToken)
        {
            var coupon = new Coupon(10);
            coupon.DecreaseUsageCount(1);
            await Task.CompletedTask;
        }
    }
}
