using AdventOfCodeShared.Models.Geometry;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using AdventOfCodeShared.Models;

namespace AdventOfCodeShared.Logic
{
    public class TwentySixteen
    {
        public static long Day1Part1(string[] input)
        {
            var directions = Parsing.ParseDirections(input);
            var endPoint = Geometry.FollowPath(directions);

            var result = Geometry.CalculateDistanceFromOrigin(endPoint);
            return result;
        }

        public static long Day1Part2(string[] input)
        {
            var directions = Parsing.ParseDirections(input);
            // Find first intersection point
            var loopbackPoint = Geometry.FindFirstLoopBackInPath(directions);
            return Geometry.CalculateDistanceFromOrigin(loopbackPoint);
        }

        public static long Day2Part1(string[] input)
        {
            Dictionary<Point, int> keyPadMap = new()
            {
                { new Point(-1,1), 1 },
                { new Point(0,1), 2 },
                { new Point(1,1), 3 },
                { new Point(-1,0), 4 },
                { new Point(0,0), 5 },
                { new Point(1,0), 6 },
                { new Point(-1,-1), 7 },
                { new Point(0,-1), 8 },
                { new Point(1,-1), 9 }
            };

            var points = new List<Point>();
            var startingPoint = new Point(0,0);
            foreach (var line in input)
            {
                //Alternative: Could optimize this by grouping letters together and using the first method
                //var groups = line.GroupBy(x => (DPadDirection)x);
                //var directions = groups.Select(x => Tuple.Create(x.Key, x.Count())).ToList();
                //points.Add(Geometry.FollowPath(directions));

                startingPoint = Geometry.FollowPathByMovingOneUnitAtATime(
                    startingPoint, 
                    line.Select(x => (DPadDirection)x),
                    keyPadMap.Keys);
                points.Add(startingPoint);
            }

            return int.Parse(string.Join("", points.Select(x => keyPadMap[x])));
        }
        public static string Day2Part2(string[] input)
        {
            Dictionary<Point, char> keyPadMap = new()
            {
                { new Point(0,0), '5' },
                { new Point(1,0), '6' },
                { new Point(2,0), '7' },
                { new Point(3,0), '8' },
                { new Point(4,0), '9' },

                { new Point(1,1), '2' },
                { new Point(2,1), '3' },
                { new Point(3,1), '4' },

                { new Point(2,2), '1' },
                
                { new Point(1,-1), 'A' },
                { new Point(2,-1), 'B' },
                { new Point(3,-1), 'C' },
                
                { new Point(2,-2), 'D' }
            };

            var points = new List<Point>();
            var startingPoint = new Point(0, 0);
            foreach (var line in input)
            {
                startingPoint = Geometry.FollowPathByMovingOneUnitAtATime(
                    startingPoint, 
                    line.Select(x => (DPadDirection)x),
                    keyPadMap.Keys);
                points.Add(startingPoint);
            }

            return string.Join("", points.Select(x => keyPadMap[x]));
        }

        public static long Day3Part1(string[] input)
        {
            return 0;
        }
        public static long Day3Part2(string[] input)
        {
            return 0;
        }

        public static long Day4Part1(string[] input)
        {
            return 0;
        }
        public static long Day4Part2(string[] input)
        {
            return 0;
        }

        public static long Day5Part1(string[] input)
        {
            return 0;
        }
        public static long Day5Part2(string[] input)
        {
            return 0;
        }

        public static long Day6Part1(string[] input)
        {
            return 0;
        }
        public static long Day6Part2(string[] input)
        {
            return 0;
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