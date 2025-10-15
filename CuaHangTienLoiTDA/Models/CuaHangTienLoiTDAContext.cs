    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    namespace CuaHangTienLoiTDA.Models;

    public partial class CuaHangTienLoiTDAContext : DbContext
    {
        public CuaHangTienLoiTDAContext()
        {
        }

        public CuaHangTienLoiTDAContext(DbContextOptions<CuaHangTienLoiTDAContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }

        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }

        public virtual DbSet<DonHang> DonHangs { get; set; }

        public virtual DbSet<KhachHang> KhachHangs { get; set; }

        public virtual DbSet<SanPham> SanPhams { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseSqlServer("Server=LAPTOP-AGRHRR3H\\MSSQLSERVER01;Database=CuaHangTienLoiTDA;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.MaNV).HasName("PK__Admin__2725D70AB590B308");

                entity.ToTable("Admin");

                entity.HasIndex(e => e.Email, "UQ__Admin__A9D105341AE74868").IsUnique();

                entity.Property(e => e.ChucVu).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.HoTen).HasMaxLength(100);
                entity.Property(e => e.MatKhau).HasMaxLength(255);
                entity.Property(e => e.NgayTao)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.SoDienThoai).HasMaxLength(20);
                entity.Property(e => e.TrangThai).HasDefaultValue(true);
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.MaCTDH).HasName("PK__ChiTietD__1E4E40F060D41D5B");

                entity.ToTable("ChiTietDonHang");

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.MaDHNavigation).WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaDH)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDon__MaDH__5FB337D6");

                entity.HasOne(d => d.MaSPNavigation).WithMany(p => p.ChiTietDonHangs)
                    .HasForeignKey(d => d.MaSP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ChiTietDon__MaSP__60A75C0F");
            });

            modelBuilder.Entity<DanhMucSanPham>(entity =>
            {
                entity.HasKey(e => e.MaDM).HasName("PK__DanhMucS__2725866E6B07BF62");

                entity.ToTable("DanhMucSanPham");

                entity.Property(e => e.MoTa).HasMaxLength(255);
                entity.Property(e => e.TenDM).HasMaxLength(100);
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDH).HasName("PK__DonHang__272586611D4C6561");

                entity.ToTable("DonHang");

                entity.Property(e => e.NgayDat)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.TrangThai)
                    .HasMaxLength(50)
                    .HasDefaultValue("Chờ duyệt");

                entity.HasOne(d => d.MaKHNavigation).WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaKH)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DonHang__MaKH__5BE2A6F2");

                entity.HasOne(d => d.MaNVNavigation).WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaNV)
                    .HasConstraintName("FK__DonHang__MaNV__5CD6CB2B");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasKey(e => e.MaKH).HasName("PK__KhachHan__2725CF1EF79EC6BD");

                entity.ToTable("KhachHang");

                entity.HasIndex(e => e.Email, "UQ__KhachHan__A9D1053459C60B54").IsUnique();

                entity.Property(e => e.ChucVu)
                    .HasMaxLength(20)
                    .HasDefaultValue("KhachHang");
                entity.Property(e => e.DiaChi).HasMaxLength(255);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.HoTen).HasMaxLength(100);
                entity.Property(e => e.MatKhau).HasMaxLength(255);
                entity.Property(e => e.NgayTao)
                    .HasDefaultValueSql("(getdate())")
                    .HasColumnType("datetime");
                entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSP).HasName("PK__SanPham__2725081CEBF9D79C");

                entity.ToTable("SanPham");

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.HinhAnh).HasMaxLength(255);
                entity.Property(e => e.TenSP).HasMaxLength(200);

                entity.HasOne(d => d.MaDMNavigation).WithMany(p => p.SanPhams)
                    .HasForeignKey(d => d.MaDM)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SanPham__MaDM__571DF1D5");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
