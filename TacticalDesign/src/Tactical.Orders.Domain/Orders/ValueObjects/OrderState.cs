using Tactical.Framework.Domain.DomainAbstractions;
using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Orders.Exceptions;

namespace Tactical.Orders.Domain.Orders.ValueObjects
{
    //TODO Must Be Abstract
    //Remove For Migration
    public class OrderState : ValueObject<OrderState>
    {

        private Dictionary<OrderStateEnum, Func<OrderState>> _orderState = new();
        public OrderState()
        {
            _orderState.Add(OrderStateEnum.Submitted, Submit);
            _orderState.Add(OrderStateEnum.Paid, Pay);
            _orderState.Add(OrderStateEnum.Accepted, Accept);
            _orderState.Add(OrderStateEnum.Rejected, Reject);
        }
        public OrderStateEnum State { get; protected set; }

        public virtual OrderState Submit() => throw new NotValidStateException(StateMessages.NotValidStateExceptionMessage);
        public virtual OrderState Pay() => throw new NotValidStateException(StateMessages.NotValidStateExceptionMessage);
        public virtual OrderState Accept() => throw new NotValidStateException(StateMessages.NotValidStateExceptionMessage);
        public virtual OrderState Reject() => throw new NotValidStateException(StateMessages.NotValidStateExceptionMessage);

        public OrderState CheckState(OrderStateEnum state)
        {
            _orderState.TryGetValue(state, out var target);
            return target!.Invoke();
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return State;
        }
    }

    public struct StateMessages
    {
        public const string NotValidStateExceptionMessage = "Could n't Change To Not Valid State";
    }

}
