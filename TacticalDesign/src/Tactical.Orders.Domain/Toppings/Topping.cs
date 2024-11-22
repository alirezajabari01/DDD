using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Orders.Domain.Toppings
{
    public class Topping : AggregateRoot<Guid>
    {
        public Guid ToppingCategoryId { get; set; }
        public long Price { get; private set; }
        public string Title { get; private set; }
    }
}
