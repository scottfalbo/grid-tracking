using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking.Critters
{
    public class Cthulhu : Critter
    {
        public Cthulhu() { }

        public Cthulhu(string name, long x, long y)
        {
            Type = "Cthulhu";
            Name = name;
            X = x;
            Y = y;
        }
    }
}
