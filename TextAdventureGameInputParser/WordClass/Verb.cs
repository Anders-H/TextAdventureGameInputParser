namespace TextAdventureGameInputParser.WordClass
{
    public class Verb : Word
    {
        public Verb(string value) : base(value)
        {
        }

        public override string GetDescription() =>
            $"[Verb]{Value}";
    }
}