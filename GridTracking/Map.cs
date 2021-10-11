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
            //MakeMap(x, y);
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
                        int[] move = DirectionToCoords(GetRandomDirection());
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

                // remove


                critter.X += move[0];
                critter.Y += move[1];


                // add new
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
        /// Converts the Direction enum result into x, y movement adjustment.
        /// Up = {-1, 0}, Down = {1, 0}, Left = {0, -1}, Right = {0, 1}
        /// </summary>
        /// <param name="direction"> Direction direction </param>
        /// <returns> int[]{x, y} </returns>
        public int[] DirectionToCoords(Direction direction)
        {
            int[] move = new int[2] { 0, 0 };
            switch (direction)
            {
                case Direction.Up:
                    move[0] -= 1;
                    break;
                case Direction.Down:
                    move[0] += 1;
                    break;
                case Direction.Left:
                    move[1] -= 1;
                    break;
                case Direction.Right:
                    move[0] += 1;
                    break;
                default:
                    break;
            }
            return move;
        }

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
        /// Instantiate the Dictionary and add entires with Coords as keys.
        /// </summary>
        /// <param name="x"> height </param>
        /// <param name="y"> width </param>
        //public void MakeMap(int x, int y)
        //{
        //    Grid = new Dictionary<Tuple<long, long>, List<Critter>>();
        //    for (int i = 0; i < x; i++)
        //    {
        //        for (int j = 0; j < y; j++)
        //        {
        //            Grid.Add(new Tuple<long, long>(i,j), new List<Critter>());
        //        }
        //    }
        //}

        /// <summary>
        /// Get a random direction for the movement.
        /// </summary>
        /// <returns> random Direction enum </returns>
        public Direction GetRandomDirection()
        {
            var random = new Random(DateTime.Now.Millisecond);
            var randomValue = random.Next(0, 4);
            return (Direction)randomValue;
        }
    }
}
