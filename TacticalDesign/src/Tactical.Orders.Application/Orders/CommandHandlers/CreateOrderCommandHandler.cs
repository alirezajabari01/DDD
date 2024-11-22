using EasyNetQ;
using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Orders.Application.Contract.Orders.AppliactionServices;
using Tactical.Orders.Application.Contract.Orders.Commands;
using Tactical.Orders.Domain.Orders;
using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Factories;
using Tactical.Orders.Domain.Orders.ValueObjects;
using IEventBus = Tactical.Framework.Application.CQRS.EventHandling.IEventBus;
namespace Tactical.Orders.Application.Orders.CommandHandlers
{
    public class CreateOrderCommandHandler : CommandHandler<CreateOrderCommand>
    {
        private readonly IVendorDomainService _vendorDomainService;
        private readonly IOrderRepository _orderRepository;
        private readonly ICalculatePriceDomainService _calculatePriceDomainService;
        private readonly IMenuItemDomainService _menuItemDomainService;
        private readonly IToppingDomainService _toppingDomainService;
        private readonly ICouponDomainService _couponDomainService;
        private readonly INotificationService _notificationService;
        
        private readonly IBus _bus;

        public CreateOrderCommandHandler(IVendorDomainService vendorDomainService,
            IOrderRepository orderRepository, IEventBus eventBus,
             ICalculatePriceDomainService calculatePriceDomainService,
             IMenuItemDomainService menuItemDomainService,
             IToppingDomainService toppingDomainService,
             ICouponDomainService couponDomainService, IBus bus, INotificationService notificationService) : base(eventBus)
        {
            _vendorDomainService = vendorDomainService;
            _orderRepository = orderRepository;
            _calculatePriceDomainService = calculatePriceDomainService;
            _menuItemDomainService = menuItemDomainService;
            _couponDomainService = couponDomainService;
            _toppingDomainService = toppingDomainService;
            _bus = bus;
            _notificationService = notificationService;
        }

        public override async Task HandleAsync(CreateOrderCommand command, CancellationToken cancellationToken)
        {
            var orderItems = await OrderItemFactory.Create(command.Items, _menuItemDomainService, _toppingDomainService, cancellationToken);

            var order = new Order(orderItems, new VendorId(command.VendorId), command.CouponCode,
                _vendorDomainService, _calculatePriceDomainService, _couponDomainService);

            await _orderRepository.CreateAsync(order, cancellationToken);

            //Supposed Order Is Delivery
            //await _bus.PubSub.PublishAsync(new OrderDeliveryTypeCreatedEvent() { Id = Guid.Parse("7454ae30-86e3-47dd-96d1-ef0d1adc61a2") },  cancellationToken);

            //_notificationService.Send(order.Id.ToString());

            await PublishAggregatedEvents(order);
        }
    }
}
