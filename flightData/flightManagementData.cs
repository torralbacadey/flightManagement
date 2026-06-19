using System.Collections.Generic;

namespace flightManagement.Data
{
    public class flightManagementData
    {
        public List<Flight> GetFlights()
        {
            return new List<Flight>()
            {
                new Flight { Id = 1,  flightdestination = "Manila",        OriginCode = "MNL", DestinationCode = "MNL", time = new TimeOnly(10, 0), price = 0m },
                new Flight { Id = 2,  flightdestination = "Tokyo",         OriginCode = "MNL", DestinationCode = "NRT", time = new TimeOnly(10, 0), price = 5000m },
                new Flight { Id = 3,  flightdestination = "Bangkok",       OriginCode = "MNL", DestinationCode = "BKK", time = new TimeOnly(10, 0), price = 5000m },
                new Flight { Id = 4,  flightdestination = "Bali",          OriginCode = "MNL", DestinationCode = "DPS", time = new TimeOnly(10, 0), price = 5000m },
                new Flight { Id = 5,  flightdestination = "Hongkong",      OriginCode = "MNL", DestinationCode = "HKG", time = new TimeOnly(10, 0), price = 5000m },

                new Flight { Id = 6,  flightdestination = "Seoul",         OriginCode = "MNL", DestinationCode = "ICN", time = new TimeOnly(14, 0), price = 8000m },
                new Flight { Id = 7,  flightdestination = "Kuala Lumpur",  OriginCode = "MNL", DestinationCode = "KUL", time = new TimeOnly(14, 0), price = 8000m },
                new Flight { Id = 8,  flightdestination = "Sydney",        OriginCode = "MNL", DestinationCode = "SYD", time = new TimeOnly(14, 0), price = 8000m },
                new Flight { Id = 9,  flightdestination = "New Delhi",     OriginCode = "MNL", DestinationCode = "DEL", time = new TimeOnly(14, 0), price = 8000m },
                new Flight { Id = 10, flightdestination = "Singapore",     OriginCode = "MNL", DestinationCode = "SIN", time = new TimeOnly(14, 0), price = 8000m },

                new Flight { Id = 11, flightdestination = "Manila",        OriginCode = "MNL", DestinationCode = "MNL", time = new TimeOnly(14, 0), price = 0m },
                new Flight { Id = 12, flightdestination = "Seoul",         OriginCode = "MNL", DestinationCode = "ICN", time = new TimeOnly(10, 0), price = 5000m },
                new Flight { Id = 13, flightdestination = "Hongkong",      OriginCode = "MNL", DestinationCode = "HKG", time = new TimeOnly(14, 0), price = 8000m },
                new Flight { Id = 14, flightdestination = "Singapore",     OriginCode = "MNL", DestinationCode = "SIN", time = new TimeOnly(10, 0), price = 5000m },
                new Flight { Id = 15, flightdestination = "Bangkok",       OriginCode = "MNL", DestinationCode = "BKK", time = new TimeOnly(14, 0), price = 8000m }
            };
        }
    }
}