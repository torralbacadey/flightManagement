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
                if (flights[i].flightdestination
                    .Equals(input, StringComparison.OrdinalIgnoreCase))
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

        public void AddFlight(string flightdestination, string time, string price)
        {
            _dataService.AddFlight(new Flight
            {
                flightdestination = flightdestination,
                time = time,
                price = price
            });

            Console.WriteLine("Flight added successfully!");
        }

        public void UpdateFlight(string flightdestination, string time, string price)
        {
            _dataService.UpdateFlight(new Flight
            {
                flightdestination = flightdestination,
                time = time,
                price = price
            });

            Console.WriteLine("Flight updated successfully!");
        }

        public void DeleteFlight(string flightdestination)
        {
            _dataService.DeleteFlight(flightdestination);

            Console.WriteLine("Flight deleted successfully!");
        }
    }
}
