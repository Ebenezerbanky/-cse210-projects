using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("How to master c#", "CodeAcademy", 600);
        Video video2 = new Video("Understanding Abstraction", "Programming Guru", 750);
        Video video3 = new Video("OOP Principles", "Tech Simplified", 900);

        // Add comments to video1
        video1.AddComment(new Comment("Adam", "Wonderful explanation!"));
        video1.AddComment(new Comment("Tope", "Great video."));
        video1.AddComment(new Comment("James", "Very Educative."));

        // Add comments to video2
        video2.AddComment(new Comment("Ebenezer", "Awesome tutorial."));
        video2.AddComment(new Comment("Thomas", "Understandable."));
        video2.AddComment(new Comment("Sam", "Perfect for beginners."));

        // Add comments to video3
        video3.AddComment(new Comment("Grace", "Nice explanation of OOP."));
        video3.AddComment(new Comment("kate", "Really informative."));
        video3.AddComment(new Comment("Aron", "Can't wait for the next video."));

        // Store videos in a list
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display details for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}