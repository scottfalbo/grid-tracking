using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking.Critters
{
    public class Cthulhu : Critter
    {
        public Cthulhu(string name, long x, long y) : base(name, x, y)
        {
            Type = "Cthulhu";
        }
    }
}
