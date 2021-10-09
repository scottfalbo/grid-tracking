# Grid Movement Tracking Data Structure

---

*Author: Scott Falbo*

---

## Description

A C# implementation of a `Map` data structure for tracking movement.  The map contains a `Dictionary` of coordinates and a list of each cells inhabitants.

---

# `Map`

## Properties

| Property | Type | Summary |
| :------- | :-------- | :-------- |
| Grid | `Dictionary<Tuple<int, int>, List<Critter>>` | The Grid property is a Dictionary containing key pair values of coordinates and a List of `Critter` objects.  The X and Y limits are set via constructor on instantiation. |
| Height | `int` | The height of the grid ( x ). |
| Width | `int` | The width of the grid ( y ). |
| CritterCount | `int` | The total number of `Critter` objects populating the current Grid. |

---

## Methods

| Method | Summary | Big O Time | Big O Space | Example | 
| :----------- | :----------- | :-------------: | :-------------: | :----------- |
| MoveCritters | Randomly moves each `Critter` object on the grid one space in a random direction. | O(n^2) | O(1) | `myMap.MoveCritters()` |
| MoveCritter | Checks to see if the requested move is within the index limits of the Grid.  If so the `Critter` object is removed from it's current coordinate and moved the new target. | O(1) | O(1) | `myMap.MoveCritter(Critter critter, int[] move)` |
| ValidMovement | Ensures that the proposed movement is within the index range of the Grid. | O(1) | O(1) | `myMap.ValidMovement(int x, int y`) |
| GetRandomDirection | Get a random direction from the `Direction enum` | O(1) | O(1) | `myMap.GetRandomDirection()` |
| DirectionToCoords | Convert the `Direction` result from `GetRandomDirection()` to in `int[]{x, y}` where `x` and `y` represent the target coordinates. | O(1) | O(1) | `myMap.DirectionToCoords(Direction direction)` |
| MakeMap | Method used by the constructor to instantiate the `Grid` property with the user given index constraints. | O(n^2) | O(n^2) | `myMap.MakeMap()` |
| PlotCritter | Places a `Critter` object in the `Grid` property at the critter's assigned coordinates. | O(1) | O(1) | `myMap.PlotCritter(Critter critter)` |

---

# `Critter`

Base class that individual critters derive from.

## Properties

| Property | Type | Summary |
| :------- | :-------- | :-------- |
| Type | `string` | Critter type classification, assigned by the derived classes constructor on instantiation |
| Name | `string` | The critter's unique name |
| X | `int` | The critter's current x coordinate. |
| Y | `int` | The critter's current y coordinate. |
| PreviousX | `int` | The critter's previous x coordinate after movement. |
| PreviousX | `int` | The critter's previous y coordinate after movement. |
