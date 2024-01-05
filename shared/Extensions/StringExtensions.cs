using adventOfCodeShared.Logic;
using AdventOfCodeShared.Models;
using System;
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

        public static IEnumerable<int> ParseIntsOnePerLine(this string[] s)
        {
            if (s is null || !s.Any()) return Enumerable.Empty<int>();
            var splitContents = new List<string>(s);
            return splitContents.Where(line => !string.IsNullOrWhiteSpace(line))
                .Where(w => int.TryParse(w, out _)).Select(x => int.Parse(x));
        }

        public static IEnumerable<List<int>> ParseIntsMultiplePerLine(this string[] s)
        {
            var result = new List<List<int>>();
            if (s is null || !s.Any()) return result;
            foreach (var line in s)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                
                var intsOnLine = ParseIntsOnLine(line);
                if (intsOnLine.Any())
                {
                    result.Add(intsOnLine);
                }
            }
            return result;
        }

        /// <summary>
        /// Convert a digit string to a collection of digits
        /// </summary>
        /// <param name="separators">If "" is passed, we make each character of the string into a list of strings</param>
        public static List<int> ParseIntsOnLine(this string line, string separators = " \t")
        {
            var result = new List<int>();
            if (line is null || !line.Any() || string.IsNullOrWhiteSpace(line)) return result;

            string[] tokens;
            if (separators != string.Empty)
            {
                tokens = line.Split(separators.ToCharArray(), StringSplitOptions.None);
            }
            else
            {
                tokens = line.Select(x=>x.ToString()).ToArray();
            }

            foreach (string token in tokens)
            {
                var x = token.Trim();
                if (string.IsNullOrWhiteSpace(token) || !int.TryParse(token.ToString(), out _))
                {
                    continue;
                }
                result.Add(int.Parse(x.ToString()));
            }
            return result;
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

        public static string FlipBitString(this string bitString)
        {
            return new string(
                bitString
                .Select(c => c == '0' ? '1' : '0')
                .ToArray());
        }

        public static string FindFirstDigit(this string line)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    return line[i].ToString();
                }
            }
            return string.Empty;
        }
        /// <summary>
        /// Returns first numeric digit (9) or first string of a digit (nine)
        /// </summary>
        public static string FindFirstRepresentationOfDigit(this string line)
        {
            for (var i = 0; i < line.Length; i++)
            {
                if (char.IsDigit(line[i]))
                {
                    return line[i].ToString();
                }
                
                var lowercaseParsed = line.Substring(0, i+1).ToLower();
                var digitString = Constants.DigitRepresentations.FirstOrDefault(x=> lowercaseParsed.Contains(x.Value));
                if (digitString.Value is not null)
                {
                    return digitString.Key.ToString();
                }
            }
            return string.Empty;
        }

        public static string FindLastDigit(this string line)
        {
            for (var i = line.Length-1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    return line[i].ToString();
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Returns first numeric digit (9) or first string of a digit (nine)
        /// </summary>
        public static string FindLastRepresentationOfDigit(this string line)
        {
            for (var i = line.Length - 1; i >= 0; i--)
            {
                if (char.IsDigit(line[i]))
                {
                    return line[i].ToString();
                }

                var lowercaseParsed = line[i..].ToLower();
                var digitString = Constants.DigitRepresentations.FirstOrDefault(x => lowercaseParsed.Contains(x.Value));
                if (digitString.Value is not null)
                {
                    return digitString.Key.ToString();
                }
            }
            return string.Empty;
        }

        public static IEnumerable<string[]> ParseTokens(this string[] tokens, string separator)
        {
            return tokens.Select(x => x.Split(separator));
        }

    }
}
