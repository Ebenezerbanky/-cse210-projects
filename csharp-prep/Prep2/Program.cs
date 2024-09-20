using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for the user's grade percentage
        Console.Write("Enter your grade percentage: ");
        int percentage = int.Parse(Console.ReadLine());

        // Variable to store the letter grade and sign
        string letter = "";
        string sign = "";

        // Determine the letter grade
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Determine the sign (+ or -) for grades B to D
        if (letter != "F") // No sign for F
        {
            int lastDigit = percentage % 10;

            if (lastDigit >= 7)
            {
                sign = "+";
            }
            else if (lastDigit < 3)
            {
                sign = "-";
            }

            // No A+ grade
            if (letter == "A" && sign == "+")
            {
                sign = "";
            }
        }

        // Print the letter grade with the sign
        Console.WriteLine($"Your letter grade is: {letter}{sign}");

        // Determine if the user passed or failed
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying, you’ll get it next time.");
        }
    }
}
