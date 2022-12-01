using AdventOfCodeShared.Models.Geometry;
using AdventOfCodeShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Logic
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
            foreach (var oi in orbitInstructions.Where(x => x.Count() > 0))
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
                    on = new ObjectNode() { Name = name };
                    on.Orbitting = new LinkedList<ObjectNode>();
                    allObjects.Add(name, on);
                }

                ObjectNode orbitting;
                if (allObjects.ContainsKey(orbittingObjectName))
                {
                    orbitting = allObjects[orbittingObjectName];
                }
                else
                {
                    orbitting = new ObjectNode() { Name = orbittingObjectName };
                    orbitting.Orbitting = new LinkedList<ObjectNode>();
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

    }
}