using System;

public abstract class Activity
{
    private DateTime _date;
    private double _minutes;

    public Activity(DateTime date, double minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public double GetMinutes()
    {
        return _minutes;
    }

    public DateTime GetDate()
    {
        return _date;
    }

    public abstract double GetDistance(); // Abstract method for distance
    public abstract double GetSpeed(); // Abstract method for speed
    public abstract double GetPace(); // Abstract method for pace

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min)";
    }
}
