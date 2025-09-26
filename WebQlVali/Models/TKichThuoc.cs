using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TKichThuoc
{
    public int MaKichThuoc { get; set; }

    public string KichThuoc { get; set; } = null!;

    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; set; } = new List<TChiTietSanPham>();
}
