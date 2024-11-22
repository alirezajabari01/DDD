using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Orders.Domain.Orders.ValueObjects
{
    public class VendorId : ValueObject<VendorId>
    {
        public long Value { get; private set; }
        public VendorId(long value)
        {
            Validate(value);
            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private static void Validate(long value)
        {
            if (value < 1)
                throw new Exception();
        }
    }
}
