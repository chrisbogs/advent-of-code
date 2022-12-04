using AdventOfCodeShared.Logic;
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
        public void Day1Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day1Part2(input));
        }

        [Theory]
        [InlineData(new string[] { "A Y", "B X", "C Z" }, 15)]
        public void Day2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day2Part1(input));
        }

        [Theory]
        [InlineData(new string[] { "A Y", "B X", "C Z" }, 12)]
        public void Day2Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day2Part2(input));
        }

        [Theory]
        [InlineData(new string[] { 
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
         }, 157)]
        public void Day3Part1(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day3Part1(input));
        }
        [Theory]
        [InlineData(new string[] {
            "vJrwpWtwJgWrhcsFMMfFFhFp",
            "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
            "PmmdzqPrVvPwwTWBwg",
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
            "ttgJtRGJQctTZtZT",
            "CrZsJsPPZsGzwwsLwLmpwMDw"
         }, 70)]
        public void Day3Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day3Part2(input));
        }

        [Theory]
        [InlineData(new string[] {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",
            }, 2)]
        public void Day4Part1(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day4Part1(input));
        }
        [Theory]
        [InlineData(new string[] {
            "2-4,6-8",
            "2-3,4-5",
            "5-7,7-9",
            "2-8,3-7",
            "6-6,4-6",
            "2-6,4-8",
            }, 4)]
        public void Day4Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day4Part2(input));
        }



    }
}
