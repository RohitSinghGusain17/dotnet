public class Person
{
    public string? Name{get; set;}
    public int Age{get; set;}

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class Student : Person
{
    public int RollNo{get; set;}
    public double Marks{get; set;}

    public Student(string name, int age, int rollno, double marks) : base(name, age)
    {
        RollNo = rollno;
        Marks=marks;
    }

    public void GetStudentDetails()
    {
        string status="";
        if (Marks < 35)
        {
            status="Fail";
        }
        else
        {
            status="Pass";
        }
        Console.WriteLine($"Student Details : {RollNo}, {Name}, {Age}, {Marks}, {status}");
    }
}

public class Program
{
    public static void Main()
    {
        Student student = new Student("Rohit", 20, 1, 50);
        student.GetStudentDetails();
    }
}