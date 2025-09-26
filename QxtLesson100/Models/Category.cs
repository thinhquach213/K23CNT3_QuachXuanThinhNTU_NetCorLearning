using System;
using System.Collections.Generic;

namespace QxtLesson100.Models;

public partial class Category
{
    public int CateId { get; set; }

    public string CateName { get; set; } = null!;

    public bool CateStatus { get; set; }
}
