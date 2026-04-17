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

        public void AddFlight(Flight flight)
        {
            var flights = GetFlights();
            flights.Add(flight);
            SaveToFile(flights);
        }

        public void UpdateFlight(Flight updatedFlight)
        {
            var flights = GetFlights();

            var existing = flights.FirstOrDefault(f =>
                f.flightdestination == updatedFlight.flightdestination);

            if (existing != null)
            {
                existing.time = updatedFlight.time;
                existing.price = updatedFlight.price;
            }

            SaveToFile(flights);
        }

        public void DeleteFlight(string flightdestination)
        {
            var flights = GetFlights();

            flights.RemoveAll(f => f.flightdestination == flightdestination);

            SaveToFile(flights);
        }

        private void SaveToFile(List<Flight> flights)
        {
            string json = JsonSerializer.Serialize(flights, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(filePath, json);
        }
    }
}