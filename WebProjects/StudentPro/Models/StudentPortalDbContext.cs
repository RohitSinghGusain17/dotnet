

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentPro.Models;

public partial class StudentPortalDbContext : DbContext
{
    public StudentPortalDbContext()
    {
    }

    public StudentPortalDbContext(DbContextOptions<StudentPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TblLog> TblLogs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasIndex(e => e.Title, "IX_Courses_Title");

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Courses_CreatedAt");
            entity.Property(e => e.Fee).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Courses_IsActive");
            entity.Property(e => e.Level).HasMaxLength(30);
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasIndex(e => e.CourseId, "IX_Enrollments_CourseId");

            entity.HasIndex(e => e.StudentId, "IX_Enrollments_StudentId");

            entity.HasIndex(e => new { e.StudentId, e.CourseId }, "UQ_Enrollments_StudentCourse").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Enrollments_CreatedAt");
            entity.Property(e => e.PaidAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .HasDefaultValue("Pending", "DF_Enrollments_PaymentStatus");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Courses");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Students");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.Email, "UX_Students_Email").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Students_CreatedAt");
            entity.Property(e => e.Email).HasMaxLength(180);
            entity.Property(e => e.FullName).HasMaxLength(120);
            entity.Property(e => e.Phone).HasMaxLength(30);
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasDefaultValue("Active", "DF_Students_Status");
        });

        modelBuilder.Entity<TblLog>(entity =>
        {
            entity.HasKey(e => e.LogId);

            entity.ToTable("tblLog");

            entity.Property(e => e.LogId).ValueGeneratedNever();
            entity.Property(e => e.Info)
                .HasMaxLength(2000)
                .IsUnicode(false);

            entity.HasOne(d => d.Student).WithMany(p => p.TblLogs)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblLog_Students");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
