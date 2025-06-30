using System;
using System.Collections.Generic;

namespace Project_Prn232.Models;

public partial class Voucher
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public decimal DiscountValue { get; set; }

    public string? DiscountType { get; set; }

    public decimal? MinOrderValue { get; set; }

    public DateTime ExpiryDate { get; set; }

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<OrderHistory> OrderHistories { get; set; } = new List<OrderHistory>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
