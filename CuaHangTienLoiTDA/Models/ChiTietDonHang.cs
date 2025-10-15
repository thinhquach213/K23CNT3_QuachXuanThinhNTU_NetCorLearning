using System;
using System.Collections.Generic;

namespace CuaHangTienLoiTDA.Models;

public partial class ChiTietDonHang
{
    public int MaCTDH { get; set; }

    public int MaDH { get; set; }

    public int MaSP { get; set; }

    public int SoLuong { get; set; }

    public decimal Gia { get; set; }

    public virtual DonHang MaDHNavigation { get; set; } = null!;

    public virtual SanPham MaSPNavigation { get; set; } = null!;
}
