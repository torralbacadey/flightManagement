using System.Collections.Generic;

namespace flightManagement.Data
{
    public class flightManagementData
    {
        public List<Flight> GetFlights()
        {
            return new List<Flight>()
            {
                new Flight {flightdestination="Manila", time="10:00 AM", price="5000"},
                new Flight {flightdestination="Tokyo", time="10:00 AM", price="5000"},
                new Flight {flightdestination="Bangkok", time="10:00 AM", price="5000"},
                new Flight {flightdestination="Bali", time="10:00 AM", price="5000"},
                new Flight {flightdestination="Hongkong", time="10:00 AM", price="5000"},

                new Flight {flightdestination="Seoul", time="2:00 PM", price="8000"},
                new Flight {flightdestination="Kuala Lumpur", time="2:00 PM", price="8000"},
                new Flight {flightdestination="Sydney", time="2:00 PM", price="8000"},
                new Flight {flightdestination="New Delhi", time="2:00 PM", price="8000"},
                new Flight {flightdestination="Singapore", time="2:00 PM", price="8000"},

                new Flight {flightdestination="Manila", time="2:00 PM", price="8000"},
                new Flight {flightdestination="Seoul", time="10:00 AM", price="5000"},
                new Flight {flightdestination="Hongkong", time="2:00 PM", price="8000"},
                new Flight {flightdestination="Singapore", time="10:00 AM", price="5000"},
                new Flight {flightdestination="Bangkok", time="2:00 PM", price="8000"}
            };
        }
    }
}