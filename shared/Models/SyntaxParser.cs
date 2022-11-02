using AdventOfCodeShared.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models
{
    public class SyntaxParser
    {
        private readonly string[] validOpenings = Array.Empty<string>();
        private readonly string[] validClosings = Array.Empty<string>();
        private string[] InvalidTokens = Array.Empty<string>();
        private readonly Dictionary<string, int> scoreMap = new();
        private readonly Dictionary<string, string> tokenMap = new();
        private long[] AutoCompleteTokens = Array.Empty<long>();

        // assume these three arrays are the same length for brevity
        public SyntaxParser(string[] openings, string[] closings, int[] scores)
        {
            this.validOpenings = openings;
            this.validClosings = closings;
            for(int i = 0; i < this.validClosings.Length; i++)
            {
                this.scoreMap.Add(validClosings[i], scores[i]);
            }
            for (int i = 0; i < this.validOpenings.Length; i++)
            {
                this.tokenMap.Add(validOpenings[i], validClosings[i]);
            }
        }

        public long GetAutoCompletedTokensScore()
        {
            var sorted = this.AutoCompleteTokens.OrderBy(x=>x).ToList();
            return sorted[(int)Math.Floor(this.AutoCompleteTokens.Length / 2.0)];
        }

        public long GetInvalidTokensScore()
        {
            long result = 0;
            foreach (var x in this.InvalidTokens)
            {
                if (scoreMap.ContainsKey(x))
                {
                    result += scoreMap[x];
                }
            }
            return result;
        }

        public string Validate(string line)
        {
            var error = string.Empty;
            var openings = new List<char>();

            var characters = line.ToList();
            openings.Add(characters[0]);
            foreach (var c in characters.Skip(1))
            {
                // validate character
                if (this.validClosings.Contains(c.ToString()))
                {
                    var expectedToken = this.tokenMap[openings[openings.Count - 1].ToString()];
                    if (expectedToken == c.ToString())
                    {
                        // matching end token
                        openings.RemoveAt(openings.Count-1);
                    }
                    else
                    {
                        InvalidTokens = InvalidTokens.Add(c.ToString());
                        return $"Expected {expectedToken}, but found {c} instead.";
                    }
                }
                else if (this.validOpenings.Contains(c.ToString()))
                {
                    // new open token
                    openings.Add(c);
                }
                else return "invalid character: " + c.ToString();
            }

            if (openings.Count > 0)
            {
                long lineScore = 0;
                var closings = Array.Empty<string>();
                openings.Reverse();
                foreach (var x in openings)
                {
                    if (this.tokenMap.ContainsKey(x.ToString()))
                    {
                        var val = this.tokenMap[x.ToString()];
                        closings = closings.Add(val);
                        if (scoreMap.ContainsKey(val.ToString()))
                        {
                            var score = this.scoreMap[val];
                            lineScore = lineScore * 5 + score;
                        }
                    }
                }
                AutoCompleteTokens = AutoCompleteTokens.Add(lineScore);
                return string.Join("", closings);
            }
            return error;
        }
 
        public void ValidateLines(string[] lines)
        {
            this.InvalidTokens = Array.Empty<string>();
            this.AutoCompleteTokens = Array.Empty<long>();
            foreach (var x in lines)
            {
                this.Validate(x);
            }
        }
    }
}