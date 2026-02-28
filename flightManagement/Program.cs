namespace flightManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] flightdestination = new string[10];
            string[] time = new string[10];
            string[] price = new string[10];

            flightdestination[0] = "Manila";
            time[0] = "10:00 AM";
            price[0] = "5000";

            flightdestination[1] = "Tokyo";
            time[1] = "10:00 AM";
            price[1] = "5000";

            flightdestination[2] = "Bangkok";
            time[2] = "10:00 AM";
            price[2] = "5000";

            flightdestination[3] = "Bali";
            time[3] = "10:00 AM";
            price[3] = "5000";

            flightdestination[4] = "Hongkong";
            time[4] = "10:00 AM";
            price[4] = "5000";

            flightdestination[5] = "Seoul";
            time[5] = "2:00 PM";
            price[5] = "8000";

            flightdestination[6] = "Kuala Lumpur";
            time[6] = "2:00 PM";
            price[6] = "8000";

            flightdestination[7] = "Sydney";
            time[7] = "2:00 PM";
            price[7] = "8000";

            flightdestination[8] = "New Delhi";
            time[8] = "2:00 PM";
            price[8] = "8000";

            flightdestination[9] = "Singapore City";
            time[9] = "2:00 PM";
            price[9] = "8000";


            Console.WriteLine("---Flight Management System---");
            Console.WriteLine("---Search for Available Flights---");
            Console.WriteLine("--------------------------------------------");
            bool continueSearch = true;
            while (continueSearch)
            {
                Console.Write("Enter Destination: ");
                string input = Console.ReadLine().ToLower();

                bool found = false;
                bool continueSearching = true;

                
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
