using GridTracking;
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
            Map testMap = new Map(x, y);
            int result = testMap.Grid.Count;
            Assert.Equal(actual, result);
        }
    }
}
