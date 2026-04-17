using flightManagement.Data;

namespace flightManagement.BLL
{
    public interface IFlightDataService
    {
        List<Flight> GetFlights();
        void AddFlight(Flight flight);

        void UpdateFlight(Flight flight);

        void DeleteFlight(string flightdestination);
    }
}