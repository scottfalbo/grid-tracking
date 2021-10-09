using System;
using System.Collections.Generic;
using System.Text;

namespace GridTracking.Critters
{
    public class Leviathan : Critter
    {
        public Leviathan() { }

        public Leviathan(string name, int x, int y)
        {
            Type = "Leviathan";
            Name = name;
            X = x;
            Y = y;
        }
    }
}
