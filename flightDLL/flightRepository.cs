using System.Collections.Generic;
using flightManagement.Data;

namespace flightManagement.DLL
{
    public class flightRepository
    {
        private flightManagementData data = new flightManagementData();

        public List<Flight> GetAllFlights()
        {
            return data.GetFlights();
        }
    }
}