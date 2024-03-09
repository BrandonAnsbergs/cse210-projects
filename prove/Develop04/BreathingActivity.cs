public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void StartActivity()
    {
        base.StartActivity();
        Breathe();
    }

    private void Breathe()
    {
        Console.WriteLine("Let's begin breathing exercises...");
        DateTime starttime = DateTime.Now;
        DateTime endtime   = starttime.AddSeconds(duration);
        while (starttime < endtime){
            BreatheIn();
            BreatheOut();
            starttime = DateTime.Now;
        }
    }

    private void BreatheIn()
    {
        Console.WriteLine("Breathe in...");
        Countdown(3);
    }

    private void BreatheOut()
    {
        Console.WriteLine("Breathe out...");
        Countdown(3);
    }
}