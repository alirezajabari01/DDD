using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Domain.Orders.Contracts.OrderStates
{
    public class Accepted : OrderState
    {
        public Accepted()
        {
            State = OrderStateEnum.Accepted;
        }

        public override OrderState Reject() => new Rejected();
    }

}
