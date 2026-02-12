using System;
using System.Reflection;
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public decimal Salary { get; private set; }

    private string secretCode = "X9Z";

    public Employee() { }

    public Employee(int id, string name, decimal salary)
    {
        Id = id;
        Name = name;
        Salary = salary;
    }

    public void GiveRaise(decimal amount)
    {
        Salary += amount;
    }

    private string GetSecretCode() => secretCode;
}


public class Program
{
    public static void Main()
    {
        Employee emp = new Employee(101, "Arun", 45000m);

        //Public method
        Type t = emp.GetType();
        MethodInfo? m = t.GetMethod("GiveRaise");
        m!.Invoke(emp, new object[] { 5000m });
        Console.WriteLine(emp.Salary);


        //Private method
        MethodInfo? m1 = t.GetMethod("GetSecretCode", BindingFlags.Instance | BindingFlags.NonPublic);
        object? result = m1!.Invoke(emp, null);
        Console.WriteLine("Private method result = " + result);
    }
}