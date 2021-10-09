using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking
{
    public class Map
    {
        public Dictionary<Coords, List<string>> Grid { get; set; }

        public Map(int x, int y)
        {
            MakeMap(x, y);
        }

        private void MakeMap(int x, int y)
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Grid.Add(new Coords(i, j), new List<string>());
                }
            }
        }


    }
}
