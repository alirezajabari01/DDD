using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Entities;

namespace Tactical.Orders.Domain.UnitTest
{
    public class OrderSelfShunt : IVendorDomainService,
                                    ICalculatePriceDomainService,
                                    IMenuItemDomainService,
                                    ICouponDomainService
    {

        public VendorContract GetById(long vendorId)
        {
            return new VendorContract { MinimumBasket = 1000 };
        }

        public CouponContract GetById(string code)
        {
            return null;
        }

        public Task<VendorContract> GetByIdAsync(long vendorId)
        {
            return null;
        }

        public Task<CouponContract> GetByIdAsync(string code, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task<List<OrderItem>> GetOrderItemAsync(List<Guid> ids, CancellationToken cancellationToken)
        {
            return null;
        }

        public Task<long> GetTotalItemPriceAsync(List<OrderItem> items, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
