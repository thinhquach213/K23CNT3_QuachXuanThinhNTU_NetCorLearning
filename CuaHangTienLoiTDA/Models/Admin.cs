using System;
using System.Collections.Generic;

namespace CuaHangTienLoiTDA.Models;

public partial class Admin
{
    public int MaNV { get; set; }

    public string HoTen { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? ChucVu { get; set; }

    public DateTime? NgayTao { get; set; }

    public bool? TrangThai { get; set; }

    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
