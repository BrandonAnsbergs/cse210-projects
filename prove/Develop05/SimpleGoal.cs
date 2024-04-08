public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, int points) : base(name, points)
        {
        }

        // Simple goals are always complete after being recorded
        public override bool IsComplete()
        {
            return true;
        }
    }