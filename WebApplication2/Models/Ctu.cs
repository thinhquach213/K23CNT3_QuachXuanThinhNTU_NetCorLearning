using System;
using System.Collections.Generic;

namespace WebApplication2.Models;

public partial class Ctu
{
    public int CtuId { get; set; }

    public string CtuTitle { get; set; } = null!;

    public string? CtuImage { get; set; }

    public string? CtuContent { get; set; }

    public bool? CtuStatus { get; set; }
}
