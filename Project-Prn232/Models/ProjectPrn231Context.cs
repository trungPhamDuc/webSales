using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Project_Prn232.Models;

public partial class ProjectPrn231Context : DbContext
{
    public ProjectPrn231Context()
    {
    }

    public ProjectPrn231Context(DbContextOptions<ProjectPrn231Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<DepositHistory> DepositHistories { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<OrderHistory> OrderHistories { get; set; }

    public virtual DbSet<OrderHistoryDetail> OrderHistoryDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductDetail> ProductDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Voucher> Vouchers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfigurationRoot configuration = builder.Build();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("MyCnn"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Brand__3214EC27C62D9361");

            entity.ToTable("Brand");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC27BDC23E72");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);

            entity.HasOne(d => d.Brand).WithMany(p => p.Categories)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK_Category_Brand");
        });

        modelBuilder.Entity<DepositHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DepositH__3214EC2707FA95A6");

            entity.ToTable("DepositHistory");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DepositDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.DepositHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DepositHi__UserI__4F7CD00D");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC273496D090");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Comment).HasMaxLength(500);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(100);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__Produc__5070F446");

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feedback__UserID__5165187F");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC072FE71918");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ShippingAddress).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__UserId__5812160E");

            entity.HasOne(d => d.Voucher).WithMany(p => p.Orders)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK__Orders__VoucherI__59063A47");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07F0E8F59F");

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__52593CB8");

            entity.HasOne(d => d.ProductDetail).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__534D60F1");
        });

        modelBuilder.Entity<OrderHistory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderHis__3214EC07BFBDA1B3");

            entity.ToTable("OrderHistory");

            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.ShippingAddress).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.User).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderHist__UserI__5441852A");

            entity.HasOne(d => d.Voucher).WithMany(p => p.OrderHistories)
                .HasForeignKey(d => d.VoucherId)
                .HasConstraintName("FK__OrderHist__Vouch__5535A963");
        });

        modelBuilder.Entity<OrderHistoryDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderHis__3214EC07379B20FA");

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.OrderHistory).WithMany(p => p.OrderHistoryDetails)
                .HasForeignKey(d => d.OrderHistoryId)
                .HasConstraintName("FK__OrderHist__Order__5629CD9C");

            entity.HasOne(d => d.ProductDetail).WithMany(p => p.OrderHistoryDetails)
                .HasForeignKey(d => d.ProductDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderHist__Produ__571DF1D5");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC27D3891319");

            entity.ToTable("Product");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.MainImage).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__Product__BrandID__59FA5E80");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__5AEE82B9");
        });

        modelBuilder.Entity<ProductDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ProductD__3214EC2731E4C7D4");

            entity.ToTable("ProductDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(100);
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SellingPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Size).HasMaxLength(20);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);

            entity.HasOne(d => d.Product).WithMany(p => p.ProductDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductDe__Produ__5BE2A6F2");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Role__3214EC27CD4D81A8");

            entity.ToTable("Role");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC2754CA687A");

            entity.ToTable("User");

            entity.HasIndex(e => e.Username, "UQ__User__536C85E42C7E889C").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__User__A9D10534AF2522FD").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.Money)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleID__5CD6CB2B");
        });

        modelBuilder.Entity<Voucher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Voucher__3214EC2716A0377F");

            entity.ToTable("Voucher");

            entity.HasIndex(e => e.Code, "UQ__Voucher__A25C5AA719598A33").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CreatedBy).HasMaxLength(100);
            entity.Property(e => e.DeletedAt).HasColumnType("datetime");
            entity.Property(e => e.DeletedBy).HasMaxLength(100);
            entity.Property(e => e.DiscountType).HasMaxLength(20);
            entity.Property(e => e.DiscountValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ExpiryDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.MinOrderValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
            entity.Property(e => e.UpdatedBy).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
