using System;
using System.Collections.Generic;

namespace WebBanHangOnline.Models;

public partial class DbSub
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public DateTime? CreatedDate { get; set; }
}
