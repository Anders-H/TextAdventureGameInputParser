namespace TextAdventureGameInputParser.WordClass
{
    public abstract class Word
    {
        public string Value { get; set; }

        protected Word(string value)
        {
            Value = (value ?? "")
                .ToUpper()
                .Trim();
        }

        public override string ToString() =>
            Value;

        public abstract string GetDescription();
    }
}