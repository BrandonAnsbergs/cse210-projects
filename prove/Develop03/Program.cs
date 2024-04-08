using System;
using System.Collections.Generic;
using System.Linq;

class Program
   {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Scripture Memorization Program!");

            List<Scripture> savedScriptures = new List<Scripture>();
            // Add some sample scriptures
            savedScriptures.Add(new Scripture(new ScriptureReference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."));
            savedScriptures.Add(new Scripture(new ScriptureReference("Psalm", 23, 1), "The LORD is my shepherd; I shall not want."));
            savedScriptures.Add(new Scripture(new ScriptureReference("Proverbs", 3, 5, 6), "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."));

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Input your own scripture");
                Console.WriteLine("2. Select a saved scripture");
                Console.WriteLine("3. Quit");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        InputScripture(savedScriptures);
                        break;
                    case "2":
                        SelectScripture(savedScriptures);
                        break;
                    case "3":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void InputScripture(List<Scripture> savedScriptures)
        {
            Console.WriteLine("\nEnter the reference of the scripture (e.g., John 3:16):");
            string referenceInput = Console.ReadLine();
            string[] referenceParts = referenceInput.Split(' ');
            string book = referenceParts[0];
            string[] verseParts = referenceParts[1].Split(':');
            int chapter = int.Parse(verseParts[0]);
            string[] verseRangeParts = verseParts[1].Split('-');
            int startVerse = int.Parse(verseRangeParts[0]);
            int endVerse = verseRangeParts.Length == 2 ? int.Parse(verseRangeParts[1]) : startVerse;

            Console.WriteLine("\nEnter the text of the scripture:");
            string text = Console.ReadLine();

            ScriptureReference reference = new ScriptureReference(book, chapter, startVerse, endVerse);
            Scripture scripture = new Scripture(reference, text);
            savedScriptures.Add(scripture);

            ProcessScripture(scripture);
        }

        static void SelectScripture(List<Scripture> savedScriptures)
        {
            Console.WriteLine("\nSelect a saved scripture:");
            for (int i = 0; i < savedScriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {savedScriptures[i].Reference}");
            }

            string option = Console.ReadLine();
            if (int.TryParse(option, out int index) && index > 0 && index <= savedScriptures.Count)
            {
                ProcessScripture(savedScriptures[index - 1]);
            }
            else
            {
                Console.WriteLine("Invalid option. Please try again.");
            }
        }

        static void ProcessScripture(Scripture scripture)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(scripture.Reference);
                Console.WriteLine(scripture);

                Console.WriteLine("\nPress Enter to continue hiding words or type 'quit' to go back to the previous menu.");
                string input = Console.ReadLine().ToLower();

                if (input == "quit")
                    return;

                scripture.HideRandomWord();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("\nAll words are hidden. Press Enter to return back to the menu.");
                    Console.ReadLine();
                    return;
                }
            }
        }
    }