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
        public List<Tuple<long, long>> Movement { get; set; }

        public Critter(string name, long x, long y)
        {
            Name = name;
            X = x;
            Y = y;
            Movement = new List<Tuple<long, long>>();
        }
    }
}
