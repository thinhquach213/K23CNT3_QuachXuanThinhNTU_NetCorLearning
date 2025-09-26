using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class THangSx
{
    public int MaHangSx { get; set; }

    public string? HangSx { get; set; }

    public int? MaNuocThuongHieu { get; set; }

    public virtual TQuocGium? MaNuocThuongHieuNavigation { get; set; }

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();
}
