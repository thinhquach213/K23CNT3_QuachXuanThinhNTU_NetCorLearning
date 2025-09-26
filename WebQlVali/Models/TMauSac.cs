using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TMauSac
{
    public int MaMauSac { get; set; }

    public string TenMauSac { get; set; } = null!;

    public virtual ICollection<TChiTietSanPham> TChiTietSanPhams { get; set; } = new List<TChiTietSanPham>();
}
