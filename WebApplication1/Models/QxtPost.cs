using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class QxtPost
{
    public int QxtId { get; set; }

    public string QxtTitle { get; set; } = null!;

    public string? QxtImage { get; set; }

    public string? QxtContent { get; set; }

    public bool QxtStatus { get; set; }
}
