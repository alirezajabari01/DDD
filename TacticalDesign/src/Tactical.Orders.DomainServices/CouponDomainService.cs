using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Enums;

namespace Tactical.Orders.DomainServices
{
    public class CouponDomainService : ICouponDomainService
    {
        public CouponContract GetById(string code)
        {
            return new()
            {
                Type = CouponType.Amount,
                ExpireDate = DateTime.UtcNow.AddDays(3),
                UsageCount = 3,
                Value = 1000
            };
        }

        public Task<CouponContract> GetByIdAsync(string code, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }


}
