using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models.Geometry
{
    internal class Parsing
    {
        /// <summary>
        /// Given a string in the format: "R2, L3,...", 
        /// return a list in the format: [("R", 2), ("L", 3)]
        /// </summary>
        public static List<Tuple<DPadDirection, int>> ParseDirections(string[] input)
        {
            return input[0]
                .Split(',')
                .Select(x => x.Trim())
                .Select(x => Tuple.Create((DPadDirection)x[0], int.Parse(x[1..])))
                .ToList();
        }
    }
}
