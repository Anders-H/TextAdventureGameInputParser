using System.Collections.Generic;
using System.Linq;

namespace TextAdventureGameInputParser
{
    public class Alias
    {
        public string Value { get; }
        public string TranslatesTo { get; }

        public Alias(string value, string translatesTo)
        {
            Value = new InputCleaner(value).GetCleanInput();
            TranslatesTo = new InputCleaner(translatesTo).GetCleanInput();
        }
    }

    public class AliasList : List<Alias>
    {
        public void Add(string translatesTo, params string[] aliases)
        {
            foreach (var a in aliases)
                Add(new Alias(a, translatesTo));
        }

        public string Apply(string value) =>
            this.FirstOrDefault(x => x.Value == value)?
                .TranslatesTo ?? value;
    }
}