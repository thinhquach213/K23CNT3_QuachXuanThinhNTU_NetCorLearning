using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebQlVali.Models;

public partial class QlvaliContext : DbContext
{
    public QlvaliContext()
    {
    }

    public QlvaliContext(DbContextOptions<QlvaliContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TAnhChiTietSp> TAnhChiTietSps { get; set; }

    public virtual DbSet<TAnhSp> TAnhSps { get; set; }

    public virtual DbSet<TChatLieu> TChatLieus { get; set; }

    public virtual DbSet<TChiTietHdb> TChiTietHdbs { get; set; }

    public virtual DbSet<TChiTietSanPham> TChiTietSanPhams { get; set; }

    public virtual DbSet<TDanhMucSp> TDanhMucSps { get; set; }

    public virtual DbSet<THangSx> THangSxes { get; set; }

    public virtual DbSet<THoaDonBan> THoaDonBans { get; set; }

    public virtual DbSet<TKhachHang> TKhachHangs { get; set; }

    public virtual DbSet<TKichThuoc> TKichThuocs { get; set; }

    public virtual DbSet<TLoaiDt> TLoaiDts { get; set; }

    public virtual DbSet<TLoaiSp> TLoaiSps { get; set; }

    public virtual DbSet<TMauSac> TMauSacs { get; set; }

    public virtual DbSet<TNhanVien> TNhanViens { get; set; }

    public virtual DbSet<TQuocGium> TQuocGia { get; set; }

    public virtual DbSet<TUser> TUsers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-AGRHRR3H\\MSSQLSERVER01;Database=QLVali;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TAnhChiTietSp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tAnhChiTietSP");

            entity.Property(e => e.MaChiTietSp).HasColumnName("MaChiTietSP");
            entity.Property(e => e.TenFileAnh).HasMaxLength(200);
            entity.Property(e => e.ViTri).HasMaxLength(50);

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany()
                .HasForeignKey(d => d.MaChiTietSp)
                .HasConstraintName("FK__tAnhChiTi__MaChi__52593CB8");
        });

        modelBuilder.Entity<TAnhSp>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tAnhSP");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.TenFileAnh).HasMaxLength(200);
            entity.Property(e => e.ViTri).HasMaxLength(50);

            entity.HasOne(d => d.MaSpNavigation).WithMany()
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK__tAnhSP__MaSP__5070F446");
        });

        modelBuilder.Entity<TChatLieu>(entity =>
        {
            entity.HasKey(e => e.MaChatLieu).HasName("PK__tChatLie__453995BCD9A0F692");

            entity.ToTable("tChatLieu");

            entity.Property(e => e.MaChatLieu).ValueGeneratedNever();
            entity.Property(e => e.ChatLieu).HasMaxLength(100);
        });

        modelBuilder.Entity<TChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaChiTietSp }).HasName("PK__tChiTiet__E50F083ECE2D294E");

            entity.ToTable("tChiTietHDB");

            entity.Property(e => e.MaChiTietSp).HasColumnName("MaChiTietSP");
            entity.Property(e => e.DonGiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GhiChu).HasMaxLength(200);
            entity.Property(e => e.GiamGia).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaChiTietSpNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaChiTietSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tChiTietH__MaChi__619B8048");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.TChiTietHdbs)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tChiTietH__MaHoa__60A75C0F");
        });

        modelBuilder.Entity<TChiTietSanPham>(entity =>
        {
            entity.HasKey(e => e.MaChiTietSp).HasName("PK__tChiTiet__651D905788955BBD");

            entity.ToTable("tChiTietSanPham");

            entity.Property(e => e.MaChiTietSp)
                .ValueGeneratedNever()
                .HasColumnName("MaChiTietSP");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(200);
            entity.Property(e => e.DonGiaBan).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GiamGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Slton).HasColumnName("SLTon");
            entity.Property(e => e.Video).HasMaxLength(200);

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaKichThuoc)
                .HasConstraintName("FK__tChiTietS__MaKic__4D94879B");

            entity.HasOne(d => d.MaMauSacNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaMauSac)
                .HasConstraintName("FK__tChiTietS__MaMau__4E88ABD4");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.TChiTietSanPhams)
                .HasForeignKey(d => d.MaSp)
                .HasConstraintName("FK__tChiTietSa__MaSP__4CA06362");
        });

        modelBuilder.Entity<TDanhMucSp>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__tDanhMuc__2725081C561BF38F");

            entity.ToTable("tDanhMucSP");

            entity.Property(e => e.MaSp)
                .ValueGeneratedNever()
                .HasColumnName("MaSP");
            entity.Property(e => e.AnhDaiDien).HasMaxLength(200);
            entity.Property(e => e.DoiNoi).HasMaxLength(100);
            entity.Property(e => e.GiaLonNhat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GiaNhoNhat).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.GioiThieuSp).HasColumnName("GioiThieuSP");
            entity.Property(e => e.MaDacTinh).HasMaxLength(200);
            entity.Property(e => e.MaDt).HasColumnName("MaDT");
            entity.Property(e => e.MaHangSx).HasColumnName("MaHangSX");
            entity.Property(e => e.MaNuocSx).HasColumnName("MaNuocSX");
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.NganLapTop).HasMaxLength(200);
            entity.Property(e => e.TenSp)
                .HasMaxLength(200)
                .HasColumnName("TenSP");
            entity.Property(e => e.Website).HasMaxLength(200);

            entity.HasOne(d => d.MaChatLieuNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaChatLieu)
                .HasConstraintName("FK__tDanhMucS__MaCha__45F365D3");

            entity.HasOne(d => d.MaDtNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaDt)
                .HasConstraintName("FK__tDanhMucSP__MaDT__49C3F6B7");

            entity.HasOne(d => d.MaHangSxNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaHangSx)
                .HasConstraintName("FK__tDanhMucS__MaHan__46E78A0C");

            entity.HasOne(d => d.MaLoaiNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaLoai)
                .HasConstraintName("FK__tDanhMucS__MaLoa__48CFD27E");

            entity.HasOne(d => d.MaNuocSxNavigation).WithMany(p => p.TDanhMucSps)
                .HasForeignKey(d => d.MaNuocSx)
                .HasConstraintName("FK__tDanhMucS__MaNuo__47DBAE45");
        });

        modelBuilder.Entity<THangSx>(entity =>
        {
            entity.HasKey(e => e.MaHangSx).HasName("PK__tHangSX__8C6D28FE1A3D0B38");

            entity.ToTable("tHangSX");

            entity.Property(e => e.MaHangSx)
                .ValueGeneratedNever()
                .HasColumnName("MaHangSX");
            entity.Property(e => e.HangSx)
                .HasMaxLength(150)
                .HasColumnName("HangSX");

            entity.HasOne(d => d.MaNuocThuongHieuNavigation).WithMany(p => p.THangSxes)
                .HasForeignKey(d => d.MaNuocThuongHieu)
                .HasConstraintName("FK__tHangSX__MaNuocT__4316F928");
        });

        modelBuilder.Entity<THoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__tHoaDonB__835ED13B64886DD8");

            entity.ToTable("tHoaDonBan");

            entity.Property(e => e.MaHoaDon).ValueGeneratedNever();
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.GiamGiaHd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("GiamGiaHD");
            entity.Property(e => e.MaSoThue).HasMaxLength(50);
            entity.Property(e => e.NgayHoaDon).HasColumnType("datetime");
            entity.Property(e => e.PhuongThucThanhToan).HasMaxLength(100);
            entity.Property(e => e.ThongTinThue).HasMaxLength(200);
            entity.Property(e => e.TongTienHd)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("TongTienHD");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__tHoaDonBa__MaKha__5CD6CB2B");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.THoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__tHoaDonBa__MaNha__5DCAEF64");
        });

        modelBuilder.Entity<TKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__tKhachHa__88D2F0E573B1518B");

            entity.ToTable("tKhachHang");

            entity.Property(e => e.MaKhachHang).ValueGeneratedNever();
            entity.Property(e => e.AnhDaiDien).HasMaxLength(200);
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.LoaiKhachHang).HasMaxLength(50);
            entity.Property(e => e.SoDienThoai).HasMaxLength(15);
            entity.Property(e => e.TenKhachHang).HasMaxLength(150);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TKhachHangs)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK__tKhachHan__usern__571DF1D5");
        });

        modelBuilder.Entity<TKichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc).HasName("PK__tKichThu__22BFD66436C8DDA7");

            entity.ToTable("tKichThuoc");

            entity.Property(e => e.MaKichThuoc).ValueGeneratedNever();
            entity.Property(e => e.KichThuoc).HasMaxLength(50);
        });

        modelBuilder.Entity<TLoaiDt>(entity =>
        {
            entity.HasKey(e => e.MaDt).HasName("PK__tLoaiDT__27258655F0C0A1D9");

            entity.ToTable("tLoaiDT");

            entity.Property(e => e.MaDt)
                .ValueGeneratedNever()
                .HasColumnName("MaDT");
            entity.Property(e => e.TenLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<TLoaiSp>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK__tLoaiSP__730A57599AF3EC87");

            entity.ToTable("tLoaiSP");

            entity.Property(e => e.MaLoai).ValueGeneratedNever();
            entity.Property(e => e.Loai).HasMaxLength(100);
        });

        modelBuilder.Entity<TMauSac>(entity =>
        {
            entity.HasKey(e => e.MaMauSac).HasName("PK__tMauSac__B9A911624A6DEAA9");

            entity.ToTable("tMauSac");

            entity.Property(e => e.MaMauSac).ValueGeneratedNever();
            entity.Property(e => e.TenMauSac).HasMaxLength(50);
        });

        modelBuilder.Entity<TNhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__tNhanVie__77B2CA474377E577");

            entity.ToTable("tNhanVien");

            entity.Property(e => e.MaNhanVien).ValueGeneratedNever();
            entity.Property(e => e.AnhDaiDien).HasMaxLength(200);
            entity.Property(e => e.ChucVu).HasMaxLength(100);
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.GhiChu).HasMaxLength(500);
            entity.Property(e => e.SoDienThoai1).HasMaxLength(15);
            entity.Property(e => e.SoDienThoai2).HasMaxLength(15);
            entity.Property(e => e.TenNhanVien).HasMaxLength(150);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.UsernameNavigation).WithMany(p => p.TNhanViens)
                .HasForeignKey(d => d.Username)
                .HasConstraintName("FK__tNhanVien__usern__59FA5E80");
        });

        modelBuilder.Entity<TQuocGium>(entity =>
        {
            entity.HasKey(e => e.MaNuoc).HasName("PK__tQuocGia__21306FEA857D7840");

            entity.ToTable("tQuocGia");

            entity.Property(e => e.MaNuoc).ValueGeneratedNever();
            entity.Property(e => e.TenNuoc).HasMaxLength(100);
        });

        modelBuilder.Entity<TUser>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PK__tUser__F3DBC5737893A92D");

            entity.ToTable("tUser");

            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
            entity.Property(e => e.LoaiUser).HasMaxLength(50);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
