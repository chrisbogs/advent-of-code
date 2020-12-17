using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCodeShared;
using Microsoft.AspNetCore.Mvc;
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
        public int Day1Part1(string? filePath = null)
        {
            filePath ??= "../shared/PuzzleInput/input1-1.txt";
            var numbers = ParseInts(ReadFile(filePath));
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
        public int Day1Part2(string? filePath = null)
        {
            var numbers = ParseInts(ReadFile(filePath));
            return Get3NumbersThatSumUpTo(numbers);
        }

        private static string[] ReadFile(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath);
        }
        private static IEnumerable<int> ParseInts(string[] s)
        {
            var splitContents = new List<string>(s);
            return splitContents.Where(w => int.TryParse(w, out _)).Select(x => int.Parse(x));
        }

    }
}
