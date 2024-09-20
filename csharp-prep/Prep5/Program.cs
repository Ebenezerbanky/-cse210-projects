using System;

class Program
{
    static void Main(string[] args)
    {
        // Call the DisplayWelcome function
        DisplayWelcome();
        
        // Call the PromptUserName function and store the returned name
        string userName = PromptUserName();
        
        // Call the PromptUserNumber function and store the returned number
        int favoriteNumber = PromptUserNumber();
        
        // Call the SquareNumber function and store the squared number
        int squaredNumber = SquareNumber(favoriteNumber);
        
        // Call the DisplayResult function to display the result
        DisplayResult(userName, squaredNumber);
    }

    // Function to display the welcome message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Function to prompt and return the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    // Function to prompt and return the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine());
    }

    // Function to square the user's favorite number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    // Function to display the result
    static void DisplayResult(string name, int squaredNumber)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");
    }
}
