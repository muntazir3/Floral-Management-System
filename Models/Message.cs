using System;
using System.Collections.Generic;

namespace Floral_Shop.Models;

public partial class Message
{
    public int MessageId { get; set; }

    public string Text { get; set; } = null!;

    public int? OccasionId { get; set; }

    public virtual Occasion? Occasion { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
