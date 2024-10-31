class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        goalManager.LoadGoals();

        while (true)
        {
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. Record Goal Achievement");
            Console.WriteLine("3. Display Goals");
            Console.WriteLine("4. Display Score and Level");
            Console.WriteLine("5. Save Goals");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            string option = Console.ReadLine();

            switch (option)
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
                    return; // Exit the application
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
