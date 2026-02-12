public class Student
{
    public string? Id{get; set;}
    public string? Name{get; set;}
    public string? Course{get; set;}
    public int Marks{get; set;}
}

public class StudentUtility
{
    public Dictionary<string, string> GetStudentDetails(string id)
    {
        Dictionary<string, string> result = new Dictionary<string, string>();
        var output = Program.studentDetails.FirstOrDefault(x=>x.Value.Id==id);

        if(output.Equals(default(KeyValuePair<int, Student>)))
        {
            return result;
        }

        string str = output.Value.Name+"_"+output.Value.Course;
        result[id]=str;

        return result;
    }

    public Dictionary<string, Student> UpdateStudentMarks(string id, int marks)
    {
        Dictionary<string, Student> result = new Dictionary<string, Student>();
        var output = Program.studentDetails.FirstOrDefault(x=>x.Value.Id==id);

        if(output.Equals(default(KeyValuePair<int, Student>)))
        {
            return result;
        }

        output.Value.Marks=marks;
        result[id]=output.Value;

        return result;
    }
}

public class Program
{
    public static Dictionary<int, Student> studentDetails = new Dictionary<int, Student>();

    public static void Main()
    {
        studentDetails.Add(1,new Student{Id="1",Name="Rohit", Marks=90, Course="english"});
        studentDetails.Add(2,new Student{Id="2",Name="Sumit", Marks=90, Course="english"});
        studentDetails.Add(3,new Student{Id="3",Name="Amit", Marks=90, Course="english"});
        StudentUtility studentUtility = new StudentUtility();
        bool flag=true;
        while (flag)
        {
            Console.WriteLine("1-Get student details");
            Console.WriteLine("2-Update marks");
            Console.WriteLine("3-Exit");

            Console.WriteLine("Enter your choice : ");
            int ch = int.Parse(Console.ReadLine()!);

            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter the student id");
                    string id = Console.ReadLine()!;
                    var result = studentUtility.GetStudentDetails(id);
                    if (result.Count==0)
                    {
                        Console.WriteLine("Student is not found");
                    }
                    else
                    {
                        foreach(var i in result)
                        {
                            Console.WriteLine(i.Key+" "+i.Value);
                        }
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the student id");
                    string Id = Console.ReadLine()!;
                    Console.WriteLine("Enter marks to update");
                    int marks = int.Parse(Console.ReadLine()!);
                    var result2 = studentUtility.UpdateStudentMarks(Id,marks);
                    if (result2.Count==0)
                    {
                        Console.WriteLine("Student is not found");
                    }
                    else
                    {
                        foreach(var i in result2)
                        {
                            Console.WriteLine(i.Key+" "+i.Value);
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Thank you");
                    flag=false;
                    break;
            }
        }
    }
}