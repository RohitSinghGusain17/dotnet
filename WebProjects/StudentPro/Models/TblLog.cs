using System;
using System.Collections.Generic;

namespace StudentPro.Models;

public partial class TblLog
{
    public int StudentId { get; set; }

    public int LogId { get; set; }

    public string? Info { get; set; }

    public virtual Student Student { get; set; } = null!;
}
