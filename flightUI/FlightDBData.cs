using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using flightManagement.Data;
using flightManagement.BLL;

namespace flightManagement.UI
{
    public class FlightDBData : IFlightDataService
    {
        private string connectionString =
        "Data Source=localhost\\SQLEXPRESS;Initial Catalog=flightDB;Integrated Security=True;TrustServerCertificate=True;";

        public List<Flight> GetFlights()
        {
            var flights = new List<Flight>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT Id, flightdestination, OriginCode, DestinationCode, time, price FROM fly";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    flights.Add(new Flight
                    {
                        Id = (int)reader["Id"],
                        flightdestination = reader["flightdestination"].ToString(),
                        OriginCode = reader["OriginCode"].ToString(),
                        DestinationCode = reader["DestinationCode"].ToString(),
                        time = TimeOnly.FromTimeSpan((TimeSpan)reader["time"]),
                        price = (decimal)reader["price"]
                    });
                }
            }

            return flights;
        }

        public void AddFlight(Flight flight)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO fly (flightdestination, OriginCode, DestinationCode, time, price) VALUES (@dest, @origin, @destCode, @time, @price)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dest", flight.flightdestination);
                cmd.Parameters.AddWithValue("@origin", flight.OriginCode);
                cmd.Parameters.AddWithValue("@destCode", flight.DestinationCode);
                cmd.Parameters.AddWithValue("@time", flight.time.ToTimeSpan());
                cmd.Parameters.AddWithValue("@price", flight.price);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateFlight(Flight flight)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE fly SET flightdestination=@dest, OriginCode=@origin, DestinationCode=@destCode, time=@time, price=@price WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", flight.Id);
                cmd.Parameters.AddWithValue("@dest", flight.flightdestination);
                cmd.Parameters.AddWithValue("@origin", flight.OriginCode);
                cmd.Parameters.AddWithValue("@destCode", flight.DestinationCode);
                cmd.Parameters.AddWithValue("@time", flight.time.ToTimeSpan());
                cmd.Parameters.AddWithValue("@price", flight.price);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteFlight(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM fly WHERE Id=@id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}