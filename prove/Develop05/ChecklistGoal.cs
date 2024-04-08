public class ChecklistGoal : Goal
    {
    private int targetCount;
    private int completedCount;

    public ChecklistGoal(string name, int points, int targetCount) : base(name, points)
    {
        this.targetCount = targetCount;
        completedCount = 0;
    }

    // Record completion of checklist goal and return points earned, including bonus if completed
    public override int RecordCompletion()
    {
        completedCount++;
        if (IsComplete())
        {
            return Points + 500; // Bonus points upon completion
        }
        else
        {
            return Points;
        }
    }

    // Check if all checklist items are complete
    public override bool IsComplete()
    {
        return completedCount >= targetCount;
    }

    // Method to get the completed count
    public int GetCompletedCount()
    {
        return completedCount;
    }

    // Override DisplayGoalStatus to show completion count for checklist goals
    public override void DisplayGoalStatus()
    {
        Console.WriteLine($"{Name}: Completed {completedCount}/{targetCount} times [{(IsComplete() ? "X" : " ")}]");
    }
}