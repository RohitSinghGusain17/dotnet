using System;
using System.Collections.Generic;

namespace StudentPro.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string Title { get; set; } = null!;

    public int DurationDays { get; set; }

    public decimal Fee { get; set; }

    public string Level { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
