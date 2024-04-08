using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
    {
        static List<Goal> goals = new List<Goal>();
        static int score = 0;
        static int level = 1;

        static void Main(string[] args)
        {
            LoadGoals();

            while (true)
            {
                Console.WriteLine("\nEternal Quest - Main Menu");
                Console.WriteLine("1. View Goals");
                Console.WriteLine("2. Add Goal");
                Console.WriteLine("3. Record Event");
                Console.WriteLine("4. View Score");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewGoals();
                        break;
                    case "2":
                        AddGoal();
                        break;
                    case "3":
                        RecordEvent();
                        break;
                    case "4":
                        ViewScore();
                        break;
                    case "5":
                        SaveGoals();
                        Console.WriteLine("Exiting Eternal Quest. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void LoadGoals()
        {
            try
            {
                using (StreamReader sr = new StreamReader("goals.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        string type = parts[0];
                        string name = parts[1];
                        int points = int.Parse(parts[2]);
                        switch (type)
                        {
                            case "Simple":
                                goals.Add(new SimpleGoal(name, points));
                                break;
                            case "Eternal":
                                goals.Add(new EternalGoal(name, points));
                                break;
                            case "Checklist":
                                int targetCount = int.Parse(parts[3]);
                                goals.Add(new ChecklistGoal(name, points, targetCount));
                                break;
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Goals file not found. Starting with no goals.");
            }
        }

        static void SaveGoals()
        {
            using (StreamWriter sw = new StreamWriter("goals.txt"))
            {
                foreach (Goal goal in goals)
                {
                    string type;
                    if (goal is SimpleGoal)
                    {
                        type = "Simple";
                    }
                    else if (goal is EternalGoal)
                    {
                        type = "Eternal";
                    }
                    else if (goal is ChecklistGoal)
                    {
                        type = "Checklist";
                    }
                    else
                    {
                        continue; // Skip unknown goal types
                    }
                    sw.WriteLine($"{type},{goal.Name},{goal.Points},{(goal is ChecklistGoal ? ((ChecklistGoal)goal).GetCompletedCount() : 0)}");
                }
            }
        }

        static void ViewGoals()
        {
            if (goals.Count == 0)
            {
                Console.WriteLine("No goals available. Add some goals first.");
                return;
            }
            Console.WriteLine("\nCurrent Goals:");
            foreach (Goal goal in goals)
            {
                goal.DisplayGoalStatus();
            }
        }

        static void AddGoal()
        {
            Console.WriteLine("\nEnter goal type (Simple, Eternal, Checklist):");
            string type = Console.ReadLine();
            Console.WriteLine("Enter goal name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter points for completing the goal:");
            int points = int.Parse(Console.ReadLine());

            switch (type)
            {
                case "Simple":
                    goals.Add(new SimpleGoal(name, points));
                    break;
                case "Eternal":
                    goals.Add(new EternalGoal(name, points));
                    break;
                case "Checklist":
                    Console.WriteLine("Enter target count for checklist:");
                    int targetCount = int.Parse(Console.ReadLine());
                    goals.Add(new ChecklistGoal(name, points, targetCount));
                    break;
                default:
                    Console.WriteLine("Invalid goal type.");
                    break;
            }
        }

        static void RecordEvent()
        {
            Console.WriteLine("\nEnter the name of the goal you completed:");
            string goalName = Console.ReadLine();
            Goal goal = goals.FirstOrDefault(g => g.Name.Equals(goalName, StringComparison.OrdinalIgnoreCase));

            if (goal == null)
            {
                Console.WriteLine("Goal not found.");
                return;
            }

            int pointsEarned = goal.RecordCompletion();
            score += pointsEarned;

            // Check for level up
            if (score >= 10000)
            {
                level++;
                score -= 10000;
                Console.WriteLine("Congratulations! You have leveled up and earned a 'Treat Yourself' reward!");
            }

            Console.WriteLine($"Event recorded for goal '{goal.Name}'. You earned {pointsEarned} points!");
        }

        static void ViewScore()
        {
            Console.WriteLine($"\nYour current score: {score} points");
            Console.WriteLine($"Your current level: {level}");
        }
    }