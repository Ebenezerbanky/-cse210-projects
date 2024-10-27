using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.LoadGoals();

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("Eternal Quest Program");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Goal Achievement");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score and Level");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    goalManager.CreateGoal();
                    break;
                case "2":
                    goalManager.RecordGoalAchievement();
                    break;
                case "3":
                    goalManager.DisplayGoals();
                    break;
                case "4":
                    goalManager.DisplayScoreAndLevel();
                    break;
                case "5":
                    goalManager.SaveGoals();
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalPoints = 0;
    private int _consecutiveDays = 0; // For tracking streaks
    private const int PointsPerLevel = 1000; // Points needed for each level
    private HashSet<string> _badges = new HashSet<string>();
    private int _level = 0;

    public void CreateGoal()
    {
        Console.WriteLine("Select goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Negative Goal");
        Console.Write("Choose an option: ");
        string choice = Console.ReadLine();

        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        Goal goal = null;

        switch (choice)
        {
            case "1":
                goal = new SimpleGoal(name, description, 1000);
                break;
            case "2":
                goal = new EternalGoal(name, description, 100);
                break;
            case "3":
                Console.Write("Enter target completion count: ");
                int targetCount = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, 50, targetCount);
                break;
            case "4":
                Console.Write("Enter points deduction: ");
                int deduction = int.Parse(Console.ReadLine());
                goal = new NegativeGoal(name, description, deduction);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(goal);
        Console.WriteLine("Goal created successfully!");
    }

    public void RecordGoalAchievement()
    {
        Console.WriteLine("Select a goal to record achievement:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetGoalSummary()}");
        }

        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            int pointsEarned = _goals[index].RecordAchievement();
            if (pointsEarned > 0)
            {
                _totalPoints += pointsEarned;
                Console.WriteLine($"You earned {pointsEarned} points!");
                if (_goals[index] is EternalGoal)
                {
                    _consecutiveDays++;
                }
                else
                {
                    _consecutiveDays = 0; // Reset streak for other goal types
                }
                CheckForBadges();
                CheckForLevelUp();
            }
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetGoalSummary());
        }
    }

    public void DisplayScoreAndLevel()
    {
        int level = _totalPoints / PointsPerLevel;
        Console.WriteLine($"Total Points: {_totalPoints}, Level: {level}");
        Console.WriteLine($"Consecutive Days Achieved: {_consecutiveDays}");
        Console.WriteLine($"Badges Earned: {string.Join(", ", _badges)}");
    }

    public void SaveGoals()
    {
        string jsonString = JsonSerializer.Serialize(_goals);
        File.WriteAllText("goals.json", jsonString);
        Console.WriteLine("Goals saved successfully!");
    }

    public void LoadGoals()
    {
        if (File.Exists("goals.json"))
        {
            string jsonString = File.ReadAllText("goals.json");
            _goals = JsonSerializer.Deserialize<List<Goal>>(jsonString) ?? new List<Goal>();
            Console.WriteLine("Goals loaded successfully!");
        }
    }

    private void CheckForBadges()
    {
        if (_totalPoints >= 500 && !_badges.Contains("Novice Achiever"))
        {
            _badges.Add("Novice Achiever");
            Console.WriteLine("You've earned the Novice Achiever badge!");
        }
        // Add more badge checks as needed
    }

    private void CheckForLevelUp()
    {
        int newLevel = _totalPoints / PointsPerLevel;
        if (newLevel > _level)
        {
            _level = newLevel;
            Console.WriteLine($"Congratulations! You've leveled up to Level {_level}!");
        }
    }
}

abstract class Goal
{
    protected string _name;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public abstract int RecordAchievement();
    public abstract string GetGoalSummary();
}

class SimpleGoal : Goal
{
    private bool _isCompleted;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isCompleted = false;
    }

    public override int RecordAchievement()
    {
        if (_isCompleted)
        {
            Console.WriteLine("This goal is already completed.");
            return 0;
        }
        _isCompleted = true;
        return _points;
    }

    public override string GetGoalSummary()
    {
        return $"{_name} [{(_isCompleted ? "X" : " ")}] - {_description}";
    }
}

class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    public override int RecordAchievement()
    {
        return _points;
    }

    public override string GetGoalSummary()
    {
        return $"{_name} [ ] - {_description} (Eternal Goal)";
    }
}

class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;

    public ChecklistGoal(string name, string description, int points, int targetCount)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
    }

    public override int RecordAchievement()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            if (_currentCount == _targetCount)
            {
                return _points + 500; // Bonus points for completion
            }
            return _points;
        }
        Console.WriteLine("This goal has already been completed.");
        return 0;
    }

    public override string GetGoalSummary()
    {
        return $"{_name} [ ] - {_description} (Completed {_currentCount}/{_targetCount})";
    }
}

class NegativeGoal : Goal
{
    private int _deduction;

    public NegativeGoal(string name, string description, int deduction)
        : base(name, description, deduction)
    {
        _deduction = deduction;
    }

    public override int RecordAchievement()
    {
        Console.WriteLine($"You lost {_deduction} points for not achieving this goal.");
        return -_deduction; // Deduct points
    }

    public override string GetGoalSummary()
    {
        return $"{_name} [ ] - {_description} (Negative Goal)";
    }
}
