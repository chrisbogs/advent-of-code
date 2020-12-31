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
    public class Day3Controller : Controller
    {
        private IInputRetriever inputRetriever;
        private string[] input = new string[] { };
        public Day3Controller(IInputRetriever inputRetriever)
        {
            this.inputRetriever = inputRetriever;
            this.input = this.inputRetriever.GetInput(2020, 3).Result;
        }

        [HttpGet("1")]
        public long Part1()
        {
            var map = new Map(this.input);
            return map.TraverseAndCountTrees(new Toboggan() { Right = 3, Down = 1 });
        }

        [HttpGet("2")]
        public long Part2()
        {
            // calculate how many tree would be hit for all slopes and return the product of those.
            var map = new Map(this.input);
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

    }
}
