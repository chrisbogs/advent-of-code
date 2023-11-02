using AdventOfCodeShared.Models.Geometry;
using AdventOfCodeShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;

namespace AdventOfCodeShared.Logic
{
    public class Helpers
    {
        private const int magicNumber = 2020;

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
        public enum MathOperator
        {
            Add = '+',
            Subtract = '-',
            Multiply = '*',
            Divide = '/'
        }

        // TODO: make this a generate algorithm to gather the permutations of the `numbers` collection
        public static int Get2NumbersThatSumUpTo(IEnumerable<int> numbers)
        {
            var l = numbers.Where(x => x <= magicNumber).OrderBy(x => x).ToList();
            var length = l.Count;
            for (var i = 0; i < length; i++)
            {
                var startIndex = 0;
                if (l[i] - magicNumber >= l[i])
                {
                    startIndex = i;
                }

                for (var j = startIndex; j < length; j++)
                {
                    if (i != j && l[i] + l[j] == magicNumber)
                    {
                        return l[i] * l[j];
                    }
                }
            }

            return -1;
        }

        // TODO: make this a generate algorithm to gather the permutations of the `numbers` collection
        public static int Get3NumbersThatSumUpTo(IEnumerable<int> numbers)
        {
            var l = numbers.Where(x => x <= magicNumber).OrderBy(x => x).ToList();
            var length = l.Count;
            for (var i = 0; i < length; i++)
            {
                var startIndex = 0;
                if (l[i] - magicNumber >= l[i])
                {
                    startIndex = i;
                }
                for (var j = startIndex; j < length; j++)
                {
                    var startIndex2 = 0;
                    if (l[i] + l[j] - magicNumber >= l[j])
                    {
                        startIndex2 = i;
                    }
                    for (var k = startIndex2; k < length; k++)
                    {
                        if (i != j && j != k && l[i] + l[j] + l[k] == magicNumber)
                        {
                            return l[i] * l[j] * l[k];
                        }
                    }
                }
            }

            return -1;
        }

        public static void FindPermutations(int[] list, List<int[]> permutations, int pointer = 0)
        {
            if (pointer == list.Length)
            {
                permutations.Add(list);
                return;
            }
            for (var i = pointer; i < list.Length; i++)
            {
                var permutation = (int[])list.Clone();
                permutation[pointer] = list[i];
                permutation[i] = list[pointer];
                FindPermutations(permutation, permutations, pointer + 1);
            }
        }
        public static long[] ResizeArray(long[] array, long index)
        {
            // Create a new array and copy the values over
            long[] newArray = (long[])Array.CreateInstance(typeof(long), index + 1);
            for (var i = 0; i < Math.Min(array.Length, newArray.Length); i++)
            {
                newArray[i] = array[i];
            }
            return newArray;
        }

        public static int WhichFloorDoWeEndUpOn(string s)
        {
            return s.Count(x => x.Equals('(')) - s.Count(x => x.Equals(')'));
        }
        public static int WhichPositionMovesUsToBasement(string s)
        {
            int position = 1;
            int currentFloor = 0;
            foreach (var c in s)
            {
                if (c.Equals('('))
                {
                    currentFloor += 1;
                }
                else if (c.Equals(')'))
                {
                    currentFloor -= 1;
                }

                if (currentFloor == -1) return position;
                position++;
            }
            return -1;
        }

        public static long CountIncreases(IList<int> nums)
        {
            if (nums is null || !nums.Any()) return 0;

            // Count the number of times that we increase when iterating though the given list of numbers.
            var result = 0;
            for (int i = 1; i < nums.Count; i++)
            {
                if (nums[i] > nums[i - 1])
                {
                    result++;
                }
            }

            return result;
        }

        public static int CountIncreasesInThreeMeasurementWindow(IList<int> nums)
        {
            if (nums == null || nums.Count < 3)
            {
                return 0;
            }

            // Count the number of times that we increase 
            // when iterating though the given list of numbers.
            // using a three value sum for the window.
            var result = 0;
            for (int i = 3; i < nums.Count; i++)
            {
                if (nums[i] + nums[i - 1] + nums[i - 2]
                    > nums[i - 1] + nums[i - 2] + nums[i - 3]
                )
                {
                    result++;
                }
            }

            return result;
        }

