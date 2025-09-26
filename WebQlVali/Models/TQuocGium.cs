using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TQuocGium
{
    public int MaNuoc { get; set; }

    public string TenNuoc { get; set; } = null!;

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();

    public virtual ICollection<THangSx> THangSxes { get; set; } = new List<THangSx>();
}
