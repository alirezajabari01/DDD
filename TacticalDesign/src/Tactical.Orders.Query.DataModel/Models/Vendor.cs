using System;
using System.Collections.Generic;

namespace Tactical.Orders.Query.DataModel.Models;

public class Vendor
{
    public long Id { get; set; }

    public string Title { get; set; } = null!;

    public long MinimumBasket { get; set; }

    public string Address { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public ICollection<Order> Orders { get; set; } = new List<Order>();
}
