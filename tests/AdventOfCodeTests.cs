using AdventOfCodeShared.Models;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var parsed = AdventOfCodeShared.Extensions.StringExtensions.ParsePasswords(new string[1]{"2-6 c: fcpwjqhcgtffzlbj"}).First();
            Assert.Equal('c', parsed.Character);
            Assert.Equal(2, parsed.First);
            Assert.Equal(6, parsed.Second);
            Assert.Equal("fcpwjqhcgtffzlbj", parsed.Password);

            Assert.True(new PasswordWithRule('c', 2, 6, "fcpwjqhcgtffzlbj").IsValidv1());
            Assert.True(new PasswordWithRule('c', 2, 6, "fcpwjqhcgtffzlbj").IsValidv2());
            Assert.Equal(582, sut.Part1("../../../../shared/PuzzleInput/input2.txt"));
            Assert.Equal(729, sut.Part2("../../../../shared/PuzzleInput/input2.txt"));
        }

    }
}
