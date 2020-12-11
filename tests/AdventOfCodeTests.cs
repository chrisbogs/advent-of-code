using Server;
using System;
using System.Collections.Generic;
using Xunit;

namespace tests
{
    public class AdventOfCodeTests
    {
        [Fact]
        public void Day1()
        {
            var sut = new Day1Controller();
            Assert.Equal(290784, sut.Day1Part1("../../../../shared/PuzzleInput/input1-1.txt"));
            Assert.Equal(514579, Day1Controller.GetNumbersThatSumUpTo(new List<int>(){ 1721,979,366,299,675,1456}));
            //Assert.Equal(2, sut.Day1Part2());
        }
    }
}
