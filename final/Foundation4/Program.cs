using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an activity to track:");
            Console.WriteLine("1. Running");
            Console.WriteLine("2. Cycling");
            Console.WriteLine("3. Swimming");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 4)
            {
                Console.WriteLine("Invalid choice. Please enter a number from 1 to 4.");
                continue;
            }

            if (choice == 4)
            {
                Console.WriteLine("Exiting the program.");
                break;
            }

            Activity activity;
            switch (choice)
            {
                case 1:
                    activity = CreateRunningActivity();
                    break;
                case 2:
                    activity = CreateCyclingActivity();
                    break;
                case 3:
                    activity = CreateSwimmingActivity();
                    break;
                default:
                    activity = null;
                    break;
            }

            if (activity != null)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }

    static Activity CreateRunningActivity()
    {
        Console.WriteLine("Enter details for Running activity:");
        Console.Write("Date (YYYY-MM-DD): ");
        DateTime runningDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Length (minutes): ");
        int runningLength = int.Parse(Console.ReadLine());
        Console.Write("Distance (miles): ");
        double runningDistance = double.Parse(Console.ReadLine());

        return new Running(runningDate, runningLength, runningDistance);
    }

    static Activity CreateCyclingActivity()
    {
        Console.WriteLine("Enter details for Cycling activity:");
        Console.Write("Date (YYYY-MM-DD): ");
        DateTime cyclingDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Length (minutes): ");
        int cyclingLength = int.Parse(Console.ReadLine());
        Console.Write("Speed (mph): ");
        double cyclingSpeed = double.Parse(Console.ReadLine());

        return new Cycling(cyclingDate, cyclingLength, cyclingSpeed);
    }

    static Activity CreateSwimmingActivity()
    {
        Console.WriteLine("Enter details for Swimming activity:");
        Console.Write("Date (YYYY-MM-DD): ");
        DateTime swimmingDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Length (minutes): ");
        int swimmingLength = int.Parse(Console.ReadLine());
        Console.Write("Number of laps: ");
        int swimmingLaps = int.Parse(Console.ReadLine());

        return new Swimming(swimmingDate, swimmingLength, swimmingLaps);
    }
}