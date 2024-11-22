using Tactical.Framework.Domain.Exceptions;

namespace Tactical.Orders.Domain.Orders.Exceptions
{
    public class EmptyOrderItemsException : DomainException
    {
        public EmptyOrderItemsException(string? message) : base(message)
        {
        }
    }
    
}
