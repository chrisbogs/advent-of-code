using System.Linq;
using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Services;
using Microsoft.AspNetCore.Mvc;
namespace Server
{
    [Route("[controller]")]
    [ApiController]
    public class Day2Controller : Controller
    {
        private IInputRetriever inputRetriever;
        private string[] input = new string[] { };
        public Day2Controller(IInputRetriever inputRetriever)
        {
            this.inputRetriever = inputRetriever;
            this.input = this.inputRetriever.GetInput(2020, 2).Result;
        }

        [HttpGet("1")]
        public int Part1()
        {
            var passwordsWithRules = this.input.ParsePasswords();
            return passwordsWithRules.Count(x=>x.IsValidv1());
        }

        [HttpGet("2")]
        public int Part2()
        {
            var passwordsWithRules = this.input.ParsePasswords();
            return passwordsWithRules.Count(x=>x.IsValidv2());

        }
    }
}
