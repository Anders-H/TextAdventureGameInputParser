using System.Collections.Generic;
using System.Linq;
using TextAdventureGameInputParser.WordClass;

namespace TextAdventureGameInputParser;

public class Parser
{
    public AliasList Aliases { get; }
    public List<Verb> Verbs { get; }
    public List<Filler> Fillers { get; }
    public List<Noun> Nouns { get; }

    public Parser()
    {
        Aliases = new AliasList();
        Verbs = new List<Verb>();
        Fillers = new List<Filler>();
        Nouns = new List<Noun>();
    }

    public Sentence Parse(string input)
    {
        var cleanInput = new InputCleaner(input).GetCleanInput();
        var result = new Sentence(cleanInput);

        var toParse = Aliases.Apply(result.CleanInput);

        result.Word1 = PopVerb(ref toParse);
        result.Word2 = PopFiller(ref toParse);
        result.Word3 = PopFiller(ref toParse);
        result.Word4 = PopNoun(ref toParse, out var word4Confident);
        result.Word5 = PopFiller(ref toParse);
        result.Word6 = PopFiller(ref toParse);
        result.Word7 = PopNoun(ref toParse, out var word7Confident);

        result.Word4Confident = word4Confident;
        if (result.Word4 != null)
            result.Word4.Confident = word4Confident;

        result.Word7Confident = word7Confident;
        if (result.Word7 != null)
            result.Word7.Confident = word7Confident;

        if (!string.IsNullOrWhiteSpace(toParse))
            result.UnknownWord = toParse.IndexOf(' ') > -1
                ? toParse.Split(' ')[0]
                : toParse;

        result.ParseSuccess = result.Word1 != null && string.IsNullOrWhiteSpace(result.UnknownWord);

        return result;
    }

    private Verb? PopVerb(ref string toParse)
    {
        foreach (var verb in Verbs.OrderByDescending(x => x.ToString().Length))
        {
            if (toParse == verb.Value || toParse.StartsWith(verb.Value + " "))
            {
                toParse = toParse.Substring(verb.Value.Length).Trim();
                return verb;
            }
        }

        return null;
    }

    public Filler? PopFiller(ref string toParse)
    {
        foreach (var f in Fillers.OrderByDescending(x => x.ToString().Length))
        {
            if (toParse == f.Value || toParse.StartsWith(f.Value + " "))
            {
                toParse = toParse.Substring(f.Value.Length).Trim();
                return f;
            }
        }

        return null;
    }

    public Noun? PopNoun(ref string toParse, out bool confident)
    {
        confident = false;

        foreach (var n in Nouns.OrderByDescending(x => x.FullString().Length))
        {
            if (toParse == n.FullString() || toParse.StartsWith(n.FullString() + " "))
            {
                toParse = toParse.Substring(n.FullString().Length).Trim();
                confident = true;
                return n;
            }
        }

        foreach (var n in Nouns.OrderByDescending(x => x.ToString().Length))
        {
            if (toParse == n.Value || toParse.StartsWith(n.Value + " "))
            {
                toParse = toParse.Substring(n.Value.Length).Trim();
                return n;
            }
        }

        return null;
    }

    public void AddVerbs(params string[] words)
    {
        foreach (var word in words)
            Verbs.Add(new Verb(word));
    }

    public void AddImportantFillers(params string[] words)
    {
        foreach (var word in words)
            Fillers.Add(new Filler(word, true));
    }

    public void AddUnimportantFillers(params string[] words)
    {
        foreach (var word in words)
            Fillers.Add(new Filler(word, false));
    }

    public void AddNouns(params string[] words)
    {
        foreach (var word in words)
        {
            if (word.IndexOf(' ') > -1)
            {
                var parts = word.Split(' ');
                Nouns.Add(new Noun(parts[1], new Adjective(parts[0])));
            }
            else
            {
                Nouns.Add(new Noun(word));
            }
        }
    }
}