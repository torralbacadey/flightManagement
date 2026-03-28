using Microsoft.Data.SqlClient;
using flightManagement.Data;
using flightManagement.BLL;

namespace flightManagement.UI
{
    public class FlightDBData : IFlightDataService
    {
        private string connectionString = "YOUR_CONNECTION_STRING_HERE";

        public List<Flight> GetFlights()
        {
            var flights = new List<Flight>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT destination, time, price FROM Flights";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    flights.Add(new Flight
                    {
                        flightdestination = reader["destination"].ToString(),
                        time = reader["time"].ToString(),
                        price = reader["price"].ToString()
                    });
                }
            }

            return flights;
        }
    }
}