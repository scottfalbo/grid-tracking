# Grid Movement Tracking Data Structure

*Author: Scott Falbo*

---

## Description

A C# implementation of a `Map` data structure for tracking movement.  The map contains a `Dictionary` of coordinates and a list of each cells inhabitants.

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
| :----------- | :----------- | :-------------: | :-------------: | :----------- |
| MoveCritters | Randomly moves each `Critter` object on the grid one space in a random direction. | O(n^2) | O(1) | `myMap.MoveCritters()` |
| MoveCritter | Checks to see if the requested move is within the index limits of the Grid.  If so the `Critter` object is removed from it's current coordinate and moved the new target. | O(1) | O(1) | `myMap.MoveCritter(Critter critter, int[] move)` |
| ValidMovement | Ensures that the proposed movement is within the index range of the Grid. | O(1) | O(1) | `myMap.ValidMovement(long x, long y`) |
| PlotCritter | Checks the `Critter` objects assigned X and Y properties.  If the key already exists in the Dictionary the critter is added to the list, if not a new key/value is created with the `Critter` object. | O(1) | O(1) | `myMap.PlotCritter(Critter critter)` |
| RemoveCritter | Removes the Critter object from the Dictionary.  If it is the only critter at that coordinate the key/value is removed from the dictionary. | O(n) | - | `myMap.RemoveCritter(Critter critter)` |
| ViewCoordinate | Retrieve a `List<Critter>` of all critters at the location.  Returns null if there are none. | O(n) | O(n) | `myMap.ViewCoordinate(long x, long y)` |
| PrintMap | Print the map to the console. Each cell is represented by the number of critters populating it. | O(n^2) | - | `myMap.PrintMap()` |

---

# `Critter`

Base class that individual critters derive from.

## Properties

| Property | Type | Summary |
| :------- | :-------- | :-------- |
| Type | `string` | Critter type classification, assigned by the derived classes constructor on instantiation |
| Name | `string` | The critter's unique name |
| X | `long` | The critter's current x coordinate. |
| Y | `long` | The critter's current y coordinate. |
| PreviousX | `long` | The critter's previous x coordinate after movement. |
| PreviousX | `long` | The critter's previous y coordinate after movement. |

---

## Change Log

+ 10/10/2021
  + Changed the type of the coordinate variables from `int` to `long` to accommodate larger tracking areas.
  + Removed the `MakeMap` method which was used to populate the dictionary with entries for each coordinate on instantiation.  Instead the Dictionary will only contain coordinates that contain critters.
  + Refactored the `PlotCritter` and `MoveCritter` methods to create and remove Dictionary entries based on whether the cell is populated or not.
  + Moved the random direction and related coordinate conversion methods to `Direction.cs`.
  + Added and tested the `ViewCoordinate` method detailed above.
  + Added the `PrintMap` method detailed above.
