using System.Collections.Generic;
using System.Text;
using TextAdventureGameInputParser.WordClass;

namespace TextAdventureGameInputParser
{
    public class Sentence
    {
        public string CleanInput { get; set; }
        public bool ParseSuccess { get; internal set; }
        public string UnknownWord { get; internal set; }
        public Verb? Word1 { get; internal set; }
        public Filler? Word2 { get; internal set; }
        public Filler? Word3 { get; internal set; }
        public Noun? Word4 { get; internal set; }
        public Filler? Word5 { get; internal set; }
        public Filler? Word6 { get; internal set; }
        public Noun? Word7 { get; internal set; }
        public bool Word4Confident { get; internal set; }
        public bool Word7Confident { get; internal set; }

        public Sentence()
        {
            CleanInput = "";
            ParseSuccess = false;
            UnknownWord = "";
        }

        public Sentence(string cleanInput)
        {
            CleanInput = cleanInput;
            ParseSuccess = false;
            UnknownWord = "";
        }

        public bool Ambiguous =>
            (Word4 != null && !Word4Confident)
            || (Word7 != null && !Word7Confident);

        public List<Word> AllWords
        {
            get
            {
                var ret = new List<Word>();
                if (Word1 != null)
                    ret.Add(Word1);
                if (Word2 != null)
                    ret.Add(Word2);
                if (Word3 != null)
                    ret.Add(Word3);
                if (Word4 != null)
                    ret.Add(Word4);
                if (Word5 != null)
                    ret.Add(Word5);
                if (Word6 != null)
                    ret.Add(Word6);
                if (Word7 != null)
                    ret.Add(Word7);
                return ret;
            }
        }

        public List<Word> ImportantWords
        {
            get
            {
                var ret = new List<Word>();
                if (Word1 != null)
                    ret.Add(Word1);
                if (Word2 != null && Word2.IsImportant)
                    ret.Add(Word2);
                if (Word3 != null && Word3.IsImportant)
                    ret.Add(Word3);
                if (Word4 != null)
                    ret.Add(Word4);
                if (Word5 != null && Word5.IsImportant)
                    ret.Add(Word5);
                if (Word6 != null && Word6.IsImportant)
                    ret.Add(Word6);
                if (Word7 != null)
                    ret.Add(Word7);
                return ret;
            }
        }

        public override string ToString()
        {
            var s = new StringBuilder();
            
            s.AppendLine($"Input:           {CleanInput}");
            s.AppendLine($"Parse success:   {ParseSuccess}");

            if (!string.IsNullOrWhiteSpace(UnknownWord))
                s.AppendLine($"Unknown word:    {UnknownWord}");

            s.AppendLine($"Ambiguous:       {Ambiguous}");

            foreach (var w in AllWords)
                s.AppendLine($"Word:            {w.GetDescription()}");

            s.AppendLine($"Important words: ");

            var s2 = new StringBuilder();
            foreach (var w in ImportantWords)
                s2.Append($"{w.GetDescription()} ");
            s.AppendLine(s2.ToString().Trim());

            return s.ToString();
        }

        public static Sentence ParseFailed(string cleanInput)
        {
            return new Sentence(cleanInput);
        }
    }
}