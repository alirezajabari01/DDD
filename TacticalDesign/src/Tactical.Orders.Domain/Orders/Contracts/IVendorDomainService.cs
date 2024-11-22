using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Orders.Domain.Orders.Contracts
{
    public interface IVendorDomainService : IDomainService
    {
        Task<VendorContract> GetByIdAsync(long vendorId);
        VendorContract GetById(long vendorId);
    }
}
