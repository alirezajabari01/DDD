using Tactical.Framework.Domain.DomainAbstractions;
using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Enums;

namespace Tactical.Orders.Domain.Orders.ValueObjects
{
    public class CouponAmount : ValueObject<CouponAmount>
    {
        private CouponAmount() { }
        public CouponAmount(string code, long totalItemPrice, ICouponDomainService couponDomainService)
        {
            PerformCoupon(code, totalItemPrice, couponDomainService);
        }

        public long Value { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }

        private void PerformCoupon(string code, long totalItemPrice, ICouponDomainService couponDomainService)
        {
            if (!string.IsNullOrEmpty(code))
            {
                var coupon = couponDomainService.GetById(code) ?? throw new Exception();

                Validate(coupon);

                SetValue(totalItemPrice, coupon);
            }
        }

        private void SetValue(long totalItemPrice, CouponContract coupon)
        {
            if (coupon.Type == CouponType.Amount)
                Value = coupon.Value;

            else
                Value = (totalItemPrice * coupon.Value) / 100;
        }

        private static void Validate(CouponContract coupon)
        {
            if (coupon.ExpireDate < DateTime.UtcNow)
                throw new Exception();

            if (coupon.UsageCount < 1)
                throw new Exception();
        }
    }
}
