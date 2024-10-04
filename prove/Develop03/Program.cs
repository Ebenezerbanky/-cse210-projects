using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{

    // My Creativity elements include:
    // 1. A hint feature that provides feedback on words still visible.
    // 2. Random selection of scriptures from a file, allowing varied practice.
    // 3. Encouraging user interaction to reinforce memorization.
    public static void Main(string[] args)
    {
        // Load scriptures from a specified file path
        List<Scripture> scriptures = LoadScripturesFromFile(@"C:\Users\HomePC\Documents\scriptures.txt");
        Random random = new Random();
        
        while (scriptures.Count > 0)
        {
            // Select a random scripture
            Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];
            selectedScripture.HideWords(random);
            
            while (true)
            {
                Console.Clear();
                Console.WriteLine(selectedScripture.Display());
                Console.WriteLine("Press Enter to hide more words, type 'hint' for a hint, or 'quit' to exit.");

                string input = Console.ReadLine();
                if (input.ToLower() == "quit")
                    return;
                if (input.ToLower() == "hint")
                {
                    selectedScripture.ShowHint();
                    continue;
                }

                selectedScripture.HideWords(random);
                if (selectedScripture.AllWordsHidden())
                {
                    Console.Clear();
                    Console.WriteLine("All words are now hidden. Goodbye!");
                    scriptures.Remove(selectedScripture); // Remove memorized scripture
                    break;
                }
            }
        }
    }

    private static List<Scripture> LoadScripturesFromFile(string filePath = @"C:\Users\HomePC\Documents\scriptures.txt")
    {
        var scriptures = new List<Scripture>();
        var lines = System.IO.File.ReadAllLines(filePath);
        
        foreach (var line in lines)
        {
            var parts = line.Split('|'); // Assuming "Reference|Text" format
            if (parts.Length == 2)
            {
                scriptures.Add(new Scripture(new Reference(parts[0]), parts[1]));
            }
        }
        
        return scriptures;
    }
}
