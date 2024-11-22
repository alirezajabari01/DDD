using System;
using System.Collections.Generic;

namespace Tactical.Orders.Query.DataModel.Models;

public class MenuItem
{
    public Guid Id { get; set; }

    public Guid MenuCategoryId { get; set; }

    public long Price { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public virtual MenuCategory MenuCategory { get; set; } = null!;
    public virtual ICollection<OrderItem> OrderItems { get; set; } = null!;
}
