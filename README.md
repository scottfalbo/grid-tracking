# Grid Movement Tracking

*Author: Scott Falbo*

---

## Description

A C# implementation of a `Map` data structure for tracking the movement of multiple targets.  The map contains a `Dictionary` of coordinates and a list of each cells inhabitants.  Class properties and methods are detailed below.

---

## Getting Started

+ There is a simple console UI in the project with a visual representation of the movement tracking system.
  + `git clone https://github.com/scottfalbo/grid-tracking.git`
  + Run the project and follow the console prompts.
+ To implement into another project copy:
  + `Map.cs`
  + `Direction.cs`
  + `Critters/Critter.cs`
    + Specific critters can be derived from `Critter`

```cs
    public class Kraken : Critter
    {
        ...
        public Kraken (string name, long x, long y, ...) : base(name, x, y)
        {
            Type = "Kraken";
            ...
        }
        ...
    }
```

---

## `Map`

[`Map.cs` code](https://github.com/scottfalbo/grid-tracking/blob/main/GridTracking/Map.cs)

## Properties

| Property | Type | Summary |
| :------- | :-------- | :-------- |
| Grid | `Dictionary<Tuple<long, long>, List<Critter>>` | The Grid property is a Dictionary containing key pair values of coordinates and a List of `Critter` objects.  The X and Y limits are set via constructor on instantiation. |
| Height | `long` | The height of the grid ( x ). |
| Width | `long` | The width of the grid ( y ). |
| CritterCount | `long` | The total number of `Critter` objects populating the current Grid. |

---

## Methods

| Method | Summary | Big O Time | Big O Space | Example |
| :- | :- | :- | :- | :- |
| MoveCritters | Randomly moves each `Critter` object on the grid one space in a random direction. | O(n^2) | O(1) | `myMap.MoveCritters()` |
| MoveCritter | The `Critter` object is removed from it's current coordinate and moved to the new targeted coordinate. | O(1) | O(1) | `myMap.MoveCritter(Critter critter, int[] move)` |
| ValidMovement | Ensures that the proposed movement is within the index range of the Grid. | O(1) | O(1) | `myMap.ValidMovement(long x, long y`) |
| PlotCritter | Checks the `Critter` objects assigned X and Y properties.  If the key already exists in the Dictionary the critter is added to the list, if not a new key/value is created with the `Critter` object. | O(1) | O(1) | `myMap.PlotCritter(Critter critter)` |
| RemoveCritter | Removes the Critter object from the Dictionary.  If it is the only critter at that coordinate the key/value is removed from the dictionary. | O(n) | - | `myMap.RemoveCritter(Critter critter)` |
| ViewCoordinate | Retrieve a `List<Critter>` of all critters at the location.  Returns null if there are none. | O(n) | O(n) | `myMap.ViewCoordinate(long x, long y)` |
| PrintMap | Print the map to the console. Each cell is represented by the number of critters populating it. | O(n^2) | - | `myMap.PrintMap()` |
| GetMovementPattern | Retrieve a list of a `Critter` objects movement history in the form of (x, y) coordinates.  Returns `Critter.Movement`. | O(1) | O(n) | `myMap.GetMovementPattern(Critter critter)` |
| GetCurrentCoord | Retrieve the current coordinate of the critter.  Returns `Tuple<long, long>(critter.X, critter.Y)` | O(1) | O(1) | `myMap.GetCurrentCoord(Critter critter)` |

---

## `Critter`

Base class that individual critters derive from.

## Properties

| Property | Type | Summary |
| :------- | :-------- | :-------- |
| Type | `string` | Critter type classification, assigned by the derived classes constructor on instantiation |
| Name | `string` | The critter's unique name |
| X | `long` | The critter's current x coordinate. |
| Y | `long` | The critter's current y coordinate. |
| Movement | `List<Tuple<long, long>>` | A list of the critters movement history. |

---

## Change Log

+ 10/10/2021
  + Changed the type of the coordinate variables from `int` to `long` to accommodate larger tracking areas.
  + Removed the `MakeMap` method which was used to populate the dictionary with entries for each coordinate on instantiation.  Instead the Dictionary will only contain coordinates that contain critters.
  + Refactored the `PlotCritter` and `MoveCritter` methods to create and remove Dictionary entries based on whether the cell is populated or not.
  + Moved the random direction and related coordinate conversion methods to `Direction.cs`.
  + Added and tested the `ViewCoordinate` method detailed above.
  + Added the `PrintMap` method detailed above.
+ 10/11/2021
  + Refactored derived class constructors to inherit shared constructor from `Critter` class.
  + Changed the `Critter` classes previous coord props to a list of all previous movement.
  + Added and tested methods to retrieve a critters movement history and current location.
