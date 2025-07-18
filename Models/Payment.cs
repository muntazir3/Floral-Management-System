﻿using System;
using System.Collections.Generic;

namespace Floral_Shop.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int? OrderId { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public string PaymentStatus { get; set; } = null!;

    public virtual Order? Order { get; set; }
}
