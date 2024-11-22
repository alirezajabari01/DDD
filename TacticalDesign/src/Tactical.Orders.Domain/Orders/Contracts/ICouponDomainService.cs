using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Orders.Domain.Orders.Contracts
{
    public interface ICouponDomainService : IDomainService
    {
        Task<CouponContract> GetByIdAsync(string code, CancellationToken cancellationToken);
        CouponContract GetById(string code);
    }
}
