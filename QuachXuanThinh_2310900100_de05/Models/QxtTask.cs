using System;
using System.Collections.Generic;

namespace QuachXuanThinh_2310900100_de05.Models;

public partial class QxtTask
{
    public int QxtTaskId { get; set; }

    public string QxtTaskName { get; set; } = null!;

    public int QxtTaskLevel { get; set; }

    public DateTime QxtStartDate { get; set; }

    public bool QxtTaskStatus { get; set; }
}
