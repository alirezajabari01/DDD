using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Domain.Orders.Contracts.OrderStates
{
    public class Rejected : OrderState
    {
        public Rejected()
        {
            State = OrderStateEnum.Rejected;
        }
    }

}
