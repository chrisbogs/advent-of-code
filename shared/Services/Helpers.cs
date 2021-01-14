using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using AdventOfCodeShared;
using AdventOfCodeShared.Extensions;

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
            return s.Count(x=>x.Equals('(')) - s.Count(x=>x.Equals(')'));
        }
        public static int WhichPositionMovesUsToBasement(string s)
        {
            int position = 1;
            int currentFloor = 0;
            foreach(var c in s){
                if (c.Equals('(')){
                    currentFloor += 1;
                }
                else if (c.Equals(')')){
                    currentFloor -= 1;
                }

                if (currentFloor == -1) return position;
                position++;
            }
            return -1;
        }
    }
}