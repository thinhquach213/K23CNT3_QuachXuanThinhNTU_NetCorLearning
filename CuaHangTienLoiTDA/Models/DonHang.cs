using System;
using System.Collections.Generic;

namespace CuaHangTienLoiTDA.Models;

public partial class DonHang
{
    public int MaDH { get; set; }

    public int MaKH { get; set; }

    public int? MaNV { get; set; }

    public DateTime? NgayDat { get; set; }

    public decimal TongTien { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual KhachHang MaKHNavigation { get; set; } = null!;

    public virtual Admin? MaNVNavigation { get; set; }
}
