public abstract class Goal
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public int Points { get; protected set; }

    protected Goal(string name, string description)
    {
        Name = name;
        Description = description;
        Points = 0;
    }

    public abstract void RecordAchievement();
    public abstract string GetStatus();
}
