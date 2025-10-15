using System;
using System.Collections.Generic;

namespace CuaHangTienLoiTDA.Models;

public partial class SanPham
{
    public int MaSP { get; set; }

    public string TenSP { get; set; } = null!;

    public decimal Gia { get; set; }

    public int SoLuong { get; set; }

    public string? HinhAnh { get; set; }

    public string? MoTa { get; set; }

    public int MaDM { get; set; }

    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    public virtual DanhMucSanPham MaDMNavigation { get; set; } = null!;
}
