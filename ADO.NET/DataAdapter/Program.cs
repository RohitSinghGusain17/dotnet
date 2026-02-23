using Microsoft.Data.SqlClient;
using DotNetEnv;
using System.Data;

public class Program
{
    public static DataSet ds = new DataSet();

    public static void GetEmployeesData(SqlConnection con, string sql)
    {
        ds.Clear();

        using (var cmd = new SqlCommand(sql, con))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(ds);
        }

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            Console.WriteLine(row[0] + " " + row[1] + " " + row[2] + " " + row[3]);
        }
    }

    public static void InsertEmployeeData(SqlConnection con, string sql)
    {
        ds.Clear();

        SqlDataAdapter adapter = new SqlDataAdapter("SELECT EmpID, EmployeeName, DeptID, Salary FROM Employee", con);
        adapter.Fill(ds, "Employee");

        adapter.InsertCommand = new SqlCommand(sql, con);

        adapter.InsertCommand.Parameters.Add("@id", SqlDbType.Int, 0, "EmpID");
        adapter.InsertCommand.Parameters.Add("@name", SqlDbType.VarChar, 50, "EmployeeName");
        adapter.InsertCommand.Parameters.Add("@deptid", SqlDbType.VarChar, 50, "DeptID");
        adapter.InsertCommand.Parameters.Add("@salary", SqlDbType.Decimal, 18, "Salary");

        DataTable table = ds.Tables["Employee"];

        Console.Write("EmployeeId (Unique): ");
        int id = int.Parse(Console.ReadLine()!);
        Console.Write("Enter Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Enter Department: ");
        string dept = Console.ReadLine()!;
        Console.Write("Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine()!);

        DataRow newRow = table.NewRow();
        newRow["EmpID"] = id;
        newRow["EmployeeName"] = name;
        newRow["DeptID"] = dept;
        newRow["Salary"] = salary;

        table.Rows.Add(newRow);

        adapter.Update(ds, "Employee");
        Console.WriteLine("Row inserted");
    }

    public static void UpdateEmployeeSalary(SqlConnection con, string sql)
    {
        ds.Clear();

        SqlDataAdapter adapter = new SqlDataAdapter("SELECT EmpID, EmployeeName, DeptID, Salary FROM Employee", con);
        adapter.Fill(ds, "Employee");

        adapter.UpdateCommand = new SqlCommand(sql, con);

        adapter.UpdateCommand.Parameters.Add("@salary", SqlDbType.Decimal, 18, "Salary");
        adapter.UpdateCommand.Parameters.Add("@id", SqlDbType.Int, 0, "EmpID");

        DataTable table = ds.Tables["Employee"];

        Console.Write("Enter Employee ID: ");
        int id = int.Parse(Console.ReadLine()!);
        Console.Write("Enter New Salary: ");
        decimal salary = decimal.Parse(Console.ReadLine()!);

        DataRow[] rows = table.Select("EmpID=" + id);

        if (rows.Length > 0)
        {
            rows[0]["Salary"] = salary;
            adapter.Update(ds, "Employee");
            Console.WriteLine("Salary updated");
        }
        else
        {
            Console.WriteLine("Employee not found");
        }
    }

    public static void GetEmployeesByDept(SqlConnection con)
    {
        ds.Clear();

        SqlDataAdapter adapter = new SqlDataAdapter("SELECT EmpID, EmployeeName, DeptID, Salary FROM Employee", con);
        adapter.Fill(ds, "Employee");

        Console.Write("Enter DeptID: ");
        string dept = Console.ReadLine()!;

        DataTable table = ds.Tables["Employee"];

        DataRow[] rows = table.Select("DeptID='" + dept + "'");

        foreach (DataRow row in rows)
        {
            Console.WriteLine(row["EmpID"] + " " + row["EmployeeName"] + " " + row["DeptID"] + " " + row["Salary"]);
        }
    }

    public static void DeleteEmployeeData(SqlConnection con, string sql)
    {
        ds.Clear();

        SqlDataAdapter adapter = new SqlDataAdapter("SELECT EmpID, EmployeeName, DeptID, Salary FROM Employee", con);
        adapter.Fill(ds, "Employee");

        adapter.DeleteCommand = new SqlCommand(sql, con);
        adapter.DeleteCommand.Parameters.Add("@id", SqlDbType.Int, 0, "EmpID");

        DataTable table = ds.Tables["Employee"];

        Console.Write("Enter Employee ID to delete: ");
        int id = int.Parse(Console.ReadLine()!);

        DataRow[] rows = table.Select("EmpID=" + id);

        if (rows.Length > 0)
        {
            rows[0].Delete();
            adapter.Update(ds, "Employee");
            Console.WriteLine("Employee deleted");
        }
        else
        {
            Console.WriteLine("Employee not found");
        }
    }

    public static void Main()
    {
        Env.Load();
        string cs = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;

        string sqlSelect = @"SELECT EmpID, EmployeeName, DeptID, Salary FROM dbo.Employee ORDER BY EmpID";
        string sqlInsert = @"INSERT INTO Employee(EmpID, EmployeeName, DeptID, Salary) VALUES (@id, @name, @deptid, @salary)";
        string sqlUpdate = @"UPDATE dbo.Employee SET Salary=@salary WHERE EmpId=@id";
        string sqlDelete = @"DELETE FROM dbo.Employee WHERE EmpId=@id";

        using (var con = new SqlConnection(cs))
        {
            con.Open();

            bool flag = true;

            while (flag)
            {
                Console.WriteLine("----------------Employee DB----------------");
                Console.WriteLine("1. Get All Employees");
                Console.WriteLine("2. Insert Employee");
                Console.WriteLine("3. Update Salary");
                Console.WriteLine("4. Get Employees By Dept");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");

                Console.Write("Enter choice: ");
                int choice = int.Parse(Console.ReadLine()!);

                switch (choice)
                {
                    case 1:
                        GetEmployeesData(con, sqlSelect);
                        break;
                    case 2:
                        InsertEmployeeData(con, sqlInsert);
                        break;
                    case 3:
                        UpdateEmployeeSalary(con, sqlUpdate);
                        break;
                    case 4:
                        GetEmployeesByDept(con);
                        break;
                    case 5:
                        DeleteEmployeeData(con, sqlDelete);
                        break;
                    case 6:
                        flag = false;
                        Console.WriteLine("Thank You");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}