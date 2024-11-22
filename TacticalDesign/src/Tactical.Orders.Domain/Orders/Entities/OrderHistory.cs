using Tactical.Framework.Core.Abstractions;
using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Orders.Contracts.OrderStates;
using Tactical.Orders.Domain.Orders.Exceptions;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Domain.Orders.Entities
{
    public class OrderHistory : Entity<long>
    {
        private OrderHistory() { }
        public OrderHistory(Guid orderId, OrderState orderState)
        {
            OrderId = orderId;
            State = orderState;
            CreateDate = DateTime.UtcNow;
        }
        public Guid OrderId { get; private set; }

        private OrderState _state;
        public OrderState State
        {
            get => GetState(_state);
            private set => _state = value;
        }

        private OrderState GetState(OrderState state)
        {
            if (!state.GetType().IsSubclassOf(typeof(OrderState)))
            {
                _state = state.State switch
                {
                    OrderStateEnum.Submitted => new Submitted(),
                    OrderStateEnum.Paid => new Paid(),
                    OrderStateEnum.Accepted => new Accepted(),
                    OrderStateEnum.Rejected => new Rejected(),
                    _ => throw new NotValidStateException(""),
                };

                state = _state;
            }

            return state;
        }
    }
}
