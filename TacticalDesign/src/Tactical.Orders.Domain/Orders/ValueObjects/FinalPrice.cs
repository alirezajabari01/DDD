using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Orders.Domain.Orders.ValueObjects
{
    public class FinalPrice : ValueObject<FinalPrice>
    {
        public long Value { get; private set; }
        public FinalPrice(long value)
        {
            //Calculate
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

    }
}
