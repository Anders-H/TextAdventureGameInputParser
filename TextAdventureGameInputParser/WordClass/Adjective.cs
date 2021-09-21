namespace TextAdventureGameInputParser.WordClass
{
    public class Adjective : Word
    {
        public Adjective(string value) : base(value)
        {
        }

        public override string GetDescription() =>
            $"[Adj]{Value}";
    }
}