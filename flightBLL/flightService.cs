using System;
using System.Collections.Generic;
using flightManagement.Data;

namespace flightManagement.BLL
{
    public class flightService
    {
        private IFlightDataService _dataService;

        public flightService(IFlightDataService dataService)
        {
            _dataService = dataService;
        }

        public List<Flight> GetAllFlights()
        {
            return _dataService.GetFlights();
        }

        public List<Flight> SearchFlights(string destination)
        {
            List<Flight> flights = _dataService.GetFlights();
            List<Flight> result = new List<Flight>();

            for (int i = 0; i < flights.Count; i++)
            {
                if (flights[i].flightdestination.Equals(destination, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(flights[i]);
                }
            }

            return result;
        }

        public void AddFlight(string flightdestination, string time, string price)
        {
            _dataService.AddFlight(new Flight
            {
                flightdestination = flightdestination,
                time = time,
                price = price
            });
        }

        public void UpdateFlight(string flightdestination, string time, string price)
        {
            _dataService.UpdateFlight(new Flight
            {
                flightdestination = flightdestination,
                time = time,
                price = price
            });
        }

        public void DeleteFlight(string flightdestination)
        {
            _dataService.DeleteFlight(flightdestination);
        }
    }
}