using AdventOfCodeShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AdventOfCodeShared.Services
{
    public class Helpers
    {
        private const int magicNumber = 2020;

        // TODO: make this a generate algorithm to gather the permutations of the `numbers` collection
        public static int Get2NumbersThatSumUpTo(IEnumerable<int> numbers)
        {
            var l = numbers.Where(x => x <= magicNumber).OrderBy(x => x).ToList();
            var length = l.Count();
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
            var length = l.Count();
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

        private enum Compass
        {
            North,
            East,
            South,
            West
        }
        internal static long FollowPath(List<Tuple<char, long>> directions)
        {
            long xAxis = 0;
            long yAxis = 0;
            var currentHeading = Compass.North;
            foreach(var (direction, distance) in directions)
            {
                if (direction == 'R')
                {
                    currentHeading = (Compass)(((int)currentHeading + 1) % 4);
                }
                else if (direction == 'L')
                {
                    currentHeading = (Compass)(((int)currentHeading - 1 + 4) % 4);
                }

                switch (currentHeading)
                {
                    case Compass.East: xAxis += distance; break;
                    case Compass.North: yAxis += distance; break;
                    case Compass.West: xAxis -= distance; break;
                    case Compass.South: yAxis -= distance; break;
                }

            }

            return Math.Abs(xAxis-0) + Math.Abs(yAxis-0);
        }
    }
}