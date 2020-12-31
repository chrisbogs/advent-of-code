using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Services;

namespace Server
{

    [Route("[controller]")]
    [ApiController]
    public class Day1Controller : Controller
    {
        private IInputRetriever inputRetriever;
        private string[] input = new string[] { };
        private const int magicNumber = 2020;
        public Day1Controller(IInputRetriever inputRetriever)
        {
            this.inputRetriever = inputRetriever;
            this.input = this.inputRetriever.GetInput(2020, 1).Result;
        }

        [HttpGet("1")]
        public int Part1()
        {
            var numbers = this.input.ParseInts();
            return Get2NumbersThatSumUpTo(numbers);
        }
        [HttpGet("2")]
        public int Part2()
        {
            var numbers = this.input.ParseInts();
            return Get3NumbersThatSumUpTo(numbers);
        }

        // TODO: make this a generate algorithm to gather the permutations of the `numbers` collection
        public static int Get2NumbersThatSumUpTo(IEnumerable<int> numbers)
        {
            var l = numbers.Where(x => x <= magicNumber).OrderBy(x => x).ToList();
            var length = l.Count();
            for (var i = 0; i < length; i++)
            {
                var startIndex = 0;
                if (l[i] - magicNumber >= l[i])
                {
                    startIndex = i;
                }

                for (var j = startIndex; j < length; j++)
                {
                    if (i != j && l[i] + l[j] == magicNumber)
                    {
                        return l[i] * l[j];
                    }
                }
            }

            return -1;
        }

        // TODO: make this a generate algorithm to gather the permutations of the `numbers` collection
        public static int Get3NumbersThatSumUpTo(IEnumerable<int> numbers)
        {
            var l = numbers.Where(x => x <= magicNumber).OrderBy(x => x).ToList();
            var length = l.Count();
            for (var i = 0; i < length; i++)
            {
                var startIndex = 0;
                if (l[i] - magicNumber >= l[i])
                {
                    startIndex = i;
                }
                for (var j = startIndex; j < length; j++)
                {
                    var startIndex2 = 0;
                    if (l[i] + l[j] - magicNumber >= l[j])
                    {
                        startIndex2 = i;
                    }
                    for (var k = startIndex2; k < length; k++)
                    {
                        if (i != j && j != k && l[i] + l[j] + l[k] == magicNumber)
                        {
                            return l[i] * l[j] * l[k];
                        }
                    }
                }
            }

            return -1;
        }
    }
}
