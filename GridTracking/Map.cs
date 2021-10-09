using GridTracking.Critters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking
{
    public class Map
    {
        public Dictionary<Tuple<int, int>, List<Critter>> Grid { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int CritterCount { get; set; }

        public Map(int x, int y)
        {
            MakeMap(x, y);
            Height = x;
            Width = y;
            CritterCount = 0;
        }

        public void MoveCritters()
        {
            foreach (var coord in Grid)
            {
                if (coord.Value.Count > 0)
                {
                    foreach (Critter critter in coord.Value)
                    {
                        Direction direction = GetRandomDirection();
                        switch (direction)
                        {
                            case Direction.Up:

                                break;
                            case Direction.Down:

                                break;
                            case Direction.Left:

                                break;
                            case Direction.Right:

                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }

        public bool ValidMovement(int x, int y) =>
            !(x < 0 || x > Height-1 || y < 0 || y > Width-1);


        /// <summary>
        /// Plot a new Critter object on the grid.
        /// </summary>
        /// <param name="critter"> Critter object </param>
        public void PlotCritter(Critter critter) 
        {
            Grid[new Tuple<int, int>(critter.X, critter.Y)].Add(critter);
            CritterCount++;
        }

        /// <summary>
        /// Instantiate the Dictionary and add entires with Coords as keys.
        /// </summary>
        /// <param name="x"> height </param>
        /// <param name="y"> width </param>
        public void MakeMap(int x, int y)
        {
            Grid = new Dictionary<Tuple<int, int>, List<Critter>>();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Grid.Add(new Tuple<int, int>(i,j), new List<Critter>());
                }
            }
        }

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
