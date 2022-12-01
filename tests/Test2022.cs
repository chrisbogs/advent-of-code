using AdventOfCodeShared.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace tests
{
    public class Test2022
    {
        [Theory]
        [InlineData(
    new string[]{
        "1000","2000","3000","","4000","","5000","6000","","7000","8000","9000", "", "10000"
    }, 24000)]
        public void Day1(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day1Part1(input));
        }

        [Theory]
        [InlineData(new string[] { "1000", "2000", "3000", "", "4000", "", "5000", "6000", "", "7000", "8000", "9000", "", "10000" }, 45000)]
        public void Day2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day1Part2(input));
        }
    }
}
