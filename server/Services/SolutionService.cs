using AdventOfCodeShared.Logic;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    /// <summary>
    /// Service for resolving and executing Advent of Code solutions.
    /// </summary>
    public interface ISolutionService
    {
        /// <summary>
        /// Gets the solution result for a given year, day, and part.
        /// </summary>
        /// <param name="year">The puzzle year (2015-2025)</param>
        /// <param name="day">The puzzle day (1-25)</param>
        /// <param name="part">The puzzle part (1-2)</param>
        /// <returns>The solution result as a string</returns>
        Task<string> GetSolutionAsync(int year, int day, int part);

        /// <summary>
        /// Validates if a year/day/part combination is valid.
        /// </summary>
        bool IsValidPuzzle(int year, int day, int part);
    }

    /// <summary>
    /// <inheritdoc cref="ISolutionService"/>
    /// </summary>
    public class SolutionService : ISolutionService
    {
        private readonly IInputRetriever _inputRetriever;
        private readonly ILogger<SolutionService> _logger;

        // Supported years in the solution
        private static readonly HashSet<int> SupportedYears = new() { 2015, 2016, 2017, 2018, 2019, 2020, 2021, 2022, 2023, 2024, 2025 };

        public SolutionService(IInputRetriever inputRetriever, ILogger<SolutionService> logger)
        {
            _inputRetriever = inputRetriever ?? throw new ArgumentNullException(nameof(inputRetriever));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public bool IsValidPuzzle(int year, int day, int part)
        {
            return SupportedYears.Contains(year) && day >= 1 && day <= 25 && part >= 1 && part <= 2;
        }

        public async Task<string> GetSolutionAsync(int year, int day, int part)
        {
            if (!IsValidPuzzle(year, day, part))
            {
                _logger.LogWarning("Invalid puzzle parameters: year={Year}, day={Day}, part={Part}", year, day, part);
                throw new ArgumentException($"Invalid puzzle parameters: year must be between 2015-2025, day 1-25, part 1-2");
            }

            try
            {
                _logger.LogInformation("Retrieving solution for {Year} day {Day} part {Part}", year, day, part);
                var input = await _inputRetriever.GetInput(year, day);

                var result = year switch
                {
                    2025 => ExecuteYear2025(day, part, input),
                    2024 => ExecuteYear2024(day, part, input),
                    2023 => ExecuteYear2023(day, part, input),
                    2022 => ExecuteYear2022(day, part, input),
                    2021 => ExecuteYear2021(day, part, input),
                    2020 => ExecuteYear2020(day, part, input),
                    2019 => ExecuteYear2019(day, part, input),
                    2018 => ExecuteYear2018(day, part, input),
                    2017 => ExecuteYear2017(day, part, input),
                    2016 => ExecuteYear2016(day, part, input),
                    2015 => ExecuteYear2015(day, part, input),
                    _ => throw new NotSupportedException($"Year {year} is not supported")
                };

                _logger.LogInformation("Solution computed successfully for {Year} day {Day} part {Part}", year, day, part);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving solution for {Year} day {Day} part {Part}", year, day, part);
                throw;
            }
        }

        #region Year Executors

        private static string ExecuteYear2025(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentyTwentyFive.Day1Part1(input).ToString(), 2 => TwentyTwentyFive.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentyTwentyFive.Day2Part1(input).ToString(), 2 => TwentyTwentyFive.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentyTwentyFive.Day3Part1(input).ToString(), 2 => TwentyTwentyFive.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentyTwentyFive.Day4Part1(input).ToString(), 2 => TwentyTwentyFive.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentyTwentyFive.Day5Part1(input).ToString(), 2 => TwentyTwentyFive.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentyTwentyFive.Day6Part1(input).ToString(), 2 => TwentyTwentyFive.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentyTwentyFive.Day7Part1(input).ToString(), 2 => TwentyTwentyFive.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentyTwentyFive.Day8Part1(input).ToString(), 2 => TwentyTwentyFive.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentyTwentyFive.Day9Part1(input).ToString(), 2 => TwentyTwentyFive.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentyTwentyFive.Day10Part1(input).ToString(), 2 => TwentyTwentyFive.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentyTwentyFive.Day11Part1(input).ToString(), 2 => TwentyTwentyFive.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentyTwentyFive.Day12Part1(input).ToString(), 2 => TwentyTwentyFive.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentyTwentyFive.Day13Part1(input).ToString(), 2 => TwentyTwentyFive.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentyTwentyFive.Day14Part1(input).ToString(), 2 => TwentyTwentyFive.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentyTwentyFive.Day15Part1(input).ToString(), 2 => TwentyTwentyFive.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentyTwentyFive.Day16Part1(input).ToString(), 2 => TwentyTwentyFive.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentyTwentyFive.Day17Part1(input).ToString(), 2 => TwentyTwentyFive.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentyTwentyFive.Day18Part1(input).ToString(), 2 => TwentyTwentyFive.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentyTwentyFive.Day19Part1(input).ToString(), 2 => TwentyTwentyFive.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentyTwentyFive.Day20Part1(input).ToString(), 2 => TwentyTwentyFive.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentyTwentyFive.Day21Part1(input).ToString(), 2 => TwentyTwentyFive.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentyTwentyFive.Day22Part1(input).ToString(), 2 => TwentyTwentyFive.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentyTwentyFive.Day23Part1(input).ToString(), 2 => TwentyTwentyFive.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentyTwentyFive.Day24Part1(input).ToString(), 2 => TwentyTwentyFive.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentyTwentyFive.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2024(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentyTwentyFour.Day1Part1(input).ToString(), 2 => TwentyTwentyFour.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentyTwentyFour.Day2Part1(input).ToString(), 2 => TwentyTwentyFour.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentyTwentyFour.Day3Part1(input).ToString(), 2 => TwentyTwentyFour.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentyTwentyFour.Day4Part1(input).ToString(), 2 => TwentyTwentyFour.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentyTwentyFour.Day5Part1(input).ToString(), 2 => TwentyTwentyFour.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentyTwentyFour.Day6Part1(input).ToString(), 2 => TwentyTwentyFour.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentyTwentyFour.Day7Part1(input).ToString(), 2 => TwentyTwentyFour.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentyTwentyFour.Day8Part1(input).ToString(), 2 => TwentyTwentyFour.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentyTwentyFour.Day9Part1(input).ToString(), 2 => TwentyTwentyFour.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentyTwentyFour.Day10Part1(input).ToString(), 2 => TwentyTwentyFour.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentyTwentyFour.Day11Part1(input).ToString(), 2 => TwentyTwentyFour.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentyTwentyFour.Day12Part1(input).ToString(), 2 => TwentyTwentyFour.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentyTwentyFour.Day13Part1(input).ToString(), 2 => TwentyTwentyFour.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentyTwentyFour.Day14Part1(input).ToString(), 2 => TwentyTwentyFour.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentyTwentyFour.Day15Part1(input).ToString(), 2 => TwentyTwentyFour.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentyTwentyFour.Day16Part1(input).ToString(), 2 => TwentyTwentyFour.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentyTwentyFour.Day17Part1(input).ToString(), 2 => TwentyTwentyFour.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentyTwentyFour.Day18Part1(input).ToString(), 2 => TwentyTwentyFour.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentyTwentyFour.Day19Part1(input).ToString(), 2 => TwentyTwentyFour.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentyTwentyFour.Day20Part1(input).ToString(), 2 => TwentyTwentyFour.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentyTwentyFour.Day21Part1(input).ToString(), 2 => TwentyTwentyFour.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentyTwentyFour.Day22Part1(input).ToString(), 2 => TwentyTwentyFour.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentyTwentyFour.Day23Part1(input).ToString(), 2 => TwentyTwentyFour.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentyTwentyFour.Day24Part1(input).ToString(), 2 => TwentyTwentyFour.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentyTwentyFour.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2023(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentyTwentyThree.Day1Part1(input).ToString(), 2 => TwentyTwentyThree.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentyTwentyThree.Day2Part1(input).ToString(), 2 => TwentyTwentyThree.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentyTwentyThree.Day3Part1(input).ToString(), 2 => TwentyTwentyThree.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentyTwentyThree.Day4Part1(input).ToString(), 2 => TwentyTwentyThree.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentyTwentyThree.Day5Part1(input).ToString(), 2 => TwentyTwentyThree.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentyTwentyThree.Day6Part1(input).ToString(), 2 => TwentyTwentyThree.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentyTwentyThree.Day7Part1(input).ToString(), 2 => TwentyTwentyThree.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentyTwentyThree.Day8Part1(input).ToString(), 2 => TwentyTwentyThree.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentyTwentyThree.Day9Part1(input).ToString(), 2 => TwentyTwentyThree.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentyTwentyThree.Day10Part1(input).ToString(), 2 => TwentyTwentyThree.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentyTwentyThree.Day11Part1(input).ToString(), 2 => TwentyTwentyThree.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentyTwentyThree.Day12Part1(input).ToString(), 2 => TwentyTwentyThree.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentyTwentyThree.Day13Part1(input).ToString(), 2 => TwentyTwentyThree.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentyTwentyThree.Day14Part1(input).ToString(), 2 => TwentyTwentyThree.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentyTwentyThree.Day15Part1(input).ToString(), 2 => TwentyTwentyThree.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentyTwentyThree.Day16Part1(input).ToString(), 2 => TwentyTwentyThree.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentyTwentyThree.Day17Part1(input).ToString(), 2 => TwentyTwentyThree.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentyTwentyThree.Day18Part1(input).ToString(), 2 => TwentyTwentyThree.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentyTwentyThree.Day19Part1(input).ToString(), 2 => TwentyTwentyThree.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentyTwentyThree.Day20Part1(input).ToString(), 2 => TwentyTwentyThree.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentyTwentyThree.Day21Part1(input).ToString(), 2 => TwentyTwentyThree.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentyTwentyThree.Day22Part1(input).ToString(), 2 => TwentyTwentyThree.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentyTwentyThree.Day23Part1(input).ToString(), 2 => TwentyTwentyThree.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentyTwentyThree.Day24Part1(input).ToString(), 2 => TwentyTwentyThree.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentyTwentyThree.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2022(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentyTwentyTwo.Day1Part1(input).ToString(), 2 => TwentyTwentyTwo.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentyTwentyTwo.Day2Part1(input).ToString(), 2 => TwentyTwentyTwo.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentyTwentyTwo.Day3Part1(input).ToString(), 2 => TwentyTwentyTwo.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentyTwentyTwo.Day4Part1(input).ToString(), 2 => TwentyTwentyTwo.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentyTwentyTwo.Day5Part1(input).ToString(), 2 => TwentyTwentyTwo.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentyTwentyTwo.Day6Part1(input).ToString(), 2 => TwentyTwentyTwo.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentyTwentyTwo.Day7Part1(input).ToString(), 2 => TwentyTwentyTwo.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentyTwentyTwo.Day8Part1(input).ToString(), 2 => TwentyTwentyTwo.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentyTwentyTwo.Day9Part1(input).ToString(), 2 => TwentyTwentyTwo.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentyTwentyTwo.Day10Part1(input).ToString(), 2 => TwentyTwentyTwo.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentyTwentyTwo.Day11Part1(input).ToString(), 2 => TwentyTwentyTwo.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentyTwentyTwo.Day12Part1(input).ToString(), 2 => TwentyTwentyTwo.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentyTwentyTwo.Day13Part1(input).ToString(), 2 => TwentyTwentyTwo.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentyTwentyTwo.Day14Part1(input).ToString(), 2 => TwentyTwentyTwo.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentyTwentyTwo.Day15Part1(input).ToString(), 2 => TwentyTwentyTwo.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentyTwentyTwo.Day16Part1(input).ToString(), 2 => TwentyTwentyTwo.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentyTwentyTwo.Day17Part1(input).ToString(), 2 => TwentyTwentyTwo.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentyTwentyTwo.Day18Part1(input).ToString(), 2 => TwentyTwentyTwo.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentyTwentyTwo.Day19Part1(input).ToString(), 2 => TwentyTwentyTwo.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentyTwentyTwo.Day20Part1(input).ToString(), 2 => TwentyTwentyTwo.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentyTwentyTwo.Day21Part1(input).ToString(), 2 => TwentyTwentyTwo.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentyTwentyTwo.Day22Part1(input).ToString(), 2 => TwentyTwentyTwo.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentyTwentyTwo.Day23Part1(input).ToString(), 2 => TwentyTwentyTwo.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentyTwentyTwo.Day24Part1(input).ToString(), 2 => TwentyTwentyTwo.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentyTwentyTwo.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2021(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentyTwentyOne.Day1Part1(input).ToString(), 2 => TwentyTwentyOne.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentyTwentyOne.Day2Part1(input).ToString(), 2 => TwentyTwentyOne.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentyTwentyOne.Day3Part1(input).ToString(), 2 => TwentyTwentyOne.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentyTwentyOne.Day4Part1(input).ToString(), 2 => TwentyTwentyOne.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentyTwentyOne.Day5Part1(input).ToString(), 2 => TwentyTwentyOne.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentyTwentyOne.Day6Part1(input).ToString(), 2 => TwentyTwentyOne.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentyTwentyOne.Day7Part1(input).ToString(), 2 => TwentyTwentyOne.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentyTwentyOne.Day8Part1(input).ToString(), 2 => TwentyTwentyOne.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentyTwentyOne.Day9Part1(input).ToString(), 2 => TwentyTwentyOne.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentyTwentyOne.Day10Part1(input).ToString(), 2 => TwentyTwentyOne.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentyTwentyOne.Day11Part1(input).ToString(), 2 => TwentyTwentyOne.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentyTwentyOne.Day12Part1(input).ToString(), 2 => TwentyTwentyOne.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentyTwentyOne.Day13Part1(input).ToString(), 2 => TwentyTwentyOne.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentyTwentyOne.Day14Part1(input).ToString(), 2 => TwentyTwentyOne.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentyTwentyOne.Day15Part1(input).ToString(), 2 => TwentyTwentyOne.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentyTwentyOne.Day16Part1(input).ToString(), 2 => TwentyTwentyOne.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentyTwentyOne.Day17Part1(input).ToString(), 2 => TwentyTwentyOne.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentyTwentyOne.Day18Part1(input).ToString(), 2 => TwentyTwentyOne.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentyTwentyOne.Day19Part1(input).ToString(), 2 => TwentyTwentyOne.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentyTwentyOne.Day20Part1(input).ToString(), 2 => TwentyTwentyOne.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentyTwentyOne.Day21Part1(input).ToString(), 2 => TwentyTwentyOne.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentyTwentyOne.Day22Part1(input).ToString(), 2 => TwentyTwentyOne.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentyTwentyOne.Day23Part1(input).ToString(), 2 => TwentyTwentyOne.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentyTwentyOne.Day24Part1(input).ToString(), 2 => TwentyTwentyOne.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentyTwentyOne.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2020(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentyTwenty.Day1Part1(input).ToString(), 2 => TwentyTwenty.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentyTwenty.Day2Part1(input).ToString(), 2 => TwentyTwenty.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentyTwenty.Day3Part1(input).ToString(), 2 => TwentyTwenty.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentyTwenty.Day4Part1(input).ToString(), 2 => TwentyTwenty.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentyTwenty.Day5Part1(input).ToString(), 2 => TwentyTwenty.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentyTwenty.Day6Part1(input).ToString(), 2 => TwentyTwenty.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentyTwenty.Day7Part1(input).ToString(), 2 => TwentyTwenty.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentyTwenty.Day8Part1(input).ToString(), 2 => TwentyTwenty.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentyTwenty.Day9Part1(input).ToString(), 2 => TwentyTwenty.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentyTwenty.Day10Part1(input).ToString(), 2 => TwentyTwenty.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentyTwenty.Day11Part1(input).ToString(), 2 => TwentyTwenty.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentyTwenty.Day12Part1(input).ToString(), 2 => TwentyTwenty.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentyTwenty.Day13Part1(input).ToString(), 2 => TwentyTwenty.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentyTwenty.Day14Part1(input).ToString(), 2 => TwentyTwenty.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentyTwenty.Day15Part1(input).ToString(), 2 => TwentyTwenty.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentyTwenty.Day16Part1(input).ToString(), 2 => TwentyTwenty.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentyTwenty.Day17Part1(input).ToString(), 2 => TwentyTwenty.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentyTwenty.Day18Part1(input).ToString(), 2 => TwentyTwenty.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentyTwenty.Day19Part1(input).ToString(), 2 => TwentyTwenty.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentyTwenty.Day20Part1(input).ToString(), 2 => TwentyTwenty.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentyTwenty.Day21Part1(input).ToString(), 2 => TwentyTwenty.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentyTwenty.Day22Part1(input).ToString(), 2 => TwentyTwenty.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentyTwenty.Day23Part1(input).ToString(), 2 => TwentyTwenty.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentyTwenty.Day24Part1(input).ToString(), 2 => TwentyTwenty.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentyTwenty.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2019(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentyNineteen.Day1Part1(input).ToString(), 2 => TwentyNineteen.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentyNineteen.Day2Part1(input).ToString(), 2 => TwentyNineteen.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentyNineteen.Day3Part1(input).ToString(), 2 => TwentyNineteen.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentyNineteen.Day4Part1(input).ToString(), 2 => TwentyNineteen.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => string.Join(",", TwentyNineteen.Day5Part1(input).Select(x => x.ToString())), 2 => TwentyNineteen.Day5Part2(input).Last().ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentyNineteen.Day6Part1(input).ToString(), 2 => TwentyNineteen.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentyNineteen.Day7Part1(input).ToString(), 2 => TwentyNineteen.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentyNineteen.Day8Part1(input).ToString(), 2 => TwentyNineteen.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentyNineteen.Day9Part1(input).ToString(), 2 => TwentyNineteen.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentyNineteen.Day10Part1(input).ToString(), 2 => TwentyNineteen.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentyNineteen.Day11Part1(input).ToString(), 2 => TwentyNineteen.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentyNineteen.Day12Part1(input).ToString(), 2 => TwentyNineteen.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentyNineteen.Day13Part1(input).ToString(), 2 => TwentyNineteen.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentyNineteen.Day14Part1(input).ToString(), 2 => TwentyNineteen.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentyNineteen.Day15Part1(input).ToString(), 2 => TwentyNineteen.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentyNineteen.Day16Part1(input).ToString(), 2 => TwentyNineteen.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentyNineteen.Day17Part1(input).ToString(), 2 => TwentyNineteen.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentyNineteen.Day18Part1(input).ToString(), 2 => TwentyNineteen.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentyNineteen.Day19Part1(input).ToString(), 2 => TwentyNineteen.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentyNineteen.Day20Part1(input).ToString(), 2 => TwentyNineteen.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentyNineteen.Day21Part1(input).ToString(), 2 => TwentyNineteen.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentyNineteen.Day22Part1(input).ToString(), 2 => TwentyNineteen.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentyNineteen.Day23Part1(input).ToString(), 2 => TwentyNineteen.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentyNineteen.Day24Part1(input).ToString(), 2 => TwentyNineteen.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentyNineteen.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2018(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentyEighteen.Day1Part1(input).ToString(), 2 => TwentyEighteen.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentyEighteen.Day2Part1(input).ToString(), 2 => TwentyEighteen.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentyEighteen.Day3Part1(input).ToString(), 2 => TwentyEighteen.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentyEighteen.Day4Part1(input).ToString(), 2 => TwentyEighteen.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentyEighteen.Day5Part1(input).ToString(), 2 => TwentyEighteen.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentyEighteen.Day6Part1(input).ToString(), 2 => TwentyEighteen.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentyEighteen.Day7Part1(input).ToString(), 2 => TwentyEighteen.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentyEighteen.Day8Part1(input).ToString(), 2 => TwentyEighteen.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentyEighteen.Day9Part1(input).ToString(), 2 => TwentyEighteen.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentyEighteen.Day10Part1(input).ToString(), 2 => TwentyEighteen.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentyEighteen.Day11Part1(input).ToString(), 2 => TwentyEighteen.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentyEighteen.Day12Part1(input).ToString(), 2 => TwentyEighteen.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentyEighteen.Day13Part1(input).ToString(), 2 => TwentyEighteen.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentyEighteen.Day14Part1(input).ToString(), 2 => TwentyEighteen.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentyEighteen.Day15Part1(input).ToString(), 2 => TwentyEighteen.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentyEighteen.Day16Part1(input).ToString(), 2 => TwentyEighteen.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentyEighteen.Day17Part1(input).ToString(), 2 => TwentyEighteen.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentyEighteen.Day18Part1(input).ToString(), 2 => TwentyEighteen.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentyEighteen.Day19Part1(input).ToString(), 2 => TwentyEighteen.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentyEighteen.Day20Part1(input).ToString(), 2 => TwentyEighteen.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentyEighteen.Day21Part1(input).ToString(), 2 => TwentyEighteen.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentyEighteen.Day22Part1(input).ToString(), 2 => TwentyEighteen.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentyEighteen.Day23Part1(input).ToString(), 2 => TwentyEighteen.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentyEighteen.Day24Part1(input).ToString(), 2 => TwentyEighteen.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentyEighteen.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2017(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentySeventeen.Day1Part1(input).ToString(), 2 => TwentySeventeen.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentySeventeen.Day2Part1(input).ToString(), 2 => TwentySeventeen.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentySeventeen.Day3Part1(input).ToString(), 2 => TwentySeventeen.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentySeventeen.Day4Part1(input).ToString(), 2 => TwentySeventeen.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentySeventeen.Day5Part1(input).ToString(), 2 => TwentySeventeen.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentySeventeen.Day6Part1(input).ToString(), 2 => TwentySeventeen.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentySeventeen.Day7Part1(input).ToString(), 2 => TwentySeventeen.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentySeventeen.Day8Part1(input).ToString(), 2 => TwentySeventeen.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentySeventeen.Day9Part1(input).ToString(), 2 => TwentySeventeen.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentySeventeen.Day10Part1(input).ToString(), 2 => TwentySeventeen.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentySeventeen.Day11Part1(input).ToString(), 2 => TwentySeventeen.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentySeventeen.Day12Part1(input).ToString(), 2 => TwentySeventeen.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentySeventeen.Day13Part1(input).ToString(), 2 => TwentySeventeen.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentySeventeen.Day14Part1(input).ToString(), 2 => TwentySeventeen.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentySeventeen.Day15Part1(input).ToString(), 2 => TwentySeventeen.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentySeventeen.Day16Part1(input).ToString(), 2 => TwentySeventeen.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentySeventeen.Day17Part1(input).ToString(), 2 => TwentySeventeen.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentySeventeen.Day18Part1(input).ToString(), 2 => TwentySeventeen.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentySeventeen.Day19Part1(input).ToString(), 2 => TwentySeventeen.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentySeventeen.Day20Part1(input).ToString(), 2 => TwentySeventeen.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentySeventeen.Day21Part1(input).ToString(), 2 => TwentySeventeen.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentySeventeen.Day22Part1(input).ToString(), 2 => TwentySeventeen.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentySeventeen.Day23Part1(input).ToString(), 2 => TwentySeventeen.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentySeventeen.Day24Part1(input).ToString(), 2 => TwentySeventeen.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentySeventeen.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2016(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentySixteen.Day1Part1(input).ToString(), 2 => TwentySixteen.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentySixteen.Day2Part1(input).ToString(), 2 => TwentySixteen.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentySixteen.Day3Part1(input).ToString(), 2 => TwentySixteen.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentySixteen.Day4Part1(input).ToString(), 2 => TwentySixteen.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentySixteen.Day5Part1(input).ToString(), 2 => TwentySixteen.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentySixteen.Day6Part1(input).ToString(), 2 => TwentySixteen.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentySixteen.Day7Part1(input).ToString(), 2 => TwentySixteen.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentySixteen.Day8Part1(input).ToString(), 2 => TwentySixteen.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentySixteen.Day9Part1(input).ToString(), 2 => TwentySixteen.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentySixteen.Day10Part1(input).ToString(), 2 => TwentySixteen.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentySixteen.Day11Part1(input).ToString(), 2 => TwentySixteen.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentySixteen.Day12Part1(input).ToString(), 2 => TwentySixteen.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentySixteen.Day13Part1(input).ToString(), 2 => TwentySixteen.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentySixteen.Day14Part1(input).ToString(), 2 => TwentySixteen.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentySixteen.Day15Part1(input).ToString(), 2 => TwentySixteen.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentySixteen.Day16Part1(input).ToString(), 2 => TwentySixteen.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentySixteen.Day17Part1(input).ToString(), 2 => TwentySixteen.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentySixteen.Day18Part1(input).ToString(), 2 => TwentySixteen.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentySixteen.Day19Part1(input).ToString(), 2 => TwentySixteen.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentySixteen.Day20Part1(input).ToString(), 2 => TwentySixteen.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentySixteen.Day21Part1(input).ToString(), 2 => TwentySixteen.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentySixteen.Day22Part1(input).ToString(), 2 => TwentySixteen.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentySixteen.Day23Part1(input).ToString(), 2 => TwentySixteen.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentySixteen.Day24Part1(input).ToString(), 2 => TwentySixteen.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentySixteen.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        private static string ExecuteYear2015(int day, int part, string[] input) => day switch
        {
            1 => part switch { 1 => TwentyFifteen.Day1Part1(input).ToString(), 2 => TwentyFifteen.Day1Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            2 => part switch { 1 => TwentyFifteen.Day2Part1(input).ToString(), 2 => TwentyFifteen.Day2Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            3 => part switch { 1 => TwentyFifteen.Day3Part1(input).ToString(), 2 => TwentyFifteen.Day3Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            4 => part switch { 1 => TwentyFifteen.Day4Part1(input).ToString(), 2 => TwentyFifteen.Day4Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            5 => part switch { 1 => TwentyFifteen.Day5Part1(input).ToString(), 2 => TwentyFifteen.Day5Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            6 => part switch { 1 => TwentyFifteen.Day6Part1(input).ToString(), 2 => TwentyFifteen.Day6Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            7 => part switch { 1 => TwentyFifteen.Day7Part1(input).ToString(), 2 => TwentyFifteen.Day7Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            8 => part switch { 1 => TwentyFifteen.Day8Part1(input).ToString(), 2 => TwentyFifteen.Day8Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            9 => part switch { 1 => TwentyFifteen.Day9Part1(input).ToString(), 2 => TwentyFifteen.Day9Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            10 => part switch { 1 => TwentyFifteen.Day10Part1(input).ToString(), 2 => TwentyFifteen.Day10Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            11 => part switch { 1 => TwentyFifteen.Day11Part1(input).ToString(), 2 => TwentyFifteen.Day11Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            12 => part switch { 1 => TwentyFifteen.Day12Part1(input).ToString(), 2 => TwentyFifteen.Day12Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            13 => part switch { 1 => TwentyFifteen.Day13Part1(input).ToString(), 2 => TwentyFifteen.Day13Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            14 => part switch { 1 => TwentyFifteen.Day14Part1(input).ToString(), 2 => TwentyFifteen.Day14Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            15 => part switch { 1 => TwentyFifteen.Day15Part1(input).ToString(), 2 => TwentyFifteen.Day15Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            16 => part switch { 1 => TwentyFifteen.Day16Part1(input).ToString(), 2 => TwentyFifteen.Day16Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            17 => part switch { 1 => TwentyFifteen.Day17Part1(input).ToString(), 2 => TwentyFifteen.Day17Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            18 => part switch { 1 => TwentyFifteen.Day18Part1(input).ToString(), 2 => TwentyFifteen.Day18Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            19 => part switch { 1 => TwentyFifteen.Day19Part1(input).ToString(), 2 => TwentyFifteen.Day19Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            20 => part switch { 1 => TwentyFifteen.Day20Part1(input).ToString(), 2 => TwentyFifteen.Day20Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            21 => part switch { 1 => TwentyFifteen.Day21Part1(input).ToString(), 2 => TwentyFifteen.Day21Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            22 => part switch { 1 => TwentyFifteen.Day22Part1(input).ToString(), 2 => TwentyFifteen.Day22Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            23 => part switch { 1 => TwentyFifteen.Day23Part1(input).ToString(), 2 => TwentyFifteen.Day23Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            24 => part switch { 1 => TwentyFifteen.Day24Part1(input).ToString(), 2 => TwentyFifteen.Day24Part2(input).ToString(), _ => throw new ArgumentException("Invalid part") },
            25 => part switch { 1 => TwentyFifteen.Day25Part1(input).ToString(), _ => throw new ArgumentException("Day 25 part 2 does not exist") },
            _ => throw new ArgumentException($"Day {day} is not supported")
        };

        #endregion
    }
}
