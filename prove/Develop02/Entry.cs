using System;

public class Entry
{
    // Properties to store prompt, response, and date
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    // Constructor to initialize a new journal entry
    public Entry(string prompt, string response, string date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    // Override the ToString method to display entry information
    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }
}
