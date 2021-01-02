using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Models;
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

        [HttpGet("{year:int}/1/1")]
        public int Day1Part1(int year)
        {
            var input = this.inputRetriever.GetInput(year, 1).Result;
            var numbers = input.ParseInts();
            return Helpers.Get2NumbersThatSumUpTo(numbers);
        }
        [HttpGet("{year:int}/1/2")]
        public int Day1Part2(int year)
        {
            var input = this.inputRetriever.GetInput(year, 1).Result;
            var numbers = input.ParseInts();
            return Helpers.Get3NumbersThatSumUpTo(numbers);
        }

        [HttpGet("{year:int}/2/1")]
        public int Day2Part1(int year)
        {
            var input = this.inputRetriever.GetInput(year, 2).Result;
            var passwordsWithRules = input.ParsePasswords();
            return passwordsWithRules.Count(x => x.IsValidv1());
        }
        [HttpGet("{year:int}/2/2")]
        public int Day2Part2(int year)
        {
            var input = this.inputRetriever.GetInput(year, 2).Result;
            var passwordsWithRules = input.ParsePasswords();
            return passwordsWithRules.Count(x => x.IsValidv2());
        }
        [HttpGet("{year:int}/3/1")]
        public long Day3Part1(int year)
        {
            var input = this.inputRetriever.GetInput(year, 3).Result;
            var map = new Map(input);
            return map.TraverseAndCountTrees(new Toboggan() { Right = 3, Down = 1 });
        }

        [HttpGet("{year:int}/3/2")]
        public long Day3Part2(int year)
        {
            var input = this.inputRetriever.GetInput(year, 3).Result;
            // calculate how many tree would be hit for all slopes and return the product of those.
            var map = new Map(input);
            return new List<Toboggan>(){
                new Toboggan(){Right=1, Down=1},
                new Toboggan(){Right=3, Down=1},
                new Toboggan(){Right=5, Down=1},
                new Toboggan(){Right=7, Down=1},
                new Toboggan(){Right=1, Down=2}
            }
            .Select(s => map.TraverseAndCountTrees(s))
            .Aggregate((a, b) => a * b);
        }

        [HttpGet("{year:int}/4/1")]
        public int Day4Part1(int year)
        {
            var input = this.inputRetriever.GetInput(year, 4).Result;
            return Passport.ParsePassports(input).Count(x=>x.IsValid);
        }

        // [HttpGet("{year:int}/4/2")]
        // public long Day4Part2(int year)
        // {
        //     var input = this.inputRetriever.GetInput(year, 4).Result;

        // }

    }
}
