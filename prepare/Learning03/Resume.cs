public class Resume 
{
  // Field to store the person's name
  private string name;
  
  // List to store the jobs for the resume
  private List<Job> jobs = new List<Job>();

  // Constructor to initialize the name
  public Resume(string yourName)
  {
    name = yourName;
  }

  // Method to add a job to the resume  
  public void AddJob(Job j)
  {
    jobs.Add(j);
  }

  // Method to display the resume information
  public void Display()
  {
    Console.WriteLine($"Name: {name}");
    Console.WriteLine("Jobs:");
    
    // Loop through the jobs and display each one
    foreach (Job j in jobs)
    {
      j.Display();
    }
  }
}