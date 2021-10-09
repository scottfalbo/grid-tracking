using GridTracking;
using GridTracking.Critters;
using System;
using Xunit;

namespace GridTrackingTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(10, 10, 100)]
        [InlineData(100, 100, 10000)]
        [InlineData(1000, 1000, 1000000)]
        public void CanSuccessfullyCreateMapAndPlotGrid(int x, int y, int actual)
        {
            Map map = new Map(x, y);
            int result = map.Grid.Count;
            Assert.Equal(actual, result);
        }

        [Theory]
        [InlineData("Spaceghost", 10, 10)]
        [InlineData("Harry Winston", 17, 65)]
        [InlineData("Lucipurr", 87, 12)]
        [InlineData("Ethel Bean", 0, 99)]
        public void CanSuccessfullyPlotNewCritterOnTheGrid(string name, int x, int y)
        {
            Map map = new Map(100, 100);
            Kraken kraken = new Kraken(name, x, y);
            map.PlotCritter(kraken);
            string actual = name;
            string result = map.Grid[new Tuple<int, int>(x, y)][0].Name;
            Assert.Equal(actual, result);
        }
    }
}
