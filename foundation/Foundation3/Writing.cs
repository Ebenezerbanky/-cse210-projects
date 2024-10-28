public class Running : Activity
{
    private double _distance; // in miles

    public Running(DateTime date, double minutes, double distance) : base(date, minutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60; // mph
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance(); // min per mile
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance {GetDistance()} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
