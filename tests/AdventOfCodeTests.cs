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
            Assert.Equal(290784, sut.Part1("../../../../shared/PuzzleInput/input1-1.txt"));
            Assert.Equal(241861950, Day1Controller.Get3NumbersThatSumUpTo(new List<int>(){ 1721,979,366,299,675,1456}));
            Assert.Equal(514579, Day1Controller.Get2NumbersThatSumUpTo(new List<int>(){ 1721,979,366,299,675,1456}));
            Assert.Equal(177337980, sut.Part2("../../../../shared/PuzzleInput/input1-1.txt"));
        }

        [Fact]
        public void Day2()
        {
            var sut = new Day2Controller();
            Assert.Equal(0, sut.Part1("../../../../shared/PuzzleInput/input2.txt"));
            Assert.Equal(0, sut.Part2("../../../../shared/PuzzleInput/input2.txt"));
        }

    }
}
