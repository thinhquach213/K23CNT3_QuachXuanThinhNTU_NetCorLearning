using System;
using System.Collections.Generic;

namespace PhuKienTDAStore.Models;

public partial class Admin
{
    public int MaNv { get; set; }

    public string HoTen { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? ChucVu { get; set; }

    public DateTime? NgayTao { get; set; }

    public string? TrangThai { get; set; }
}
