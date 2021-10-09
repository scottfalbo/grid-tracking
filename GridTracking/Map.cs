using GridTracking.Critters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking
{
    public class Map
    {
        public Dictionary<Tuple<int, int>, List<Critter>> Grid { get; set; }

        public Map(int x, int y)
        {
            MakeMap(x, y);
        }

        /// <summary>
        /// Plot a new Critter object on the grid.
        /// </summary>
        /// <param name="critter"> Critter object </param>
        public void PlotCritter(Critter critter) 
        {
            Grid[new Tuple<int, int>(critter.X, critter.Y)].Add(critter);
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
