using AdventOfCodeShared.Models;
using AdventOfCodeShared.Models.Geometry;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using static AdventOfCodeShared.Logic.TwentyTwentyTwo;
using System.Threading;

namespace AdventOfCodeShared.Logic
{
    public class TwentyTwentyTwo
    {
        public static long Day1Part1(string[] input)
        {
            List<long> calories = Helpers.SumContiguousLines(input);
            return calories.Max();
        }

        public static long Day1Part2(string[] input)
        {
            List<long> calories = Helpers.SumContiguousLines(input);
            return calories.OrderByDescending(x => x).Take(3).Sum();
        }

        public enum OpponentShape
        {
            Rock = 'A',
            Paper = 'B',
            Scissors = 'C'
        }
        public enum PlayerShape
        {
            Rock = 'X',
            Paper = 'Y',
            Scissors = 'Z'
        }
        public enum ShapeScore
        {
            Rock = 1,
            Paper = 2,
            Scissors = 3
        }
        public enum RoundScore
        {
            Lost = 0,
            Draw = 3,
            Win = 6
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
        public static int RunRockPaperScissorsRound(string[] line)
        {
            var opponentLetter = line[0][0];
            var playerLetter = line[1][0];
            var roundScore = 0;
            switch ((OpponentShape)opponentLetter)
            {
                case OpponentShape.Rock:
                    switch ((PlayerShape)playerLetter)
                    {
                        case PlayerShape.Rock:
                            roundScore = (int)RoundScore.Draw + (int)ShapeScore.Rock; break;
                        case PlayerShape.Paper:
                            roundScore = (int)RoundScore.Win + (int)ShapeScore.Paper; break;
                        case PlayerShape.Scissors:
                            roundScore = (int)RoundScore.Lost + (int)ShapeScore.Scissors; break;
                    }
                    break;
                case OpponentShape.Paper:
                    switch ((PlayerShape)playerLetter)
                    {
                        case PlayerShape.Rock:
                            roundScore = (int)RoundScore.Lost + (int)ShapeScore.Rock; break;
                        case PlayerShape.Paper:
                            roundScore = (int)RoundScore.Draw + (int)ShapeScore.Paper; break;
                        case PlayerShape.Scissors:
                            roundScore = (int)RoundScore.Win + (int)ShapeScore.Scissors; break;
                    }
                    break;
                case OpponentShape.Scissors:
                    switch ((PlayerShape)playerLetter)
                    {
                        case PlayerShape.Rock:
                            roundScore = (int)RoundScore.Win + (int)ShapeScore.Rock; break;
                        case PlayerShape.Paper:
                            roundScore = (int)RoundScore.Lost + (int)ShapeScore.Paper; break;
                        case PlayerShape.Scissors:
                            roundScore = (int)RoundScore.Draw + (int)ShapeScore.Scissors; break;
                    }
                    break;
            }
            return roundScore;
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

        private static Dictionary<char, int> priorityMap = new Dictionary<char, int>()
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
                if (FullyContains(set1, set2) || FullyContains(set2, set1))
                {
                    sum++;
                }
            }
            return sum;
        }
        private static bool FullyContains(List<long> set1, List<long> set2)
        {
            if (!set1.Any() || !set2.Any()) return false;

            return set1[0] <= set2[0] && set1[1] >= set2[1];
        }
        private static bool Hasintersection(List<long> set1, List<long> set2)
        {
            if (!set1.Any() || !set2.Any()) return false;

            return
                (set1[0] <= set2[0] && set1[1] >= set2[0])
                || (set1[0] <= set2[1] && set1[1] >= set2[1])
                ;
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
                if (Hasintersection(set1, set2) || Hasintersection(set2, set1))
                {
                    sum++;
                }
            }
            return sum;
        }

