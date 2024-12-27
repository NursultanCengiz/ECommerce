using System;
using System.Collections.Generic;

namespace ECommerce.Data;

public partial class Order : BaseEntity
{

    public int? ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Product? Product { get; set; }
}
