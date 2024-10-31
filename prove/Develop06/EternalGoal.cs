public class EternalGoal : Goal
{
    public EternalGoal(string name, string description) : base(name, description) { }

    public override void RecordAchievement()
    {
        Points += 100; // Fixed points for each achievement
    }

    public override string GetStatus()
    {
        return $"[ ] {Name} - {Description} (Points: {Points})";
    }
}
