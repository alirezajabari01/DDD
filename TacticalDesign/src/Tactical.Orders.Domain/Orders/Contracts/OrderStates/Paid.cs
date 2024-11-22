using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Domain.Orders.Contracts.OrderStates
{
    public class Paid : OrderState
    {
        public Paid()
        {
            State = OrderStateEnum.Paid;
        }

        public override OrderState Accept() => new Accepted();

        public override OrderState Reject() => new Rejected();
    }

}
