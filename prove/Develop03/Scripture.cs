public class Scripture
   {
        public ScriptureReference Reference { get; }
        public List<ScriptureWord> Words { get; }

        public Scripture(ScriptureReference reference, string text)
        {
            Reference = reference;
            Words = text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(word => new ScriptureWord(word))
                        .ToList();
        }

        // Hide a random word in the scripture
        public void HideRandomWord()
        {
            Random random = new Random();
            int index = random.Next(0, Words.Count);
            if (!Words[index].IsHidden)
                Words[index].IsHidden = true;
            else // If word is already hidden, find another word
                HideRandomWord();
        }

        // Check if all words in the scripture are hidden
        public bool AllWordsHidden()
        {
            return Words.All(word => word.IsHidden);
        }

        // Override ToString to display scripture text
        public override string ToString()
        {
            return string.Join(" ", Words);
        }
    }