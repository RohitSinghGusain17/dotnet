using System;
using System.Collections.Generic;
using System.Linq;

// Base constraints
public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

// 1. Generic enrollment system
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();
    
    // TODO: Enroll student with constraints
    public bool EnrollStudent(TStudent student, TCourse course)
    {
        if (!_enrollments.ContainsKey(course))
        {
            _enrollments[course] = new List<TStudent>();
        }

        var students = _enrollments[course];

        // - Course not at capacity
        if (students.Count >= course.MaxCapacity)
        {
            return false;
        }

        // - Student not already enrolled
        if (students.Contains(student))
        {
            return false;
        }

        students.Add(student);
        return true;
    }
    
    // TODO: Get students for course
    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (!_enrollments.ContainsKey(course))
        {
            return Array.Empty<TStudent>();
        }

        // Return immutable list
        return _enrollments[course].AsReadOnly();
    }
    
    // TODO: Get courses for student
    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        // Return courses student is enrolled in
        return _enrollments.Where(x => x.Value.Contains(student)).Select(x => x.Key);
    }
    
    // TODO: Calculate student workload
    public int CalculateStudentWorkload(TStudent student)
    {
        // Sum credits of all enrolled courses
        return GetStudentCourses(student).Sum(c => c.Credits);
    }

    public bool IsEnrolled(TStudent student, TCourse course)
    {
        return _enrollments.ContainsKey(course) && _enrollments[course].Contains(student);
    }
}

// 2. Specialized implementations
public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; } // Prerequisite
}

// 3. Generic gradebook
public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();
    private EnrollmentSystem<TStudent, TCourse> _enrollment;
    
    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
    {
        _enrollment = enrollment;
    }
    
    // TODO: Add grade with validation
    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        // Grade must be between 0 and 100
        if (grade < 0 || grade > 100)
        {
            throw new Exception("Grade must be between 0 and 100");
        }

        // Student must be enrolled in course
        if (!_enrollment.IsEnrolled(student, course))
        {
            throw new Exception("Student must be enrolled in course");
        }

        _grades[(student, course)] = grade;
    }
    
    // TODO: Calculate GPA for student
    public double? CalculateGPA(TStudent student)
    {
        var records = _grades.Where(g=>g.Key.Item1.Equals(student)).ToList();

        if (!records.Any())
        {
            return null;
        }

        double totalWeighted = 0;
        int totalCredits = 0;
        foreach (var r in records)
        {
            var course = r.Key.Item2;
            totalWeighted += r.Value * course.Credits;
            totalCredits += course.Credits;
        }

        return totalWeighted / totalCredits;
    }
    
    // TODO: Find top student in course
    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var records = _grades.Where(g=>g.Key.Item2.Equals(course)).ToList();

        if (!records.Any())
        {
            return null;
        }

        var top = records.OrderByDescending(g => g.Value).First();
        return (top.Key.Item1, top.Value);
    }
}

// 4. TEST SCENARIO: Create a simulation
public class Program
{
    public static void Main()
    {
        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
        var gradebook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

        // a) Create 3 EngineeringStudent instances
        var s1 = new EngineeringStudent { StudentId = 1, Name = "Rohit", Semester = 3, Specialization = "AI" };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "Aman", Semester = 1, Specialization = "CS" };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "Sumit", Semester = 4, Specialization = "Robotics" };

        // b) Create 2 LabCourse instances with prerequisites
        var c1 = new LabCourse
        {
            CourseCode = "LAB101",
            Title = "Electronics Lab",
            MaxCapacity = 2,
            Credits = 3,
            LabEquipment = "BreadBoard",
            RequiredSemester = 2
        };

        var c2 = new LabCourse
        {
            CourseCode = "LAB201",
            Title = "Advanced Robotics Lab",
            MaxCapacity = 1,
            Credits = 4,
            LabEquipment = "Robot Arm",
            RequiredSemester = 4
        };

        // c) Demonstrate:
        //    - Successful enrollment
        Console.WriteLine(enrollment.EnrollStudent(s1, c1));
        Console.WriteLine(enrollment.EnrollStudent(s3, c1));

        //    - Failed enrollment (capacity, prerequisite)
        Console.WriteLine(enrollment.EnrollStudent(s2, c1));
        Console.WriteLine(enrollment.EnrollStudent(s1, c2));
        Console.WriteLine(enrollment.EnrollStudent(s3, c2));
        Console.WriteLine(enrollment.EnrollStudent(s1, c2));

        //    - Grade assignment
        gradebook.AddGrade(s1, c1, 85);
        gradebook.AddGrade(s3, c1, 92);
        gradebook.AddGrade(s3, c2, 88);

        //    - GPA calculation
        Console.WriteLine($"GPA Rohit: {gradebook.CalculateGPA(s1)}");
        Console.WriteLine($"GPA Neha: {gradebook.CalculateGPA(s3)}");

        //    - Top student per course
        var top = gradebook.GetTopStudent(c1);
        if (top != null)
        {
            Console.WriteLine($"Top student in {c1.Title}: {top.Value.student.Name} ({top.Value.grade})");
        }
    }
}