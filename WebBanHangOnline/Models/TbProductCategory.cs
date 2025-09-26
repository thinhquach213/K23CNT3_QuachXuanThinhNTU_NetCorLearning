using System;
using System.Collections.Generic;

namespace WebBanHangOnline.Models;

public partial class TbProductCategory
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Icon { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public string? ModifierBy { get; set; }
}
