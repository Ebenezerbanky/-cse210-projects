using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    private Reference Reference { get; set; }
    private List<Word> Words { get; set; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(w => new Word(w)).ToList();
    }

    public string Display()
    {
        return $"{Reference.Display()}\n" + string.Join(" ", Words.Select(w => w.IsHidden ? "_____" : w.Text));
    }

    public void HideWords(Random random)
    {
        if (Words.Any(w => !w.IsHidden))
        {
            // Hide a random word
            int index = random.Next(Words.Count);
            Words[index].IsHidden = true;
        }
    }

    public bool AllWordsHidden()
    {
        return Words.All(w => w.IsHidden);
    }

    public void ShowHint()
    {
        var visibleWords = Words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count > 0)
        {
            int index = new Random().Next(visibleWords.Count);
            Console.WriteLine($"Hint: {visibleWords[index].Text}");
        }
        else
        {
            Console.WriteLine("No more hints available.");
        }
    }
}
