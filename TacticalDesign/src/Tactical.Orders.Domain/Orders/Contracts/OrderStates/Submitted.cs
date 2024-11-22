using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Domain.Orders.Contracts.OrderStates
{
    public class Submitted : OrderState
    {
        public Submitted()
        {
            State = OrderStateEnum.Submitted;
        }

        public override OrderState Pay() => new Paid();

        public override OrderState Reject() => new Rejected();

    }

}
