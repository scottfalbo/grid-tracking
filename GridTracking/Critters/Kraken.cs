using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking.Critters
{
    public class Kraken : Critter
    {
        public Kraken(string name, long x, long y) : base(name, x, y)
        {
            Type = "Kraken";
        }
    }
}
