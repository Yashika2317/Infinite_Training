using System;
using ConsoleTables;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = new TrainDBEntities();
            var trainFunctions = new TrainFunctions(dbContext);


            bool isLoggedIn = false;
            string adminPassword = "2317";

            DisplayMainScreen();
            
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                isLoggedIn = true;
                User(trainFunctions);
            }
            else if (choice == "2")
            {
                Console.WriteLine("\nEnter Authorization ID for admin:");
                string password = Console.ReadLine();

                if (password == adminPassword)
                {
                    isLoggedIn = true;
                    AdminMenu(trainFunctions); 
                }
                else
                {
                    Console.WriteLine("\nSorry, Incorrect password.\n");
                }
            }

            if (!isLoggedIn)
            {
                Main(args);
            }

            Console.ReadLine();
        }

        static void DisplayMainScreen()
        {
            Console.WriteLine("╔════════════════════════════════════════════╗");
            Console.WriteLine("║     Welcome to the Train Booking System    ║");
            Console.WriteLine("║────────────────────────────────────────────║");
            Console.WriteLine("║                                            ║");
            Console.WriteLine("║   1. User                                  ║");
            Console.WriteLine("║   2. Admin                                 ║");
            Console.WriteLine("║                                            ║");
            Console.WriteLine("╚════════════════════════════════════════════╝");
            Console.WriteLine("Enter your choice:");
        }


        static void AdminMenu(TrainFunctions trainFunctions) 
        {
            bool exitMenu = false;

            while (!exitMenu)
            {
                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║            Admin Menu             ║");
                Console.WriteLine("╟───────────────────────────────────╢");
                Console.WriteLine("║   a. Add train                    ║");
                Console.WriteLine("║   b. Modify train                 ║");
                Console.WriteLine("║   c. Delete train                 ║");
                Console.WriteLine("║   d. Exit                         ║");
                Console.WriteLine("╚═══════════════════════════════════╝");
                Console.WriteLine("Enter your choice:");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "a":
                        AddTrain(trainFunctions);
                        break;
                    case "b":
                        ModifyTrain(trainFunctions);
                        break;
                    case "c":
                        DeleteTrain(trainFunctions);
                        break;
                    case "d":
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.\n");
                        break;
                }
            } 

            Console.ReadLine();
        }

        static void AddTrain(TrainFunctions trainFunctions)
        {
            Console.WriteLine("Enter Train No:");
            int trainNo = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Train Name:");
            string trainName = Console.ReadLine();

            Console.WriteLine("\nEnter Class:");
            string trainClass = Console.ReadLine();

            Console.WriteLine("\nEnter Total Berths:");
            int totalBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Available Berths:");
            int availableBerths = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Source:");
            string source = Console.ReadLine();

            Console.WriteLine("\nEnter Destination:");
            string destination = Console.ReadLine();

            Console.WriteLine("\nEnter Date of Travel (YYYY-MM-DD):");
            DateTime dateOfTravel = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Fare:");
            int fare = int.Parse(Console.ReadLine()); 

            Console.WriteLine("\nEnter Train Status (Active/Not Active):");
            string trainStatus = Console.ReadLine(); 

            Train train = new Train
            {
                Train_no = trainNo,
                Train_name = trainName,
                Class = trainClass,
                Total_Berths = totalBerths,
                Available_Berths = availableBerths,
                Source_loc = source,
                Destination = destination,
                Date_of_Travel = dateOfTravel,
                Fare = fare,
                Train_Status = trainStatus
            };

            trainFunctions.AddTrain(train);
            Console.WriteLine("\nTrain added successfully!\n");
            Console.ReadLine();
        }

        static void ModifyTrain(TrainFunctions trainFunctions)
        {
            Console.WriteLine("\nEnter Train Numner to modify:");
            int trainNo = int.Parse(Console.ReadLine());

            Console.WriteLine("\nFor the Following Data Please (Enter value or leave blank) to keep current value ");
           
            Console.WriteLine("\n\nEnter New Train Name:");
            string trainNameInput = Console.ReadLine();
            string trainName = string.IsNullOrWhiteSpace(trainNameInput) ? null : trainNameInput;

            Console.WriteLine("Enter New Class:");
            string trainClassInput = Console.ReadLine();
            string trainClass = string.IsNullOrWhiteSpace(trainClassInput) ? null : trainClassInput;

            Console.WriteLine("Enter New Total Berths:");
            string totalBerthsInput = Console.ReadLine();
            int? totalBerths = string.IsNullOrWhiteSpace(totalBerthsInput) ? (int?)null : int.Parse(totalBerthsInput);

            Console.WriteLine("Enter New Available Berths:");
            string availableBerthsInput = Console.ReadLine();
            int? availableBerths = string.IsNullOrWhiteSpace(availableBerthsInput) ? (int?)null : int.Parse(availableBerthsInput);

            Console.WriteLine("Enter New Source:");
            string sourceInput = Console.ReadLine();
            string source = string.IsNullOrWhiteSpace(sourceInput) ? null : sourceInput;

            Console.WriteLine("Enter New Destination:");
            string destinationInput = Console.ReadLine();
            string destination = string.IsNullOrWhiteSpace(destinationInput) ? null : destinationInput;

            Console.WriteLine("Enter New Date of Travel:");
            string dateOfTravelInput = Console.ReadLine();
            DateTime? dateOfTravel = string.IsNullOrWhiteSpace(dateOfTravelInput) ? (DateTime?)null : DateTime.Parse(dateOfTravelInput);

            Console.WriteLine("Enter New Fare:");
            string fareInput = Console.ReadLine();
            int? fare = string.IsNullOrWhiteSpace(fareInput) ? (int?)null : int.Parse(fareInput);

            Console.WriteLine("Enter New Train Status:");
            string trainStatusInput = Console.ReadLine();
            string trainStatus = string.IsNullOrWhiteSpace(trainStatusInput) ? null : trainStatusInput;

            trainFunctions.ModifyTrain(trainNo, trainName, trainClass, totalBerths, availableBerths, source, destination, dateOfTravel, fare, trainStatus);

            Console.WriteLine("\nTrain Data modified successfully!\n");
            Console.ReadLine();
        }

        static void DeleteTrain(TrainFunctions trainFunctions)
        {
            Console.WriteLine("\nEnter Train No to delete:");
            int trainNo = int.Parse(Console.ReadLine());

            trainFunctions.DeleteTrain(trainNo);
            Console.WriteLine("\nTrain deleted successfully!\n");
            Console.ReadLine();
        }


        static void User(TrainFunctions trainFunctions)
        {
            bool exitMenu = false;

            do
            {

                Console.WriteLine("╔═══════════════════════════════════╗");
                Console.WriteLine("║             User Menu             ║");
                Console.WriteLine("╟───────────────────────────────────╢");
                Console.WriteLine("║   a. Show all train details       ║");
                Console.WriteLine("║   b. Book train ticket            ║");
                Console.WriteLine("║   c. Cancel train ticket          ║");
                Console.WriteLine("║   d. Exit                         ║");
                Console.WriteLine("╚═══════════════════════════════════╝");
                Console.WriteLine("Enter your choice:");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "a":
                        ShowAllTrainDetails(trainFunctions);
                        break;
                    case "b":
                        BookTrainTicket(trainFunctions);
                        break;
                    case "c":
                        CancelTrainTicket(trainFunctions);
                        break;
                    case "d":
                        exitMenu = true; 
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice.\n");
                        break;
                }
            } while (!exitMenu);
            Console.ReadLine();

        }

        static void ShowAllTrainDetails(TrainFunctions trainFunctions)
        {
            var allTrains = trainFunctions.GetAllTrains();
            var table = new ConsoleTable("Train Number", "Train Name", "Class", "Total Berths", "Available Berths", "Source", "Destination", "Date of Travel", "Fare", "Train Status");

            foreach (var train in allTrains)
            {
                table.AddRow(train.Train_no, train.Train_name, train.Class, train.Total_Berths, train.Available_Berths, train.Source_loc, train.Destination, train.Date_of_Travel, train.Fare, train.Train_Status);
            }

            table.Write();
        

            Console.WriteLine("\nPress any key to return to the user menu...\n");
            Console.ReadKey();

        }

        static void BookTrainTicket(TrainFunctions trainFunctions)
        {
            Console.WriteLine("\nEnter your name:");
            string userName = Console.ReadLine();

            Console.WriteLine("\nEnter Train Number:");
            int trainNo = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Class:");
            string trainClass = Console.ReadLine();

            Console.WriteLine("\nEnter Number of Tickets:");
            int numTickets = int.Parse(Console.ReadLine());

            Console.WriteLine("\nDo you want to proceed to payment? (Y/N)");
            char proceedToPayment = char.ToUpper(Console.ReadKey().KeyChar);           

            var ticketDetails = trainFunctions.BookTicket(userName, trainNo, trainClass, numTickets);

            if (ticketDetails != null)
            {
                Console.WriteLine("\n______________________________________________________________");

                Console.WriteLine($"\nHi {userName}");
                Console.WriteLine($"TRAIN NUMBER: {ticketDetails.Train_no}");
                Console.WriteLine($"TOTAL FARE: {ticketDetails.Total_Fare}");
                Console.WriteLine($"Your ticket from {ticketDetails.Source_loc} to {ticketDetails.Destination} has been booked.");
                Console.WriteLine("Have a Safe Journey!...\n");
                Console.WriteLine("______________________________________________________________");


            }
            else
            {
                Console.WriteLine("\nSorry, not enough tickets available or Train in NOT ACTIVE Status\nPlease check the display and Book Tickets for ACTIVE trains only.\n");
            }

            Console.ReadLine();
        }


        static void CancelTrainTicket(TrainFunctions trainFunctions)
        {
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();

            Console.WriteLine("\nEnter Train Number of the booked ticket:");
            int trainNo = int.Parse(Console.ReadLine());

            Console.WriteLine("\nEnter Number of Tickets to cancel:");
            int numTicketsToCancel = int.Parse(Console.ReadLine()); 

            var canceledTicketDetails = trainFunctions.CancelTicket(userName, trainNo, numTicketsToCancel);

            if (canceledTicketDetails != null)
            {
                Console.WriteLine("______________________________________________________________");
                Console.WriteLine($"\nHi {userName}");
                Console.WriteLine($"Train Number: {canceledTicketDetails.Train_no}");
                Console.WriteLine($"Your ticket(s) from {canceledTicketDetails.Source_loc} to {canceledTicketDetails.Destination} have been cancelled.");
                Console.WriteLine($"Refunded Amount: {canceledTicketDetails.Refund_Amount}\n");
                Console.WriteLine("______________________________________________________________");


            }
            else
            {
                Console.WriteLine("\nTicket not found or cancellation failed.\n" +"");
            }

            Console.ReadLine();
        }


    }
}
