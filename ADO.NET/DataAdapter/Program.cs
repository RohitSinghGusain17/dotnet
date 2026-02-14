using Microsoft.Data.SqlClient;
using DotNetEnv;
using System.Data;

public class Program
{
    public static void Main()
    {
        Env.Load();
        string cs = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;

        string sql = @"SELECT EmpID, EmployeeName, DeptID, Salary FROM dbo.Employee ORDER BY EmpID";
        DataSet ds = new DataSet();
        using (var con = new SqlConnection(cs)){
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
            }
            ds.WriteXml("TestData");
        }
    }
}