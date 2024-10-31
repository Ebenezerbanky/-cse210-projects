public class ChecklistGoal : Goal
{
    public int TimesCompleted { get; private set; }
    public int Target { get; private set; }
    public int Bonus { get; private set; }

    public ChecklistGoal(string name, string description, int target, int points, int bonus) 
        : base(name, description)
    {
        Target = target;
        Points = points;
        Bonus = bonus;
        TimesCompleted = 0;
    }

    public override void RecordAchievement()
    {
        TimesCompleted++;
        Points += Points; // Points earned for each achievement
        if (TimesCompleted == Target)
        {
            Points += Bonus; // Bonus for completing all targets
        }
    }

    public override string GetStatus()
    {
        return $"[ ] {Name} - {Description} (Completed {TimesCompleted}/{Target} times, Points: {Points})";
    }
}
