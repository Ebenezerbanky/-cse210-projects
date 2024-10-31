public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description)
    {
        Points = points; // Initialize points
    }

    // Ensure the method returns void to match the abstract definition
    public override void RecordAchievement()
    {
        Points -= Points; // Deduct points for the negative goal
    }

    // Implement GetStatus to provide a summary of the goal
    public override string GetStatus()
    {
        return $"[ ] {Name} - {Description} (Points: {Points})";
    }
}