using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;

namespace AdventOfCodeShared.Logic
{
    public class TwentySeventeen
    {
        public static long Day1Part1(string[] input)
        {
            var numbers = input[0].ParseIntsOnLine("").ToArray();
            //find the sum of all digits that match the next digit in the list. The list is circular, so the digit after the last digit is the first digit in the list
            int i = 0;
            var sum = 0;
            while (i < numbers.Length)
            {
                var nextIndex = (i + 1) % numbers.Length;
                if (numbers[i] == numbers[nextIndex])
                {
                    sum += numbers[i];
                }
                i++;
            }
            return sum;
        }
        /// <summary>
        /// Now, instead of considering the next digit, it wants you to consider the digit halfway around the circular list. That is, if your list contains 10 items, only include a digit in your sum if the digit 10/2 = 5 steps forward matches it. Fortunately, your list has an even number of elements.
        /// </summary>
        public static long Day1Part2(string[] input)
        {
            var numbers = input[0].ParseIntsOnLine("").ToArray();
            //find the sum of all digits that match the halfway around digit in the list.
            //The list is circular, so the digit after the last digit is the first digit in the list
            int i = 0;
            var sum = 0;
            int midIndex = numbers.Length / 2;
            while (i < numbers.Length)
            {
                var nextIndex = (i + midIndex) % numbers.Length;
                if (numbers[i] == numbers[nextIndex])
                {
                    sum += numbers[i];
                }
                i++;
            }
            return sum;
        }

        public static long Day2Part1(string[] input)
        {
            //Calculate Checksum
            //For each row, determine the difference between the largest value and the smallest value; the checksum is the sum of all of these differences.
            if (input is null) return 0;
            return input.ParseIntsMultiplePerLine()?
                .Where(x=>x.Any())
                .Select(line => Math.Abs(line.Max() - line.Min()))?.Sum() ?? 0;
        }
        public static long Day2Part2(string[] input)
        {
            return 0;
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