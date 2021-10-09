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

        [Fact]
        public void CanSuccessfullyMoveCritterToNewValidCoord()
        {
            Map map = new Map(10, 10);
            Leviathan leviathan = new Leviathan("Lucipurr", 5, 6);
            map.PlotCritter(leviathan);
            int[] move = new int[] { 0, 1 };
            map.MoveCritter(leviathan, move);
            string expected = "Lucipurr";
            string result = map.Grid[new Tuple<int, int>(5, 7)][0].Name;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanSuccessfullyRemoveCritterFromCurrentCoordOnMove()
        {
            Map map = new Map(10, 10);
            Leviathan leviathan = new Leviathan("Ethel", 5, 6);
            map.PlotCritter(leviathan);
            int[] move = new int[] { 0, 1 };
            map.MoveCritter(leviathan, move);
            int expected = 0;
            int result = map.Grid[new Tuple<int, int>(5, 6)].Count;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CritterStaysInPlaceOnEdgeCollison()
        {
            Map map = new Map(10, 10);
            Cthulhu cthulhu = new Cthulhu("Harry Winston", 9, 9);
            map.PlotCritter(cthulhu);
            int[] move = new int[] { 0, 1 };
            map.MoveCritter(cthulhu, move);
            string expected = "Harry Winston";
            string result = map.Grid[new Tuple<int, int>(9, 9)][0].Name;
            Assert.Equal(expected, result);
        }
    }
}
