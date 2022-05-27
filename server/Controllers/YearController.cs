using AdventOfCodeShared.Services;
using Microsoft.AspNetCore.Mvc;
namespace Server
{

    [Route("[controller]")]
    [ApiController]
    public class YearController : Controller
    {
        private IInputRetriever inputRetriever;
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
                case 2021:
                    switch (day)
                    {
                        case 5:
                            return TwentyTwentyOne.Day5Part1(input).ToString();
                    }
                    break;
                case 2020:
                    switch (day)
                    {
                        case 1:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day1Part1(input).ToString();
                                case 2:
                                    return TwentyTwenty.Day1Part2(input).ToString();
                            }
                            break;
                        case 2:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day2Part1(input).ToString();
                                case 2:
                                    return TwentyTwenty.Day2Part2(input).ToString();
                            }
                            break;
                        case 3:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day3Part1(input).ToString();
                                case 2:
                                    return TwentyTwenty.Day3Part2(input).ToString();
                            }
                            break;
                        case 4:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day4Part1(input).ToString();
                                case 2:
                                    return TwentyTwenty.Day4Part2(input).ToString();
                            }
                            break;
                        case 5:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day5Part1(input).ToString();
                                case 2:
                                    return TwentyTwenty.Day5Part2(input).ToString();
                            }
                            break;
                        case 6:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day6Part1(input).ToString();
                                case 2:
                                    return TwentyTwenty.Day6Part2(input).ToString();
                            }
                            break;
                    }
                    break;
                case 2019:
                    switch (day)
                    {
                        case 1:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day1Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day1Part2(input).ToString();
                            }
                            break;
                        case 2:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day2Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day2Part2(input).ToString();
                            }
                            break;
                        case 3:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day3Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day3Part2(input).ToString();
                            }
                            break;
                        case 4:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day4Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day4Part2(input).ToString();
                            }
                            break;
                        case 5:
                            switch (part)
                            {
                                case 1:
                                    return string.Join(',', TwentyNineteen.Day5Part1(input));
                                case 2:
                                    return TwentyNineteen.Day5Part2(input)[0].ToString();
                            }
                            break;
                        case 6:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day6Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day6Part2(input).ToString();
                            }
                            break;
                        case 7:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day7Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day7Part2(input).ToString();
                            }
                            break;
                        case 8:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day8Part1(input).ToString();
                                case 2:
                                    TwentyNineteen.Day8Part2(input); return "";
                            }
                            break;
                        case 9:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day9Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day9Part2(input).ToString();
                            }
                            break;
                        case 10:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day10Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day10Part2(input).ToString();
                            }
                            break;
                        case 11:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day11Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day11Part2(input).ToString();
                            }
                            break;
                        case 12:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day12Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day12Part2(input).ToString();
                            }
                            break;
                        case 13:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day13Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day13Part2(input).ToString();
                            }
                            break;
                        case 14:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day14Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day14Part2(input).ToString();
                            }
                            break;
                        case 15:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day15Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day15Part2(input).ToString();
                            }
                            break;
                        case 16:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day16Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day16Part2(input).ToString();
                            }
                            break;
                        case 17:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day17Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day17Part2(input).ToString();
                            }
                            break;
                        case 18:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day18Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day18Part2(input).ToString();
                            }
                            break;
                        case 19:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day19Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day19Part2(input).ToString();
                            }
                            break;
                        case 20:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day20Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day20Part2(input).ToString();
                            }
                            break;
                        case 21:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day21Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day21Part2(input).ToString();
                            }
                            break;
                        case 22:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day22Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day22Part2(input).ToString();
                            }
                            break;
                        case 23:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day23Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day23Part2(input).ToString();
                            }
                            break;
                        case 24:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day24Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day24Part2(input).ToString();
                            }
                            break;
                        case 25:
                            switch (part)
                            {
                                case 1:
                                    return TwentyNineteen.Day25Part1(input).ToString();
                                case 2:
                                    return TwentyNineteen.Day25Part2(input).ToString();
                            }
                            break;
                    }
                    break;
                case 2015:
                    switch (day)
                    {
                        case 1:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day1Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day1Part2(input).ToString();
                            }
                            break;
                        case 2:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day2Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day2Part2(input).ToString();
                            }
                            break;
                        case 3:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day3Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day3Part2(input).ToString();
                            }
                            break;
                        case 4:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day4Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day4Part2(input).ToString();
                            }
                            break;
                        case 5:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day5Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day5Part2(input).ToString();
                            }
                            break;
                        case 6:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day6Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day6Part2(input).ToString();
                            }
                            break;
                        case 7:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day7Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day7Part2(input).ToString();
                            }
                            break;
                        case 8:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day8Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day8Part2(input).ToString();
                            }
                            break;
                        case 9:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day9Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day9Part2(input).ToString();
                            }
                            break;
                        case 10:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day10Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day10Part2(input).ToString();
                            }
                            break;
                        case 11:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day11Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day11Part2(input).ToString();
                            }
                            break;
                        case 12:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day12Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day12Part2(input).ToString();
                            }
                            break;
                        case 13:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day13Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day13Part2(input).ToString();
                            }
                            break;
                        case 14:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day14Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day14Part2(input).ToString();
                            }
                            break;
                        case 15:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day15Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day15Part2(input).ToString();
                            }
                            break;
                        case 16:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day16Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day16Part2(input).ToString();
                            }
                            break;
                        case 17:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day17Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day17Part2(input).ToString();
                            }
                            break;
                        case 18:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day18Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day18Part2(input).ToString();
                            }
                            break;
                        case 19:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day19Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day19Part2(input).ToString();
                            }
                            break;
                        case 20:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day20Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day20Part2(input).ToString();
                            }
                            break;
                        case 21:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day21Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day21Part2(input).ToString();
                            }
                            break;
                        case 22:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day22Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day22Part2(input).ToString();
                            }
                            break;
                        case 23:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day23Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day23Part2(input).ToString();
                            }
                            break;
                        case 24:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day24Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day24Part2(input).ToString();
                            }
                            break;
                        case 25:
                            switch (part)
                            {
                                case 1:
                                    return TwentyFifteen.Day25Part1(input).ToString();
                                case 2:
                                    return TwentyFifteen.Day25Part2(input).ToString();
                            }
                            break;
                    }
                    break;
            }
            return "invalid parameters";
        }



    }
}
