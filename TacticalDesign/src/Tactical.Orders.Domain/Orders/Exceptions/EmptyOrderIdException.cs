using Tactical.Framework.Domain.Exceptions;

namespace Tactical.Orders.Domain.Orders.Exceptions
{
    public class EmptyOrderIdException : DomainException
    {
        public EmptyOrderIdException(string? message) : base(message)
        {
        }
    }

}
