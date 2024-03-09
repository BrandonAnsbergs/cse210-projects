using System.Security.Cryptography.X509Certificates;

public class ListActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListActivity() : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        ListItems();
    }


    
    private void ListItems()
    {
        string prompt = prompts[new Random().Next(prompts.Length)];
        Console.WriteLine(prompt);
        Console.WriteLine("You have a few seconds to think and list...");
        Countdown(5);
        Console.Write("Enter items: \n");

        DateTime currentTime = DateTime.Now;
        DateTime futureTime = currentTime.AddSeconds(5);
        int _counter = 0;

        while (currentTime <= futureTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _counter++;
            currentTime = DateTime.Now;
        }

        string[] items = Console.ReadLine().Split(',');
        Console.WriteLine($"You listed {_counter} items.");
    }
}
