using System;
using System.Linq;
using System.Threading.Tasks;
using AdventOfCodeShared.Extensions;
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
        public int Part1()
        {
            return 0;
        }

        [HttpGet("2")]
        public int Part2()
        {
            return 0;
        }

    }
}
