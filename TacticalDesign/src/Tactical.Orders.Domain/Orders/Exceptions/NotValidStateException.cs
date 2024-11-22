using Tactical.Framework.Domain.Exceptions;

namespace Tactical.Orders.Domain.Orders.Exceptions
{
    public class NotValidStateException : DomainException
    {
        public NotValidStateException(string? message) : base(message)
        {
        }
    }

}
