using GridTracking.Critters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking
{
    public class Map
    {
        public Dictionary<Tuple<long, long>, List<Critter>> Grid { get; set; }
        public long Height { get; set; }
        public long Width { get; set; }
        public long CritterCount { get; set; }

        public Map(long x, long y)
        {
            Grid = new Dictionary<Tuple<long, long>, List<Critter>>();
            Height = x;
            Width = y;
            CritterCount = 0;
        }

        /// <summary>
        /// Move each critter on the grid in a random direction.
        /// Critters do not move beyond map boundries. (Index Range)
        /// </summary>
        public void MoveCritters()
        {
            foreach (var coord in Grid)
            {
                if (coord.Value.Count > 0)
                {
                    foreach (Critter critter in coord.Value)
                    {
                        int[] move = Direction.GetRandomDirection();
                        MoveCritter(critter, move);
                    }   
                }
            }
        }

        /// <summary>
        /// Helper method to validate, remove, and assign new positions on the Grid for each critter movement.
        /// </summary>
        /// <param name="critter"> Critter object to move </param>
        /// <param name="move"> int[]{x, y} </param>
        public void MoveCritter(Critter critter, int[] move)
        {
            if (ValidMovement(critter.X + move[0], critter.Y + move[1]))
            {
                critter.PreviousX = critter.X;
                critter.PreviousY = critter.Y;
                RemoveCritter(critter);

                critter.X += move[0];
                critter.Y += move[1];
                PlotCritter(critter);
            }
        }

        /// <summary>
        /// Checks for edges of the grid to ensure movement is not out of range.
        /// </summary>
        /// <param name="x"> int x </param>
        /// <param name="y"> int y </param>
        /// <returns> true if valid else false </returns>
        public bool ValidMovement(long x, long y) =>
            (x >= 0 && x < Height && y >= 0 && y < Width);

        /// <summary>
        /// Check to see if key exists in Dictionary.
        /// If it exists add the critter to the List, if not create the key/value pair.
        /// </summary>
        /// <param name="critter"> Critter object </param>
        public void PlotCritter(Critter critter) 
        {
            Tuple<long, long> coords = new Tuple<long, long>(critter.X, critter.Y);
            if (Grid.ContainsKey(coords))
                Grid[coords].Add(critter);
            else
                Grid.Add(coords, new List<Critter>() { critter });
            CritterCount++;
        }

        /// <summary>
        /// Removes the critter from the dictionary.
        /// If it's the only critter in a cell the keay/value is removed from dictionary.
        /// </summary>
        /// <param name="critter"> Critter object to remove </param>
        public void RemoveCritter(Critter critter)
        {
            Tuple<long, long> coords = new Tuple<long, long>(critter.X, critter.Y);
            if (Grid.ContainsKey(coords))
                Grid[coords].Remove(critter);
            else
                Grid.Remove(coords);
            CritterCount--;
        }

        /// <summary>
        /// Returns a list of critters at the given coordinates.
        /// Returns null if the cell is empty.
        /// </summary>
        /// <param name="x"> x coord </param>
        /// <param name="y"> y coord </param>
        /// <returns> List<Critter> : null </returns>
        public List<Critter> ViewCoordinate(long x, long y)
        {
            List<Critter> critters = new List<Critter>();
            Tuple<long, long> coords = new Tuple<long, long>(x, y);
            if (Grid.ContainsKey(coords))
            {
                foreach (Critter critter in Grid[coords])
                    critters.Add(critter);
                return critters;
            }
            return null;
        }

        /// <summary>
        /// Output the Map to the console.
        /// Each cell is represented by the number of creatures populating it.
        /// </summary>
        public void PrintMap()
        {
            for (long i = 0; i < Height; i++)
            {
                for (long j = 0; j < Width; j++)
                {
                    Tuple<long, long> coords = new Tuple<long, long>(i, j);
                    if (Grid.ContainsKey(coords))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write($" {Grid[coords].Count} ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write($" {0} ");
                    }
                }
                Console.WriteLine("");
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
