using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Extensions
{
    public static class StringExtensions
    {
        public static string[] ReadFile(this string filePath)
        {
            return System.IO.File.ReadAllLines(filePath);
        }

        public static IEnumerable<int> ParseInts(this string[] s)
        {
            var splitContents = new List<string>(s);
            return splitContents.Where(w => int.TryParse(w, out _)).Select(x => int.Parse(x));
        }
    }
}
