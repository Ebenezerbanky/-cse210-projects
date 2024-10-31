using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();

    public void LoadGoals()
    {
        if (File.Exists("goals.json"))
        {
            string jsonString = File.ReadAllText("goals.json");
            var options = new JsonSerializerOptions { Converters = { new GoalConverter() } };
            _goals = JsonSerializer.Deserialize<List<Goal>>(jsonString, options) ?? new List<Goal>();
        }
    }

    public void SaveGoals()
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(_goals, options);
        File.WriteAllText("goals.json", jsonString);
    }

    public void CreateGoal()
    {
        // Logic to create a new goal (user input)
    }

    public void RecordGoalAchievement()
    {
        // Logic to record goal achievement (user input)
    }

    public void DisplayGoals()
    {
        foreach (var goal in _goals)
        {
            Console.WriteLine(goal.GetStatus());
        }
    }

    public void DisplayScoreAndLevel()
    {
        int totalPoints = 0;
        foreach (var goal in _goals)
        {
            totalPoints += goal.Points;
        }
        Console.WriteLine($"Total Points: {totalPoints}");
    }
}
