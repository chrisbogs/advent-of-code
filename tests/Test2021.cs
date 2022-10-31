using AdventOfCodeShared.Models;
using AdventOfCodeShared.Services;
using Server;
using System.Collections.Generic;
using Xunit;

namespace tests
{
    public class Test2021
    {
        [Fact]
        public void Day1()
        {
            var sut = new YearController(new InputRetriever());
            Assert.Equal("1446", sut.Router(2021, 1, 1));
            Assert.Equal(7, Helpers.CountIncreases(new List<int>() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }));
            Assert.Equal(5, Helpers.CountIncreasesInThreeMeasurementWindow(new List<int>() { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }));
            Assert.Equal("1486", sut.Router(2021, 1, 2));
        }

        [Fact]
        public void Day2()
        {
            var sut = new YearController(new InputRetriever());
            Assert.Equal(150, TwentyTwentyOne.Day2Part1(new string[]{"forward 5",
        "down 5",
        "forward 8",
        "up 3",
        "down 8",
        "forward 2" }));
            Assert.Equal(900, TwentyTwentyOne.Day2Part2(new string[]{"forward 5",
        "down 5",
        "forward 8",
        "up 3",
        "down 8",
        "forward 2" }));

            Assert.Equal("2187380", sut.Router(2021, 2, 1));
            Assert.Equal("2086357770", sut.Router(2021, 2, 2));
        }

        [Fact]
        public void Day3()
        {
            var sut = new YearController(new InputRetriever());
            Assert.Equal("2648450", sut.Router(2021, 3, 1));
            Assert.Equal("2845944", sut.Router(2021, 3, 2));
        }

        [Fact]
        public void Day4()
        {
            Assert.Equal("4512", TwentyTwentyOne.Day4Part1(new string[]{
                "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
                "",
                  "22 13 17 11  0",
                   "8  2 23  4 24",
                  "21  9 14 16  7",
                   "6 10  3 18  5",
                   "1 12 20 15 19",
                  "",
                   "3 15  0  2 22",
                   "9 18 13 17  5",
                  "19  8  7 25 23",
                  "20 11 10 24  4",
                  "14 21 16 12  6",
                  "",
                  "14 21 17 24  4",
                  "10 16 15  9 19",
                  "18  8 23 26 20",
                  "22 11 13  6  5",
                   "2  0 12  3  7",
                   "" }));

            Assert.Equal("1924", TwentyTwentyOne.Day4Part2(new string[]{
                "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1",
                "",
                  "22 13 17 11  0",
                   "8  2 23  4 24",
                  "21  9 14 16  7",
                   "6 10  3 18  5",
                   "1 12 20 15 19",
                  "",
                   "3 15  0  2 22",
                   "9 18 13 17  5",
                  "19  8  7 25 23",
                  "20 11 10 24  4",
                  "14 21 16 12  6",
                  "",
                  "14 21 17 24  4",
                  "10 16 15  9 19",
                  "18  8 23 26 20",
                  "22 11 13  6  5",
                   "2  0 12  3  7",
                   "" }));

            var sut = new YearController(new InputRetriever());
            Assert.Equal("71708", sut.Router(2021, 4, 1));
            Assert.Equal("34726", sut.Router(2021, 4, 2));
        }


        //[Fact]
        //public void Day5()
        //{
        //    var input = new string[]{
        //        "0,9 -> 5,9",
        //        "8,0 -> 0,8",
        //        "9,4 -> 3,4",
        //        "2,2 -> 2,1",
        //        "7,0 -> 7,4",
        //        "6,4 -> 2,0",
        //        "0,9 -> 2,9",
        //        "3,4 -> 1,4",
        //        "0,0 -> 8,8",
        //        "5,5 -> 8,2"
        //    };
        //    Assert.Equal("5", TwentyTwentyOne.Day5Part1(input));
        //    Assert.Equal("12", TwentyTwentyOne.Day5Part2(input));

        //    var sut = new YearController(new InputRetriever());
        //    Assert.Equal("7674", sut.Router(2021, 5, 1));
        //    Assert.Equal("20898", sut.Router(2021, 5, 2));
        //}

