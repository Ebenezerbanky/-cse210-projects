using System;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Ask for the magic number
        Console.Write("What is the magic number? ");
        int magicNumber = int.Parse(Console.ReadLine());

        // Step 2: Ask the user for a guess
        Console.Write("What is your guess? ");
        int guess = int.Parse(Console.ReadLine());

        // Step 3: Compare the guess to the magic number
        if (guess < magicNumber)
        {
            Console.WriteLine("Higher");
        }
        else if (guess > magicNumber)
        {
            Console.WriteLine("Lower");
        }
        else
        {
            Console.WriteLine("You guessed it!");
        }
    }
}
