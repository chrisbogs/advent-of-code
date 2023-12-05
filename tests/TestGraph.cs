using System.Drawing;
using Xunit;
using AdventOfCodeShared.Algorithms;

namespace Tests
{
    public class GraphTests
    {
        [Fact]
        public void FindShortestPathBFSIterative_SingleCellGrid_ReturnsZero()
        {
            Point start = new Point(0, 0);
            Point end = new Point(0, 0);

            int result = Graph.FindShortestPathBFSIterative(start, end);

            Assert.Equal(0, result);
        }

        [Fact]
        public void FindShortestPathBFSIterative_ShortPath_ReturnsCorrectDistance()
        {
            Point start = new Point(0, 0);
            Point end = new Point(4, 4);

            int result = Graph.FindShortestPathBFSIterative(start, end);

            Assert.Equal(8, result);
        }

    }
}
