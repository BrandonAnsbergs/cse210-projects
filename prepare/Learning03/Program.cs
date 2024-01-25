using System;

class Program
{
    static void Main(string[] args)
    {
        // Create some sample jobs
        Job job1 = new Job("Del Taco", "Manager", 1706, 2020);
        Job job2 = new Job("Google", "CTO", 2020, 2024);
    
        // Create a resume 
        Resume r = new Resume("Brandon Ansbergs");

        // Add the jobs 
        r.AddJob(job1);
        r.AddJob(job2);

        // Display the resume
        r.Display();
    }
}