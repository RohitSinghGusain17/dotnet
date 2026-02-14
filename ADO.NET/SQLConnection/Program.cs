using Microsoft.Data.SqlClient;
using DotNetEnv;
public class Program
{
    public static void GetEmployeesData(SqlConnection con, string sqlSelect)
    {
        using (var cmd = new SqlCommand(sqlSelect, con))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string name = reader.GetString(1);
                    string dept = reader.GetString(2);
                    decimal salary = reader.GetDecimal(3);

                    Console.WriteLine($"{id} | {name} | {dept} | {salary}");
                }
            }
        }
    }

    public static void InsertEmployeeData(SqlConnection con, string insertQuery)
    {
        Console.Write("EmployeeId (Unique): ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("Enter Name: ");
        string name = Console.ReadLine() ?? "";
        Console.Write("Enter Department (e.g., IT): ");
        string dept = Console.ReadLine() ?? "";
        Console.Write("New Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

        using (var cmd = new SqlCommand(insertQuery, con))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@deptid", dept);
            cmd.Parameters.AddWithValue("@salary", salary);

            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine("Inserted Row : " + rows);
        }
    }

    public static void UpdateEmployeeSalary(SqlConnection con, string sqlUpdate)
    {
        Console.Write("EmployeeId: ");
        int id = int.Parse(Console.ReadLine() ?? "0");
        Console.Write("New Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine() ?? "0");

        using (var cmd = new SqlCommand(sqlUpdate, con))
        {
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@salary", salary);
            int rows = cmd.ExecuteNonQuery();
            Console.WriteLine($"Updated rows: {rows}");
        }
    }

    public static void GetEmployeesByDept(SqlConnection con, string sqlFilter)
    {
        Console.Write("Enter Department (e.g., IT): ");
        string dept = Console.ReadLine() ?? "";

        using (var cmd = new SqlCommand(sqlFilter, con))
        {
            cmd.Parameters.AddWithValue("@dept", dept);
            using var r = cmd.ExecuteReader();
            while (r.Read())
            {
                Console.WriteLine($"{r["EmpId"]} | {r["EmployeeName"]} | {r["Salary"]}");
            }
        }
    }

    public static void DeleteEmployeeData(SqlConnection con, string sqlDelete)
    {
        Console.Write("EmployeeId to delete: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        using(var cmd = new SqlCommand(sqlDelete, con)){

            cmd.Parameters.AddWithValue("@id", id);

            int rows = cmd.ExecuteNonQuery();

            Console.WriteLine(rows == 1 ? "Deleted" : "Not found");
        }
    }

    public static void Main()
    {
        Env.Load();
        string cs = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;

        string sqlSelect = @"SELECT EmpID, EmployeeName, DeptID, Salary FROM dbo.Employee ORDER BY EmpID";
        string sqlInsert = @"INSERT INTO dbo.Employee(EmpID, EmployeeName, DeptID, Salary) VALUES (@id, @name, @deptid, @salary)";
        string sqlFilter = @"SELECT EmpId, EmployeeName, Salary FROM dbo.Employee WHERE DeptId = @dept ORDER BY Salary DESC";
        string sqlUpdate = @"UPDATE dbo.Employee SET Salary=@salary WHERE EmpId=@id";
        string sqlDelete = @"DELETE FROM dbo.Employee WHERE EmpId=@id";

        using (var con = new SqlConnection(cs))
        {
            con.Open();

            bool flag = true;
            while (flag)
            {
                Console.WriteLine("------------------------------Employee DB-----------------------------");
                Console.WriteLine("1. Get All Employee Details");
                Console.WriteLine("2. Insert Employee");
                Console.WriteLine("3. Update Employee Salary by ID");
                Console.WriteLine("4. Get Employees by Dept");
                Console.WriteLine("5. Delete Employee by ID");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice : ");

                int choice = int.Parse(Console.ReadLine()!);
                switch (choice)
                {
                    case 1:
                        Program.GetEmployeesData(con, sqlSelect);
                        break;
                    case 2:
                        Program.InsertEmployeeData(con, sqlInsert);
                        break;
                    case 3:
                        Program.UpdateEmployeeSalary(con, sqlUpdate);
                        break;
                    case 4:
                        Program.GetEmployeesByDept(con, sqlFilter);
                        break;
                    case 5:
                        Program.DeleteEmployeeData(con, sqlDelete);
                        break;
                    case 6:
                        flag=false;
                        Console.WriteLine("Thank You");
                        break;
                }
            }
        }
    }
}