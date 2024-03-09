using System;
using System.Collections.Generic;
using System.Threading;

public abstract class Activity
{
    protected static Dictionary<string, int> activityCounts = new Dictionary<string, int>();
    protected static Dictionary<string, int> activityDurations = new Dictionary<string, int>();

    protected string name;
    protected string description;
    protected int duration;
    protected int totalDuration;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
        if (!activityCounts.ContainsKey(name))
        {
            activityCounts[name] = 0;
            activityDurations[name] = 0;
        }
    }

    public virtual void StartActivity()
    {
        Console.WriteLine($"Starting {name} activity...");
        Console.WriteLine(description);
        SetDuration();
        PrepareToBegin();
        activityCounts[name]++;
    }

    protected virtual void SetDuration()
    {
        Console.Write("Enter duration in seconds: ");
        duration = int.Parse(Console.ReadLine());
        activityDurations[name] += duration;
    }

    protected virtual void PrepareToBegin()
    {
        Console.WriteLine("Get ready to begin...");
        Countdown(3);
    }

    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"{i}...");
            Thread.Sleep(1000);
        }
    }

    protected void ShowSpinner()
    {
        string[] spinners = { "-", "\\", "|", "/" };
        for (int i = 0; i < 10; i++)
        {
            foreach (string spinner in spinners)
            {
                Console.Write(spinner + "\r");
                Thread.Sleep(150);
            }
        }
    }

    public virtual void FinishActivity()
    {
        Console.WriteLine("Good job!");
        totalDuration += duration;
        Console.WriteLine($"You have completed the {name} activity for {activityDurations[name]} seconds.");
        Console.WriteLine($"Total times {name} activity performed: {activityCounts[name]}");
        Thread.Sleep(3000);
    }
}
//     protected static Dictionary<string, int> activityCounts = new Dictionary<string, int>();

//     protected string name;
//     protected string description;
//     protected int duration;
//     protected int totalDuration;

//     public Activity(string name, string description)
//     {
//         this.name = name;
//         this.description = description;
//         if (!activityCounts.ContainsKey(name))
//         {
//             activityCounts[name] = 0;
//         }
//     }

//     public virtual void StartActivity()
//     {
//         Console.WriteLine($"Starting {name} activity...");
//         Console.WriteLine(description);
//         SetDuration();
//         PrepareToBegin();
//         activityCounts[name]++;
//     }

//     protected virtual void SetDuration()
//     {
//         Console.Write("Enter duration in seconds: ");
//         duration = int.Parse(Console.ReadLine());
//     }

//     protected virtual void PrepareToBegin()
//     {
//         Console.WriteLine("Get ready to begin...");
//         Countdown(3);
//     }

//     protected void Countdown(int seconds)
//     {
//         for (int i = seconds; i > 0; i--)
//         {
//             Console.WriteLine($"{i}...");
//             Thread.Sleep(1000);
//         }
//     }

//     protected void ShowSpinner()
//     {
//         string[] spinners = { "-", "\\", "|", "/" };
//         for (int i = 0; i < 10; i++)
//         {
//             foreach (string spinner in spinners)
//             {
//                 Console.Write(spinner + "\r");
//                 Thread.Sleep(100);
//             }
//         }
//     }

//     public virtual void FinishActivity()
//     {
//         Console.WriteLine("Good job!");
//         totalDuration += duration;
//         Console.WriteLine($"You have completed the {name} activity for {totalDuration} seconds.");
//         Console.WriteLine($"Total times {name} activity performed: {activityCounts[name]}");
//         Thread.Sleep(3000);
//     }
// }