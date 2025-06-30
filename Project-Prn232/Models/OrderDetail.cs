using System;
using System.Collections.Generic;

namespace Project_Prn232.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int ProductDetailId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual ProductDetail ProductDetail { get; set; } = null!;
}
