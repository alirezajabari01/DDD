using System;
using System.Collections.Generic;

namespace Tactical.Orders.Query.DataModel.Models;

public class OrderItem
{
    public long Id { get; set; }

    public Guid OrderId { get; set; }

    public Guid MenuItemId { get; set; }

    public long Price { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public int Count { get; set; }
    public long Discount { get; set; } = 0;

    public virtual Order Order { get; set; } = null!;
    public virtual MenuItem MenuItem { get; set; } = null!;

    public virtual ICollection<OrderItemTopping> OrderItemToppings { get; set; } = new List<OrderItemTopping>();
}
