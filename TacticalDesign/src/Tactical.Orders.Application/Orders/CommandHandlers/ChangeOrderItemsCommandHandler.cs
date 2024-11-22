using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Orders.Application.Contract.Orders.Commands;
using Tactical.Orders.Domain.Orders;
using Tactical.Orders.Domain.Orders.Contracts;
using Tactical.Orders.Domain.Orders.Factories;
using Tactical.Orders.Domain.Orders.ValueObjects;

namespace Tactical.Orders.Application.Orders.CommandHandlers
{
    public class ChangeOrderItemsCommandHandler : CommandHandler<ChangeOrderItemsCommand>
    {
        private readonly IVendorDomainService _vendorDomainService;
        private readonly IOrderRepository _orderRepository;
        private readonly ICalculatePriceDomainService _calculatePriceDomainService;
        private readonly IMenuItemDomainService _menuItemDomainService;
        public ChangeOrderItemsCommandHandler(IVendorDomainService vendorDomainService,
             IOrderRepository orderRepository, IEventBus eventbus,
             ICalculatePriceDomainService calculatePriceDomainService,
             IMenuItemDomainService menuItemDomainService) : base(eventbus)
        {
            _vendorDomainService = vendorDomainService;
            _orderRepository = orderRepository;
            _calculatePriceDomainService = calculatePriceDomainService;
            _menuItemDomainService = menuItemDomainService;
        }

        public override async Task HandleAsync(ChangeOrderItemsCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(command.OrderId) ?? throw new Exception();

            var orderItems = await OrderItemFactory.Create(command.Items.Select(x => x.ItemId).ToList(), _menuItemDomainService, cancellationToken);

            order.Update(order.Id, orderItems, new VendorId(command.VendorId), _vendorDomainService, _calculatePriceDomainService);

            order.AppendTracking(order.Id, JsonConvert.SerializeObject(order));

            await _orderRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
