// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new resume instance
        Resume myResume = new Resume("John Doe");

        // Create some job instances
        Job job1 = new Job("Software Engineer", "Microsoft", 2019, 2022);
        Job job2 = new Job("Web Developer", "Google", 2020, 2023);

        // Add jobs to the resume
        myResume.AddJob(job1);
        myResume.AddJob(job2);

        // Call the Resume Display method to show the full resume
        myResume.Display();
    }
}
