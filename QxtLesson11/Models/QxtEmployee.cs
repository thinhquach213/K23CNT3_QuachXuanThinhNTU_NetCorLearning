using System;
using System.Collections.Generic;

namespace QxtLesson11.Models;

public partial class QxtEmployee
{
    public int QxtEmpId { get; set; }

    public string QxtEmpName { get; set; } = null!;

    public string QxtEmpLevel { get; set; } = null!;

    public DateOnly QxtEmpStartDate { get; set; }

    public bool QxtEmpStatus { get; set; }
}
