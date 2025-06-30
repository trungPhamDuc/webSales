﻿using System;
using System.Collections.Generic;

namespace Project_Prn232.Models;

public partial class ProductDetail
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string? Size { get; set; }

    public string? Color { get; set; }

    public decimal OriginalPrice { get; set; }

    public decimal SellingPrice { get; set; }

    public int StockQuantity { get; set; }

    public string? Image { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<OrderHistoryDetail> OrderHistoryDetails { get; set; } = new List<OrderHistoryDetail>();

    public virtual Product Product { get; set; } = null!;
}
