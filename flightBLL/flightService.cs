using System;
using System.Collections.Generic;
using flightManagement.Data;
using flightManagement.DLL;


namespace flightManagement.BLL
{
    public class flightService


    {
        private IFlightDataService _dataService;

        public flightService(IFlightDataService dataService)
        {
            _dataService = dataService;
        }

        public void SearchFlights(string input)
        {
            List<Flight> flights = _dataService.GetFlights();

            bool found = false;
            int result = 0;

            for (int i = 0; i < flights.Count; i++)
            {
                if (input.ToLower() == flights[i].flightdestination.ToLower())
                {
                    if (!found)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Available flights for " + flights[i].flightdestination + ":");
                        Console.WriteLine("");
                    }

                    Console.WriteLine("Destination: " + flights[i].flightdestination);
                    Console.WriteLine("Time: " + flights[i].time);
                    Console.WriteLine("Price: " + flights[i].price);
                    Console.WriteLine("");
                    found = true;
                    result++;
                }
            }

            if (!found)
            {
                Console.WriteLine("Sorry, there is no available flight.");
            }
            else
            {
                Console.WriteLine("Flights found: " + result);
            }
        }
    }
}
