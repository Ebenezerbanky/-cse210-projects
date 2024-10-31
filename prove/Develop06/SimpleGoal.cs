public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points) : base(name, description)
    {
        Points = points;
    }

    public override void RecordAchievement()
    {
        Points += Points; // Points earned for achieving the goal
    }

    public override string GetStatus()
    {
        return $"[X] {Name} - {Description} (Points: {Points})";
    }
}
