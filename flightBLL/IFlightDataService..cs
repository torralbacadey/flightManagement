using flightManagement.Data;

namespace flightManagement.BLL
{
    public interface IFlightDataService
    {
        List<Flight> GetFlights();
    }
}