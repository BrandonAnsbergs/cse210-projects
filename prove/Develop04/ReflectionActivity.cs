using System.CodeDom.Compiler;

public class ReflectionActivity : Activity
{
    private int[] questionsChosen = {};
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Reflect();
    }

    Random generator = new Random();
    public string GetPrompt()
    {
        int index = generator.Next(0,prompts.Length);
        return prompts[index];
    }

    public string GetQuestion()
    {
        int index = generator.Next(0, questions.Length);
        int exists = Array.IndexOf(questionsChosen, index);

        while (exists > -1)
        {
            index = generator.Next(0, questions.Length);
            exists = Array.IndexOf(questionsChosen, index);
        }

        questionsChosen = questionsChosen.Append(index).ToArray(); // Add the index to questionsChosen array
        string question = questions[index];
        questionsChosen = questionsChosen.Where((val, idx) => idx != Array.IndexOf(questionsChosen, index)).ToArray(); // Remove the used question from questionsChosen array
        return question;
    }

   public void Reflect()
    {
        Console.WriteLine("\nConsider the following prompt:\n");
        Console.Write(GetPrompt());
        Console.Write(" ");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.Write("You may begin in: \n");
        Countdown(3);
        // Console.Write("3");
        // Thread.Sleep(1000);
        // Console.Write("\b \b");
        // Console.Write("2");
        // Thread.Sleep(1000);
        // Console.Write("\b \b"); 
        // Console.Write("1");
        // Thread.Sleep(1000);
        // Console.Write("\b \b");
        // Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime stopTime = startTime.AddSeconds(duration);

        while (startTime < stopTime)
        {
            Console.Write(GetQuestion());
            Console.Write(" \n");
            ShowSpinner();
            Console.WriteLine();
            startTime = DateTime.Now;
        }
    }
}