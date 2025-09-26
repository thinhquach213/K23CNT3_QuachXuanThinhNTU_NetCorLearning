using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TAnhSp
{
    public int? MaSp { get; set; }

    public string? TenFileAnh { get; set; }

    public string? ViTri { get; set; }

    public virtual TDanhMucSp? MaSpNavigation { get; set; }
}