        // put each starting fish into a bucket.
        // There is one bucket per day in the cycle.
        // Each bucket has a count of the fish in that age.
        public static long SimulateFish(int daysToSimulate, IEnumerable<int> allFish)
        {
            var newFish = new List<long>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            foreach (var x in allFish)
            {
                newFish[x]++;
            }

            for (var i = 0; i < daysToSimulate; i++)
            {
                var aboutToSpawn = newFish[0];
                newFish[0] = newFish[1];
                newFish[1] = newFish[2];
                newFish[2] = newFish[3];
                newFish[3] = newFish[4];
                newFish[4] = newFish[5];
                newFish[5] = newFish[6];
                newFish[6] = newFish[7];
                newFish[7] = newFish[8];
                newFish[8] = aboutToSpawn;
                newFish[6] += aboutToSpawn;
            }
            return newFish.Sum();
        }

        public static int SumOfSeriesInt(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            if (n == 2) return 3;
            return (int)decimal.Floor(n * (n + 1) / 2);
        }



        //Finds the first character that does not appear in the other string.
        public static IList<char> FindFirstDiff(string str1, string str2)
        {
            var string1 = str1.ToList();
            var string2 = str2.ToList();
            var diff = string1.Where(x => !string2.Contains(x));
            if (!diff.Any())
            {
                diff = string2.Where(x => !string1.Contains(x));
            }
            return diff.ToList();
        }

        public static double CalcFuelNeeded(string[] moduleMasses)
        {
            var fuelNeeded = 0.0;
            foreach (var moduleMass in moduleMasses)
            {
                fuelNeeded += CalcFuelNeeded(double.Parse(moduleMass));
            }
            return fuelNeeded;
        }

        public static double CalcFuelNeeded(double moduleMass)
        {
            return Math.Floor(moduleMass / 3.0) - 2;
        }

        public static double CalcFuelNeededPart2(string[] moduleMasses)
        {
            var fuelNeeded = 0.0;

            foreach (var moduleMass in moduleMasses)
            {
                fuelNeeded += CalcFuelNeededPart2(double.Parse(moduleMass));
            }

            return fuelNeeded;
        }

        public static double CalcFuelNeededPart2(double moduleMass)
        {
            var fuelNeededForMass = CalcFuelNeeded(moduleMass);

            // calc fuel needed for mass of fuel
            var existingMass = fuelNeededForMass;
            while (existingMass > 0)
            {
                var moreFuelNeeded = CalcFuelNeeded(existingMass);
                if (moreFuelNeeded > 0)
                {
                    fuelNeededForMass += moreFuelNeeded;
                }
                existingMass = moreFuelNeeded;
            }
            return fuelNeededForMass;
        }

        public static int FindClosestDistanceToOrigin(string[] wire1, string[] wire2)
        {
            var wire1Path = Geometry.TracePathCountingSteps(wire1);
            var wire2Path = Geometry.TracePathCountingSteps(wire2);
            var crossings = Geometry.FindIntersectionPoints(wire1Path, wire2Path);
            var closestPoint = crossings.Select(p => new
            {
                p.Key.X,
                p.Key.Y,
                Distance = Math.Abs(p.Key.X) + Math.Abs(p.Key.Y)
            })
                .OrderBy(x => x.Distance)
                .FirstOrDefault();

            //What is the Manhattan distance from the central port to the closest intersection?
            return closestPoint?.Distance ?? 0;
        }

        public static int FindIntersectionWithLeastSteps(string[] wire1, string[] wire2)
        {
            var wire1Path = Geometry.TracePathCountingSteps(wire1);
            var wire2Path = Geometry.TracePathCountingSteps(wire2);

            var crossings = Geometry.FindIntersectionPoints(wire1Path, wire2Path);

            var closestPoint = crossings.Min(x => x.Value);
            return closestPoint;
        }
        public static bool MeetsCriteria(string password, int criteriaMin, int criteriaMax)
        {
            var number = int.Parse(password);

            //It is a six-digit number.
            if (number < 100000 || number > 999999)
            {
                return false;
            }
            //The value is within the range given in your puzzle input.
            if (number > criteriaMax || number < criteriaMin)
            {
                return false;
            }

            var result = false;
            for (var i = 0; i < password.Length; i++)
            {
                //Two adjacent digits are the same (like 22 in 122345).
                result |= i > 0 && password[i] == password[i - 1] || i + 1 < password.Length && password[i] == password[i + 1];
                //Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
                if (i > 0 && password[i] < password[i - 1])
                {
                    return false;
                }
            }
            return result;
        }

