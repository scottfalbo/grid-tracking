using GridTracking.Critters;
using System;
using System.Collections.Generic;

namespace GridTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map(20, 20);
            Kraken spaceghost = new Kraken("Spaceghost", 1, 2);
            Cthulhu harry = new Cthulhu("Harry Winston", 4, 7);
            Leviathan luci = new Leviathan("Lucipurr", 10, 15);
            Leviathan ethel = new Leviathan("Ethel Bean", 19, 18);
            map.PlotCritter(spaceghost);
            map.PlotCritter(harry);
            map.PlotCritter(luci);
            map.PlotCritter(ethel);
            map.PrintMap();
        }
    }

}
