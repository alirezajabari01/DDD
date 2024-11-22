using Tactical.Framework.Application.CQRS.CommandHandling;
using Tactical.Orders.Domain.Contract.Enums;

namespace Tactical.Orders.Application.Contract.Orders.Commands
{
    public record ChangeOrderStateCommand(Guid OrderId, OrderStateEnum OrderState) : ICommand;
}
