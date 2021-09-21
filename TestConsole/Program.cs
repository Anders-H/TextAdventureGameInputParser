using System;
using TextAdventureGameInputParser;

namespace TestConsole
{
    internal class Program
    {
        private static void Main()
        {
            var parser = CreateParser();
            do
            {
                Console.Write("Parse what?> ");
                var input = Console.ReadLine() ?? "";
                if (string.IsNullOrWhiteSpace(input))
                    return;
                Console.WriteLine(parser.Parse(input));
            } while (true);
        }

        private static Parser CreateParser()
        {
            var parser = new Parser();

            parser.AddVerbs("GO", "OPEN", "CLOSE", "GIVE", "SHOW", "LOOK", "INVENTORY", "GET", "TAKE", "DROP", "USE");
            parser.AddImportantFillers("TO", "ON", "IN");
            parser.AddUnimportantFillers("THE", "A", "AN", "AT");
            parser.AddNouns(
                "NORTH",
                "EAST",
                "WEST",
                "SOUTH",
                "GREEN DOOR",
                "BLUE DOOR",
                "SKELETON KEY",
                "GOLD KEY"
            );
            parser.Aliases.Add("GO NORTH", "N", "NORTH");
            parser.Aliases.Add("GO EAST", "E", "EAST");
            parser.Aliases.Add("GO SOUTH", "S", "SOUTH");
            parser.Aliases.Add("GO WEST", "W", "WEST");
            parser.Aliases.Add("INVENTORY", "I", "INV");

            return parser;
        }
    }
}