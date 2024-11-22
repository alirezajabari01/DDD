using System;
using System.Collections.Generic;

namespace Tactical.Orders.Query.DataModel.Models;

public class ToppingCategory
{
    public Guid Id { get; set; }

    public DateTime CreateDate { get; set; }

    public virtual ICollection<Topping> Toppings { get; set; } = new List<Topping>();
}
