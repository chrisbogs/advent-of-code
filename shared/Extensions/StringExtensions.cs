using AdventOfCodeShared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCodeShared.Extensions
{
    public static class StringExtensions
    {
        public static async Task<string[]> ReadFile(this string filePath)
        {
            return await System.IO.File.ReadAllLinesAsync(filePath);
        }

        public static IEnumerable<int> ParseInts(this string[] s)
        {
            var splitContents = new List<string>(s);
            return splitContents.Where(w => int.TryParse(w, out _)).Select(x => int.Parse(x));
        }

        public static IEnumerable<PasswordWithRule> ParsePasswords(this string[] s)
        {
            // Each line gives the password policy and then the password.
            // The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid.
            // For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.
            var result = new List<PasswordWithRule>();
            foreach (var line in s)
            {
                var parts = line.Split(':');
                var policy = parts[0];
                var password = parts[1].Trim();

                var policyParts = policy.Split('-');
                var minCount = int.Parse(policyParts[0]);
                var parts2 = policyParts[1].Split(' ');
                var maxCount = int.Parse(parts2[0]);
                var character = (char)parts2[1].FirstOrDefault();
                result.Add(new PasswordWithRule(character, minCount, maxCount, password));
            }
            return result.AsEnumerable();
        }

    }
}
