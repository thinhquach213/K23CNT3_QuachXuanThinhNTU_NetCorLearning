using System;
using System.Collections.Generic;

namespace WebBanHangOnline.Models;

public partial class DbOrderDetail
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? ProductId { get; set; }

    public decimal? Price { get; set; }

    public int? Quantity { get; set; }
}
