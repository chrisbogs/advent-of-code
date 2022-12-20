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
        public static bool Hasintersection(this List<long> set1, List<long> set2)
        {
            if (!set1.Any() || !set2.Any()) return false;

            return
                (set1[0] <= set2[0] && set1[1] >= set2[0])
                || (set1[0] <= set2[1] && set1[1] >= set2[1])
                ;
        }
    }
}