        [Fact]
        public void Day6()
        {
            var input = new string[] { "3,4,3,1,2" };
            Assert.Equal("26", TwentyTwentyOne.Day6Part1(input, 18));
            Assert.Equal("5934", TwentyTwentyOne.Day6Part1(input, 80));
            Assert.Equal("26984457539", TwentyTwentyOne.Day6Part2(input, 256));

            var sut = new YearController(new InputRetriever());
            Assert.Equal("356190", sut.Router(2021, 6, 1));
            Assert.Equal("1617359101538", sut.Router(2021, 6, 2));
        }

        [Fact]
        public void Day7()
        {
            var input = new string[] { "16,1,2,0,4,2,7,1,2,14" };
            Assert.Equal("37", TwentyTwentyOne.Day7Part1(input));
            Assert.Equal("168", TwentyTwentyOne.Day7Part2(input));

            var sut = new YearController(new InputRetriever());
            Assert.Equal("323647", sut.Router(2021, 7, 1));
            Assert.Equal("87640209", sut.Router(2021, 7, 2));
        }

        [Theory]
        [InlineData(new string[] {
                "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe",
                "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc",
                "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg",
                "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb",
                "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea",
                "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb",
                "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe",
                "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef",
                "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb",
                "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce"
            }, "61229")]
        [InlineData(new string[] { "be cfbegad cbdgef fgaecd cgeb fdcge agebfd fecdb fabcd edb | fdgacbe cefdb cefbgd gcbe" }, "8394")]
        [InlineData(new string[] { "edbfga begcd cbg gc gcadebf fbgde acbgfd abcde gfcbed gfec | fcgedb cgb dgebacf gc" }, "9781")]
        [InlineData(new string[] { "fgaebd cg bdaec gdafb agbcfd gdcbef bgcad gfac gcb cdgabef | cg cg fdcagb cbg" }, "1197")]
        [InlineData(new string[] { "fbegcd cbd adcefb dageb afcb bc aefdc ecdab fgdeca fcdbega | efabcd cedba gadfec cb" }, "9361")]
        [InlineData(new string[] { "aecbfdg fbg gf bafeg dbefa fcge gcbea fcaegb dgceab fcbdga | gecf egdcabf bgf bfgea" }, "4873")]
        [InlineData(new string[] { "fgeab ca afcebg bdacfeg cfaedg gcfdb baec bfadeg bafgc acf | gebdcfa ecba ca fadegcb" }, "8418")]
        [InlineData(new string[] { "dbcfg fgd bdegcaf fgec aegbdf ecdfab fbedc dacgb gdcebf gf | cefg dcbef fcge gbcadfe" }, "4548")]
        [InlineData(new string[] { "bdfegc cbegaf gecbf dfcage bdacg ed bedf ced adcbefg gebcd | ed bcgafe cdgba cbgef" }, "1625")]
        [InlineData(new string[] { "egadfb cdbfeg cegd fecab cgb gbdefca cg fgcdab egfdb bfceg | gbdfcae bgc cg cgb" }, "8717")]
        [InlineData(new string[] { "gcafb gcf dcaebfg ecagb gf abcdeg gaef cafbge fdbac fegbdc | fgae cfgab fg bagce" }, "4315")]

        public void Day8Part2(string[] input, string expected)
        {
            Assert.Equal(expected, TwentyTwentyOne.Day8Part2(input));
        }

        [Fact]
        public void Day8DetermineSegments()
        {
            var displayDigits = DisplayDigits.DetermineSegments(new List<string>() {
"acedgfb", "cdfbe", "gcdfa", "fbcad", "dab", "cefabd", "cdfgeb", "eafb", "cagedb", "ab"});
            Assert.Equal("abcdf", string.Join("", displayDigits.Three));
            Assert.Equal("ab", string.Join("", displayDigits.One));
            Assert.Equal("abef", string.Join("", displayDigits.Four));
            Assert.Equal("abd", string.Join("", displayDigits.Seven));
            Assert.Equal("abcdeg", string.Join("", displayDigits.Zero));
            Assert.Equal("acdfg", string.Join("", displayDigits.Two));
            Assert.Equal("bcdef", string.Join("", displayDigits.Five));
            Assert.Equal("bcdefg", string.Join("", displayDigits.Six));
            Assert.Equal("abcdefg", string.Join("", displayDigits.Eight));
            Assert.Equal("abcdef", string.Join("", displayDigits.Nine));
        }

        [Fact]
        public void Day8()
        {
            var sut = new YearController(new InputRetriever());
            Assert.Equal("330", sut.Router(2021, 8, 1));
            Assert.Equal("1010472", sut.Router(2021, 8, 2));
        }

