using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Logic;
using Xunit;

namespace Tests
{
    public class Test2023
    {
        [Theory]
        [InlineData(new string[] { "1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet" }, 142)]
        [InlineData(new string[] { "sixsrvldfour4seven" }, 44)]
        [InlineData(new string[] { "fives2dznl" }, 22)]
        [InlineData(new string[] { "twocrqvjsix5threethree" }, 55)] //55
        [InlineData(new string[] { "gtjtwonefourone6fouronefccmnpbpeightnine" }, 66)]//66
        [InlineData(new string[] { "seventdtrcseveneightsevencgjgjxfpmfsix8twones" }, 88)] //88
        [InlineData(new string[] { "fourninethrnnth8" }, 88)] //88
        [InlineData(new string[] { "53hvhgchljnlxqjsgrhxgf1zfoureightmlhvvv" }, 51)]
        [InlineData(new string[] { "fourthreeseven1grvhrjxklh3ninetwothree" }, 13)]
        [InlineData(new string[] { "aaaaa4a" }, 44)]
        [InlineData(new string[] { "4aaa" }, 44)]
        [InlineData(new string[] { "aaa4" }, 44)]

        public void TestDay1(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day1Part1(input));
        }

        [Theory]
        [InlineData(new string[] { "1onebc2" }, 12)]
        [InlineData(new string[] { "1onebc" }, 11)]
        [InlineData(new string[] { "1two" }, 12)]
        [InlineData(new string[] { "one" }, 11)]
        [InlineData(new string[] { "one2" }, 12)]
        [InlineData(new string[] { "aone2" }, 12)]
        [InlineData(new string[] { "aonetwo" }, 12)]
        [InlineData(new string[] { "aonetwoerdfvsrgy" }, 12)]
        public void Day1Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day1Part2(input));
        }
    }  
}
