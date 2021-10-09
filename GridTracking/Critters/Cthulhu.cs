using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking.Critters
{
    public class Cthulhu : Critter
    {
        public Cthulhu() { }

        public Cthulhu(string name, int x, int y)
        {
            Type = "Cthulhu";
            Name = name;
            X = x;
            Y = y;
        }
    }
}
