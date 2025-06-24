using System;
using System.Collections.Generic;

namespace Floral_Shop.Models;

public partial class OrderDetail
{
    public int OrderDetailsId { get; set; }

    public int? OrderId { get; set; }

    public int? BouquetId { get; set; }

    public int Quantity { get; set; }

    public virtual Bouquet? Bouquet { get; set; }

    public virtual Order? Order { get; set; }
}
