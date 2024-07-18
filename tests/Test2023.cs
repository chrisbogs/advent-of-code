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
        public void TestDay1Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day1Part2(input));
        }

        [Theory]
        [InlineData(new string[] { "Game 11: 12 red, 13 green, 14 blue" }, 11)]
        [InlineData(new string[] { "Game 1: 0 red, 0 green, 0 blue" }, 1)]
        [InlineData(new string[] { "Game 1: 1 red, 1 green, 1 blue; 12 red, 13 green, 14 blue" }, 1)]
        [InlineData(new string[] { "Game 1: 0 red" }, 1)]
        [InlineData(new string[] { "Game 1: 0 green" }, 1)]
        [InlineData(new string[] { "Game 1: 0 blue" }, 1)]
        [InlineData(new string[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green" }, 1)]
        [InlineData(new string[] { "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue" }, 2)]
        [InlineData(new string[] { "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red" }, 0)]
        [InlineData(new string[] { "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red" }, 0)]
        [InlineData(new string[] { "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green" }, 5)]
        [InlineData(new string[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
        , "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue" 
        , "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red"
        , "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red"
        , "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green" }, 8)]
        public void TestDay2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day2Part1(input));
        }

        [Theory]
        [InlineData(new string[] { "Game 11: 12 red, 13 green, 14 blue" }, 2184)]
        [InlineData(new string[] { "Game 1: 0 red, 0 green, 0 blue" }, 0)]
        [InlineData(new string[] { "Game 1: 1 red, 1 green, 1 blue; 12 red, 13 green, 14 blue" }, 2184)]
        [InlineData(new string[] { "Game 1: 0 red" }, 0)]
        [InlineData(new string[] { "Game 1: 0 green" }, 0)]
        [InlineData(new string[] { "Game 1: 0 blue" }, 0)]
        [InlineData(new string[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green" }, 48)]
        [InlineData(new string[] { "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue" }, 12)]
        [InlineData(new string[] { "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red" }, 1560)]
        [InlineData(new string[] { "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red" }, 630)]
        [InlineData(new string[] { "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green" }, 36)]
        [InlineData(new string[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green"
        , "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue"
        , "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red"
        , "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red"
        , "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green" }, 2286)]
        public void TestDay2Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day2Part2(input));
        }

        [Theory]
        [InlineData(new string[] { 
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.." }, 4361)]
        public void TestDay3(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day3Part1(input));
        }

        [Theory]
        [InlineData(new string[] {
            "467..114..",
            "...*......",
            "..35..633.",
            "......#...",
            "617*......",
            ".....+.58.",
            "..592.....",
            "......755.",
            "...$.*....",
            ".664.598.." }, 467835)]
        public void TestDay3Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day3Part2(input));
        }

        [Theory]
        [InlineData(new string[] {
             "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
             "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
             "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
             "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
             "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
             "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"}, 13)]
        public void TestDay4(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day4Part1(input));
        }

        [Theory]
        [InlineData(new string[] {
             "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53",
             "Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19",
             "Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1",
             "Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83",
             "Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36",
             "Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11"}, 30)]
        public void TestDay4Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day4Part2(input));
        }

        [Theory]
        [InlineData(new string[] {
         "seeds: 79 14 55 13",
         "seed-to-soil map:",
         "50 98 2",
         "52 50 48",
         "soil-to-fertilizer map:",
         "0 15 37",
         "37 52 2",
         "39 0 15",
         "fertilizer-to-water map:",
         "49 53 8",
         "0 11 42",
         "42 0 7",
         "57 7 4",
         "water-to-light map:",
         "88 18 7",
         "18 25 70",
         "light-to-temperature map:",
         "45 77 23",
         "81 45 19",
         "68 64 13",
         "temperature-to-humidity map:",
         "0 69 1",
         "1 0 69",
         "humidity-to-location map:",
         "60 56 37",
         "56 93 4 ",
         }, 35)]
        public void TestDay5(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyThree.Day5Part1(input));
        }

        //[Theory]
        //[InlineData(new string[] {
        // "seeds: 79 14 55 13",
        // "seed-to-soil map:",
        // "50 98 2",
        // "52 50 48",
        // "soil-to-fertilizer map:",
        // "0 15 37",
        // "37 52 2",
        // "39 0 15",
        // "fertilizer-to-water map:",
        // "49 53 8",
        // "0 11 42",
        // "42 0 7",
        // "57 7 4",
        // "water-to-light map:",
        // "88 18 7",
        // "18 25 70",
        // "light-to-temperature map:",
        // "45 77 23",
        // "81 45 19",
        // "68 64 13",
        // "temperature-to-humidity map:",
        // "0 69 1",
        // "1 0 69",
        // "humidity-to-location map:",
        // "60 56 37",
        // "56 93 4 ",
        // }, 35)]
        //public void TestDay5Part2(string[] input, int expected)
        //{
        //    Assert.Equal(expected, TwentyTwentyThree.Day5Part2(input));
        //}
    }
}
