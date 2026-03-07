using System;
using System.Collections.Generic;

namespace StudentPro.Models;

public partial class Enrollment
{
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateOnly EnrollDate { get; set; }

    public string PaymentStatus { get; set; } = null!;

    public decimal PaidAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
