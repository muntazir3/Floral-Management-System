using System;
using System.Collections.Generic;

namespace Floral_Shop.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? UserId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public string RecipientName { get; set; } = null!;

    public string RecipientAddress { get; set; } = null!;

    public string RecipientPhone { get; set; } = null!;

    public int? MessageId { get; set; }

    public string? CustomMessage { get; set; }

    public virtual Message? Message { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual User? User { get; set; }
}
