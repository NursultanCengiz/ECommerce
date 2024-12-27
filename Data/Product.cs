using System;
using System.Collections.Generic;

namespace ECommerce.Data;

public partial class Product : BaseEntity
{

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
