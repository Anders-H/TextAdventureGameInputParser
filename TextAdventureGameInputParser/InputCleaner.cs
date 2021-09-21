using System.Text;

namespace TextAdventureGameInputParser
{
    public class InputCleaner
    {
        private readonly string _input;

        public InputCleaner(string input)
        {
            _input = (input ?? "")
                .ToUpper()
                .Trim();
        }

        public string GetCleanInput()
        {
            var result = new StringBuilder();
            const string allowed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            foreach (var c in _input)
            {
                if (allowed.IndexOf(c) >= 0)
                    result.Append(c);
                if (c == ' ' && !result.ToString().EndsWith(" "))
                    result.Append(" ");
            }
            return result.ToString();
        }
    }
}