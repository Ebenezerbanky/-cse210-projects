public class Swimming : Activity
{
    private int _laps; // number of laps

    public Swimming(DateTime date, double minutes, int laps) : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return (_laps * 50) / 1000.0; // Distance in kilometers
    }

    public override double GetSpeed()
    {
        return (GetDistance() / GetMinutes()) * 60; // kph
    }

    public override double GetPace()
    {
        return GetMinutes() / GetDistance(); // min per km
    }

    public override string GetSummary()
    {
        return base.GetSummary() + $" - Distance {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}
