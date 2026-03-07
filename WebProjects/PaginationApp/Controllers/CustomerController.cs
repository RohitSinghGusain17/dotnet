using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using PaginationApp.Models;
using System.Data;


namespace PaginationApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly string connectionString = "Data Source=.\\SQLEXPRESS;Database=AdventureWorksLT2025;Trusted_Connection=True;TrustServerCertificate=True;";

        public IActionResult Index(int page = 1)
        {
            int pageSize = 10;

            List<Customer> customers = new List<Customer>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("GetCustomerPagination", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@PageNumber", page);
                cmd.Parameters.AddWithValue("@PageSize", pageSize);

                con.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new Customer
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString()
                    });
                }
            }

            ViewBag.Page = page;

            return View(customers);
        }
    }
}
