using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Orders.Domain.Coupons
{
    public class Coupon : AggregateRoot<Guid>
    {
        public Coupon(int usageCount)
        {
            UsageCount = usageCount;
        }

        public int UsageCount { get; private set; }
        public void DecreaseUsageCount(int usageCount)
        {
           // throw new NotImplementedException();
            UsageCount -= usageCount;
        }
    }
}
