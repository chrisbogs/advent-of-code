using Server;
using System;
using Xunit;

namespace tests
{
    public class AdventOfCodeTests
    {
        [Fact]
        public void Day1()
        {
            var sut = new Day1Controller();
            Assert.Equal(25926, sut.Day1Part1("../../../../shared/PuzzleInput/input1-1.txt"));
            Assert.Equal(2, sut.Day1Part2());
        }
    }
}
