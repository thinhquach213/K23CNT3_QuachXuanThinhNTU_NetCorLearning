using System;
using System.Collections.Generic;

namespace WebQlVali.Models;

public partial class TChatLieu
{
    public int MaChatLieu { get; set; }

    public string ChatLieu { get; set; } = null!;

    public virtual ICollection<TDanhMucSp> TDanhMucSps { get; set; } = new List<TDanhMucSp>();
}
