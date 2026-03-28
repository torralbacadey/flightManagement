using System;
using flightManagement.BLL;
using flightManagement.UI;

namespace flightManagement.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IFlightDataService dataSource = new FlightJsonData(); 

            flightService service = new flightService(dataSource);

            Console.WriteLine("---Flight Management System---");
            Console.WriteLine("---Search for Available Flights---");
            Console.WriteLine("--------------------------------------------");
            bool continueSearch = true;
            while (continueSearch)
            {
                Console.Write("Enter Destination: ");
                string input = Console.ReadLine().ToLower();

                service.SearchFlights(input);

                Console.Write("Do you want to continue searching? (y/n): ");
                string choose = Console.ReadLine().ToLower();

                if (choose == "n")
                {
                    Console.WriteLine("Thank you for using the system!");
                    continueSearch = false;
                }

                else if (choose == "y")
                {
                    continueSearch = true;
                }
            }
        }
    }
}
