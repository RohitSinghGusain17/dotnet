using visit;

namespace Day6
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region interface
            // Child c = new Child();
            // c.Print();
            #endregion


            #region Visitor
            // Visitor v = new Visitor();
            // v.EatVeg();
            // v.EatNonVeg();
            // Iveg veg = v;
            // veg.Taste();
            // INonVeg nonveg = v;
            // nonveg.Taste();
            #endregion


            #region User
            HOD hod = new HOD("Dr. Hod", 101, "Computer Science");
            Examiner examiner = new Examiner("abc", 201, "Computer Science");
            Semester semester = new Semester();
            semester.Number = 3;
            Exam exam = new Exam();
            exam.Subject = "Data Structures";
            exam.semester = semester;
            hod.ScheduleExam(semester, exam);
            hod.AssignExaminer(examiner, exam);
            #endregion
        }
    }
}
