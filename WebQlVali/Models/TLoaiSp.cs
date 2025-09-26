using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TLoaiSp
{
    public int MaLoai { get; set; }

    public string Loai { get; set; } = null!;

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();
}
