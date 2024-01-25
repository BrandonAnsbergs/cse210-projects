public class Job
{

  // Field to store company name
  private string company;

  // Field to store job title 
  private string jobTitle;

  // Fields to store start and end years
  private int startYear;
  private int endYear;

  // Constructor to initialize the job info
  public Job(string companyName, string title, int start, int end)
  {
    company = companyName;
    jobTitle = title;
    startYear = start; 
    endYear = end;
  }

  // Method to display the job info
  public void Display()
  {
    Console.WriteLine($"{jobTitle} ({company}) {startYear}-{endYear}");
  }

}