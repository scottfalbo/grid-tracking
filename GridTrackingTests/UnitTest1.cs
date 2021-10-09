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
        public void CanSuccessfullyCreateMapAndPlotGrid(int x, int y, int expected)
        {
            Map map = new Map(x, y);
            int result = map.Grid.Count;
            Assert.Equal(expected, result);
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
            string expected = name;
            string result = map.Grid[new Tuple<int, int>(x, y)][0].Name;
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2, 5, true)]
        [InlineData(-1, 7, false)]
        [InlineData(0, 11, false)]
        [InlineData(11, 5, false)]
        [InlineData(6, -3, false)]
        public void CanSuccessfullyFindEdgeOfGrid(int x, int y, bool expected)
        {
            Map map = new Map(10, 10);
            bool result = map.ValidMovement(x, y);
            Assert.Equal(expected, result);
        }
    }
}
