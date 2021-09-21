# Text Adventure Game Input Parser

A parser for a text adventure game. Can recognize sentences such as "go north", "use gold key on door" and "give food to Gandalf".

## Sample usages

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
Word:            [Adj/Noun]KEY SKELETON(Ambigous!)
Important words:
[Verb]GET [Adj/Noun]KEY SKELETON(Ambigous!)
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
Word:            [Adj/Noun]KEY GOLD(Confident)
Word:            [Fill]ON(not important?)
Word:            [Adj/Noun]DOOR GREEN(Ambigous!)
Important words:
[Verb]USE [Adj/Noun]KEY GOLD(Confident) [Adj/Noun]DOOR GREEN(Ambigous!)
```
