using System;
using System.Collections.Generic;
using System.Linq;
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
            if (string.IsNullOrWhiteSpace(destination))
            {
                throw new ArgumentException("Destination must not be empty.");
            }

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

        public void AddFlight(string flightdestination, string destinationCode, TimeOnly time, decimal price)
        {
            if (string.IsNullOrWhiteSpace(flightdestination))
            {
                throw new ArgumentException("Destination is required.");
            }

            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }

            if (string.IsNullOrWhiteSpace(destinationCode))
            {
                throw new ArgumentException("Destination airport code is required.");
            }

            string normalizedDestination = destinationCode.Trim().ToUpperInvariant();

            if (!AirportDirectory.IsKnownCode(normalizedDestination))
            {
                throw new ArgumentException($"'{normalizedDestination}' is not a recognized airport code.");
            }

            var flights = _dataService.GetFlights();

            bool duplicate = flights.Any(f =>
                f.flightdestination.Equals(flightdestination, StringComparison.OrdinalIgnoreCase) &&
                f.time == time);

            if (duplicate)
            {
                throw new InvalidOperationException(
                    $"A flight to {flightdestination} at {time} already exists.");
            }

            _dataService.AddFlight(new Flight
            {
                flightdestination = flightdestination,
                OriginCode = AirportDirectory.DefaultOriginCode,
                DestinationCode = normalizedDestination,
                time = time,
                price = price
            });
        }

        public void UpdateFlight(int id, string flightdestination, string destinationCode, TimeOnly time, decimal price)
        {
            if (string.IsNullOrWhiteSpace(flightdestination))
            {
                throw new ArgumentException("Destination is required.");
            }

            if (price < 0)
            {
                throw new ArgumentException("Price cannot be negative.");
            }

            if (string.IsNullOrWhiteSpace(destinationCode))
            {
                throw new ArgumentException("Destination airport code is required.");
            }

            string normalizedDestination = destinationCode.Trim().ToUpperInvariant();

            if (!AirportDirectory.IsKnownCode(normalizedDestination))
            {
                throw new ArgumentException($"'{normalizedDestination}' is not a recognized airport code.");
            }

            var flights = _dataService.GetFlights();

            if (!flights.Any(f => f.Id == id))
            {
                throw new KeyNotFoundException($"Flight with Id {id} was not found.");
            }

            _dataService.UpdateFlight(new Flight
            {
                Id = id,
                flightdestination = flightdestination,
                OriginCode = AirportDirectory.DefaultOriginCode,
                DestinationCode = normalizedDestination,
                time = time,
                price = price
            });
        }

        public void DeleteFlight(int id)
        {
            var flights = _dataService.GetFlights();

            if (!flights.Any(f => f.Id == id))
            {
                throw new KeyNotFoundException($"Flight with Id {id} was not found.");
            }

            _dataService.DeleteFlight(id);
        }
    }
}