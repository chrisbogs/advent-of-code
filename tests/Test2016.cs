using AdventOfCodeShared.Models;
using AdventOfCodeShared.Logic;
using Server;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class Test2016
    {
        [Theory]
        [InlineData(new string[] { "R2, L3" }, 5)]
        [InlineData(new string[] { "R2, R2, R2" }, 2)]
        [InlineData(new string[] { "R2, R2, R2, R2" }, 0)]
        [InlineData(new string[] { "L2, L2, L2, L2" }, 0)]
        [InlineData(new string[] { "L20000, L20000, R20000, R20000" }, 40000)]
        [InlineData(new string[] { "R5, L5, R5, R3" }, 12)]
        [InlineData(new string[] { "R2, L1, R2, R1, R1, L3, R3, L5, L5" }, 13)]
        [InlineData(new string[] { "R2, L1, R2, R1, R1, L3, R3, L5, L5, L2, L1, R4, R1, R3, L5, L5, R3, L4, L4, R5, R4, R3, L1, L2, R5, R4, L2, R1, R4, R4, L2, L1, L1, R190, R3, L4, R52, R5, R3, L5, R3, R2, R1, L5, L5, L4, R2, L3, R3, L1, L3, R5, L3, L4, R3, R77, R3, L2, R189, R4, R2, L2, R2, L1, R5, R4, R4, R2, L2, L2, L5, L1, R1, R2, L3, L4, L5, R1, L1, L2, L2, R2, L3, R3, L4, L1, L5, L4, L4, R3, R5, L2, R4, R5, R3, L2, L2, L4, L2, R2, L5, L4, R3, R1, L2, R2, R4, L1, L4, L4, L2, R2, L4, L1, L1, R4, L1, L3, L2, L2, L5, R5, R2, R5, L1, L5, R2, R4, R4, L2, R5, L5, R5, R5, L4, R2, R1, R1, R3, L3, L3, L4, L3, L2, L2, L2, R2, L1, L3, R2, R5, R5, L4, R3, L3, L4, R2, L5, R5" }, 234)]
        public void TestDay1(string[] directions, long expected)
        {
            Assert.Equal(expected, TwentySixteen.Day1Part1(directions));
        }
        [Theory]
        [InlineData(new string[] { "R8, R4, R4, R8" }, 4)]
        public void TestDay1Part2(string[] directions, long expected)
        {
            Assert.Equal(expected, TwentySixteen.Day1Part2(directions));
        }

        [Theory]
        [InlineData(new string[] { "ULL", "RRDDD", "LURDL", "UUUUD" }, 1985)]

        public void TestDay2Part1(string[] input, int expected)
        {
            Assert.Equal(expected, TwentySixteen.Day2Part1(input));
        }

        [Theory]
        [InlineData(new string[] { "ULL", "RRDDD", "LURDL", "UUUUD" }, "5DB3")]

        public void TestDay2Part2(string[] input, string expected)
        {
            Assert.Equal(expected, TwentySixteen.Day2Part2(input));
        }
        //[Fact]
        //public void TestDay3()
        //{
        //    }

        //[Fact]
        //public void TestDay4()
        //{
        //    }

        //[Fact]
        //public void TestDay5()
        //{
        //    }

        //[Fact]
        //public void TestDay6()
        //{
        //   }

        //[Fact]
        //public void TestDay7()
        //{
        //   }

        //[Fact]
        //public void TestDay8()
        //{
        //           }

        //[Fact]
        //public void TestDay9()
        //{
        //   }

        //[Fact]
        //public void TestDay10()
        //{

        //}

        //[Fact]
        //public void TestDay11()
        //{
        //}

        //[Fact]
        //public void TestDay12()
        //{
        //}

        //[Fact]
        //public void TestDay13()
        //{
        //}

        //[Fact]
        //public void TestDay14()
        //{
        //}

        //[Fact]
        //public void TestDay15()
        //{
        //}

        //[Fact]
        //public void TestDay16()
        //{
        //}

        //[Fact]
        //public void TestDay17()
        //{
        //}

        //[Fact]
        //public void TestDay18()
        //{
        //}

        //[Fact]
        //public void TestDay19()
        //{
        //}

        //[Fact]
        //public void TestDay20()
        //{
        //}

        //[Fact]
        //public void TestDay21()
        //{
        //}

        //[Fact]
        //public void TestDay22()
        //{
        //}

        //[Fact]
        //public void TestDay23()
        //{
        //}

        //[Fact]
        //public void TestDay24()
        //{
        //}

        //[Fact]
        //public void TestDay25()
        //{
        //}
    }
}
