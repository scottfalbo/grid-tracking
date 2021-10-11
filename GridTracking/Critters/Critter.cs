using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking.Critters
{
    public class Critter
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long PreviousX { get; set; }
        public long PreviousY { get; set; }

        public Critter(string name, long x, long y)
        {
            Name = name;
            X = x;
            Y = y;
        }
    }
}
