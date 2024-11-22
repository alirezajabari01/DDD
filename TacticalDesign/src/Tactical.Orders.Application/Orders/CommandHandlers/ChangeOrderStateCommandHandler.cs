using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Framework.Application.CQRS.EventHandling;
using Tactical.Orders.Application.Contract.Orders.Commands;
using Tactical.Orders.Domain.Orders.Contracts;

namespace Tactical.Orders.Application.Orders.CommandHandlers
{
    public class ChangeOrderStateCommandHandler : CommandHandler<ChangeOrderStateCommand>
    {
        private readonly IVendorDomainService _vendorDomainService;
        private readonly IOrderRepository _orderRepository;
        private readonly ICalculatePriceDomainService _calculatePriceDomainService;
        private readonly IMenuItemDomainService _menuItemDomainService;
        public ChangeOrderStateCommandHandler(IVendorDomainService vendorDomainService,
             IOrderRepository orderRepository, IEventBus eventbus,
             ICalculatePriceDomainService calculatePriceDomainService,
             IMenuItemDomainService menuItemDomainService) : base(eventbus)
        {
            _vendorDomainService = vendorDomainService;
            _orderRepository = orderRepository;
            _calculatePriceDomainService = calculatePriceDomainService;
            _menuItemDomainService = menuItemDomainService;
        }

        public override async Task HandleAsync(ChangeOrderStateCommand command, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(command.OrderId) ?? throw new Exception();

            order.ChangeState(command.OrderState);

            await _orderRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
