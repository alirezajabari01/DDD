using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Orders.Domain.Vendors
{
    public class Vendor : AggregateRoot<long>
    {
        public Vendor(string title, long minimumBasket, string address)
        {
            MinimumBasket = minimumBasket;
            Address = address;
            Title = title;
        }

        public string Title { get; private set; }
        public long MinimumBasket { get; private set; }
        public string Address { get; private set; } = null;
    }
}
