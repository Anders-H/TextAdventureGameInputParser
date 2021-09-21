# Text Adventure Game Input Parser

A parser for a text adventure game. Can recognize sentences such as "go north", "use gold key on door" and "give food to Gandalf".

## Install:

```
Install-Package TextAdventureGameInputParser
```

## Sample usages

The following examples uses a parser created like this:

```
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
```

### Example 1

**Input**

```
GO NORTH
```

**Output**

```
Input:           GO NORTH
Parse success:   True
Ambiguous:       False
Word:            [Verb]GO
Word:            [Noun]NORTH(Confident)
Important words:
[Verb]GO [Noun]NORTH(Confident)
```

### Example 2

**Input**

```
GET KEY
```

**Output**

```
Input:           GET KEY
Parse success:   True
Ambiguous:       True
Word:            [Verb]GET
Word:            [Adj/Noun]SKELETON KEY(Ambigous!)
Important words:
[Verb]GET [Adj/Noun]SKELETON KEY(Ambigous!)
```

### Example 3

**Input**

```
USE GOLD KEY ON DOOR
```

**Output**

```
Input:           USE GOLD KEY ON DOOR
Parse success:   True
Ambiguous:       True
Word:            [Verb]USE
Word:            [Adj/Noun]GOLD KEY(Confident)
Word:            [Fill]ON(not important?)
Word:            [Adj/Noun]GREEN DOOR(Ambigous!)
Important words:
[Verb]USE [Adj/Noun]GOLD KEY(Confident) [Adj/Noun]GREEN DOOR(Ambigous!)
```
