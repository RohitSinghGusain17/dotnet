public class Program
{
    public static int unique = 1;

    static void Main(string[] args)
    {
        SchoolManager manager = new SchoolManager();

        // Add students
        manager.AddStudent("Alice", "Grade 10");
        manager.AddStudent("Bob", "Grade 10");
        manager.AddStudent("Charlie", "Grade 11");

        // Add grades
        manager.AddGrade(1, "Math", 90);
        manager.AddGrade(1, "Science", 85);

        manager.AddGrade(2, "Math", 78);
        manager.AddGrade(2, "Science", 88);

        manager.AddGrade(3, "Math", 92);
        manager.AddGrade(3, "Science", 95);

        // Calculate student average
        Console.WriteLine($"Alice's Average: {manager.CalculateStudentAverage(1)}");

        // Group students by grade level
        Console.WriteLine("\nStudents Grouped by Grade Level:");
        var grouped = manager.GroupStudentsByGradeLevel();
        foreach (var grade in grouped)
        {
            Console.WriteLine(grade.Key);
            foreach (var student in grade.Value)
            {
                Console.WriteLine($"  - {student.Name}");
            }
        }

        // Calculate subject averages
        Console.WriteLine("\nSubject Averages:");
        var subjectAverages = manager.CalculateSubjectAverages();
        foreach (var subject in subjectAverages)
        {
            Console.WriteLine($"{subject.Key}: {subject.Value}");
        }

        // Get top performers
        Console.WriteLine("\nTop Performers:");
        var topStudents = manager.GetTopPerformers(2);
        foreach (var student in topStudents)
        {
            Console.WriteLine($"{student.Name}");
        }
    }
}
