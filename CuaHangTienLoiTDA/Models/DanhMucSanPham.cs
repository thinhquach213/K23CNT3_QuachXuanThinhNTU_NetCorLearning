using System;
using System.Collections.Generic;

namespace CuaHangTienLoiTDA.Models;

public partial class DanhMucSanPham
{
    public int MaDM { get; set; }

    public string TenDM { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
