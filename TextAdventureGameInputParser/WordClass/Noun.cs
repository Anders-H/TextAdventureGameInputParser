namespace TextAdventureGameInputParser.WordClass
{
    public class Noun : Word
    {
        public Adjective? PrecedingAdjective { get; set; }
        public bool Confident { get; internal set; }

        public Noun(string value) : base(value)
        {
            PrecedingAdjective = null;
            Confident = false;
        }

        public Noun(string value, Adjective? precedingAdjective) : base(value)
        {
            PrecedingAdjective = precedingAdjective;
            Confident = false;
        }

        public string FullString() =>
            $@"{(PrecedingAdjective?.Value ?? "")} {Value}".Trim();

        public override string GetDescription() =>
            PrecedingAdjective == null
                ? $"[Noun]{Value}({ConfString})"
                : $"[Adj/Noun]{PrecedingAdjective.Value} {Value}({ConfString})";

        private string ConfString =>
            Confident ? "Confident" : "Ambigous!";
    }
}