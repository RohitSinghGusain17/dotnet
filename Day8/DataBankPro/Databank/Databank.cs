using Model;

namespace Databank
{
    public static class DataBank
    {
        public static List<Student>? students = new List<Student>();
        public static List<StudentSession>? sessions = new List<StudentSession>();
        static DataBank()
        {
            students.Add(new Student(){ID=1, Name="Rohit"});
            students.Add(new Student(){ID=2, Name="Sumit"});
            students.Add(new Student(){ID=3, Name="Amit"});

            sessions.Add(new StudentSession(){ID=1, Name="Rohit", Detail="hello 1"});
            sessions.Add(new StudentSession(){ID=2, Name="Sumit", Detail="hello 2"});
            sessions.Add(new StudentSession(){ID=3, Name="Amit", Detail="hello 3"});
        }

        public static List<Student>? GetStudents()
        {
            return students;
        }

        public static List<StudentSession>? GetSessions()
        {
            return sessions;
        }
    }
}