using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TAnhChiTietSp
{
    public int? MaChiTietSp { get; set; }

    public string? TenFileAnh { get; set; }

    public string? ViTri { get; set; }

    public virtual TChiTietSanPham? MaChiTietSpNavigation { get; set; }
}
