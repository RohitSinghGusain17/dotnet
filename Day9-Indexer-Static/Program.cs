using partial;
namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Indexer.cs
            // Indexer i = new Indexer();
            // i[0]="hello";
            // i[1]="rohit";
            // i[2]="how are you?";

            // Console.WriteLine(i[0]);
            // Console.WriteLine(i[1]);
            // Console.WriteLine(i[2]);
            #endregion


            #region Student.cs
            // Student s = new Student(1,"Rohit","Jalandhar");
            // s[0]="C#";
            // s[1]="C prog.";
            // s[2]="C++";
            // Console.WriteLine(s[0]);
            // Console.WriteLine(s.GetAddress());
            #endregion

            #region YoungProfessional
            // YoungProfessional yp = new YoungProfessional();
            #endregion

            #region Partial
            // Partial1 p2 = new Partial1();
            // Console.WriteLine(p2.Add());
            // Console.WriteLine(p2.Multiply());
            #endregion


            #region static class
            // StaticClass.GetRno();
            // StaticClass.Rno=2;
            // StaticClass.GetRno();
            #endregion


            #region Extended Method
            string sent = "I am Fine.";
            int count = sent.WordCount();
            Console.WriteLine(count);
            #endregion
        }
    }
}
