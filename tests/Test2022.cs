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

        [Theory]
        [InlineData(new string[] {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
            }, "CMZ")]
        public void Day5Part1(string[] input, string expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day5Part1(input));
        }
        [Theory]
        [InlineData(new string[] {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3",
            "",
            "move 1 from 2 to 1",
            "move 3 from 1 to 3",
            "move 2 from 2 to 1",
            "move 1 from 1 to 2"
            }, "MCD")]
        public void Day5Part2(string[] input, string expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day5Part2(input));
        }
        
        [Theory]
        [InlineData(new string[] { "mjqjpqmgbljsphdztnvjfqwrcgsmlb" }, 7)]
        [InlineData(new string[] { "bvwbjplbgvbhsrlpgdmjqwftvncz" }, 5)]
        [InlineData(new string[] { "nppdvjthqldpwncqszvftbrmjlhg" }, 6)]
        [InlineData(new string[] { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" }, 10)]
        [InlineData(new string[] { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" }, 11)]
        public void Day6Part1(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day6Part1(input));
        }
        [Theory]
        [InlineData(new string[] { "mjqjpqmgbljsphdztnvjfqwrcgsmlb" }, 19)]
        [InlineData(new string[] { "bvwbjplbgvbhsrlpgdmjqwftvncz" }, 23)]
        [InlineData(new string[] { "nppdvjthqldpwncqszvftbrmjlhg" }, 23)]
        [InlineData(new string[] { "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg" }, 29)]
        [InlineData(new string[] { "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw" }, 26)]
        public void Day6Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day6Part2(input));
        }

        [Theory]
        [InlineData(new string[] { 
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k" 
            }, 95437)]
        public void Day7Part1(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day7Part1(input));
        }
        [Theory]
        [InlineData(new string[] {
            "$ cd /",
            "$ ls",
            "dir a",
            "14848514 b.txt",
            "8504156 c.dat",
            "dir d",
            "$ cd a",
            "$ ls",
            "dir e",
            "29116 f",
            "2557 g",
            "62596 h.lst",
            "$ cd e",
            "$ ls",
            "584 i",
            "$ cd ..",
            "$ cd ..",
            "$ cd d",
            "$ ls",
            "4060174 j",
            "8033020 d.log",
            "5626152 d.ext",
            "7214296 k"
            }, 24933642)]
        public void Day7Part2(string[] input, int expected)
        {
            Assert.Equal(expected, TwentyTwentyTwo.Day7Part2(input));
        }


    }
}
