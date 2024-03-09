using System;
using System.Diagnostics;
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            Activity activity;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    activity.StartActivity();
                    activity.FinishActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    activity.StartActivity();
                    activity.FinishActivity();
                    break;
                case "3":
                    activity = new ListActivity();
                    activity.StartActivity();
                    activity.FinishActivity();
                    break;
                case "4":
                    Console.WriteLine("Quitting...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                    break;
            }
        }
    }
}