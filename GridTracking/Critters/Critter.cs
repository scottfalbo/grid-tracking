using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking.Critters
{
    public class Critter
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int PreviousX { get; set; }
        public int PreviousY { get; set; }
    }
}