        public static bool MeetsCriteriaUpdated(string password, int criteriaMin, int criteriaMax)
        {
            var number = int.Parse(password);

            //It is a six-digit number.
            if (number < 100000 || number > 999999)
            {
                return false;
            }
            //The value is within the range given in your puzzle input.
            if (number > criteriaMax || number < criteriaMin)
            {
                return false;
            }

            char? prev = null;
            var seqCount = 1;
            var pairFound = false;
            for (var i = 0; i < password.Length; i++)
            {
                //Two adjacent digits are the same (like 22 in 122345).
                //the two adjacent matching digits are not part of a larger group of matching digits.
                if (prev.HasValue && password[i] == prev.Value)
                {
                    seqCount++;
                    if ((i == password.Length - 1 || password[i] != password[i + 1]) && seqCount == 1)
                    {
                        pairFound = true;
                    }
                }
                else
                {
                    seqCount = 0;
                }

                //Going from left to right, the digits never decrease; they only ever increase or stay the same(like 111123 or 135679).
                if (i > 0 && password[i] < password[i - 1])
                {
                    return false;
                }
                prev = password[i];
            }
            return pairFound;
        }

        public static Dictionary<string, ObjectNode> LoadOrbits(string[] allOrbits)
        {
            var allObjects = new Dictionary<string, ObjectNode>();
            //In the map data, this orbital relationship is written AAA)BBB, which means "BBB is in orbit around AAA".
            var orbitInstructions = allOrbits;
            foreach (var oi in orbitInstructions.Where(x => x.Length > 0))
            {
                var objects = oi.Split(')');
                var name = objects[1];
                var orbittingObjectName = objects[0];

                ObjectNode on;
                if (allObjects.ContainsKey(name))
                {
                    on = allObjects[name];
                }
                else
                {
                    on = new ObjectNode
                    {
                        Name = name,
                        Orbitting = new LinkedList<ObjectNode>()
                    };
                    allObjects.Add(name, on);
                }

                ObjectNode orbitting;
                if (allObjects.ContainsKey(orbittingObjectName))
                {
                    orbitting = allObjects[orbittingObjectName];
                }
                else
                {
                    orbitting = new ObjectNode
                    {
                        Name = orbittingObjectName,
                        Orbitting = new LinkedList<ObjectNode>()
                    };
                    allObjects.Add(orbittingObjectName, orbitting);
                }
                on.Orbitting.AddLast(orbitting);
            }
            return allObjects;
        }
        //public static int CalcOrbits(Dictionary<string, ObjectNode> allObjects)
        //{
        //    //Whenever A orbits B and B orbits C, then A indirectly orbits C.
        //    //This chain can be any number of objects long: if A orbits B, B orbits C, and C orbits D, then A indirectly orbits D.
        //    return DepthFirstTraverse(allObjects);
        //}
        public struct ObjectNode
        {
            public string Name;
            public LinkedList<ObjectNode> Orbitting;
        }
        //private static int DepthFirstTraverse(Dictionary<string, ObjectNode> allObjects)
        //{
        //    return 0;
        //}

        public static long FindMaxSignal(Computer[] amplifiers, string amplifierControllerSoftware, int[] phaseSettingSequence)
        {
            //Try every combination of phase settings on the amplifiers.
            var maxSignal = long.MinValue;

            var permutations = new List<int[]>();
            Helpers.FindPermutations(phaseSettingSequence, permutations);
            foreach (var permute in permutations)
            {
                long lastOutputSignal = 0;
                maxSignal = RunProgramThroughAmplifiers(amplifiers, permute, maxSignal, ref lastOutputSignal, amplifierControllerSoftware);
            }
            return maxSignal;
        }

        public static long RunProgramThroughAmplifiers(Computer[] amplifiers, int[] amplifierInput, long maxSignal, ref long lastOutputSignal, string amplifierControllerSoftware)
        {
            for (var i = 0; i < amplifiers.Length; i++)
            {
                amplifiers[i] = new Computer(amplifierControllerSoftware);
                amplifiers[i].RunIntCodeProgram(new Stack<long>(new List<long>() { lastOutputSignal, amplifierInput[i] }));
                lastOutputSignal = amplifiers[i].DiagnosticOutput[0];
                maxSignal = Math.Max(maxSignal, lastOutputSignal);
            }
            return maxSignal;
        }

