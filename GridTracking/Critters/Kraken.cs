using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking.Critters
{
    public class Kraken : Critter
    {
        public Kraken() { }

        public Kraken(string name, long x, long y)
        {
            Type = "Kraken";
            Name = name;
            X = x;
            Y = y;
        }
    }
}
