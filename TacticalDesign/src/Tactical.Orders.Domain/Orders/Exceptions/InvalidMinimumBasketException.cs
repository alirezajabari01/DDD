using Tactical.Framework.Domain.Exceptions;

namespace Tactical.Orders.Domain.Orders.Exceptions
{
    public class InvalidMinimumBasketException : DomainException
    {
        public InvalidMinimumBasketException(string? message) : base(message)
        {
        }
    }
    
}
