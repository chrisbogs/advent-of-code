using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AdventOfCodeShared.Extensions;

namespace Server
{

    [Route("[controller]")]
    [ApiController]
    public class Day1Controller : Controller
    {
        public Day1Controller()
        {
        }

        [HttpGet("1")]
        public int Part1(string? filePath = null)
        {
            filePath ??= "../shared/PuzzleInput/input1-1.txt";
            var numbers = filePath.ReadFile().ParseInts();
            return Get2NumbersThatSumUpTo(numbers);
        }

        // TODO: make this a generate algorithm to gather the permutations of the `numbers` collection
        public static int Get2NumbersThatSumUpTo(IEnumerable<int> numbers)
        {
            var length = numbers.Count();
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    if (i != j && numbers.ElementAt(i) + numbers.ElementAt(j) == 2020)
                    {
                        return numbers.ElementAt(i) * numbers.ElementAt(j);
                    }
                }
            }

            return -1;
        }

        // TODO: make this a generate algorithm to gather the permutations of the `numbers` collection
        public static int Get3NumbersThatSumUpTo(IEnumerable<int> numbers)
        {
            var length = numbers.Count();
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    for (var k = 0; k < length; k++)
                    {
                        if (i != j && j != k && numbers.ElementAt(i) + numbers.ElementAt(j) + numbers.ElementAt(k) == 2020)
                        {
                            return numbers.ElementAt(i) * numbers.ElementAt(j) * numbers.ElementAt(k);
                        }
                    }
                }
            }

            return -1;
        }

        [HttpGet("2")]
        public int Part2(string? filePath = null)
        {
            filePath ??= "../shared/PuzzleInput/input1-1.txt";
            var numbers = filePath?.ReadFile()?.ParseInts() ?? Enumerable.Empty<int>();
            return Get3NumbersThatSumUpTo(numbers);
        }
    }
}
