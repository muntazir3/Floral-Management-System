using System;
using System.Collections.Generic;

namespace Floral_Shop.Models;

public partial class Bouquet
{
    public int BouquetId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public int? OccasionId { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Occasion? Occasion { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
