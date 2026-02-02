public class Student
{
    public int StudentId;
    public string? Name;
    public string? GradeLevel;
    public Dictionary<string, double> Subjects = new Dictionary<string, double>();
}

public class SchoolManager{
    List<Student> students = new List<Student>();
    public void AddStudent(string name, string gradeLevel)
    {
        students.Add(new Student{StudentId=Program.unique++, Name=name, GradeLevel=gradeLevel});
    }

    public void AddGrade(int studentId, string subject, double grade){
        students.FirstOrDefault(x=>x.StudentId==studentId)?.Subjects[subject]=grade;
    }

    public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
    {
        SortedDictionary<string,List<Student>> listStudent = new SortedDictionary<string, List<Student>>();
        var list = students.GroupBy(x=>x.GradeLevel).ToList();
        foreach(var i in list)
        {
            listStudent[i.Key!]=i.ToList();
        }

        return listStudent;
    }
    public double CalculateStudentAverage(int studentId)
    {
        var studentData = students.FirstOrDefault(x=>x.StudentId==studentId)?.Subjects;
        return studentData!.Average(x=>x.Value);
    }

    public Dictionary<string, double> CalculateSubjectAverages()
    {
        // Dictionary<string, double> dict = new Dictionary<string, double>();
        return students
        .SelectMany(s => s.Subjects)          // flatten all subject-grade pairs
        .GroupBy(s => s.Key)                  // group by subject name
        .ToDictionary(
            g => g.Key,
            g => g.Average(x => x.Value)
        );
    }

    public List<Student> GetTopPerformers(int count)
    {
        return students.OrderByDescending(x=>x.Subjects.Average(a=>a.Value)).Take(count).ToList();
    }
}