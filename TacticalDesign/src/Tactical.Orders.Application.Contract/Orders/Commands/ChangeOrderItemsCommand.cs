using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Orders.Domain.Orders.Arguments;

namespace Tactical.Orders.Application.Contract.Orders.Commands
{
    public record ChangeOrderItemsCommand(Guid OrderId, List<OrderItemArg> Items, long VendorId) : ICommand;
}
