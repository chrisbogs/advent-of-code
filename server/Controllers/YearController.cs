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
        public long Router(int year, int day, int part)
        {
            var input = this.inputRetriever.GetInput(year, day).Result;
            switch (year)
            {
                case 2020:
                    switch (day)
                    {
                        case 1:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day1Part1(input);
                                case 2:
                                    return TwentyTwenty.Day1Part2(input);
                            }
                            break;
                        case 2:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day2Part1(input);
                                case 2:
                                    return TwentyTwenty.Day2Part2(input);
                            }
                            break;
                        case 3:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day3Part1(input);
                                case 2:
                                    return TwentyTwenty.Day3Part2(input);
                            }
                            break;
                        case 4:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day4Part1(input);
                                case 2:
                                    return TwentyTwenty.Day4Part2(input);
                            }
                            break;
                        case 5:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day5Part1(input);
                                case 2:
                                    return TwentyTwenty.Day5Part2(input);
                            }
                            break;
                        case 6:
                            switch (part)
                            {
                                case 1:
                                    return TwentyTwenty.Day6Part1(input);
                                case 2:
                                    return TwentyTwenty.Day6Part2(input);
                            }
                            break;
                    }
                    break;
            }
            return 0;
        }



    }
}
