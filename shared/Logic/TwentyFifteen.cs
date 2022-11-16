using AdventOfCodeShared.Models;
using System.Collections.Generic;
using System.Drawing;

namespace AdventOfCodeShared.Logic
{
    public class TwentyFifteen
    {
        public static int Day1Part1(string[] input)
        {
            return Helpers.WhichFloorDoWeEndUpOn(input[0]);
        }
        public static int Day1Part2(string[] input)
        {
            return Helpers.WhichPositionMovesUsToBasement(input[0]);
        }

        public static int Day2Part1(string[] input)
        {
            var total = 0;
            foreach (var line in input)
            {
                var s = line.Split('x');
                var rp = new RectangularPrism(int.Parse(s[0].ToString()), int.Parse(s[1].ToString()), int.Parse(s[2].ToString()));
                total += rp.SurfaceArea + rp.AreaOfSmallestSide;
            }
            return total;
        }
        public static int Day2Part2(string[] input)
        {
            var total = 0;
            foreach (var line in input)
            {
                var s = line.Split('x');
                var rp = new RectangularPrism(int.Parse(s[0].ToString()), int.Parse(s[1].ToString()), int.Parse(s[2].ToString()));
                total += rp.SmallestPerimeterOfAnyFace + rp.Volume;
            }
            return total;
        }
        public static long Day3Part1(string[] input)
        {
            //keep track of visited coordinates
            var currentLocation = new Point(0, 0);
            var visited = new HashSet<Point>() { currentLocation };
            //assume one line
            foreach (var move in input[0])
            {
                switch (move)
                {
                    case '<':
                        currentLocation.X -= 1;
                        break;
                    case '>':
                        currentLocation.X += 1;
                        break;
                    case 'v':
                        currentLocation.Y -= 1;
                        break;
                    case '^':
                        currentLocation.Y += 1;
                        break;
                }

                if (!visited.Contains(currentLocation))
                {
                    visited.Add(currentLocation);
                }
            }
            return visited.Count;
        }

        public static long Day3Part2(string[] input)
        {
            var currentMover = new Point(0, 0);
            var visited = new HashSet<Point>() { currentMover };

            var robotDirections = new List<char>();
            var santaDirections = new List<char>();
            for (int i = 0; i < input[0].Length; i++)
            {
                if (i % 2 == 0)
                {
                    santaDirections.Add(input[0][i]);
                }
                else
                {
                    robotDirections.Add(input[0][i]);
                }
            }
            SantaPointMover.MovePoint(santaDirections, ref visited);
            SantaPointMover.MovePoint(robotDirections, ref visited);

            return visited.Count;
        }

        public static int Day4Part1(string[] input)
        {
            return 0;
        }

        public static int Day4Part2(string[] input)
        {
            return 0;
        }

        public static int Day5Part1(string[] input)
        {
            return 0;
        }
        public static int Day5Part2(string[] input)
        {
            return 0;
        }

        public static int Day6Part1(string[] input)
        {
            return 0;
        }
        public static int Day6Part2(string[] input)
        {
            return 0;
        }
        public static long Day7Part1(string[] input)
        {
            return 0;
        }
        public static int Day7Part2(string[] input)
        {
            return 0;
        }
        public static int Day8Part1(string[] input)
        {
            return 0;
        }
        public static int Day8Part2(string[] input)
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

        public static int Day10Part1(string[] input)
        {
            return 0;
        }
        public static int Day10Part2(string[] input)
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