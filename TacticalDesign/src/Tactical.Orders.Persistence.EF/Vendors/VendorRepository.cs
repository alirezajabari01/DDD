using System.Linq.Expressions;
using Tactical.Framework.Persistence.EF;
using Tactical.Orders.Domain.Vendors;
using Tactical.Orders.Domain.Vendors.Contracts;
using Tactical.Orders.Persistence.EF.Contexts;

namespace Tactical.Orders.Persistence.EF.Vendors
{
    public class VendorRepository : BaseRepository<Vendor, long>, IVendorRepository
    {
        public VendorRepository(OrderContext context) : base(context)
        {
        }
    }
}
