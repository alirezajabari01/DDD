namespace Tactical.Orders.Query.DataModel.Models;

public class MenuCategory
{
    public Guid Id { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new HashSet<MenuItem>();
}
