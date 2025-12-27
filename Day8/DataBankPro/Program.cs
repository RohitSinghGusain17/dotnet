using Databank;
using Model;

namespace ExamSchedule
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Student>? localStudents = DataBank.GetStudents()!;
            // var localStudents = DataBank.GetStudents();
            // foreach(var i in localStudents)
            // {
            //     Console.WriteLine(i.ID+" "+i.Name);   
            // }

            List<StudentSession>? totalSessions = DataBank.GetSessions()!;
        }
    }
}