        public static string Day5Part1(string[] input)
        {
            List<Stack<char>> stacks;
            List<Tuple<int, int, int>> instructions;
            ParseStacks(input, out stacks, out instructions);

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

        private static void ParseStacks(string[] input, out List<Stack<char>> stacks, out List<Tuple<int, int, int>> instructions)
        {
            bool secondPart = false;
            stacks = new List<Stack<char>>();
            instructions = new();
            foreach (var line in input)
            {
                if (!secondPart && line == string.Empty)
                {
                    secondPart = true;
                }
                if (!secondPart)
                {
                    var parts = line.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToList();
                    if (int.TryParse(parts[0], out int columnNum))
                    {
                        // skip the column # 
                        continue;
                    }
                    else
                    {
                        int stackIndex = 0;
                        // parse the items on the stacks
                        for (int i = 0; i < line.Length - 1; i += 4)
                        {
                            if (stacks.Count - 1 < stackIndex)
                            {
                                stacks.Add(new Stack<char>());
                            }
                            if (line[i + 1] != ' ')
                            {
                                stacks[stackIndex].Push(line[i + 1]);
                            }
                            stackIndex++;
                        }

                    }
                }
                else
                {
                    var parts = line.Split(" ").Where(x => !string.IsNullOrEmpty(x)).ToList();
                    if (parts.Count < 5) continue;
                    instructions.Add(Tuple.Create(
                        int.Parse(parts[1]),
                        int.Parse(parts[3]),
                        int.Parse(parts[5])));
                }
            }

            // I parse it upside down, so need to reverse it.
            for (int i = 0; i < stacks.Count; i++)
            {
                stacks[i] = new Stack<char>(stacks[i]);
            }
        }

        public static string Day5Part2(string[] input)
        {
            List<Stack<char>> stacks;
            List<Tuple<int, int, int>> instructions;
            ParseStacks(input, out stacks, out instructions);

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

        private static long FindFirstDistinctSubString(string dataStream, int length)
        {
            for (int i = length; i < dataStream.Length; i++)
            {
                var startIndex = i - length;
                var packet = dataStream[startIndex..i];
                var uniqueCount = new HashSet<char>(packet).Count;
                if (uniqueCount == packet.Length)
                {
                    return i;
                }
            }

            return 0;
        }

        public static long Day7Part1(string[] input)
        {
            DirectoryNode<string> root = ParseTerminalInput(input);

            //Console.WriteLine(root);
            var files = root.FindAllChildrenLessThan(100000);
            return files.Sum(x => x.Size);
        }

        /// <summary>
        /// Returns an object which represents the directory structure of the file system.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static DirectoryNode<string> ParseTerminalInput(string[] input)
        {
            const char COMMAND_START = '$';

            List<Tuple<string, List<string>>> commands = new();
            Tuple<string, List<string>> currentCommand = null;
            foreach (var line in input)
            {
                if (line.StartsWith(COMMAND_START))
                {
                    currentCommand = Tuple.Create(line.Split("$")[1], new List<string>());
                    commands.Add(currentCommand);
                }
                else
                {
                    if (currentCommand != null)
                    {
                        currentCommand.Item2.Add(line);
                    }
                }
            }

            // analyze commands and output
            var rootName = "/";
            var currentDirectory = new DirectoryNode<string>(rootName, new List<Tuple<string, int>>(), null);
            var root = currentDirectory;
            foreach (var command in commands)
            {
                if (command.Item1.Trim().ToLower().StartsWith("cd"))
                {
                    var param = command.Item1.Split("cd")[1].Trim();
                    if (param == "..")
                    {
                        currentDirectory = currentDirectory.Parent ?? currentDirectory;
                    }
                    else if (param.Equals(rootName))
                    {
                        currentDirectory = root;
                    }
                    else
                    {
                        // if child with same name does not already exist, add it
                        currentDirectory = currentDirectory.AddChild<DirectoryNode<string>>(
                            param, new List<Tuple<string, int>>());
                    }
                }
                if (command.Item1.Trim().ToLower() == "ls")
                {
                    foreach (var output in command.Item2)
                    {
                        if (output.StartsWith("dir"))
                        {
                            var directoryName = output.Split("dir")[1].Trim().ToLower();
                            currentDirectory.AddChild<DirectoryNode<string>>(directoryName,
                                new List<Tuple<string, int>>());
                        }
                        else
                        {
                            var words = output.Split(' ');
                            var size = int.Parse(words[0]);
                            var fileName = words[1];
                            currentDirectory.AddFile(Tuple.Create(fileName, size));
                        }
                    }
                }
            }

            return root;
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
            //parse grid
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

        public static bool IsVisible(List<List<int>> grid, int row, int col)
        {
            // if any adjacent row's integers are all greater than myself then return true.
            var currentSize = grid[row][col];
            return isVisibleLeft(grid, row, col, currentSize)
            || isVisibleRight(grid, row, col, currentSize)
            || isVisibleUp(grid, row, col, currentSize)
            || isVisibleDown(grid, row, col, currentSize)
            ;
        }

        private static bool isVisibleDown(List<List<int>> grid, int row, int col, int currentSize)
        {
            for (int i = grid.Count - 1; i > row; i--)
            {
                if (grid[i][col] >= currentSize)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isVisibleUp(List<List<int>> grid, int row, int col, int currentSize)
        {
            for (int i = 0; i < row; i++)
            {
                if (grid[i][col] >= currentSize)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isVisibleRight(List<List<int>> grid, int row, int col, int currentSize)
        {
            for (int i = grid[row].Count - 1; i > col; i--)
            {
                if (grid[row][i] >= currentSize)
                {
                    return false;
                }
            }

            return true;
        }

        private static bool isVisibleLeft(List<List<int>> grid, int row, int col, int currentSize)
        {
            for (int i = 0; i < col; i++)
            {
                if (grid[row][i] >= currentSize)
                {
                    return false;
                }
            }

            return true;
        }

        public static long Day8Part2(string[] input)
        {
            //parse grid
            var grid = new List<List<int>>();
            foreach (var line in input)
            {
                var ints = line.Select(x => int.Parse(x.ToString())).ToList();
                grid.Add(ints);
            }

            var maxScore = 0;
            for (int row = 1; row < grid.Count - 1; row++)
            {
                for (int col = 1; col < grid[row].Count - 1; col++)
                {
                    // find max scenic score
                    var currentSize = grid[row][col];

                    int newScore = scoreUp(grid, row, col, currentSize)
                        * scoreLeft(grid, row, col, currentSize)
                        * scoreDown(grid, row, col, currentSize)
                        * scoreRight(grid, row, col, currentSize);

                    if (newScore > maxScore)
                    {
                        maxScore = newScore;
                    }
                }
            }

            return maxScore;
        }

        private static int scoreDown(List<List<int>> grid, int row, int col, int currentSize)
        {
            var score = 0;
            for (int i = row + 1; i < grid.Count; i++)
            {
                score++;
                if (grid[i][col] >= currentSize)
                {
                    return score;
                }
            }

            return score;
        }

        private static int scoreUp(List<List<int>> grid, int row, int col, int currentSize)
        {
            var score = 0;
            for (int i = row - 1; i >= 0; i--)
            {
                score++;
                if (grid[i][col] >= currentSize)
                {
                    return score;
                }
            }

            return score;
        }

        private static int scoreRight(List<List<int>> grid, int row, int col, int currentSize)
        {
            var score = 0;
            for (int i = col + 1; i < grid[row].Count; i++)
            {
                score++;
                if (grid[row][i] >= currentSize)
                {
                    return score;
                }
            }

            return score;
        }

        private static int scoreLeft(List<List<int>> grid, int row, int col, int currentSize)
        {
            var score = 0;
            for (int i = col - 1; i >= 0; i--)
            {
                score++;
                if (grid[row][i] >= currentSize)
                {
                    return score;
                }
            }

            return score;
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
            var monkeys = ParseMonkeyInTheMiddle(input);

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

        private static List<Point> MoveRopeAndTrackPath(
            List<Tuple<DPadDirection, int>> directions,
            int numKnots)
        {
            var knotPositions = new List<Point>();
            for (var i = 0; i < numKnots; i++)
            {
                knotPositions.Add(new Point(0, 0));
            }

            var tailPath = new List<Point>() { knotPositions[knotPositions.Count - 1] };
            foreach (var movement in directions)
            {
                //If the head is ever two steps directly up, down, left, or right
                //from the tail, the tail must also move one step in that direction
                //so it remains close enough
                //Otherwise, if the head and tail aren't touching and aren't in the same row or column, the tail always moves one step diagonally to keep up
                Point head;
                for (int i = 0; i < movement.Item2; i++)
                {
                    switch (movement.Item1)
                    {
                        case DPadDirection.RIGHT:
                            head = knotPositions[0];
                            knotPositions[0] = new Point(head.X + 1, head.Y);
                            for (int j = 1; j < knotPositions.Count; j++)
                            {
                                knotPositions[j] = MoveKnotGeneral(knotPositions[j - 1], knotPositions[j]);
                            }
                            break;
                        case DPadDirection.DOWN:
                            head = knotPositions[0];
                            knotPositions[0] = new Point(head.X, head.Y - 1);
                            for (int j = 1; j < knotPositions.Count; j++)
                            {
                                knotPositions[j] = MoveKnotGeneral(knotPositions[j - 1], knotPositions[j]);
                            }
                            break;
                        case DPadDirection.LEFT:
                            head = knotPositions[0];
                            knotPositions[0] = new Point(head.X - 1, head.Y);
                            for (int j = 1; j < knotPositions.Count; j++)
                            {
                                knotPositions[j] = MoveKnotGeneral(knotPositions[j - 1], knotPositions[j]);
                            }
                            break;
                        case DPadDirection.UP:
                            head = knotPositions[0];
                            knotPositions[0] = new Point(head.X, head.Y + 1);
                            for (int j = 1; j < knotPositions.Count; j++)
                            {
                                knotPositions[j] = MoveKnotGeneral(knotPositions[j - 1], knotPositions[j]);
                            }
                            break;
                    }
                    tailPath.Add(knotPositions[knotPositions.Count - 1]);
                }
            }
            return tailPath;
        }

        private static Point MoveKnotGeneral(Point headPosition, Point tailPosition)
        {
            //TODO: improve this algorithm, it is not smart and the complexity is bad since we are checking all directions.
            var distance = Math.Floor(MyPoint.Distance(headPosition, tailPosition));
            if (Math.Abs(distance) <= 1) return tailPosition;

            Point newPosition = MoveKnotPositionDown(headPosition, tailPosition);
            distance = Math.Floor(MyPoint.Distance(headPosition, newPosition));

            if (Math.Abs(distance) <= 1) return newPosition;

            newPosition = MoveKnotPositionUp(headPosition, tailPosition);
            distance = Math.Floor(MyPoint.Distance(headPosition, newPosition));

            if (Math.Abs(distance) <= 1) return newPosition;

            newPosition = MoveKnotPositionLeft(headPosition, tailPosition);
            distance = Math.Floor(MyPoint.Distance(headPosition, newPosition));

            if (Math.Abs(distance) <= 1) return newPosition;

            newPosition = MoveKnotPositionRight(headPosition, tailPosition);
            distance = Math.Floor(MyPoint.Distance(headPosition, newPosition));
            if (Math.Abs(distance) <= 1) return newPosition;

            return new Point(0, 0); ;
        }
        private static Point MoveKnotPositionLeft(Point headPosition, Point tailPosition)
        {
            var distance = Math.Floor(MyPoint.Distance(headPosition, tailPosition));
            if (Math.Abs(distance) > 1)
            {
                if (headPosition.X != tailPosition.X && headPosition.Y != tailPosition.Y)
                {
                    // move diagonally
                    if (headPosition.Y > tailPosition.Y)
                    {
                        tailPosition.Y++;
                    }
                    else
                    {
                        tailPosition.Y--;
                    }
                }
                tailPosition.X--;
            }
            return tailPosition;
        }

        private static Point MoveKnotPositionDown(Point headPosition, Point tailPosition)
        {
            double distance = Math.Floor(MyPoint.Distance(headPosition, tailPosition));
            if (Math.Abs(distance) > 1)
            {
                if (headPosition.X != tailPosition.X && headPosition.Y != tailPosition.Y)
                {
                    // move diagonally
                    if (headPosition.X > tailPosition.X)
                    {
                        tailPosition.X++;
                    }
                    else
                    {
                        tailPosition.X--;
                    }
                }
                tailPosition.Y--;
            }

            return tailPosition;
        }

        private static Point MoveKnotPositionRight(Point parentKnot, Point tailPosition)
        {
            double distance = Math.Floor(MyPoint.Distance(parentKnot, tailPosition));
            if (Math.Abs(distance) > 1)
            {
                if (parentKnot.X != tailPosition.X && parentKnot.Y != tailPosition.Y)
                {
                    // move diagonally
                    if (parentKnot.Y > tailPosition.Y)
                    {
                        tailPosition.Y += 1;
                    }
                    else
                    {
                        tailPosition.Y -= 1;
                    }
                }
                tailPosition.X += 1;
            }

            return tailPosition;
        }

        private static Point MoveKnotPositionUp(Point headPosition, Point tailPosition)
        {
            var distance = Math.Floor(MyPoint.Distance(headPosition, tailPosition));
            if (Math.Abs(distance) > 1)
            {
                if (headPosition.X != tailPosition.X && headPosition.Y != tailPosition.Y)
                {
                    // move diagonally
                    if (headPosition.X > tailPosition.X)
                    {
                        tailPosition.X++;
                    }
                    else
                    {
                        tailPosition.X--;
                    }
                }
                tailPosition.Y++;
            }

            return tailPosition;
        }

        public enum MathOperator
        {
            Add = '+',
            Subtract = '-',
            Multiply = '*',
            Divide = '/'
        }
        public class Monkey
        {

            public long Id { get; set; }
            public List<int> WorryLevelForItems { get; set; }
            public MathOperator Operation { get; set; }
            public string OperationParameter { get; set; } // could be a number or "old"
            public int Test { get; set; }
            public long TrueResult { get; set; }
            public long FalseResult { get; set; }
            public long NumberOfInspections { get; set; }

            internal void TakeTurn(ref List<Monkey> monkeys)
            {
                List<int> indicesToDelete = new();

                // Monkey goes through it's list of items and inspects each one of them, 
                for (int i = 0; i < WorryLevelForItems.Count; i++)
                {
                    int OperationParameterValue = OperationParameter.ToLower().Equals("old") ? WorryLevelForItems[i] : int.Parse(OperationParameter);

                    switch (Operation)
                    {
                        case MathOperator.Add:
                            WorryLevelForItems[i] += OperationParameterValue;
                            break;
                        case MathOperator.Subtract:
                            WorryLevelForItems[i] -= OperationParameterValue;
                            break;
                        case MathOperator.Multiply:
                            WorryLevelForItems[i] *= OperationParameterValue;
                            break;
                        case MathOperator.Divide:
                            WorryLevelForItems[i] /= OperationParameterValue;
                            break;
                    }

                    //After each monkey inspects an item but before it tests your worry level,
                    //your relief that the monkey's inspection didn't damage the item causes
                    //your worry level to be divided by three and rounded down to the nearest integer.
                    WorryLevelForItems[i] = (int)Math.Floor(WorryLevelForItems[i] / 3.0);

                    // then decides which monkey to throw it to depending on the test
                    if (WorryLevelForItems[i] % Test == 0)
                    {
                        var throwTo = monkeys.FirstOrDefault(x => x.Id == TrueResult);
                        throwTo?.GiveItem(WorryLevelForItems[i]);
                    }
                    else
                    {
                        var throwTo = monkeys.FirstOrDefault(x => x.Id == FalseResult);
                        throwTo?.GiveItem(WorryLevelForItems[i]);
                    }
                    indicesToDelete.Add(i);

                    NumberOfInspections++;
                }

                // delete the higher indices first so that the lower are still valid.
                indicesToDelete.Reverse();
                foreach (var item in indicesToDelete)
                {
                    WorryLevelForItems.RemoveAt(item);
                }
            }

            private void GiveItem(int item)
            {
                this.WorryLevelForItems.Add(item);
            }
        }
        /// <summary>
        /// Accepts string in the form:
        ///Monkey 0:
        //  Starting items: 79, 98
        //  Operation: new = old* 19
        //  Test: divisible by 23
        //    If true: throw to monkey 2
        //    If false: throw to monkey 3

        //Monkey 1:
        //  Starting items: 54, 65, 75, 74
        //  Operation: new = old + 6
        //  Test: divisible by 19
        //    If true: throw to monkey 2
        //    If false: throw to monkey 0
        /// </summary>
        private static List<Monkey> ParseMonkeyInTheMiddle(string[] input)
        {
            var result = new List<Monkey>();
            var currentMonkey = new Monkey();
            foreach (var line in input)
            {
                var trimmed = line.Trim();
                if (trimmed.Length == 0)
                {
                    result.Add(currentMonkey);
                    currentMonkey = new Monkey();
                }
                else
                {
                    if (trimmed.StartsWith("Monkey"))
                    {
                        currentMonkey.Id = long.Parse(trimmed.Split("Monkey")[1].Trim().Replace(":", ""));
                    }
                    else if (trimmed.StartsWith("Starting items:"))
                    {
                        currentMonkey.WorryLevelForItems = trimmed.Split("Starting items:")[1].Split(",").Select(int.Parse).ToList();
                    }
                    else if (trimmed.StartsWith("Operation: new = old"))
                    {
                        var split = trimmed.Split("Operation: new = old ");
                        var operatorSplit = split[1].Split(" ");
                        currentMonkey.Operation = (MathOperator)operatorSplit[0][0];
                        currentMonkey.OperationParameter = operatorSplit[1];
                    }
                    else if (trimmed.StartsWith("Test: divisible by "))
                    {
                        currentMonkey.Test = int.Parse(trimmed.Split("Test: divisible by ")[1]);
                    }
                    else if (trimmed.StartsWith("If true: throw to monkey "))
                    {
                        currentMonkey.TrueResult = int.Parse(trimmed.Split("If true: throw to monkey ")[1]);
                    }
                    else if (trimmed.StartsWith("If false: throw to monkey "))
                    {
                        currentMonkey.FalseResult = int.Parse(trimmed.Split("If false: throw to monkey ")[1]);
                    }
                }
            }
            result.Add(currentMonkey);

            return result;
        }
    }
}