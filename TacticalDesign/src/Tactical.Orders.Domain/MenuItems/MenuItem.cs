using Tactical.Framework.Domain.DomainAbstractions;

namespace Tactical.Orders.Domain.MenuItems
{
    public class MenuItem : AggregateRoot<Guid>
    {
        private MenuItem() { }
        public MenuItem(Guid menuCategoryId, long price, string title)
        {
            MenuCategoryId = menuCategoryId;
            Price = price;
            Title = title;
        }

        public Guid MenuCategoryId { get; set; }
        public long Price { get; private set; }
        public string Title { get; private set; }
    }
}
