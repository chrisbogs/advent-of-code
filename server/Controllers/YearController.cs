using AdventOfCodeShared.Logic;
using Microsoft.AspNetCore.Mvc;
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
namespace Server
{

    [Route("[controller]")]
    [ApiController]
    public class YearController : Controller
    {
        private readonly IInputRetriever inputRetriever;
        public YearController(IInputRetriever inputRetriever)
        {
            this.inputRetriever = inputRetriever;
        }

        [HttpGet("{year:int}/{day:int}/{part:int}")]
        public string Router(int year, int day, int part)
        {
            var input = this.inputRetriever.GetInput(year, day).Result;
            switch (year)
            {
                case 2022:
                    return day switch
                    {
                        1 => part switch
                        {
                            1 => TwentyTwentyTwo.Day1Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day1Part2(input).ToString()
                        },
                        2 => part switch
                        {
                            1 => TwentyTwentyTwo.Day2Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day2Part2(input).ToString()
                        },
                        3 => part switch
                        {
                            1 => TwentyTwentyTwo.Day3Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day3Part2(input).ToString()
                        },
                        4 => part switch
                        {
                            1 => TwentyTwentyTwo.Day4Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day4Part2(input).ToString()
                        },
                        5 => part switch
                        {
                            1 => TwentyTwentyTwo.Day5Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day5Part2(input).ToString()
                        },
                        6 => part switch
                        {
                            1 => TwentyTwentyTwo.Day6Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day6Part2(input).ToString()
                        },
                        7 => part switch
                        {
                            1 => TwentyTwentyTwo.Day7Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day7Part2(input).ToString()
                        },
                        8 => part switch
                        {
                            1 => TwentyTwentyTwo.Day8Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day8Part2(input).ToString()
                        },
                        9 => part switch
                        {
                            1 => TwentyTwentyTwo.Day9Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day9Part2(input).ToString()
                        },
                        10 => part switch
                        {
                            1 => TwentyTwentyTwo.Day10Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day10Part2(input).ToString()
                        },
                        11 => part switch
                        {
                            1 => TwentyTwentyTwo.Day11Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day11Part2(input).ToString()
                        },
                        12 => part switch
                        {
                            1 => TwentyTwentyTwo.Day12Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day12Part2(input).ToString()
                        },
                        13 => part switch
                        {
                            1 => TwentyTwentyTwo.Day13Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day13Part2(input).ToString()
                        },
                        14 => part switch
                        {
                            1 => TwentyTwentyTwo.Day14Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day14Part2(input).ToString()
                        },
                        15 => part switch
                        {
                            1 => TwentyTwentyTwo.Day15Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day15Part2(input).ToString()
                        },
                        16 => part switch
                        {
                            1 => TwentyTwentyTwo.Day16Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day16Part2(input).ToString()
                        },
                        17 => part switch
                        {
                            1 => TwentyTwentyTwo.Day17Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day17Part2(input).ToString()
                        },
                        18 => part switch
                        {
                            1 => TwentyTwentyTwo.Day18Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day18Part2(input).ToString()
                        },
                        19 => part switch
                        {
                            1 => TwentyTwentyTwo.Day19Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day19Part2(input).ToString()
                        },
                        20 => part switch
                        {
                            1 => TwentyTwentyTwo.Day20Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day20Part2(input).ToString()
                        },
                        21 => part switch
                        {
                            1 => TwentyTwentyTwo.Day21Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day21Part2(input).ToString()
                        },
                        22 => part switch
                        {
                            1 => TwentyTwentyTwo.Day22Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day22Part2(input).ToString()
                        },
                        23 => part switch
                        {
                            1 => TwentyTwentyTwo.Day23Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day23Part2(input).ToString()
                        },
                        24 => part switch
                        {
                            1 => TwentyTwentyTwo.Day24Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day24Part2(input).ToString()
                        },
                        25 => part switch
                        {
                            1 => TwentyTwentyTwo.Day25Part1(input).ToString(),
                            2 => TwentyTwentyTwo.Day25Part2(input).ToString()
                        }
                    };
                case 2021:
                    return day switch
                    {
                        1 => part switch
                        {
                            1 => TwentyTwentyOne.Day1Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day1Part2(input).ToString()
                        },
                        2 => part switch
                        {
                            1 => TwentyTwentyOne.Day2Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day2Part2(input).ToString()
                        },
                        3 => part switch
                        {
                            1 => TwentyTwentyOne.Day3Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day3Part2(input).ToString()
                        },
                        4 => part switch
                        {
                            1 => TwentyTwentyOne.Day4Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day4Part2(input).ToString()
                        },
                        5 => part switch
                        {
                            1 => TwentyTwentyOne.Day5Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day5Part2(input).ToString()
                        },
                        6 => part switch
                        {
                            1 => TwentyTwentyOne.Day6Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day6Part2(input).ToString()
                        },
                        7 => part switch
                        {
                            1 => TwentyTwentyOne.Day7Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day7Part2(input).ToString()
                        },
                        8 => part switch
                        {
                            1 => TwentyTwentyOne.Day8Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day8Part2(input).ToString()
                        },
                        9 => part switch
                        {
                            1 => TwentyTwentyOne.Day9Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day9Part2(input).ToString()
                        },
                        10 => part switch
                        {
                            1 => TwentyTwentyOne.Day10Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day10Part2(input).ToString()
                        },
                        11 => part switch
                        {
                            1 => TwentyTwentyOne.Day11Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day11Part2(input).ToString()
                        },
                        12 => part switch
                        {
                            1 => TwentyTwentyOne.Day12Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day12Part2(input).ToString()
                        },
                        13 => part switch
                        {
                            1 => TwentyTwentyOne.Day13Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day13Part2(input).ToString()
                        },
                        14 => part switch
                        {
                            1 => TwentyTwentyOne.Day14Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day14Part2(input).ToString()
                        },
                        15 => part switch
                        {
                            1 => TwentyTwentyOne.Day15Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day15Part2(input).ToString()
                        },
                        16 => part switch
                        {
                            1 => TwentyTwentyOne.Day16Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day16Part2(input).ToString()
                        },
                        17 => part switch
                        {
                            1 => TwentyTwentyOne.Day17Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day17Part2(input).ToString()
                        },
                        18 => part switch
                        {
                            1 => TwentyTwentyOne.Day18Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day18Part2(input).ToString()
                        },
                        19 => part switch
                        {
                            1 => TwentyTwentyOne.Day19Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day19Part2(input).ToString()
                        },
                        20 => part switch
                        {
                            1 => TwentyTwentyOne.Day20Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day20Part2(input).ToString()
                        },
                        21 => part switch
                        {
                            1 => TwentyTwentyOne.Day21Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day21Part2(input).ToString()
                        },
                        22 => part switch
                        {
                            1 => TwentyTwentyOne.Day22Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day22Part2(input).ToString()
                        },
                        23 => part switch
                        {
                            1 => TwentyTwentyOne.Day23Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day23Part2(input).ToString()
                        },
                        24 => part switch
                        {
                            1 => TwentyTwentyOne.Day24Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day24Part2(input).ToString()
                        },
                        25 => part switch
                        {
                            1 => TwentyTwentyOne.Day25Part1(input).ToString(),
                            2 => TwentyTwentyOne.Day25Part2(input).ToString()
                        }
                    };
                case 2020:
                    return day switch
                    {
                        1 => part switch
                        {
                            1 => TwentyTwenty.Day1Part1(input).ToString(),
                            2 => TwentyTwenty.Day1Part2(input).ToString()
                        },
                        2 => part switch
                        {
                            1 => TwentyTwenty.Day2Part1(input).ToString(),
                            2 => TwentyTwenty.Day2Part2(input).ToString()
                        },
                        3 => part switch
                        {
                            1 => TwentyTwenty.Day3Part1(input).ToString(),
                            2 => TwentyTwenty.Day3Part2(input).ToString()
                        },
                        4 => part switch
                        {
                            1 => TwentyTwenty.Day4Part1(input).ToString(),
                            2 => TwentyTwenty.Day4Part2(input).ToString()
                        },
                        5 => part switch
                        {
                            1 => TwentyTwenty.Day5Part1(input).ToString(),
                            2 => TwentyTwenty.Day5Part2(input).ToString()
                        },
                        6 => part switch
                        {
                            1 => TwentyTwenty.Day6Part1(input).ToString(),
                            2 => TwentyTwenty.Day6Part2(input).ToString()
                        },
                        7 => part switch
                        {
                            1 => TwentyTwenty.Day7Part1(input).ToString(),
                            2 => TwentyTwenty.Day7Part2(input).ToString()
                        },
                        8 => part switch
                        {
                            1 => TwentyTwenty.Day8Part1(input).ToString(),
                            2 => TwentyTwenty.Day8Part2(input).ToString()
                        },
                        9 => part switch
                        {
                            1 => TwentyTwenty.Day9Part1(input).ToString(),
                            2 => TwentyTwenty.Day9Part2(input).ToString()
                        },
                        10 => part switch
                        {
                            1 => TwentyTwenty.Day10Part1(input).ToString(),
                            2 => TwentyTwenty.Day10Part2(input).ToString()
                        },
                        11 => part switch
                        {
                            1 => TwentyTwenty.Day11Part1(input).ToString(),
                            2 => TwentyTwenty.Day11Part2(input).ToString()
                        },
                        12 => part switch
                        {
                            1 => TwentyTwenty.Day12Part1(input).ToString(),
                            2 => TwentyTwenty.Day12Part2(input).ToString()
                        },
                        13 => part switch
                        {
                            1 => TwentyTwenty.Day13Part1(input).ToString(),
                            2 => TwentyTwenty.Day13Part2(input).ToString()
                        },
                        14 => part switch
                        {
                            1 => TwentyTwenty.Day14Part1(input).ToString(),
                            2 => TwentyTwenty.Day14Part2(input).ToString()
                        },
                        15 => part switch
                        {
                            1 => TwentyTwenty.Day15Part1(input).ToString(),
                            2 => TwentyTwenty.Day15Part2(input).ToString()
                        },
                        16 => part switch
                        {
                            1 => TwentyTwenty.Day16Part1(input).ToString(),
                            2 => TwentyTwenty.Day16Part2(input).ToString()
                        },
                        17 => part switch
                        {
                            1 => TwentyTwenty.Day17Part1(input).ToString(),
                            2 => TwentyTwenty.Day17Part2(input).ToString()
                        },
                        18 => part switch
                        {
                            1 => TwentyTwenty.Day18Part1(input).ToString(),
                            2 => TwentyTwenty.Day18Part2(input).ToString()
                        },
                        19 => part switch
                        {
                            1 => TwentyTwenty.Day19Part1(input).ToString(),
                            2 => TwentyTwenty.Day19Part2(input).ToString()
                        },
                        20 => part switch
                        {
                            1 => TwentyTwenty.Day20Part1(input).ToString(),
                            2 => TwentyTwenty.Day20Part2(input).ToString()
                        },
                        21 => part switch
                        {
                            1 => TwentyTwenty.Day21Part1(input).ToString(),
                            2 => TwentyTwenty.Day21Part2(input).ToString()
                        },
                        22 => part switch
                        {
                            1 => TwentyTwenty.Day22Part1(input).ToString(),
                            2 => TwentyTwenty.Day22Part2(input).ToString()
                        },
                        23 => part switch
                        {
                            1 => TwentyTwenty.Day23Part1(input).ToString(),
                            2 => TwentyTwenty.Day23Part2(input).ToString()
                        },
                        24 => part switch
                        {
                            1 => TwentyTwenty.Day24Part1(input).ToString(),
                            2 => TwentyTwenty.Day24Part2(input).ToString()
                        },
                        25 => part switch
                        {
                            1 => TwentyTwenty.Day25Part1(input).ToString(),
                            2 => TwentyTwenty.Day25Part2(input).ToString()
                        }
                    };
                case 2019:
                    return day switch
                    {
                        1 => part switch
                        {
                            1 => TwentyNineteen.Day1Part1(input).ToString(),
                            2 => TwentyNineteen.Day1Part2(input).ToString()
                        },
                        2 => part switch
                        {
                            1 => TwentyNineteen.Day2Part1(input).ToString(),
                            2 => TwentyNineteen.Day2Part2(input).ToString()
                        },
                        3 => part switch
                        {
                            1 => TwentyNineteen.Day3Part1(input).ToString(),
                            2 => TwentyNineteen.Day3Part2(input).ToString()
                        },
                        4 => part switch
                        {
                            1 => TwentyNineteen.Day4Part1(input).ToString(),
                            2 => TwentyNineteen.Day4Part2(input).ToString()
                        },
                        5 => part switch
                        {
                            1 => string.Join(',', TwentyNineteen.Day5Part1(input)),
                            2 => TwentyNineteen.Day5Part2(input)[0].ToString()
                        },
                        6 => part switch
                        {
                            1 => TwentyNineteen.Day6Part1(input).ToString(),
                            2 => TwentyNineteen.Day6Part2(input).ToString()
                        },
                        7 => part switch
                        {
                            1 => TwentyNineteen.Day7Part1(input).ToString(),
                            2 => TwentyNineteen.Day7Part2(input).ToString()
                        },
                        8 => part switch
                        {
                            1 => TwentyNineteen.Day8Part1(input).ToString(),
                            2 => TwentyNineteen.Day8Part2(input).ToString()
                        },
                        9 => part switch
                        {
                            1 => TwentyNineteen.Day9Part1(input).ToString(),
                            2 => TwentyNineteen.Day9Part2(input).ToString()
                        },
                        10 => part switch
                        {
                            1 => TwentyNineteen.Day10Part1(input).ToString(),
                            2 => TwentyNineteen.Day10Part2(input).ToString()
                        },
                        11 => part switch
                        {
                            1 => TwentyNineteen.Day11Part1(input).ToString(),
                            2 => TwentyNineteen.Day11Part2(input).ToString()
                        },
                        12 => part switch
                        {
                            1 => TwentyNineteen.Day12Part1(input).ToString(),
                            2 => TwentyNineteen.Day12Part2(input).ToString()
                        },
                        13 => part switch
                        {
                            1 => TwentyNineteen.Day13Part1(input).ToString(),
                            2 => TwentyNineteen.Day13Part2(input).ToString()
                        },
                        14 => part switch
                        {
                            1 => TwentyNineteen.Day14Part1(input).ToString(),
                            2 => TwentyNineteen.Day14Part2(input).ToString()
                        },
                        15 => part switch
                        {
                            1 => TwentyNineteen.Day15Part1(input).ToString(),
                            2 => TwentyNineteen.Day15Part2(input).ToString()
                        },
                        16 => part switch
                        {
                            1 => TwentyNineteen.Day16Part1(input).ToString(),
                            2 => TwentyNineteen.Day16Part2(input).ToString()
                        },
                        17 => part switch
                        {
                            1 => TwentyNineteen.Day17Part1(input).ToString(),
                            2 => TwentyNineteen.Day17Part2(input).ToString()
                        },
                        18 => part switch
                        {
                            1 => TwentyNineteen.Day18Part1(input).ToString(),
                            2 => TwentyNineteen.Day18Part2(input).ToString()
                        },
                        19 => part switch
                        {
                            1 => TwentyNineteen.Day19Part1(input).ToString(),
                            2 => TwentyNineteen.Day19Part2(input).ToString()
                        },
                        20 => part switch
                        {
                            1 => TwentyNineteen.Day20Part1(input).ToString(),
                            2 => TwentyNineteen.Day20Part2(input).ToString()
                        },
                        21 => part switch
                        {
                            1 => TwentyNineteen.Day21Part1(input).ToString(),
                            2 => TwentyNineteen.Day21Part2(input).ToString()
                        },
                        22 => part switch
                        {
                            1 => TwentyNineteen.Day22Part1(input).ToString(),
                            2 => TwentyNineteen.Day22Part2(input).ToString()
                        },
                        23 => part switch
                        {
                            1 => TwentyNineteen.Day23Part1(input).ToString(),
                            2 => TwentyNineteen.Day23Part2(input).ToString()
                        },
                        24 => part switch
                        {
                            1 => TwentyNineteen.Day24Part1(input).ToString(),
                            2 => TwentyNineteen.Day24Part2(input).ToString()
                        },
                        25 => part switch
                        {
                            1 => TwentyNineteen.Day25Part1(input).ToString(),
                            2 => TwentyNineteen.Day25Part2(input).ToString()
                        }
                    };
                case 2018:
                    return day switch
                    {
                        1 => part switch
                        {
                            1 => TwentyEighteen.Day1Part1(input).ToString(),
                            2 => TwentyEighteen.Day1Part2(input).ToString()
                        },
                        2 => part switch
                        {
                            1 => TwentyEighteen.Day2Part1(input).ToString(),
                            2 => TwentyEighteen.Day2Part2(input).ToString()
                        },
                        3 => part switch
                        {
                            1 => TwentyEighteen.Day3Part1(input).ToString(),
                            2 => TwentyEighteen.Day3Part2(input).ToString()
                        },
                        4 => part switch
                        {
                            1 => TwentyEighteen.Day4Part1(input).ToString(),
                            2 => TwentyEighteen.Day4Part2(input).ToString()
                        },
                        5 => part switch
                        {
                            1 => TwentyEighteen.Day5Part1(input).ToString(),
                            2 => TwentyEighteen.Day5Part2(input).ToString()
                        },
                        6 => part switch
                        {
                            1 => TwentyEighteen.Day6Part1(input).ToString(),
                            2 => TwentyEighteen.Day6Part2(input).ToString()
                        },
                        7 => part switch
                        {
                            1 => TwentyEighteen.Day7Part1(input).ToString(),
                            2 => TwentyEighteen.Day7Part2(input).ToString()
                        },
                        8 => part switch
                        {
                            1 => TwentyEighteen.Day8Part1(input).ToString(),
                            2 => TwentyEighteen.Day8Part2(input).ToString()
                        },
                        9 => part switch
                        {
                            1 => TwentyEighteen.Day9Part1(input).ToString(),
                            2 => TwentyEighteen.Day9Part2(input).ToString()
                        },
                        10 => part switch
                        {
                            1 => TwentyEighteen.Day10Part1(input).ToString(),
                            2 => TwentyEighteen.Day10Part2(input).ToString()
                        },
                        11 => part switch
                        {
                            1 => TwentyEighteen.Day11Part1(input).ToString(),
                            2 => TwentyEighteen.Day11Part2(input).ToString()
                        },
                        12 => part switch
                        {
                            1 => TwentyEighteen.Day12Part1(input).ToString(),
                            2 => TwentyEighteen.Day12Part2(input).ToString()
                        },
                        13 => part switch
                        {
                            1 => TwentyEighteen.Day13Part1(input).ToString(),
                            2 => TwentyEighteen.Day13Part2(input).ToString()
                        },
                        14 => part switch
                        {
                            1 => TwentyEighteen.Day14Part1(input).ToString(),
                            2 => TwentyEighteen.Day14Part2(input).ToString()
                        },
                        15 => part switch
                        {
                            1 => TwentyEighteen.Day15Part1(input).ToString(),
                            2 => TwentyEighteen.Day15Part2(input).ToString()
                        },
                        16 => part switch
                        {
                            1 => TwentyEighteen.Day16Part1(input).ToString(),
                            2 => TwentyEighteen.Day16Part2(input).ToString()
                        },
                        17 => part switch
                        {
                            1 => TwentyEighteen.Day17Part1(input).ToString(),
                            2 => TwentyEighteen.Day17Part2(input).ToString()
                        },
                        18 => part switch
                        {
                            1 => TwentyEighteen.Day18Part1(input).ToString(),
                            2 => TwentyEighteen.Day18Part2(input).ToString()
                        },
                        19 => part switch
                        {
                            1 => TwentyEighteen.Day19Part1(input).ToString(),
                            2 => TwentyEighteen.Day19Part2(input).ToString()
                        },
                        20 => part switch
                        {
                            1 => TwentyEighteen.Day20Part1(input).ToString(),
                            2 => TwentyEighteen.Day20Part2(input).ToString()
                        },
                        21 => part switch
                        {
                            1 => TwentyEighteen.Day21Part1(input).ToString(),
                            2 => TwentyEighteen.Day21Part2(input).ToString()
                        },
                        22 => part switch
                        {
                            1 => TwentyEighteen.Day22Part1(input).ToString(),
                            2 => TwentyEighteen.Day22Part2(input).ToString()
                        },
                        23 => part switch
                        {
                            1 => TwentyEighteen.Day23Part1(input).ToString(),
                            2 => TwentyEighteen.Day23Part2(input).ToString()
                        },
                        24 => part switch
                        {
                            1 => TwentyEighteen.Day24Part1(input).ToString(),
                            2 => TwentyEighteen.Day24Part2(input).ToString()
                        },
                        25 => part switch
                        {
                            1 => TwentyEighteen.Day25Part1(input).ToString(),
                            2 => TwentyEighteen.Day25Part2(input).ToString()
                        }
                    };
                case 2017:
                    return day switch
                    {
                        1 => part switch
                        {
                            1 => TwentySeventeen.Day1Part1(input).ToString(),
                            2 => TwentySeventeen.Day1Part2(input).ToString()
                        },
                        2 => part switch
                        {
                            1 => TwentySeventeen.Day2Part1(input).ToString(),
                            2 => TwentySeventeen.Day2Part2(input).ToString()
                        },
                        3 => part switch
                        {
                            1 => TwentySeventeen.Day3Part1(input).ToString(),
                            2 => TwentySeventeen.Day3Part2(input).ToString()
                        },
                        4 => part switch
                        {
                            1 => TwentySeventeen.Day4Part1(input).ToString(),
                            2 => TwentySeventeen.Day4Part2(input).ToString()
                        },
                        5 => part switch
                        {
                            1 => TwentySeventeen.Day5Part1(input).ToString(),
                            2 => TwentySeventeen.Day5Part2(input).ToString()
                        },
                        6 => part switch
                        {
                            1 => TwentySeventeen.Day6Part1(input).ToString(),
                            2 => TwentySeventeen.Day6Part2(input).ToString()
                        },
                        7 => part switch
                        {
                            1 => TwentySeventeen.Day7Part1(input).ToString(),
                            2 => TwentySeventeen.Day7Part2(input).ToString()
                        },
                        8 => part switch
                        {
                            1 => TwentySeventeen.Day8Part1(input).ToString(),
                            2 => TwentySeventeen.Day8Part2(input).ToString()
                        },
                        9 => part switch
                        {
                            1 => TwentySeventeen.Day9Part1(input).ToString(),
                            2 => TwentySeventeen.Day9Part2(input).ToString()
                        },
                        10 => part switch
                        {
                            1 => TwentySeventeen.Day10Part1(input).ToString(),
                            2 => TwentySeventeen.Day10Part2(input).ToString()
                        },
                        11 => part switch
                        {
                            1 => TwentySeventeen.Day11Part1(input).ToString(),
                            2 => TwentySeventeen.Day11Part2(input).ToString()
                        },
                        12 => part switch
                        {
                            1 => TwentySeventeen.Day12Part1(input).ToString(),
                            2 => TwentySeventeen.Day12Part2(input).ToString()
                        },
                        13 => part switch
                        {
                            1 => TwentySeventeen.Day13Part1(input).ToString(),
                            2 => TwentySeventeen.Day13Part2(input).ToString()
                        },
                        14 => part switch
                        {
                            1 => TwentySeventeen.Day14Part1(input).ToString(),
                            2 => TwentySeventeen.Day14Part2(input).ToString()
                        },
                        15 => part switch
                        {
                            1 => TwentySeventeen.Day15Part1(input).ToString(),
                            2 => TwentySeventeen.Day15Part2(input).ToString()
                        },
                        16 => part switch
                        {
                            1 => TwentySeventeen.Day16Part1(input).ToString(),
                            2 => TwentySeventeen.Day16Part2(input).ToString()
                        },
                        17 => part switch
                        {
                            1 => TwentySeventeen.Day17Part1(input).ToString(),
                            2 => TwentySeventeen.Day17Part2(input).ToString()
                        },
                        18 => part switch
                        {
                            1 => TwentySeventeen.Day18Part1(input).ToString(),
                            2 => TwentySeventeen.Day18Part2(input).ToString()
                        },
                        19 => part switch
                        {
                            1 => TwentySeventeen.Day19Part1(input).ToString(),
                            2 => TwentySeventeen.Day19Part2(input).ToString()
                        },
                        20 => part switch
                        {
                            1 => TwentySeventeen.Day20Part1(input).ToString(),
                            2 => TwentySeventeen.Day20Part2(input).ToString()
                        },
                        21 => part switch
                        {
                            1 => TwentySeventeen.Day21Part1(input).ToString(),
                            2 => TwentySeventeen.Day21Part2(input).ToString()
                        },
                        22 => part switch
                        {
                            1 => TwentySeventeen.Day22Part1(input).ToString(),
                            2 => TwentySeventeen.Day22Part2(input).ToString()
                        },
                        23 => part switch
                        {
                            1 => TwentySeventeen.Day23Part1(input).ToString(),
                            2 => TwentySeventeen.Day23Part2(input).ToString()
                        },
                        24 => part switch
                        {
                            1 => TwentySeventeen.Day24Part1(input).ToString(),
                            2 => TwentySeventeen.Day24Part2(input).ToString()
                        },
                        25 => part switch
                        {
                            1 => TwentySeventeen.Day25Part1(input).ToString(),
                            2 => TwentySeventeen.Day25Part2(input).ToString()
                        }
                    };
                case 2016:
                    return day switch
                    {
                        1 => part switch
                        {
                            1 => TwentySixteen.Day1Part1(input).ToString(),
                            2 => TwentySixteen.Day1Part2(input).ToString()
                        },
                        2 => part switch
                        {
                            1 => TwentySixteen.Day2Part1(input).ToString(),
                            2 => TwentySixteen.Day2Part2(input).ToString()
                        },
                        3 => part switch
                        {
                            1 => TwentySixteen.Day3Part1(input).ToString(),
                            2 => TwentySixteen.Day3Part2(input).ToString()
                        },
                        4 => part switch
                        {
                            1 => TwentySixteen.Day4Part1(input).ToString(),
                            2 => TwentySixteen.Day4Part2(input).ToString()
                        },
                        5 => part switch
                        {
                            1 => TwentySixteen.Day5Part1(input).ToString(),
                            2 => TwentySixteen.Day5Part2(input).ToString()
                        },
                        6 => part switch
                        {
                            1 => TwentySixteen.Day6Part1(input).ToString(),
                            2 => TwentySixteen.Day6Part2(input).ToString()
                        },
                        7 => part switch
                        {
                            1 => TwentySixteen.Day7Part1(input).ToString(),
                            2 => TwentySixteen.Day7Part2(input).ToString()
                        },
                        8 => part switch
                        {
                            1 => TwentySixteen.Day8Part1(input).ToString(),
                            2 => TwentySixteen.Day8Part2(input).ToString()
                        },
                        9 => part switch
                        {
                            1 => TwentySixteen.Day9Part1(input).ToString(),
                            2 => TwentySixteen.Day9Part2(input).ToString()
                        },
                        10 => part switch
                        {
                            1 => TwentySixteen.Day10Part1(input).ToString(),
                            2 => TwentySixteen.Day10Part2(input).ToString()
                        },
                        11 => part switch
                        {
                            1 => TwentySixteen.Day11Part1(input).ToString(),
                            2 => TwentySixteen.Day11Part2(input).ToString()
                        },
                        12 => part switch
                        {
                            1 => TwentySixteen.Day12Part1(input).ToString(),
                            2 => TwentySixteen.Day12Part2(input).ToString()
                        },
                        13 => part switch
                        {
                            1 => TwentySixteen.Day13Part1(input).ToString(),
                            2 => TwentySixteen.Day13Part2(input).ToString()
                        },
                        14 => part switch
                        {
                            1 => TwentySixteen.Day14Part1(input).ToString(),
                            2 => TwentySixteen.Day14Part2(input).ToString()
                        },
                        15 => part switch
                        {
                            1 => TwentySixteen.Day15Part1(input).ToString(),
                            2 => TwentySixteen.Day15Part2(input).ToString()
                        },
                        16 => part switch
                        {
                            1 => TwentySixteen.Day16Part1(input).ToString(),
                            2 => TwentySixteen.Day16Part2(input).ToString()
                        },
                        17 => part switch
                        {
                            1 => TwentySixteen.Day17Part1(input).ToString(),
                            2 => TwentySixteen.Day17Part2(input).ToString()
                        },
                        18 => part switch
                        {
                            1 => TwentySixteen.Day18Part1(input).ToString(),
                            2 => TwentySixteen.Day18Part2(input).ToString()
                        },
                        19 => part switch
                        {
                            1 => TwentySixteen.Day19Part1(input).ToString(),
                            2 => TwentySixteen.Day19Part2(input).ToString()
                        },
                        20 => part switch
                        {
                            1 => TwentySixteen.Day20Part1(input).ToString(),
                            2 => TwentySixteen.Day20Part2(input).ToString()
                        },
                        21 => part switch
                        {
                            1 => TwentySixteen.Day21Part1(input).ToString(),
                            2 => TwentySixteen.Day21Part2(input).ToString()
                        },
                        22 => part switch
                        {
                            1 => TwentySixteen.Day22Part1(input).ToString(),
                            2 => TwentySixteen.Day22Part2(input).ToString()
                        },
                        23 => part switch
                        {
                            1 => TwentySixteen.Day23Part1(input).ToString(),
                            2 => TwentySixteen.Day23Part2(input).ToString()
                        },
                        24 => part switch
                        {
                            1 => TwentySixteen.Day24Part1(input).ToString(),
                            2 => TwentySixteen.Day24Part2(input).ToString()
                        },
                        25 => part switch
                        {
                            1 => TwentySixteen.Day25Part1(input).ToString(),
                            2 => TwentySixteen.Day25Part2(input).ToString()
                        }
                    };
                case 2015:
                    return day switch
                    {
                        1 => part switch
                        {
                            1 => TwentyFifteen.Day1Part1(input).ToString(),
                            2 => TwentyFifteen.Day1Part2(input).ToString()
                        },
                        2 => part switch
                        {
                            1 => TwentyFifteen.Day2Part1(input).ToString(),
                            2 => TwentyFifteen.Day2Part2(input).ToString()
                        },
                        3 => part switch
                        {
                            1 => TwentyFifteen.Day3Part1(input).ToString(),
                            2 => TwentyFifteen.Day3Part2(input).ToString()
                        },
                        4 => part switch
                        {
                            1 => TwentyFifteen.Day4Part1(input).ToString(),
                            2 => TwentyFifteen.Day4Part2(input).ToString()
                        },
                        5 => part switch
                        {
                            1 => TwentyFifteen.Day5Part1(input).ToString(),
                            2 => TwentyFifteen.Day5Part2(input).ToString()
                        },
                        6 => part switch
                        {
                            1 => TwentyFifteen.Day6Part1(input).ToString(),
                            2 => TwentyFifteen.Day6Part2(input).ToString()
                        },
                        7 => part switch
                        {
                            1 => TwentyFifteen.Day7Part1(input).ToString(),
                            2 => TwentyFifteen.Day7Part2(input).ToString()
                        },
                        8 => part switch
                        {
                            1 => TwentyFifteen.Day8Part1(input).ToString(),
                            2 => TwentyFifteen.Day8Part2(input).ToString()
                        },
                        9 => part switch
                        {
                            1 => TwentyFifteen.Day9Part1(input).ToString(),
                            2 => TwentyFifteen.Day9Part2(input).ToString()
                        },
                        10 => part switch
                        {
                            1 => TwentyFifteen.Day10Part1(input).ToString(),
                            2 => TwentyFifteen.Day10Part2(input).ToString()
                        },
                        11 => part switch
                        {
                            1 => TwentyFifteen.Day11Part1(input).ToString(),
                            2 => TwentyFifteen.Day11Part2(input).ToString()
                        },
                        12 => part switch
                        {
                            1 => TwentyFifteen.Day12Part1(input).ToString(),
                            2 => TwentyFifteen.Day12Part2(input).ToString()
                        },
                        13 => part switch
                        {
                            1 => TwentyFifteen.Day13Part1(input).ToString(),
                            2 => TwentyFifteen.Day13Part2(input).ToString()
                        },
                        14 => part switch
                        {
                            1 => TwentyFifteen.Day14Part1(input).ToString(),
                            2 => TwentyFifteen.Day14Part2(input).ToString()
                        },
                        15 => part switch
                        {
                            1 => TwentyFifteen.Day15Part1(input).ToString(),
                            2 => TwentyFifteen.Day15Part2(input).ToString()
                        },
                        16 => part switch
                        {
                            1 => TwentyFifteen.Day16Part1(input).ToString(),
                            2 => TwentyFifteen.Day16Part2(input).ToString()
                        },
                        17 => part switch
                        {
                            1 => TwentyFifteen.Day17Part1(input).ToString(),
                            2 => TwentyFifteen.Day17Part2(input).ToString()
                        },
                        18 => part switch
                        {
                            1 => TwentyFifteen.Day18Part1(input).ToString(),
                            2 => TwentyFifteen.Day18Part2(input).ToString()
                        },
                        19 => part switch
                        {
                            1 => TwentyFifteen.Day19Part1(input).ToString(),
                            2 => TwentyFifteen.Day19Part2(input).ToString()
                        },
                        20 => part switch
                        {
                            1 => TwentyFifteen.Day20Part1(input).ToString(),
                            2 => TwentyFifteen.Day20Part2(input).ToString()
                        },
                        21 => part switch
                        {
                            1 => TwentyFifteen.Day21Part1(input).ToString(),
                            2 => TwentyFifteen.Day21Part2(input).ToString()
                        },
                        22 => part switch
                        {
                            1 => TwentyFifteen.Day22Part1(input).ToString(),
                            2 => TwentyFifteen.Day22Part2(input).ToString()
                        },
                        23 => part switch
                        {
                            1 => TwentyFifteen.Day23Part1(input).ToString(),
                            2 => TwentyFifteen.Day23Part2(input).ToString()
                        },
                        24 => part switch
                        {
                            1 => TwentyFifteen.Day24Part1(input).ToString(),
                            2 => TwentyFifteen.Day24Part2(input).ToString()
                        },
                        25 => part switch
                        {
                            1 => TwentyFifteen.Day25Part1(input).ToString(),
                            2 => TwentyFifteen.Day25Part2(input).ToString()
                        }
                    };
            }
            return "invalid parameters";
        }
    }
    #pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
}
