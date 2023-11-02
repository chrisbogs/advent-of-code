using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Logic
{
    public class TwentyTwentyOne
    {
        public static long Day1Part1(string[] input)
        {
            var numbers = input.ParseIntsOnePerLine();
            return Helpers.CountIncreases(numbers.ToList());
        }
        public static long Day1Part2(string[] input)
        {
            var numbers = input.ParseIntsOnePerLine();
            return Helpers.CountIncreasesInThreeMeasurementWindow(numbers.ToList());
        }

        public static long Day2Part1(string[] input)
        {
            var sub = new Submarine();
            var commands = sub.ParseCommands(input);
            sub.MovePart1(commands);
            return sub.CurrentPositionHash;
        }
        public static long Day2Part2(string[] input)
        {
            var sub = new Submarine();
            var commands = sub.ParseCommands(input);
            sub.Move(commands);
            return sub.CurrentPositionHash;
        }

        public static long Day3Part1(string[] input)
        {
            var d = new Diagnostic();
            d.Read(input);
            return d.PowerConsumption;
        }
        public static long Day3Part2(string[] input)
        {
            var d = new Diagnostic();
            d.Read(input);
            return d.LifeSupportRating;
        }

        public static string Day4Part1(string[] input)
        {
            var result = Bingo.ParseInput(input);
            return Bingo.RunBingo(result.NumbersCalled,
                result.BingoCards,
                true);
        }
        public static string Day4Part2(string[] input)
        {
            var result = Bingo.ParseInput(input);
            return Bingo.RunBingo(result.NumbersCalled,
                result.BingoCards,
                false);
        }

        public static long Day5Part1(string[] input)
        {
            //// read in the start point and end points
            //var lines: Line[] = Line.ParseLines(input);
            //const map: number[][] = Line.BuildCountOfPoints(lines);

            //// determine the number of points 
            //// where at least two lines overlap
            //var count = 0;
            //for (var x of map)
            //{
            //    for (var c of x)
            //    {
            //        if ((c) >= 2)
            //        {
            //            count++;
            //        }
            //    }
            //}

            //return count.toString();
            return 0;
        }
        public static long Day5Part2(string[] input)
        {
            // public static (int, int) Run(string[] input)
            // {
            //     var vents = input
            //         .Select(x => line.FromString(x))
            //         .ToArray();

            //     var straightVents = vents
            //         .Where(line => line.IsStraight)
            //         .ToArray();

            //     int overlaps(line[] lines) => lines
            //         .SelectMany(vent => vent.points)
            //         .GroupBy(point => point)
            //         .Where(group => group.Count() >= 2)
            //         .Count();

            //     return (overlaps(straightVents), overlaps(vents));
            // }

            // record coord
            // {
            //     public int X;
            //     public int Y;
            //     public coord(int x, int y) { X = x; Y = y; }
            //     public static coord FromString(string coord)
            //     {
            //         var parts = coord.Split(',');
            //         return new coord(Convert.ToInt32(parts[0]), Convert.ToInt32(parts[1]));
            //     }
            // };

            // record line
            // {
            //     public coord start;
            //     public coord end;
            //     public coord[] points;

            //     public bool IsStraight => start.X == end.X || start.Y == end.Y;

            //     static IEnumerable<int> range(int a, int b) => (a == b)
            //         ? Enumerable.Repeat(a, int.MaxValue)
            //         : (a < b) ? Enumerable.Range(a, Math.Abs(a - b) + 1) : Enumerable.Range(b, Math.Abs(a - b) + 1).Reverse();

            //     public static line FromString(string input)
            //     {
            //         var parts = input.Split(" -> ");
            //         var start = coord.FromString(parts[0]);
            //         var end = coord.FromString(parts[1]);

            //         var points = range(start.X, end.X)
            //             .Zip(range(start.Y, end.Y))
            //             .Select(zip => new coord(zip.First, zip.Second))
            //             .ToArray();

            //         return new line()
            //         {
            //             start = start,
            //             end = end,
            //             points = points
            //         };
            //     }
            // }

            //// read in the start point and end points
            //var lines: Line[] = Line.ParseLines(input, true);
            //const map: number[][] = Line.BuildCountOfPoints(lines);

            //// determine the number of points 
            //// where at least two lines overlap
            //var count = 0;
            //for (var x of map)
            //{
            //    for (var c of x)
            //    {
            //        if ((c) >= 2)
            //        {
            //            count++;
            //        }
            //    }
            //}

            //return count.toString();
            return 0;
        }

        public static string Day6Part1(string[] input, int daysToSimulate=80)
        {
            var allFish = input[0].Split(',').Select(age => int.Parse(age));
            var result = Helpers.SimulateFish(daysToSimulate, allFish);
            return result.ToString();
        }
        public static string Day6Part2(string[] input, int daysToSimulate = 256)
        {
            var allFish = input[0].Split(',').Select(age => int.Parse(age));
            var result = Helpers.SimulateFish(daysToSimulate, allFish);
            return result.ToString();
        }

        public static string Day7Part1(string[] input)
        {
            var crabs = input[0].Split(',').Select(x => int.Parse(x));
            var lowestFuelCost = int.MaxValue;

            var min = crabs.Min();
            var max = crabs.Max();
            for (var i = min; i < max; i++)
            {
                // find sum of distance away from origin
                var fuelNeeded = 0;
                foreach(var x in crabs)
                {
                    fuelNeeded += Math.Abs(i - x);
                }
                lowestFuelCost = Math.Min(fuelNeeded, lowestFuelCost);
            }

            return lowestFuelCost.ToString();
        }
        public static string Day7Part2(string[] input)
        {
            var crabs = input[0].Split(',').Select(x => int.Parse(x));
            var lowestFuelCost = int.MaxValue;

            var min = crabs.Min();
            var max = crabs.Max();
            for (var i = min; i < max; i++)
            {
                // find sum of distance away from origin
                var fuelNeeded = 0;
                foreach (var x in crabs)
                {
                    fuelNeeded += Helpers.SumOfSeriesInt(Math.Abs(i - x));
                }
                lowestFuelCost = Math.Min(fuelNeeded, lowestFuelCost);
            }

            return lowestFuelCost.ToString();
        }

        public static string Day8Part1(string[] input)
        {
            var signalPatterns = new List<List<string>>();
            var fourDigitOutputValue = new List<List<string>>();

            foreach (var x in input)
            {
                var s = x.Split(" | ");
                signalPatterns.Add(s[0].Split(' ').ToList());
                fourDigitOutputValue.Add(s[1].Split(' ').ToList());
            }

            // how many times do 1,4,7,8 appear in output?
            // 1=2, 4=4, 7=3, 8=7
            //0=6, 2=5, 3=5, 5=5, 6=6, 9=6
            var total = 0;
            var listOfNums = new List<int> { 2, 4, 3, 7 };
            foreach (var x in fourDigitOutputValue)
            {
                foreach (var y in x)
                {
                    if (listOfNums.Contains(y.Length))
                    {
                        total++;
                    }
                }
            }

            return total.ToString();
        }
        
        public static string Day8Part2(string[] input)
        {
            var signalPatterns = new List<List<string>>();
            var fourDigitOutputValues = new List<List<string>>();

            foreach (var x in input)
            {
                var s = x.Split(" | ");
                signalPatterns.Add(s[0].Split(' ').ToList());
                fourDigitOutputValues.Add(s[1].Split(' ').ToList());
            }

            var segments = new List<DisplayDigits>();
            foreach (var signalPattern in signalPatterns)
            {
                segments.Add(DisplayDigits.DetermineSegments(signalPattern));
            }

            // For each entry, determine all of the wire/segment connections and decode the four-digit output values.
            var result= 0;
            for (int i = 0; i < fourDigitOutputValues.Count; i++)
            {
                var outputValue = fourDigitOutputValues[i];
                var actualDigits = "";
                foreach (var x in outputValue)
                {
                    var sortedOutput = x.ToList().OrderBy(x => x).ToList();
                    actualDigits += segments[i].Lookup(sortedOutput);
                }
                result += int.Parse(actualDigits);
            }

            //  What do you get if you add up all of the output values?
            return result.ToString();
        }

        public static long Day9Part1(string[] input)
        {
            var heightPoints= Grid<int>.ParseIntGrid(input);
            var minPoints = heightPoints.FindMinPoints();
            return minPoints.Aggregate(0, (acc, next)=>acc += next + 1);
        }
        public static long Day9Part2(string[] input)
        {
            var heightPoints = Grid<int>.ParseIntGrid(input);
            var basins = heightPoints.FindBasins();
            var topThree = basins.Take(3).ToList();
            return topThree.Aggregate(1, (acc, next) => acc *= next.Count);
        }

        public static long Day10Part1(string[] input)
        {
            var parser = new SyntaxParser(
                new string[] { "(", "[", "{", "<" },
                new string[] { ")", "]", "}", ">" },
                new int[] { 3, 57, 1197, 25137 });

            parser.ValidateLines(input);
            return parser.GetInvalidTokensScore();
        }
        public static long Day10Part2(string[] input)
        {
            var parser = new SyntaxParser(
                new string[] { "(", "[", "{", "<" },
                new string[] { ")", "]", "}", ">" },
                new int[] { 1, 2, 3, 4 });
            parser.ValidateLines(input);
            return parser.GetAutoCompletedTokensScore();
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