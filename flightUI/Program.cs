using System;
using flightManagement.BLL;
using flightManagement.UI;

namespace flightManagement.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            IFlightDataService dataSource = new FlightDBData(); 

            flightService service = new flightService(dataSource);

            Console.WriteLine("---Flight Management System---");
            Console.WriteLine("---Search for Available Flights---");
            Console.WriteLine("--------------------------------------------");

            while (true)
            {
                Console.WriteLine("\n---Flight Management System---");
                Console.WriteLine("1. Search Flights");
                Console.WriteLine("2. Add Flight");
                Console.WriteLine("3. Update Flight");
                Console.WriteLine("4. Delete Flight");
                Console.WriteLine("5. Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Enter Destination: ");
                    string input = Console.ReadLine().ToLower();

                    service.SearchFlights(input);
                }

                else if (choice == "2")
                {
                    Console.Write("Destination: ");
                    string flightdestination = Console.ReadLine();

                    Console.Write("Time: ");
                    string time = Console.ReadLine();

                    Console.Write("Price: ");
                    string price = Console.ReadLine();

                    service.AddFlight(flightdestination, time, price);
                }

                else if (choice == "3")
                {
                    Console.Write("Destination to update: ");
                    string flightdestination = Console.ReadLine();

                    Console.Write("New Time: ");
                    string time = Console.ReadLine();

                    Console.Write("New Price: ");
                    string price = Console.ReadLine();

                    service.UpdateFlight(flightdestination, time, price);
                }

                else if (choice == "4")
                {
                    Console.Write("Destination to delete: ");
                    string flightdestination = Console.ReadLine();

                    service.DeleteFlight(flightdestination);
                }

                else if (choice == "5")
                {
                    Console.WriteLine("Thank you for using our system.");
                    break;
                }
            }
        }
    }
}
