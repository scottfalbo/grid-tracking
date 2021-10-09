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

        [Fact]
        public void CanSuccessfullyPlotNewCritterOnTheGrid()
        {
            Map map = new Map(100, 100);
            Kraken kraken = new Kraken("Spaceghost", 56, 67);
            map.PlotCritter(kraken);
            string actual = "Spaceghost";
            string result = map.Grid[new Tuple<int, int>(56, 67)][0].Name;
            Assert.Equal(actual, result);
        }
    }
}
