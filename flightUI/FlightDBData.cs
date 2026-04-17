using Microsoft.Data.SqlClient;
using flightManagement.Data;
using flightManagement.BLL;

namespace flightManagement.UI
{
    public class FlightDBData : IFlightDataService
    {
        private string connectionString =
        "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=flightDB;Integrated Security=True;TrustServerCertificate=True;";

        public List<Flight> GetFlights()
        {
            var flights = new List<Flight>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT flightdestination, time, price FROM Flights";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    flights.Add(new Flight
                    {
                        flightdestination = reader["flightdestination"].ToString(),
                        time = reader["time"].ToString(),
                        price = reader["price"].ToString()
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

                string query = "INSERT INTO Flights (flightdestination, time, price) VALUES (@dest, @time, @price)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dest", flight.flightdestination);
                cmd.Parameters.AddWithValue("@time", flight.time);
                cmd.Parameters.AddWithValue("@price", flight.price);

                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateFlight(Flight flight)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Flights SET time=@time, price=@price WHERE flightdestination=@dest";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dest", flight.flightdestination);
                cmd.Parameters.AddWithValue("@time", flight.time);
                cmd.Parameters.AddWithValue("@price", flight.price);

                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteFlight(string flightdestination)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Flights WHERE flightdestination=@dest";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dest", flightdestination);

                cmd.ExecuteNonQuery();
            }
        }
    }
}