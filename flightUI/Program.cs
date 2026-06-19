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

                try
                {
                    if (choice == "1")
                    {
                        Console.Write("Enter Destination: ");
                        string input = Console.ReadLine();

                        var results = service.SearchFlights(input);

                        if (results.Count == 0)
                        {
                            Console.WriteLine("No flights found.");
                        }
                        else
                        {
                            foreach (var f in results)
                            {
                                Console.WriteLine($"[{f.Id}] {f.OriginCode} -> {f.DestinationCode} ({f.flightdestination}) - {f.time:HH:mm} - \u20b1{f.price:N2}");
                            }
                        }
                    }
                    else if (choice == "2")
                    {
                        Console.Write("Destination: ");
                        string flightdestination = Console.ReadLine();

                        Console.Write("Destination Airport Code (e.g. NRT): ");
                        string destinationCode = Console.ReadLine();

                        Console.Write("Time (24hr, e.g. 14:00): ");
                        TimeOnly time = TimeOnly.Parse(Console.ReadLine());

                        Console.Write("Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        service.AddFlight(flightdestination, destinationCode, time, price);
                        Console.WriteLine("Flight added.");
                    }
                    else if (choice == "3")
                    {
                        Console.Write("Id of flight to update: ");
                        int id = int.Parse(Console.ReadLine());

                        Console.Write("New Destination: ");
                        string flightdestination = Console.ReadLine();

                        Console.Write("New Destination Airport Code (e.g. NRT): ");
                        string destinationCode = Console.ReadLine();

                        Console.Write("New Time (24hr, e.g. 14:00): ");
                        TimeOnly time = TimeOnly.Parse(Console.ReadLine());

                        Console.Write("New Price: ");
                        decimal price = decimal.Parse(Console.ReadLine());

                        service.UpdateFlight(id, flightdestination, destinationCode, time, price);
                        Console.WriteLine("Flight updated.");
                    }
                    else if (choice == "4")
                    {
                        Console.Write("Id of flight to delete: ");
                        int id = int.Parse(Console.ReadLine());

                        service.DeleteFlight(id);
                        Console.WriteLine("Flight deleted.");
                    }
                    else if (choice == "5")
                    {
                        Console.WriteLine("Thank you for using our system.");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}