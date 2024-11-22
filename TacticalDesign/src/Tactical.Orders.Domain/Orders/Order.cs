using Tactical.Framework.Domain.DomainAbstractions;
using Tactical.Orders.Domain.Contract.Enums;
using Tactical.Orders.Domain.Contract.IntegrationEvents;
using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Contracts.OrderStates;
using Tactical.Orders.Domain.Orders.Entities;
using Tactical.Orders.Domain.Orders.Events;
using Tactical.Orders.Domain.Orders.Exceptions;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Domain.Orders
{
    public partial class Order : AggregateRoot<Guid>
    {
        private long _totalItemPrice = 0;
        private Order() { }
        public Order(List<OrderItem> orderItems, VendorId vendorId, string couponCode,
            IVendorDomainService vendorDomainService,
            ICalculatePriceDomainService calculatePriceDomainService,
            ICouponDomainService couponDomainService)
        {
            SetId(Id);
            Validate(orderItems);
            SetProperties(vendorId, orderItems);

            ValidateMinimumBasket(vendorDomainService, orderItems, vendorId.Value);
            //TODO Nice to have Call Async
            PerformCoupon(couponCode, _totalItemPrice, couponDomainService);

            SetFinalPrice();

            QueueEvent(new OrderCreatedEvent { Id = this.Id });
        }

        public void Update(Guid orderId, List<OrderItem> orderItems, VendorId vendorId,
           IVendorDomainService vendorDomainService,
           ICalculatePriceDomainService calculatePriceDomainService)
        {
            //SetId(orderId);
            //Validate(orderItems);
            //SetProperties(vendorId, orderItems);


            ////TODO Nice to have Call Async
            //ValidateMinimumBasket(vendorDomainService, orderItems, vendorId.Value);
        }

        public static async Task<List<OrderItem>> CreateOrderItem(List<Guid> orderItemIds, IMenuItemDomainService menuItemDomainService, CancellationToken cancellationToken)
        {
            return await menuItemDomainService.GetOrderItemAsync(orderItemIds, cancellationToken);
        }

        public void AppendTracking(Guid orderId, string content)
        {
            OrderTrackings.Add(new OrderTracking(orderId, content));
        }

        public void ChangeState(OrderStateEnum state)
        {
            var lastState = OrderHistories.OrderByDescending(x => x.CreateDate).First();
            var nextState = lastState.State.CheckState(state);
            OrderHistories.Add(new OrderHistory(Id, nextState));
            SetLastState();
        }

        private void SetId(Guid id)
        {
            Id = id == default ? Guid.NewGuid() : id;
        }

        private void SetProperties(VendorId vendorId, List<OrderItem> orderItems)
        {
            VendorId = vendorId;
            OrderItems = orderItems;
            CreateDate = DateTime.UtcNow;
            OrderHistories.Add(new OrderHistory(Id, new Submitted()));
            SetLastState();
            //TODO Fill this
            CustomerId = new CustomerId(long.MaxValue);
        }

        private void Validate(List<OrderItem> orderItems)
        {
            if (Id == default)
                throw new EmptyOrderIdException("Id Must be Set");

            if (orderItems is null || orderItems.Count < 1)
                throw new EmptyOrderItemsException("Items Must be select");
        }

        private void ValidateMinimumBasket(IVendorDomainService vendorService, List<OrderItem> orderItems,
            long vendorId)
        {
            //(SumOfItems-Discount) + SumOfToppings   == minBasket
            _totalItemPrice = GetTotalItemPriceAsync(orderItems);

            var vendor = vendorService.GetById(vendorId);

            if (_totalItemPrice < vendor.MinimumBasket)
                throw new InvalidMinimumBasketException($"your order Must be greater than {vendor.MinimumBasket}");
        }

        private static long GetTotalItemPriceAsync(List<OrderItem> items)
        {
            var sumOfItems = items.Sum(x => x.Count * (x.Price - x.Discount));
            var sumOfToppings = items.Sum(x => x.OrderItemToppings?.Sum(t => t.Price * t.Count)) ?? 0;

            return sumOfItems + sumOfToppings;
        }

        private void SetFinalPrice()
        {
            FinalPrice = new FinalPrice(_totalItemPrice);
        }

        private void PerformCoupon(string couponCode, long totalItemPrice, ICouponDomainService couponDomainService)
        {
            CouponAmount = new CouponAmount(couponCode, totalItemPrice, couponDomainService);
            if (CouponAmount.Value != default)
                QueueEvent(new PerformedCouponEvent());
        }

        private void SetLastState()
        {
            var lastState = OrderHistories.OrderByDescending(x => x.CreateDate).First();
            State = lastState.State.State;
        }
    }
}
