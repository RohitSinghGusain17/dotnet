public class MyProcess
{
    public int Id{get; set;}
    public string? Name{get; set;}
}
public class LinqStudent
{
    public string? Name{get; set;}
}

public class Program
{
    private static void LinqExample1()
    {
        var proCollection = from p in System.Diagnostics.Process.GetProcesses() select new MyProcess()
        {
            Name=p.ProcessName,
            Id=p.Id,
        };

        foreach(var i in proCollection)
        {
            System.Console.WriteLine(i.Name+" "+i.Id);
        }
    }
    private static void LinqExample2()
    {
        var proCollection = from p in System.Diagnostics.Process.GetProcesses() select new
        {
            Name=p.ProcessName,
            Id=p.Id,
        };

        foreach(var i in proCollection)
        {
            System.Console.WriteLine(i.Name+" "+i.Id);
        }
    }
    public static bool Palindrome(string str)
    {
        int i=0;
        int j=str.Length-1;
        while (i < j)
        {
            if (str[i] != str[j])
            {
                return false;
            }
            i++;
            j--;
        }
        return true;
    }

    public static void Main(string[] args)
    {
        string[] names = {"Rohit","Aman","Sumit","Naman"};
        //string contains
        // var myLinqQuery = from name in names where name.Contains('a') select name;
        // foreach(var name in myLinqQuery)
        // {
        //     Console.WriteLine(name+" ");
        // }


        //bulkoperation
        // var findname = from name in names orderby name ascending select name.ToUpper();
        // foreach(var name in findname)
        // {
        //     Console.WriteLine(name+" ");
        // }


        //Palindrome
        // var ans = from name in names where Palindrome(name.ToLower()) select name;
        // foreach(var name in ans)
        // {
        //     Console.WriteLine(name+" ");
        // }


        //LinqStudent
        // var findname2= from name in names orderby name ascending select new LinqStudent()
        // {
        //     Name=name
        // };
        // foreach(var n in findname2)
        // {
        //     System.Console.WriteLine(n.Name);
        // }


        //Process
        // LinqExample1();
        // LinqExample2();


        //Average of two marks (used collection here)
        // List<List<int>> marks = new List<List<int>>
        // {   
        //     new List<int>{ 23, 34 },
        //     new List<int>{ 34, 56 }
        // };


        // var students = from mark in marks select new
        // {
        //     Marks1=mark[0],
        //     Marks2=mark[1],
        // };
        // var avg = (from s in students select s.Marks2+s.Marks1).Average();
        
        // Console.WriteLine(avg);


        //Demo
        LearnLinq.RunDemo();

    }
}

