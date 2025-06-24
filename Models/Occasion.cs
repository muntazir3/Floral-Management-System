using System;
using System.Collections.Generic;

namespace Floral_Shop.Models;

public partial class Occasion
{
    public int OccasionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Bouquet> Bouquets { get; set; } = new List<Bouquet>();

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();
}
