using System;
using System.Collections.Generic;

namespace Tactical.Orders.Query.DataModel.Models;

public partial class OrderItemTopping
{
    public long Id { get; set; }

    public long OrderItemId { get; set; }

    public Guid ToppingId { get; set; }

    public string Title { get; set; } = null!;

    public int Count { get; set; }

    public long Price { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual OrderItem OrderItem { get; set; } = null!;
    public virtual Topping Topping { get; set; }
}
