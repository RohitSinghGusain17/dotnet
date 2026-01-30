using System.Reflection.Metadata.Ecma335;

public delegate void Notify();
public class Student
{
    public int RollNo;
    public string? Name;
    public double Marks1;
    public double Marks2;
    public double Average;

    public event Notify? Notification;
    public void IsFail()
    {
        Notification?.Invoke();
    }
    public void calculateAverage()
    {
        Average = (Marks1+Marks2)/2;
    }
}
    

public class Program
{
    public static List<Student> students = new List<Student>();
    public static void Main(string[] args)
    {   
        
        students.Add(new Student{RollNo=1, Name="Rohit",Marks1=90, Marks2=89}); //90+89  89.5
        students.Add(new Student{RollNo=2, Name="Amit",Marks1=50, Marks2=59}); //50+79   
        students.Add(new Student{RollNo=3, Name="Sumit",Marks1=98, Marks2=89}); //98+89

        // var avg = students.Average(x=>(x.Marks1+x.Marks2)/2);
        // Console.WriteLine(avg);

        students=students.OrderByDescending(x=>x.Marks1+x.Marks2).ToList();
        Dictionary<double,int> RankList = new Dictionary<double, int>();
        int rank =1;
        foreach(var i in students)
        {
            if (!RankList.ContainsKey((i.Marks1 + i.Marks2) / 2))
            {
                RankList[(i.Marks1 + i.Marks2) / 2] = rank++;
            }
        }

        var obj = new Student();
        obj.Notification+=()=>Console.WriteLine("You need Improvement");
        
        foreach(var i in students)
        {
            i.calculateAverage();
            
            if (i.Average < 60)
            {
                Console.Write($" {i.Name}, Rank : {RankList[i.Average]}, ");
                obj.IsFail();
            }
            else
            {
                Console.WriteLine($" {i.Name}, Rank : {RankList[i.Average]}");
            }
        }


        // Predicate<int> Even = (x) => x%2==0;
        // Action print = () => Console.WriteLine("Hello");
        // Func<int,int,int> Sum = (a,b) => a+b;

        // Console.WriteLine(Even(4));
        // Console.WriteLine(Sum(4,2));
        // print();
    }
}