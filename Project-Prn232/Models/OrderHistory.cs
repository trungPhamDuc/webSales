using System;
using System.Collections.Generic;

namespace Project_Prn232.Models;

public partial class OrderHistory
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public string ShippingAddress { get; set; } = null!;

    public int? VoucherId { get; set; }

    public virtual ICollection<OrderHistoryDetail> OrderHistoryDetails { get; set; } = new List<OrderHistoryDetail>();

    public virtual User User { get; set; } = null!;

    public virtual Voucher? Voucher { get; set; }
}
