public class Employee
{
    public int EmployeeId{get; set;}
    public string? Name{get; set;}
    public string? Department{get; set;}
    public double Salary{get; set;}
    public DateTime JoiningDate;
}

public class HRManager
{
    public List<Employee> EmployeesList = new List<Employee>();
    public void AddEmployee(string name, string dept, double salary)
    {
        EmployeesList.Add(new Employee{EmployeeId=Program.unique++, Name=name, Department=dept, Salary=salary, JoiningDate=DateTime.Now});
    }

    public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
    {
        SortedDictionary<string, List<Employee>> result = new SortedDictionary<string, List<Employee>>();
        var emp = EmployeesList.GroupBy(x=>x.Department);
        foreach (var i in emp)
        {
            result[i.Key!]=i.ToList();
        }

        return result;
    }

    public double CalculateDepartmentSalary(string department)
    {
        return EmployeesList.Where(x=>x.Department==department).Sum(x=>x.Salary);
    }

    public List<Employee> GetEmployeesJoinedAfter(DateTime date)
    {
        return EmployeesList.Where(x=>x.JoiningDate>date).ToList();
    }
}


public class Program
{
    public static int unique=1;
    public static void Main()
    {
        HRManager hr = new HRManager();

        hr.AddEmployee("Rohit", "IT", 50000);
        hr.AddEmployee("Aman", "HR", 40000);
        hr.AddEmployee("Priya", "IT", 55000);

        // Group by department
        var groups = hr.GroupEmployeesByDepartment();

        Console.WriteLine("Employees by Department:");
        foreach (var dept in groups)
        {
            Console.WriteLine(dept.Key + ":");
            foreach (var emp in dept.Value)
            {
                Console.WriteLine($"  {emp.EmployeeId} - {emp.Name}");
            }
        }

        // Department salary
        double total = hr.CalculateDepartmentSalary("IT");
        Console.WriteLine($"\nTotal IT Salary: {total}");

        // Employees joined after a date
        DateTime checkDate = DateTime.Now.AddMinutes(-1);
        var recent = hr.GetEmployeesJoinedAfter(checkDate);

        Console.WriteLine("\nRecently joined employees:");
        foreach (var emp in recent)
        {
            Console.WriteLine(emp.Name);
        }
    }
}