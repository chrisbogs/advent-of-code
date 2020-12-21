using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCodeShared;
using AdventOfCodeShared.Extensions;
using Microsoft.AspNetCore.Mvc;
namespace Server
{

    [Route("[controller]")]
    [ApiController]
    public class Day2Controller : Controller
    {
        public Day2Controller()
        {
        }

        [HttpGet("2")]
        public int Part1(string? filePath = null)
        {
            filePath ??= "../shared/PuzzleInput/input2.txt";
            var passwordsWithRules = filePath.ReadFile().ParsePasswords();
            return passwordsWithRules.Count(x=>x.IsValidv1());
        }

        [HttpGet("2")]
        public int Part2(string? filePath = null)
        {
            filePath ??= "../shared/PuzzleInput/input2.txt";
            var passwordsWithRules = filePath.ReadFile().ParsePasswords();
            return passwordsWithRules.Count(x=>x.IsValidv2());

        }


    }
}
