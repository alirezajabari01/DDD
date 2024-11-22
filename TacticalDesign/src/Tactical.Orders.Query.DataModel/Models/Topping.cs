using System;
using System.Collections.Generic;

namespace Tactical.Orders.Query.DataModel.Models;

public class Topping
{
    public Guid Id { get; set; }

    public Guid ToppingCategoryId { get; set; }

    public long Price { get; set; }

    public string Title { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public virtual ToppingCategory ToppingCategory { get; set; } = null!;
    public virtual ICollection<OrderItemTopping> OrderItemTopping { get; set; } = new List<OrderItemTopping>();
}
