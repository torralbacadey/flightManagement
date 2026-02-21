namespace flightManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] flightdestination = new string[4];
            string[] time = new string[4];
            string[] price = new string[4];

            flightdestination[0] = "Manila";
            time[0] = "10:00 AM";
            price[0] = "5000";

            flightdestination[1] = "Tokyo";
            time[1] = "2:00 PM";
            price[1] = "8000";

            flightdestination[2] = "Bangkok";
            time[2] = "10:00 AM";
            price[2] = "5000";

            flightdestination[3] = "Bali";
            time[3] = "2:00 PM";
            price[3] = "8000";

            Console.WriteLine("---Flight Management System---");
            Console.WriteLine("---Search for Available Flights---");
            Console.WriteLine("--------------------------------------------");
            bool continueSearch = true;
            while (continueSearch)
            {
                Console.Write("Enter Destination: ");
                string input = Console.ReadLine().ToLower();

                bool found = false;

                for (int i = 0; i < flightdestination.Length; i++)
                {
                    if (input == flightdestination[i].ToLower())
                    {
                        Console.WriteLine("Available flights for " + flightdestination[i]);
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine("Destination: " + flightdestination[i]);
                        Console.WriteLine("Time: " + time[i]);
                        Console.WriteLine("Price: " + price[i]);
                        found = true;
                        break;
                    }

                }

                if (!found)
                {
                    Console.WriteLine("Sorry, there is no available flight.");

                }

                Console.WriteLine("Do you want to continue searching? y/n");
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
