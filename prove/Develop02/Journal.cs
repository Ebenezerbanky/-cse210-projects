using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    // List to store all journal entries
    private List<Entry> entries = new List<Entry>();

    // Add a new entry to the journal
    public void AddEntry(Entry entry)
    {
        entries.Add(entry);
    }

    // Display all entries in the journal
    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    // Save the journal to a file
    public void SaveJournal(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    // Load the journal from a file
    public void LoadJournal(string filename)
    {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);

        foreach (var line in lines)
        {
            string[] parts = line.Split('|');
            if (parts.Length == 3)
            {
                entries.Add(new Entry(parts[1], parts[2], parts[0]));
            }
        }
    }
}
