using System;

class Program
{
    static void Main(string[] args)
    {
        // Get address details from the user
        Console.WriteLine("Enter address details:");
        Console.Write("Street: ");
        string street = Console.ReadLine();
        Console.Write("City: ");
        string city = Console.ReadLine();
        Console.Write("State: ");
        string country = Console.ReadLine();

        // Create address object
        Address address = new Address(street, city, country);

        while (true)
        {
            Console.WriteLine("\nChoose the type of event to create:");
            Console.WriteLine("1. Lecture");
            Console.WriteLine("2. Reception");
            Console.WriteLine("3. Outdoor Gathering");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            if (choice == 4)
            {
                Console.WriteLine("Exiting the program.");
                break;
            }

            switch (choice)
            {
                case 1:
                    CreateLectureEvent(address);
                    break;
                case 2:
                    CreateReceptionEvent(address);
                    break;
                case 3:
                    CreateOutdoorGatheringEvent(address);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }

    static void CreateLectureEvent(Address address)
    {
        Console.WriteLine("\nEnter details for Lecture event:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Date (YYYY-MM-DD): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Time (HH:MM): ");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine());
        Console.Write("Speaker: ");
        string speaker = Console.ReadLine();
        Console.Write("Capacity: ");
        int capacity = int.Parse(Console.ReadLine());

        Lecture lecture = new Lecture(title, description, date, time, address, speaker, capacity);
        ShowEventDetails(lecture);
    }

    static void CreateReceptionEvent(Address address)
    {
        Console.WriteLine("\nEnter details for Reception event:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Date (YYYY-MM-DD): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Time (HH:MM): ");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine());
        Console.Write("RSVP Email: ");
        string rsvpEmail = Console.ReadLine();

        Reception reception = new Reception(title, description, date, time, address, rsvpEmail);
        ShowEventDetails(reception);
    }

    static void CreateOutdoorGatheringEvent(Address address)
    {
        Console.WriteLine("\nEnter details for Outdoor Gathering event:");
        Console.Write("Title: ");
        string title = Console.ReadLine();
        Console.Write("Description: ");
        string description = Console.ReadLine();
        Console.Write("Date (YYYY-MM-DD): ");
        DateTime date = DateTime.Parse(Console.ReadLine());
        Console.Write("Time (HH:MM): ");
        TimeSpan time = TimeSpan.Parse(Console.ReadLine());
        Console.Write("Weather Forecast: ");
        string weatherForecast = Console.ReadLine();

        OutdoorGathering gathering = new OutdoorGathering(title, description, date, time, address, weatherForecast);
        ShowEventDetails(gathering);
    }

    static void ShowEventDetails(Event eventObj)
    {
        while (true)
        {
            Console.WriteLine("\nChoose the type of detail to view:");
            Console.WriteLine("1. Standard Details");
            Console.WriteLine("2. Full Details");
            Console.WriteLine("3. Short Description");
            Console.WriteLine("4. Return to main menu");

            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid choice. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine(eventObj.StandardDetails());
                    break;
                case 2:
                    Console.WriteLine(eventObj.FullDetails());
                    break;
                case 3:
                    Console.WriteLine(eventObj.ShortDescription());
                    break;
                case 4:
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please choose again.");
                    break;
            }
        }
    }
}