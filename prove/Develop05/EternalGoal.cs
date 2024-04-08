public class EternalGoal : Goal
    {
        public EternalGoal(string name, int points) : base(name, points)
        {
        }

        // Eternal goals are never complete
        public override bool IsComplete()
        {
            return false;
        }
    }