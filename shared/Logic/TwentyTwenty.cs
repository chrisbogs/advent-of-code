using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Logic
{
    public class TwentyTwenty
    {
        public static int Day1Part1(string[] input)
        {
            var numbers = input.ParseInts();
            return Helpers.Get2NumbersThatSumUpTo(numbers);
        }
        public static int Day1Part2(string[] input)
        {
            var numbers = input.ParseInts();
            return Helpers.Get3NumbersThatSumUpTo(numbers);
        }

        public static int Day2Part1(string[] input)
        {
            var passwordsWithRules = input.ParsePasswords();
            return passwordsWithRules.Count(x => x.IsValidv1());
        }
        public static int Day2Part2(string[] input)
        {
            var passwordsWithRules = input.ParsePasswords();
            return passwordsWithRules.Count(x => x.IsValidv2());
        }
        public static long Day3Part1(string[] input)
        {
            var map = new Map(input);
            return map.TraverseAndCountTrees(new Toboggan() { Right = 3, Down = 1 });
        }

        public static long Day3Part2(string[] input)
        {
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

        public static int Day4Part1(string[] input)
        {
            return Passport.ParsePassports(input).Count(x => x.IsValid);
        }

        public static int Day4Part2(string[] input)
        {
            return Passport.ParsePassports(input).Count(x => x.IsValid);
        }

        public static long Day5Part1(string[] input)
        {
            return input.Select(x => new BoardingPass(x)).Max(m => m.SeatId);
        }
        public static int Day5Part2(string[] input)
        {
            var seatIds = input.Select(x => new BoardingPass(x).SeatId).OrderBy(x => x);
            var missingSeatIds = Enumerable.Range((int)seatIds.First(), (int)seatIds.Last()).Where(w => !seatIds.Contains(w));
            return missingSeatIds.Where(w => seatIds.Contains(w + 1) && seatIds.Contains(w - 1)).FirstOrDefault();
        }

        public static int Day6Part1(string[] input)
        {
            return CustomsForm.Parse(input).Sum(x => x.UniqueAnswers);
        }
        public static int Day6Part2(string[] input)
        {
            return CustomsForm.Parse(input).Sum(x => x.CommonAnswers);
        }

        public static long Day7Part1(string[] input)
        {
            return 0;
        }
        public static long Day7Part2(string[] input)
        {
            return 0;
        }

        public static long Day8Part1(string[] input)
        {
            return 0;
        }

        public static long Day8Part2(string[] input)
        {
            return 0;
        }

        public static long Day9Part1(string[] input)
        {
            return 0;
        }
        public static long Day9Part2(string[] input)
        {
            return 0;
        }

        public static long Day10Part1(string[] input)
        {
            return 0;
        }
        public static long Day10Part2(string[] input)
        {
            return 0;
        }

        public static int Day11Part1(string[] input)
        {
            return 0;
        }
        public static int Day11Part2(string[] input)
        {
            return 0;
        }

        public static int Day12Part1(string[] input)
        {
            return 0;
        }
        public static int Day12Part2(string[] input)
        {
            return 0;
        }

        public static int Day13Part1(string[] input)
        {
            return 0;
        }
        public static int Day13Part2(string[] input)
        {
            return 0;
        }

        public static int Day14Part1(string[] input)
        {
            return 0;
        }
        public static int Day14Part2(string[] input)
        {
            return 0;
        }

        public static int Day15Part1(string[] input)
        {
            return 0;
        }
        public static int Day15Part2(string[] input)
        {
            return 0;
        }

        public static int Day16Part1(string[] input)
        {
            return 0;
        }
        public static int Day16Part2(string[] input)
        {
            return 0;
        }

        public static int Day17Part1(string[] input)
        {
            return 0;
        }
        public static int Day17Part2(string[] input)
        {
            return 0;
        }

        public static int Day18Part1(string[] input)
        {
            return 0;
        }
        public static int Day18Part2(string[] input)
        {
            return 0;
        }

        public static int Day19Part1(string[] input)
        {
            return 0;
        }
        public static int Day19Part2(string[] input)
        {
            return 0;
        }

        public static int Day20Part1(string[] input)
        {
            return 0;
        }
        public static int Day20Part2(string[] input)
        {
            return 0;
        }

        public static int Day21Part1(string[] input)
        {
            return 0;
        }
        public static int Day21Part2(string[] input)
        {
            return 0;
        }

        public static int Day22Part1(string[] input)
        {
            return 0;
        }
        public static int Day22Part2(string[] input)
        {
            return 0;
        }

        public static int Day23Part1(string[] input)
        {
            return 0;
        }
        public static int Day23Part2(string[] input)
        {
            return 0;
        }

        public static int Day24Part1(string[] input)
        {
            return 0;
        }
        public static int Day24Part2(string[] input)
        {
            return 0;
        }

        public static int Day25Part1(string[] input)
        {
            return 0;
        }
        public static int Day25Part2(string[] input)
        {
            return 0;
        }
    }
}