public abstract class Goal
    {
        public string Name { get; set; }
        public int Points { get; set; }

        // Constructor
        public Goal(string name, int points)
        {
            Name = name;
            Points = points;
        }

        // Method to record completion of goal and return points earned
        public virtual int RecordCompletion()
        {
            return Points;
        }

        // Method to display goal details
        public virtual void DisplayGoalStatus()
        {
            Console.WriteLine($"{Name}: [{(IsComplete() ? "X" : " ")}]");
        }

        // Abstract method to check if goal is complete
        public abstract bool IsComplete();
    }
