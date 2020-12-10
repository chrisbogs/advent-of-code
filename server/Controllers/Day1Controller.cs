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

            for (var i = 0; i < numbers.Count(); i++)
            {
                for (var j = 0; j < numbers.Count(); j++)
                {
                    if (i != j && numbers.ElementAt(i) + numbers.ElementAt(j) == 2020)
                    {
                        return i*j;
                    }
                }
            }

            return -1;
        }


        [HttpGet("2")]
        public int Day1Part2()
        {
            return 2;
        }

        private static string[] ReadFile(string filePath)
        {
            return System.IO.File.ReadAllLines(filePath);
        }
        private static IEnumerable<int> ParseInts(string[] s)
        {
            var splitContents = new List<string>(s);
            return splitContents.Where(w=>int.TryParse(w, out _)).Select(x => int.Parse(x));
        }

    }
}
