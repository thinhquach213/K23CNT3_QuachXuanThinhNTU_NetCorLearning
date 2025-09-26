using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebBanHangOnline.Models;

public partial class WebBanHangContext : DbContext
{
    public WebBanHangContext()
    {
    }

    public WebBanHangContext(DbContextOptions<WebBanHangContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DbAdv> DbAdvs { get; set; }

    public virtual DbSet<DbCategory> DbCategories { get; set; }

    public virtual DbSet<DbContract> DbContracts { get; set; }

    public virtual DbSet<DbNew> DbNews { get; set; }

    public virtual DbSet<DbOrder> DbOrders { get; set; }

    public virtual DbSet<DbOrderDetail> DbOrderDetails { get; set; }

    public virtual DbSet<DbPost> DbPosts { get; set; }

    public virtual DbSet<DbProduct> DbProducts { get; set; }

    public virtual DbSet<DbSub> DbSubs { get; set; }

    public virtual DbSet<DbSubscribe> DbSubscribes { get; set; }

    public virtual DbSet<DbSystemSetting> DbSystemSettings { get; set; }

    public virtual DbSet<TbProductCategory> TbProductCategories { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-AGRHRR3H\\MSSQLSERVER01;Database=WebBanHang;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DbAdv>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__db_Adv__3214EC0765E6F0C3");

            entity.ToTable("db_Adv");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.Link).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierBy).HasMaxLength(150);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<DbCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__db_Menu__3214EC0754FED03E");

            entity.ToTable("db_Category");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierBy).HasMaxLength(150);
            entity.Property(e => e.SeoDescription).HasMaxLength(550);
            entity.Property(e => e.SeoKeywords).HasMaxLength(250);
            entity.Property(e => e.SeoTitle).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<DbContract>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__db_Contr__3214EC0711CE52D2");

            entity.ToTable("db_Contract");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Message).HasMaxLength(4000);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierBy).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Website).HasMaxLength(150);
        });

        modelBuilder.Entity<DbNew>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__db_New__3214EC075CBE5CD6");

            entity.ToTable("db_New");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierBy).HasMaxLength(150);
            entity.Property(e => e.SeoDescription).HasMaxLength(550);
            entity.Property(e => e.SeoKeywords).HasMaxLength(250);
            entity.Property(e => e.SeoTitle).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<DbOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__db_Order__3214EC07F06F6E7E");

            entity.ToTable("db_Order");

            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Code).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierBy).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<DbOrderDetail>(entity =>
        {
            entity.ToTable("db_OrderDetail");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<DbPost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__db_Post__3214EC0752B4D2F2");

            entity.ToTable("db_Post");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierBy).HasMaxLength(150);
            entity.Property(e => e.SeoDescription).HasMaxLength(550);
            entity.Property(e => e.SeoKeywords).HasMaxLength(250);
            entity.Property(e => e.SeoTitle).HasMaxLength(250);
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<DbProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__db_Produ__3214EC07F49E40C8");

            entity.ToTable("db_Product");

            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(4000);
            entity.Property(e => e.Image).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierBy).HasMaxLength(150);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.PriceSale).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.Title).HasMaxLength(250);
        });

        modelBuilder.Entity<DbSub>(entity =>
        {
            entity.ToTable("db_Sub");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
        });

        modelBuilder.Entity<DbSubscribe>(entity =>
        {
            entity.ToTable("db_Subscribe");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(150);
        });

        modelBuilder.Entity<DbSystemSetting>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("db_SystemSetting");

            entity.Property(e => e.SettingDescription).HasMaxLength(250);
            entity.Property(e => e.SettingKey).HasMaxLength(50);
        });

        modelBuilder.Entity<TbProductCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tb_Produ__3214EC07E9081B4F");

            entity.ToTable("tb_ProductCategory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Icon).HasMaxLength(500);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.ModifierBy).HasMaxLength(150);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
