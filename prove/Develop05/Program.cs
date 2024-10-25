using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        MindfulnessActivity activity = null;
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine("Select an activity:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");

            switch (Console.ReadLine())
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    running = false;
                    continue;
                default:
                    Console.WriteLine("Invalid choice. Please select again.");
                    continue;
            }

            activity.Start();
            LogActivity(activity.GetType().Name);
        }
    }

    private static Dictionary<string, int> _activityLog = new Dictionary<string, int>();

    private static void LogActivity(string activityName)
    {
        if (_activityLog.ContainsKey(activityName))
        {
            _activityLog[activityName]++;
        }
        else
        {
            _activityLog[activityName] = 1;
        }

        using (StreamWriter sw = new StreamWriter("ActivityLog.txt", true))
        {
            sw.WriteLine($"{activityName}: {_activityLog[activityName]}");
        }
    }
}

abstract class MindfulnessActivity
{
    protected int _duration;
    protected List<string> _usedPrompts = new List<string>();
    protected string _name;
    protected string _description;

    public MindfulnessActivity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        Console.WriteLine($"Starting {_name}...");
        Console.Write("Duration (seconds): ");

        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out _duration) && _duration > 0)
                break; // Valid input
            Console.WriteLine("Please enter a positive integer for the duration.");
        }

        Console.WriteLine("Prepare to begin...");
        Pause(3);
        ExecuteActivity();
        Finish();
    }

    protected abstract void ExecuteActivity();

    protected void Finish()
    {
        Console.WriteLine("Good job! You've completed the activity.");
        Console.WriteLine($"Duration: {_duration} seconds.");
        Pause(3);
    }

    protected void Pause(int seconds)
    {
        if (seconds < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(seconds), "Seconds must be non-negative.");
        }

        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"\r{new string('.', 3 - (i % 4))}"); // Modulo to cycle through dots
            Thread.Sleep(1000);
        }
        Console.WriteLine(); // Move to the next line after the pause
    }

    protected string GetRandomPrompt(List<string> prompts)
    {
        if (_usedPrompts.Count == prompts.Count)
        {
            _usedPrompts.Clear(); // Reset for the next session
        }

        string prompt;
        Random rand = new Random();
        do
        {
            prompt = prompts[rand.Next(prompts.Count)];
        } while (_usedPrompts.Contains(prompt));

        _usedPrompts.Add(prompt);
        return prompt;
    }
}

class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity() : base("Breathing Activity", "This activity helps you relax by walking you through breathing in and out slowly.") { }

    protected override void ExecuteActivity()
    {
        for (int i = 0; i < _duration; i += 5)
        {
            BreathingAnimation("Breathe in...");
            Pause(4);
            BreathingAnimation("Breathe out...");
            Pause(4);
        }
    }

    private void BreathingAnimation(string action)
    {
        Console.Clear();
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(action + new string(' ', i));
            Thread.Sleep(100);
        }
        for (int i = 10; i >= 1; i--)
        {
            Console.WriteLine(action + new string(' ', i));
            Thread.Sleep(100);
        }
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity() : base("Reflection Activity", "This activity helps you reflect on times in your life when you have shown strength and resilience.") { }

    protected override void ExecuteActivity()
    {
        string prompt = GetRandomPrompt(_prompts);
        Console.WriteLine(prompt);
        Pause(5);

        List<string> userReflections = new List<string>();

        for (int i = 0; i < _duration; i += 6)
        {
            string question = GetRandomPrompt(_questions);
            Console.WriteLine(question);
            string userResponse = Console.ReadLine();
            userReflections.Add(userResponse);
            Pause(5);
        }

        // Save reflections to a file
        using (StreamWriter sw = new StreamWriter("Reflections.txt", true))
        {
            sw.WriteLine(string.Join("\n", userReflections));
        }
    }
}

class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you reflect on the good things in your life by having you list as many things as you can in a certain area.") { }

    protected override void ExecuteActivity()
    {
        string prompt = GetRandomPrompt(_prompts);
        Console.WriteLine(prompt);
        Pause(5);

        int count = 0;
        Console.WriteLine("Start listing now:");

        while (true)
        {
            Console.Write("Enter an item (or type 'done' to finish): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;
            count++;
        }

        Console.WriteLine($"You listed {count} items.");
    }
}

class GratitudeActivity : MindfulnessActivity
{
    public GratitudeActivity() : base("Gratitude Activity", "This activity helps you focus on gratitude by listing things you're thankful for.") { }

    protected override void ExecuteActivity()
    {
        Console.WriteLine("Take a moment to think about what you're grateful for...");
        Pause(5);

        int count = 0;
        Console.WriteLine("Start listing things you are grateful for (type 'done' to finish):");

        while (true)
        {
            Console.Write("Item: ");
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;
            count++;
        }

        Console.WriteLine($"You listed {count} things you are grateful for.");
    }
}
