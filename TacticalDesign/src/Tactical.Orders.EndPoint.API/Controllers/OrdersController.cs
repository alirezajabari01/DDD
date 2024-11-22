using Microsoft.AspNetCore.Mvc;
using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Orders.Application.Contract.Orders.Commands;
using Tactical.Orders.Domain.Orders.Events;

namespace Tactical.Orders.EndPoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ICommandBus _commandBus;

        public OrdersController(ICommandBus commandBus)
        {
            _commandBus = commandBus;
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateOrderCommand command, CancellationToken cancellation)
        {
            Guid orderId = default;
            await _commandBus.Execute(command)
                .On<OrderCreatedEvent>(e => orderId = e.Id)
                .DispatchAsync(cancellation);

            return Ok(orderId);
        }

        [HttpPut]
        public async Task<IActionResult> Put(ChangeOrderItemsCommand command, CancellationToken cancellation)
        {
            await _commandBus.DispatchAsync(command, cancellation);
            return Ok();
        }

        [HttpPatch]
        public async Task<IActionResult> Patch(ChangeOrderStateCommand command, CancellationToken cancellation)
        {
            await _commandBus.DispatchAsync(command, cancellation);
            return Ok();
        }
    }
}
