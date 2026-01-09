using System.Security.Cryptography.X509Certificates;

public class Program
{
    public delegate void Mydelegate(string msg);
    static void MethodA(string msg)
    {
        Console.WriteLine("A: "+msg);
    }
    static void MethodB(string msg)
    {
        Console.WriteLine("B: "+msg);
    }
    static void MethodC(string msg)
    {
        Console.WriteLine("C: "+msg);
    }
    private static string HappyDiwali(string message)
    {
        return "Happy Diwali";
    }
    public static void Main(string[] args)
    {
        #region PrintingComapny
        // PrintingCompany printingCompany = new PrintingCompany();
        // printingCompany.CustomerChoicePrintMessage = new PrintMessage(HappyDiwali);
        // printingCompany.Print("hello");
        #endregion


        #region Multiple Delegate(combined)
        // Mydelegate d = MethodA;
        // d += MethodB;
        // d+=MethodC;
        // d("Hello");
        #endregion


        #region Question 1
        // IList<Person> p = new List<Person>();
        // p.Add(new Person {Name = "Aarya", Address = "A2101", Age = 69});
        // p.Add(new Person {Name = "Daniel", Address="D104", Age = 40});
        // p.Add(new Person {Name = "Ira", Address = "H801", Age = 25});
        // p.Add(new Person {Name = "Jennifer", Address = "I1704", Age = 33});
        // PersonImplementaion obj = new PersonImplementaion();
        // Console.WriteLine(obj.GetName(p));
        // Console.WriteLine(obj.Average(p));
        // Console.WriteLine(obj.Max(p));
        #endregion


        #region Question Student List
        // List<Student> stu = new List<Student>();
        // stu.Add(new Student{StudentId=1, StudentName="Rohit", CourseName="abc"});
        // stu.Add(new Student{StudentId=2, StudentName="Aman", CourseName="xyz"});
        // stu.Add(new Student{StudentId=3, StudentName="Amit", CourseName="abc"});
        
        // foreach(Student i in stu)
        // {
        //     Console.WriteLine(i.StudentId+" "+i.StudentName+" "+i.CourseName);
        // }
        #endregion
    }
}