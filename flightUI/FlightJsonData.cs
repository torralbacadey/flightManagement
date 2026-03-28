using System.Text.Json;
using flightManagement.Data;
using flightManagement.BLL;

namespace flightManagement.UI
{
    public class FlightJsonData : IFlightDataService
    {
        private string filePath = $"{AppDomain.CurrentDomain.BaseDirectory}/flights.json";

        public List<Flight> GetFlights()
        {
            if (!File.Exists(filePath))
                return new List<Flight>();

            string json = File.ReadAllText(filePath);

            return JsonSerializer.Deserialize<List<Flight>>(json)
                   ?? new List<Flight>();
        }
    }
}