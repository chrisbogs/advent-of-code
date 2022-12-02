using System;
using System.Collections.Generic;
using System.Linq;

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

        public enum OpponentShape {
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
        public enum ShapeScore {
            Rock=1,
            Paper=2,
            Scissors=3
        }
        public enum RoundScore {
            Lost=0,
            Draw=3,
            Win=6
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
                switch (outcome) {
                    case 'X': //lose
                        switch ((OpponentShape)opponentShape) {
                            case OpponentShape.Rock:
                                shapes = new string[] { $"{opponentShape}", $"{(char)PlayerShape.Scissors}" };break;
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
