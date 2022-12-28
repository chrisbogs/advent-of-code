using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Models;
using AdventOfCodeShared.Models.Geometry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using static AdventOfCodeShared.Logic.Helpers;

namespace AdventOfCodeShared.Logic
{
    public class TwentyTwentyTwo
    {
        public static long Day1Part1(string[] input)
        {
            List<long> calories = SumContiguousLines(input);
            return calories.Max();
        }

        public static long Day1Part2(string[] input)
        {
            List<long> calories = SumContiguousLines(input);
            return calories.OrderByDescending(x => x).Take(3).Sum();
        }

        public static long Day2Part1(string[] input)
        {
            var lines = input.Select(x => x.Split(' ')).ToList();
            var totalScore = 0;
            foreach (var line in lines)
            {
                totalScore += RunRockPaperScissorsRound(line);
            }

            return totalScore;
        }

        public static long Day2Part2(string[] input)
        {
            var lines = input.Select(x => x.Split(' ')).ToList();
            var totalScore = 0;

            foreach (var line in lines)
            {
                var shapes = Array.Empty<string>();
                // calculate which shape to use
                var opponentShape = line[0][0];
                var outcome = line[1][0];
                switch (outcome)
                {
                    case 'X': //lose
                        switch ((OpponentShape)opponentShape)
                        {
                            case OpponentShape.Rock:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Scissors}" }; break;
                            case OpponentShape.Paper:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Rock}" }; break;
                            case OpponentShape.Scissors:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Paper}" }; break;
                        }
                        break;
                    case 'Y': //tie
                        switch ((OpponentShape)opponentShape)
                        {
                            case OpponentShape.Rock:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Rock}" }; break;
                            case OpponentShape.Paper:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Paper}" }; break;
                            case OpponentShape.Scissors:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Scissors}" }; break;
                        }
                        break;
                    case 'Z': //win
                        switch ((OpponentShape)opponentShape)
                        {
                            case OpponentShape.Rock:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Paper}" }; break;
                            case OpponentShape.Paper:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Scissors}" }; break;
                            case OpponentShape.Scissors:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Rock}" }; break;
                        }
                        break;
                }
                totalScore += RunRockPaperScissorsRound(shapes);
            }

            return totalScore;
        }

        // Maps an integer value to each upper and lowercase letter.
        private static readonly Dictionary<char, int> priorityMap = new()
        {
            { 'a', 1 },
            { 'b', 2 },
            { 'c', 3 },
            { 'd', 4 },
            { 'e', 5 },
            { 'f', 6 },
            { 'g', 7 },
            { 'h', 8 },
            { 'i', 9 },
            { 'j', 10 },
            { 'k', 11 },
            { 'l', 12 },
            { 'm', 13 },
            { 'n', 14 },
            { 'o', 15 },
            { 'p', 16 },
            { 'q', 17 },
            { 'r', 18 },
            { 's', 19 },
            { 't', 20 },
            { 'u', 21 },
            { 'v', 22 },
            { 'w', 23 },
            { 'x', 24 },
            { 'y', 25 },
            { 'z', 26 },
            { 'A', 27 },
            { 'B', 28 },
            { 'C', 29 },
            { 'D', 30 },
            { 'E', 31 },
            { 'F', 32 },
            { 'G', 33 },
            { 'H', 34 },
            { 'I', 35 },
            { 'J', 36 },
            { 'K', 37 },
            { 'L', 38 },
            { 'M', 39 },
            { 'N', 40 },
            { 'O', 41 },
            { 'P', 42 },
            { 'Q', 43 },
            { 'R', 44 },
            { 'S', 45 },
            { 'T', 46 },
            { 'U', 47 },
            { 'V', 48 },
            { 'W', 49 },
            { 'X', 50 },
            { 'Y', 51 },
            { 'Z', 52 }
        };
        public static long Day3Part1(string[] input)
        {
            var sum = 0;
            foreach (var line in input)
            {
                // for each bag divide the line into 2 "pockets" of items
                var midIndex = (int)Math.Floor(line.Length / 2.0);
                var firstPocketItems = line[0..midIndex];
                var secondPocketItems = line[midIndex..^0];
                var sharedLetter = firstPocketItems.Intersect(secondPocketItems).FirstOrDefault();
                var priority = priorityMap[sharedLetter];
                sum += priority;
            }
            return sum;
        }
        public static long Day3Part2(string[] input)
        {
            var sum = 0;
            for (int i = 0; i < input.Length - 2; i += 3)
            {
                var first = input[i];
                var second = input[i + 1];
                var third = input[i + 2];
                var sharedLetter = first.Intersect(second).Intersect(third).FirstOrDefault();
                var priority = priorityMap[sharedLetter];
                sum += priority;
            }
            return sum;
        }

        public static long Day4Part1(string[] input)
        {
            var sum = 0;
            foreach (var line in input)
            {
                var parts = line.Split(',');
                var set1 = parts[0].Split('-').Select(long.Parse).Take(2).ToList();
                var set2 = parts[1].Split('-').Select(long.Parse).Take(2).ToList();
                // check if one group of integers is fully contained in the second set
                if (set1.FullyContains(set2) || set2.FullyContains(set1))
                {
                    sum++;
                }
            }
            return sum;
        }


        public static long Day4Part2(string[] input)
        {
            var sum = 0;
            foreach (var line in input)
            {
                var parts = line.Split(',');
                var set1 = parts[0].Split('-').Select(long.Parse).Take(2).ToList();
                var set2 = parts[1].Split('-').Select(long.Parse).Take(2).ToList();
                // check if one group of integers is fully contained in the second set
                if (set1.Hasintersection(set2) || set2.Hasintersection(set1))
                {
                    sum++;
                }
            }
            return sum;
        }

        public static string Day5Part1(string[] input)
        {
            ParseStacks(input, out List<Stack<char>> stacks, out List<Tuple<int, int, int>> instructions);

            if (!stacks.Any() || !instructions.Any()) return "";

            // execute instructions
            foreach (var (count, sourceColumn, destColumn) in instructions)
            {
                for (var i = 0; i < count; i++)
                {
                    if (stacks[sourceColumn - 1].Count > 0)
                    {
                        var itemBeingMoved = stacks[sourceColumn - 1].Pop();
                        stacks[destColumn - 1].Push(itemBeingMoved);
                    }
                }
            }

            return string.Join("", stacks.Where(x => x.Count > 0).Select(x => x.Pop()));
        }
        public static string Day5Part2(string[] input)
        {
            ParseStacks(input, out List<Stack<char>> stacks, out List<Tuple<int, int, int>> instructions);

            if (!stacks.Any() || !instructions.Any()) return "";

            // execute instructions
            foreach (var (count, sourceColumn, destColumn) in instructions)
            {
                var itemsBeingMoved = new List<char>();
                for (var i = 0; i < count; i++)
                {
                    if (stacks[sourceColumn - 1].Count > 0)
                    {
                        itemsBeingMoved.Add(stacks[sourceColumn - 1].Pop());
                    }
                }
                itemsBeingMoved.Reverse();
                itemsBeingMoved.ForEach(x => stacks[destColumn - 1].Push(x));
            }

            return string.Join("", stacks.Where(x => x.Count > 0).Select(x => x.Pop()));
        }

        public static long Day6Part1(string[] input)
        {
            var dataStream = input[0];
            return FindFirstDistinctSubString(dataStream, 4);
        }
        public static long Day6Part2(string[] input)
        {
            var dataStream = input[0];
            return FindFirstDistinctSubString(dataStream, 14);
        }

        public static long Day7Part1(string[] input)
        {
            DirectoryNode<string> root = ParseTerminalInput(input);
            var files = root.FindAllChildrenLessThan(100000);
            return files.Sum(x => x.Size);
        }
        public static long Day7Part2(string[] input)
        {
            const int availableSpace = 70_000_000;
            const int spaceNeeded = 30_000_000;
            DirectoryNode<string> root = ParseTerminalInput(input);

            var unUsedSpace = availableSpace - root.Size;
            if (unUsedSpace > spaceNeeded)
            {
                return 0;
            }

            var files = root.FindAllChildrenGreaterThan(spaceNeeded - unUsedSpace);
            return files?.Min(x => x.Size) ?? 0;
        }

        public static long Day8Part1(string[] input)
        {
            //parse grid based on lines of single digit integers
            var grid = new List<List<int>>();
            foreach (var line in input)
            {
                var ints = line.Select(x => int.Parse(x.ToString())).ToList();
                grid.Add(ints);
            }

            var visibleCount = 0;
            for (int j = 0; j < grid.Count; j++)
            {
                for (int k = 0; k < grid[j].Count; k++)
                {
                    if (IsVisible(grid, j, k))
                    {
                        visibleCount++;
                    }
                }
            }

            return visibleCount;
        }

        public static long Day8Part2(string[] input)
        {
            //parse grid based on lines of single digit integers
            var grid = new List<List<int>>();
            foreach (var line in input)
            {
                var ints = line.Select(x => int.Parse(x.ToString())).ToList();
                grid.Add(ints);
            }

            int maxScore = DetermineScore(grid);
            return maxScore;
        }

        public static long Day9Part1(string[] input)
        {
            var directions = Parsing.ParseDirections(input);
            List<Point> tailPath = MoveRopeAndTrackPath(directions, 2);
            return tailPath.Distinct().Count();
        }
        public static long Day9Part2(string[] input)
        {
            var directions = Parsing.ParseDirections(input);
            List<Point> tailPath = MoveRopeAndTrackPath(directions, 10);
            return tailPath.Distinct().Count();
        }

        public static long Day10Part1(string[] input)
        {
            var instructions = CommunicationSystemComputer.ParseInstructions(input);
            //Find the signal strength during the 20th, 60th, 100th, 140th, 180th, and 220th cycles. What is the sum of these six signal strengths ?
            var comp = new CommunicationSystemComputer();
            comp.Run(instructions);
            return comp.CombinedSignalStrengths;
        }
        public static long Day10Part2(string[] input)
        {
            var instructions = CommunicationSystemComputer.ParseInstructions(input);
            var comp = new CommunicationSystemComputer();
            comp.Run(instructions, draw: true);
            comp.PrintScreen();
            return 0;
        }
        public static long Day11Part1(string[] input)
        {
            var monkeys = Monkey.ParseMonkeyInTheMiddle(input);

            for (int i = 0; i < 20; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.TakeTurn(ref monkeys);
                }
            }
            return monkeys
                .Select(x => x.NumberOfInspections)
                .OrderByDescending(x => x)
                .Take(2)
                .Aggregate((x, y) => x * y);
        }
        public static long Day11Part2(string[] input, int rounds = 10000)
        {
            //TODO: not complete overflow error
            var monkeys = Monkey.ParseMonkeyInTheMiddle(input);

            for (int i = 0; i < rounds; i++)
            {
                foreach (var monkey in monkeys)
                {
                    monkey.TakeTurn(ref monkeys, false);
                }
            }
            return monkeys
                .Select(x => x.NumberOfInspections)
                .OrderByDescending(x => x)
                .Take(2)
                .Aggregate((x, y) => x * y);
        }

        public static int Day12Part1(string[] input)
        {
            input = new string[] {
                "Sabqponm",
                "abcryxxl",
                "accszExk",
                "acctuvwj",
                "abdefghi"};
            // where a is the lowest elevation, b is the next - lowest, and so on up to the highest elevation, z.
            var grid = Grid<char>.ParseGridOfLettersIntoNodes(input);
            //Also included on the heightmap are marks for your current position(S) and the location that should get the best signal(E).
            var startAndEnd = FindStartAndEndPosition(grid);

            //Your current position(S) has elevation a, and the location that should get the best signal(E) has elevation z.

            var path = Grid<char>.FindPath(grid, startAndEnd.Item1, startAndEnd.Item2);
            //You'd like to reach E, but to save energy, you should do it in as few steps as possible.
            return path.Item2.Count-1;
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