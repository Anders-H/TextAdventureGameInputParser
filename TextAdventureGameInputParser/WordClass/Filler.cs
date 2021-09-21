namespace TextAdventureGameInputParser.WordClass
{
    public class Filler : Word
    {
        public bool IsImportant { get; }

        public Filler(string value, bool isImportant) : base(value)
        {
            IsImportant = false;
        }

        public override string GetDescription() =>
            $"[Fill]{Value}{(IsImportant ? "(imporant)" : "(not important?)")}";
    }
}