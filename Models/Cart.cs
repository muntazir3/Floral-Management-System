using System;
using System.Collections.Generic;

namespace Floral_Shop.Models;

public partial class Cart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public int? BouquetId { get; set; }

    public int Quantity { get; set; }

    public decimal? TotalPrice { get; set; }

    public virtual Bouquet? Bouquet { get; set; }

    public virtual User? User { get; set; }
}