        [Fact]
        public void Day9()
        {
            var input = new string[]{
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678"
            };
            Assert.Equal(15, TwentyTwentyOne.Day9Part1(input));
            Assert.Equal(1134, TwentyTwentyOne.Day9Part2(input));

            var sut = new YearController(new InputRetriever());
            Assert.Equal("548", sut.Router(2021, 9, 1));
            Assert.Equal("786048", sut.Router(2021, 9, 2));
        }
        [Fact]
        public void Day9FindBasins()
        {
            var basins = new Grid(new string[] {
              "2199943210",
              "3987894921",
              "9856789892",
              "8767896789",
              "9899965678" })
            .FindBasins();

            Assert.Equal(new int[] { 5, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8 }, basins[0]);
            Assert.Equal(new int[] { 0, 1, 1, 2, 2, 2, 3, 4, 4 }, basins[1]);
            Assert.Equal(new int[] { 5, 6, 6, 6, 7, 7, 8, 8, 8 }, basins[2]);
            Assert.Equal(new int[] { 1, 2, 3 }, basins[3]);
        }

        [Fact]
        public void Day10()
        {
            var sut = new YearController(new InputRetriever());
            Assert.Equal("268845", sut.Router(2021, 10, 1));
            Assert.Equal("4038824534", sut.Router(2021, 10, 2));
        }
        [Fact]
        public void TestDay10()
        {
            var input = new string[]{"[({(<(())[]>[[{[]{<()<>>",
              "[(()[<>])]({[<{<<[]>>(",
              "{([(<{}[<>[]}>{[]{[(<()>",
              "(((({<>}<{<{<>}{[]{[]{}",
              "[[<[([]))<([[{}[[()]]]",
              "[{[{({}]{}}([{[{{{}}([]",
              "{<[[]]>}<{[{[{[]{()[[[]",
              "[<(<(<(<{}))><([]([]()",
              "<{([([[(<>()){}]>(<<{{",
              "<{([{{}}[<[[[<>{}]]]>[]]" };
            Assert.Equal(26397, TwentyTwentyOne.Day10Part1(input));
            Assert.Equal(26397, TwentyTwentyOne.Day10Part1(input));
        }

        [Theory]
        [InlineData("()")]
        [InlineData("[]")]
        [InlineData("{}")]
        [InlineData("<>")]
        [InlineData("([])")]
        [InlineData("{()()()}")]
        [InlineData("<([{}])>")]
        [InlineData("[<>({}){}[([])<>]]")]
        [InlineData("(((((((((())))))))))")]
        public void TestValidParsings(string input)
        {
            var parser = new SyntaxParser(new string[] { "(", "[", "{", "<" }, new string[] { ")", "]", "}", ">" }, new int[] { 3, 57, 1197, 25137 });

            Assert.Equal("", parser.Validate(input));
        }
        [Theory]
        [InlineData("(]", "Expected ), but found ] instead.")]
        [InlineData("{()()()>", "Expected }, but found > instead.")] 
        [InlineData("(((()))}", "Expected ), but found } instead.")] 
        [InlineData("<([]){()}[{}])", "Expected >, but found ) instead.")] 
        [InlineData("{([(<{}[<>[]}>{[]{[(<()>", "Expected ], but found } instead.")] 
        [InlineData("[[<[([]))<([[{}[[()]]]", "Expected ], but found ) instead.")] 
        [InlineData("[{[{({}]{}}([{[{{{}}([]", "Expected ), but found ] instead.")] 
        [InlineData("[<(<(<(<{}))><([]([]()", "Expected >, but found ) instead.")] 
        [InlineData("<{([([[(<>()){}]>(<<{{", "Expected ], but found > instead.")] 
        [InlineData("[({(<(())[]>[[{[]{<()<>>", "}}]])})]")]
        [InlineData("[(()[<>])]({[<{<<[]>>(", ")}>]})")]
        [InlineData("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))")]
        [InlineData("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>")]
        [InlineData("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")]
        public void TestInvalidParsings(string input, string expected)
        {
            var parser = new SyntaxParser(new string[] { "(", "[", "{", "<" },
                new string[] { ")", "]", "}", ">" }, 
                new int[] { 1, 2, 3, 4 });
            var result = parser.Validate(input);
            Assert.Equal(expected, result);
        }
    }
}
