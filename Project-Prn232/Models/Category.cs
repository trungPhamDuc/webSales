using System;
using System.Collections.Generic;

namespace Project_Prn232.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool? IsDeleted { get; set; }

    public string? DeletedBy { get; set; }

    public int? BrandId { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