        //obsolete
        public static List<long> SumContiguousLines(string[] input)
        {
            var calories = new List<long>();
            long currentSum = 0;
            foreach (var line in input)
            {
                var trimmed = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmed))
                {
                    calories.Add(currentSum);
                    currentSum = 0;
                }
                else
                {
                    currentSum += long.Parse(trimmed);
                }
            }
            calories.Add(currentSum);
            return calories;
        }
        public static IEnumerable<long> SumContiguousLinesGenerator(string[] input)
        {
            long currentSum = 0;
            foreach (var line in input)
            {
                var trimmed = line.Trim();
                if (string.IsNullOrWhiteSpace(trimmed))
                {
                    yield return currentSum;
                    currentSum = 0;
                }
                else
                {
                    currentSum += long.Parse(trimmed);
                }
            }
            yield return currentSum;
        }

        public static int DetermineScore(List<List<int>> grid)
        {
            var maxScore = 0;
            for (int row = 1; row < grid.Count - 1; row++)
            {
                for (int col = 1; col < grid[row].Count - 1; col++)
                {
                    // find max scenic score
                    var currentSize = grid[row][col];

                    int newScore = ScoreUp(grid, row, col, currentSize)
                        * ScoreLeft(grid, row, col, currentSize)
                        * ScoreDown(grid, row, col, currentSize)
                        * ScoreRight(grid, row, col, currentSize);

                    if (newScore > maxScore)
                    {
                        maxScore = newScore;
                    }
                }
            }

            return maxScore;
        }

        public static bool IsVisible(List<List<int>> grid, int row, int col)
        {
            // if any adjacent row's integers are all greater than myself then return true.
            var currentSize = grid[row][col];
            return IsVisibleLeft(grid, row, col, currentSize)
            || IsVisibleRight(grid, row, col, currentSize)
            || IsVisibleUp(grid, row, col, currentSize)
            || IsVisibleDown(grid, row, col, currentSize)
            ;
        }

        private static bool IsVisibleDown(List<List<int>> grid, int row, int col, int currentSize)
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

        private static bool IsVisibleUp(List<List<int>> grid, int row, int col, int currentSize)
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

        private static bool IsVisibleRight(List<List<int>> grid, int row, int col, int currentSize)
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

        private static bool IsVisibleLeft(List<List<int>> grid, int row, int col, int currentSize)
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

        private static int ScoreDown(List<List<int>> grid, int row, int col, int currentSize)
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

        private static int ScoreUp(List<List<int>> grid, int row, int col, int currentSize)
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

        private static int ScoreRight(List<List<int>> grid, int row, int col, int currentSize)
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

        private static int ScoreLeft(List<List<int>> grid, int row, int col, int currentSize)
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

        public static List<Point> MoveRopeAndTrackPath(
    List<Tuple<DPadDirection, int>> directions,
    int numKnots)
        {
            var knotPositions = new List<Point>();
            for (var i = 0; i < numKnots; i++)
            {
                knotPositions.Add(new Point(0, 0));
            }

            var tailPath = new List<Point>() { knotPositions[^1] };
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
                    tailPath.Add(knotPositions[^1]);
                }
            }
            return tailPath;
        }

        public static Point MoveKnotGeneral(Point headPosition, Point tailPosition)
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

        public static void ParseStacks(string[] input, out List<Stack<char>> stacks, out List<Tuple<int, int, int>> instructions)
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

        public static long FindFirstDistinctSubString(string dataStream, int length)
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

        /// <summary>
        /// Returns an object which represents the directory structure of the file system.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DirectoryNode<string> ParseTerminalInput(string[] input)
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
                    currentCommand?.Item2.Add(line);
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

        /// <summary>
        /// Given a list of lists of nodes, return the point that contains the start marker
        /// and the point that contains the end marker.
        /// ASSUME that both will always exist in the grid.
        /// </summary>
        public static Tuple<Point, Point> FindStartAndEndPosition(
            Grid<char> grid)
        {
            const char StartSymbol = 'S';
            const char EndSymbol = 'E';
            Point? startPoint = null;
            Point? endPoint = null;
            for (int i = 0; i < grid.Columns; i++)
            {
                for (int j = 0; j < grid.RowCount(i); j++)
                {
                    if (grid.NodeAt(i,j).Value.Equals(StartSymbol))
                    {
                        startPoint = new Point(i, j);
                    }
                    if (grid.NodeAt(i, j).Value.Equals(EndSymbol))
                    {
                        endPoint = new Point(i, j);
                    }
                    if (startPoint != null && endPoint != null)
                    {
                        break;
                    }
                }
            }
            return Tuple.Create(startPoint.Value, endPoint.Value);
        }
    }
}