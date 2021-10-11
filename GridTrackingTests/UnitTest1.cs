using GridTracking;
using GridTracking.Critters;
using System;
using System.Collections.Generic;
using Xunit;

namespace GridTrackingTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("Spaceghost", 10, 10)]
        [InlineData("Harry Winston", 17, 65)]
        [InlineData("Lucipurr", 87, 12)]
        [InlineData("Ethel Bean", 56003, 70933)]
        public void CanPlotNewCritterOnTheGrid(string name, long x, long y)
        {
            Map map = new Map(100, 100);
            Kraken kraken = new Kraken(name, x, y);
            map.PlotCritter(kraken);
            string expected = name;
            string result = map.Grid[new Tuple<long, long>(x, y)][0].Name;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanAccuratelyCountTotalNumberOfCrittersOnMap()
        {
            Map map = new Map(10, 10);
            Kraken spaceghost = new Kraken("Spaceghost", 2, 3);
            Cthulhu harry = new Cthulhu("Harry Winston", 7, 1);
            Leviathan luci = new Leviathan("Lucipurr", 5, 6);
            Leviathan ethel = new Leviathan("Ethel", 7, 1);
            map.PlotCritter(spaceghost);
            map.PlotCritter(harry);
            map.PlotCritter(luci);
            map.PlotCritter(ethel);

            long expected = 4;
            long actual = map.CritterCount;

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void CanAccuratelyCountTotalNumberOfCrittersOnMapWhenRemoved()
        {
            Map map = new Map(10, 10);
            Kraken spaceghost = new Kraken("Spaceghost", 2, 3);
            Cthulhu harry = new Cthulhu("Harry Winston", 7, 1);
            Leviathan luci = new Leviathan("Lucipurr", 5, 6);
            Leviathan ethel = new Leviathan("Ethel", 7, 1);
            map.PlotCritter(spaceghost);
            map.PlotCritter(harry);
            map.PlotCritter(luci);
            map.PlotCritter(ethel);
            map.RemoveCritter(spaceghost);

            long expected = 3;
            long actual = map.CritterCount;

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(2, 5, true)]
        [InlineData(-1, 7, false)]
        [InlineData(0, 11, false)]
        [InlineData(11, 5, false)]
        [InlineData(6, -3, false)]
        public void CanFindEdgeOfGrid(int x, int y, bool expected)
        {
            Map map = new Map(10, 10);
            bool result = map.ValidMovement(x, y);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanMoveCritterToNewValidCoord()
        {
            Map map = new Map(10, 10);
            Leviathan leviathan = new Leviathan("Lucipurr", 5, 6);
            map.PlotCritter(leviathan);
            int[] move = new int[] { 0, 1 };
            map.MoveCritter(leviathan, move);
            string expected = "Lucipurr";
            string result = map.Grid[new Tuple<long, long>(5, 7)][0].Name;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanRemoveCritterFromCurrentCoordOnMove()
        {
            Map map = new Map(10, 10);
            Leviathan leviathan = new Leviathan("Ethel", 5, 6);
            map.PlotCritter(leviathan);
            int[] move = new int[] { 0, 1 };
            map.MoveCritter(leviathan, move);
            Assert.Null(map.ViewCoordinate(5, 6));
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
            string result = map.Grid[new Tuple<long, long>(9, 9)][0].Name;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void CanRetrieveCrittersFromGridAtGivenCoords()
        {
            Map map = new Map(1000, 1000);
            Kraken spaceghost = new Kraken("Spaceghost", 600, 600);
            Cthulhu harry = new Cthulhu("Harry Winston", 600, 600);
            Leviathan luci = new Leviathan("Lucipurr", 600, 600);
            Leviathan ethel = new Leviathan("Ethel Bean", 600, 600);
            map.PlotCritter(spaceghost);
            map.PlotCritter(harry);
            map.PlotCritter(luci);
            map.PlotCritter(ethel);
            List<Critter> expected = new List<Critter>()
                { spaceghost, harry, luci, ethel };
            List<Critter> actual = map.ViewCoordinate(600, 600);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ViewCoordinateReturnsNullIfCellHasNoCritters()
        {
            Map map = new Map(1000, 1000);
            Assert.Null(map.ViewCoordinate(123, 456));
        }

        [Fact]
        public void CanTrackAndRecordCritterMovement()
        {
            Map map = new Map(100, 100);
            Kraken kraken = new Kraken("Lucipurr the Destroyer", 50, 50);
            map.PlotCritter(kraken);
            int[] move = new int[] { 1, 0 };
            map.MoveCritter(kraken, move);
            move = new int[] { 0, -1 };
            map.MoveCritter(kraken, move);
            move = new int[] { 1, 0 };
            map.MoveCritter(kraken, move);

            List<Tuple<long, long>> expected = new List<Tuple<long, long>>();
            expected.Add(new Tuple<long, long>(50, 50));
            expected.Add(new Tuple<long, long>(51, 50));
            expected.Add(new Tuple<long, long>(51, 49));

            List<Tuple<long, long>> actual = map.GetMovementPattern(kraken);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(25, 76)]
        [InlineData(30, 16)]
        [InlineData(10, 90)]
        [InlineData(0, 99)]
        public void CanRetrieveCrittersCurrentCoords(long x, long y)
        {
            Map map = new Map(100, 100);
            Kraken kraken = new Kraken("Lucipurr the Destroyer", x, y);
            map.PlotCritter(kraken);

            Tuple<long, long> expected = new Tuple<long, long>(x, y);
            Tuple<long, long> actual = map.GetCurrentCoord(kraken);

            Assert.Equal(expected, actual);
        }
    }
}
