using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Vendors.Contracts;

namespace Tactical.Orders.DomainServices
{
    public class VendorDomainService : IVendorDomainService
    {
        private IVendorRepository _vendorRepository;
        public VendorDomainService(IVendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public VendorContract GetById(long vendorId)
        {
            var vendor = _vendorRepository.GetById(vendorId);
            return new()
            {
                MinimumBasket = vendor.MinimumBasket
            };
        }

        public Task<VendorContract> GetByIdAsync(long vendorId)
        {
            throw new NotImplementedException();
        }
    }
}
