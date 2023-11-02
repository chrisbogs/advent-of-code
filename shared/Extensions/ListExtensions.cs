using AdventOfCodeShared.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Extensions
{
    public static class ListExtensions
    {
        public static bool FullyContains(this List<long> set1, List<long> set2)
        {
            if (!set1.Any() || !set2.Any()) return false;

            return set1[0] <= set2[0] && set1[1] >= set2[1];
        }
        public static bool HasIntersection(this List<long> set1, List<long> set2)
        {
            if (!set1.Any() || !set2.Any()) return false;

            return
                (set1[0] <= set2[0] && set1[1] >= set2[0])
                || (set1[0] <= set2[1] && set1[1] >= set2[1])
                ;
        }

        public static List<GridNode<T>> ReturnSmallestNonEmpty<T>(
            this List<GridNode<T>> list1, 
            List<GridNode<T>> list2) where T:struct
        {
            if (list1 is null || !list1.Any()) return list2;
            if (list2 is null || !list2.Any()) return list1;
            
            if (list1.Count <= list2.Count) return list1;
            return list2;
        }
    }
}
