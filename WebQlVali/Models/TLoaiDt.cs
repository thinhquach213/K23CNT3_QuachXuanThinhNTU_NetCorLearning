using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TLoaiDt
{
    public int MaDt { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();
}
