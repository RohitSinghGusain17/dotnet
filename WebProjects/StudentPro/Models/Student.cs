using System;
using System.Collections.Generic;

namespace StudentPro.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly JoinDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();

    public virtual ICollection<TblLog> TblLogs { get; set; } = new List<TblLog>();
}
