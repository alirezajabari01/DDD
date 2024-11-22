using Tactical.Orders.Domain.Orders.Enums;

namespace Tactical.Orders.Domain.Orders.Contracts
{
    public sealed record CouponContract
    {
        public CouponType Type { get; set; }
        public int Value { get; set; }
        public DateTime ExpireDate { get; set; }
        public int UsageCount { get; set; }
    }
}
