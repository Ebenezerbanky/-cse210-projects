public class Cycling : Activity
{
    private double _speed; // in mph

    public Cycling(DateTime date, double minutes, double speed) : base(date, minutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return _speed * (GetMinutes() / 60); // Distance in miles
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / GetSpeed(); // min per mile
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
