public class ScriptureWord
   {
        public string Word { get; }
        public bool IsHidden { get; set; }

        public ScriptureWord(string word)
        {
            Word = word;
            IsHidden = false;
        }

        // Override ToString to handle hiding of words
        public override string ToString()
        {
            if (IsHidden)
                return new string('_', Word.Length);
            else
                return Word;
        }
    }