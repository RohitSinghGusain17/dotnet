using FlightSearchEngine.Models;
using Microsoft.Data.SqlClient;
using System.Data;

public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    public async Task<List<string>> GetSourcesAsync()
    {
        var list = new List<string>();

        using SqlConnection con = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetSources", con);
        cmd.CommandType = CommandType.StoredProcedure;

        await con.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(reader["Source"].ToString());
        }

        return list;
    }

    public async Task<List<string>> GetDestinationsAsync()
    {
        var list = new List<string>();

        using SqlConnection con = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetDestinations", con);
        cmd.CommandType = CommandType.StoredProcedure;

        await con.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(reader["Destination"].ToString());
        }

        return list;
    }

    public async Task<List<FlightResult>> SearchFlightsAsync(string source, string destination, int persons)
    {
        var list = new List<FlightResult>();

        using SqlConnection con = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("sp_SearchFlights", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Source", source);
        cmd.Parameters.AddWithValue("@Destination", destination);
        cmd.Parameters.AddWithValue("@Persons", persons);

        await con.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(new FlightResult
            {
                FlightId = Convert.ToInt32(reader["FlightId"]),
                FlightName = reader["FlightName"].ToString(),
                FlightType = reader["FlightType"].ToString(),
                Source = reader["Source"].ToString(),
                Destination = reader["Destination"].ToString(),
                TotalCost = Convert.ToDecimal(reader["TotalCost"])
            });
        }

        return list;
    }

    public async Task<List<FlightHotelResult>> SearchFlightsWithHotelsAsync(string source, string destination, int persons)
    {
        var list = new List<FlightHotelResult>();

        using SqlConnection con = new SqlConnection(_connectionString);
        using SqlCommand cmd = new SqlCommand("sp_SearchFlightsWithHotels", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Source", source);
        cmd.Parameters.AddWithValue("@Destination", destination);
        cmd.Parameters.AddWithValue("@Persons", persons);

        await con.OpenAsync();
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(new FlightHotelResult
            {
                FlightId = Convert.ToInt32(reader["FlightId"]),
                FlightName = reader["FlightName"].ToString(),
                Source = reader["Source"].ToString(),
                Destination = reader["Destination"].ToString(),
                HotelName = reader["HotelName"].ToString(),
                TotalCost = Convert.ToDecimal(reader["TotalCost"])
            });
        }

        return list;
    }
}