using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCodeShared.Models
{
    public class Passport
    {
        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpirationYear { get; set; }
        public string? Height { get; set; }
        public string? HairColor { get; set; }
        public string? EyeColor { get; set; }
        public string? PassportId { get; set; }
        public int? CountryId { get; set; }

        public Passport()
        {
        }

        public bool IsValid => BirthYear.HasValue
            && IssueYear.HasValue
            && ExpirationYear.HasValue
            && Height != null
            && HairColor != null
            && EyeColor != null
            && PassportId != null;

        public static IEnumerable<Passport> ParsePassports(string[] lines)
        {
            var passports = new List<Passport>();
            Passport current = new();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    passports.Add(current);
                    current = new();
                    continue;
                }

                var blocks = line.Split();
                foreach (var block in blocks)
                {
                    // ignoring format validation; assuming text in the form <prop>:<value> ...
                    var kvs = block.Split(':');
                    if (kvs[0] == "byr")
                    {
                        current.BirthYear = int.Parse(kvs[1]);
                    }
                    else if (kvs[0] == "iyr")
                    {
                        current.IssueYear = int.Parse(kvs[1]);
                    }
                    else if (kvs[0] == "eyr")
                    {
                        current.ExpirationYear = int.Parse(kvs[1]);
                    }
                    else if (kvs[0] == "hgt")
                    {
                        // format xxxcm or xxxin
                        current.Height = kvs[1];
                    }
                    else if (kvs[0] == "hcl")
                    {
                        current.HairColor = kvs[1];
                    }
                    else if (kvs[0] == "ecl")
                    {
                        current.EyeColor = kvs[1];
                    }
                    else if (kvs[0] == "pid")
                    {
//                         var success = long.TryParse(kvs[1], out var pid);
                        current.PassportId = kvs[1];
                    }
                    else if (kvs[0] == "cid")
                    {
                        current.CountryId = int.Parse(kvs[1]);
                    }
                }
            }

            //workaround for parsing the last passport
            passports.Add(current);

            return passports;
        }

    }
}
