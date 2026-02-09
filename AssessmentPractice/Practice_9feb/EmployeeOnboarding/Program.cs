public class Employee
{
    public int Id{get; set;}
    public string? Name{get; set;}
    public string? Email{get; set;}
    public double Salary{get; set;}

    public Employee(int id, string name, string email, double salary){
        Id=id;
        Name=name;
        if (!email.Contains('@'))
        {
            Email="unknown@company.com";
        }
        else
        {
            Email=email;
        }

        if (salary <= 0)
        {
            Salary=30000;
        }
        else
        {
            Salary=salary;
        }
    }

    public void getEmployeeDetails()
    {
        Console.WriteLine($"Employee Details : {Id}, {Name}, {Email}, {Salary}");
    }
}

public class Program
{
    public static void Main()
    {
        Employee employee1 = new Employee(1,"Rohit","rohit@gmail.com",23456);
        Employee employee2 = new Employee(2,"Amit","abcgmail.com",34563);
        Employee employee3 = new Employee(3,"Sumit","qwet@gmail.com",0);
        employee1.getEmployeeDetails();
        employee2.getEmployeeDetails();
        employee3.getEmployeeDetails();
    }
}