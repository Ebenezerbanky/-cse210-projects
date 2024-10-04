using System;
using System.Collections.Generic;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
         // My Creativity elements include:
        // 1. A hint feature that provides feedback on words still visible.
       // 2. Random selection of scriptures from a file, allowing varied practice.
       // 3. Encouraging user interaction to reinforce memorization.
      //4. Load scriptures from the same directory as the Program.cs file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");
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

    private static List<Scripture> LoadScripturesFromFile(string filePath = "scriptures.txt")
    {
        var scriptures = new List<Scripture>();
        var lines = File.ReadAllLines(filePath);
        
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
