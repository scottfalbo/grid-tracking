using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking.Critters
{
    public class Leviathan : Critter
    {
        public Leviathan(string name, long x, long y) : base(name, x, y)
        {
            Type = "Leviathan";
        }
    }
}
