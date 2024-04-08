public class ScriptureReference
   {
        public string Book { get; }
        public int Chapter { get; }
        public int StartVerse { get; }
        public int EndVerse { get; }

        public ScriptureReference(string book, int chapter, int startVerse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = startVerse;
        }

        public ScriptureReference(string book, int chapter, int startVerse, int endVerse)
        {
            Book = book;
            Chapter = chapter;
            StartVerse = startVerse;
            EndVerse = endVerse;
        }

        // Override ToString to display scripture reference
        public override string ToString()
        {
            if (StartVerse == EndVerse)
                return $"{Book} {Chapter}:{StartVerse}";
            else
                return $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
        }
    }