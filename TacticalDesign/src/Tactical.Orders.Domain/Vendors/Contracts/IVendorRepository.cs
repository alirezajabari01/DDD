using Tactical.Orders.Domain.Vendors;

namespace Tactical.Orders.Domain.Vendors.Contracts
{
    public interface IVendorRepository
    {
        Vendor GetById(long id);
    }
}
