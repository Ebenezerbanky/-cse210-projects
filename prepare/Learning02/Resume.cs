// Resume.cs
using System;
using System.Collections.Generic;

public class Resume
{
    // Member variables
    public string _name;            // Person's name
    public List<Job> _jobs;         // List of jobs

    // Constructor to initialize the name and create a new list for jobs
    public Resume(string name)
    {
        _name = name;
        _jobs = new List<Job>();    // Initialize the list of jobs
    }

    // Behavior: Add a job to the list
    public void AddJob(Job job)
    {
        _jobs.Add(job);
    }

    // Behavior: Display the resume details (name and job history)
    public void Display()
    {
        // Display the person's name
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Job History:");

        // Iterate through the jobs and call their Display method
        foreach (Job job in _jobs)
        {
            job.Display();  // Calls the Job class's Display method to show job details
        }
    }
}
