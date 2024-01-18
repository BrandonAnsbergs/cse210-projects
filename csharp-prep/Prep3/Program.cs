using System;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {   Random randomGenerator = new Random();
        int magicNumber = randomGenerator.Next(1, 101); 
        int guess = -1;
        int countGuess = 0;

        Console.WriteLine("Guess the Magic Number!");
        
        while (guess != magicNumber)
        {
            Console.WriteLine("What is your guess?");
            guess = int.Parse(Console.ReadLine());

            countGuess++;

            string guessans; 

            if (guess > magicNumber)
            {
                guessans = "Lower";
            }
            
            else if (guess < magicNumber)
            {
                guessans = "Higher";
            }

            else 
            {
                guessans = "You guessed it!";
            }

            Console.WriteLine($"{guessans}");
        }
            Console.WriteLine($"It took you {countGuess} tries to guess the Magic Number.");
    }
}