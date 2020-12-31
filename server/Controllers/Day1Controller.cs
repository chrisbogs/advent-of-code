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
    }
}
