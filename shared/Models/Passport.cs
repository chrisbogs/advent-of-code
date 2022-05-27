using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCodeShared.Models
{
    public class Passport
    {
        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpirationYear { get; set; }
        public int? Height { get; set; }
        public string HeightUnitOfMeasure { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public long? PassportId { get; set; }
        public long? CountryId { get; set; }

        private static class UnitOfMeasure
        {
            public readonly static string Centimetre = "cm";
            public readonly static string Inch = "in";
        }
        private static string[] EyeColors = new string[]{
            "amb",
            "blu",
            "brn",
            "gry",
            "grn",
            "hzl",
            "oth"
        };

        public Passport()
        {
        }

        public bool IsValid
        {
            get
            {
                var hasValues = BirthYear.HasValue
                        && IssueYear.HasValue
                        && ExpirationYear.HasValue
                        && Height.HasValue
                        && HairColor != null
                        && EyeColor != null
                        && PassportId != null;
                return hasValues;
            }
        }

        // Returns a list of valid passports that it finds in the text.
        public static IEnumerable<Passport> ParsePassports(string[] lines)
        {
            var passports = new List<Passport>();
            Passport current = new();
            foreach (var line in lines)
            {
                if (line == "")
                {
                    if (current.IsValid)
                    {
                        passports.Add(current);
                    }
                    current = new();
                    continue;
                }

                var blocks = line.Split();
                foreach (var block in blocks)
                {
                    var kvs = block.Split(':');
                    if (kvs[0] == "byr")
                    {
                        current.BirthYear = ValidateBirthYear(kvs[1]);
                    }
                    else if (kvs[0] == "iyr")
                    {
                        current.IssueYear = ValidateIssueYear(kvs[1]);
                    }
                    else if (kvs[0] == "eyr")
                    {
                        current.ExpirationYear = ValidateExpirationYear(kvs[1]);
                    }
                    else if (kvs[0] == "hgt")
                    {
                        var tuple = ValidateHeight(kvs[1]);
                        current.Height = tuple.Item1;
                        current.HeightUnitOfMeasure = tuple.Item2;
                    }
                    else if (kvs[0] == "hcl")
                    {
                        current.HairColor = ValidateHairColor(kvs[1]);
                    }
                    else if (kvs[0] == "ecl")
                    {
                        current.EyeColor = ValidateEyeColor(kvs[1]);
                    }
                    else if (kvs[0] == "pid")
                    {
                        current.PassportId = ValidatePassportId(kvs[1]);
                    }
                    else if (kvs[0] == "cid")
                    {
                        current.CountryId = int.Parse(kvs[1]);
                    }
                }
            }
            if (current.IsValid)
            {
                //workaround for parsing the last passport
                passports.Add(current);
            }

            return passports;
        }

        public static int? ValidateBirthYear(string s)
        {
            if (Regex.IsMatch(s, @"^\d{4}$"))
            {
                var byr = int.Parse(s);
                if (byr >= 1920 && byr <= 2002)
                {
                    return byr;
                }
            }
            return null;
        }
        public static int? ValidateIssueYear(string s)
        {
            if (Regex.IsMatch(s, @"^\d{4}$"))
            {
                var iyr = int.Parse(s);
                if (iyr >= 2010 && iyr <= 2020) { return iyr; }
            }
            return null;
        }
        public static int? ValidateExpirationYear(string s)
        {
            if (Regex.IsMatch(s, @"^\d{4}$"))
            {
                var eyr = int.Parse(s);
                if (eyr >= 2020 && eyr <= 2030) { return eyr; }
            }
            return null;
        }
        public static Tuple<int?, string> ValidateHeight(string s)
        {
            // format xxxcm or xxxin
            if (Regex.IsMatch(s, @"^\d+(cm|in)$"))
            {
                string uom = s.Substring(s.Length - 2);
                var hgt = s.Substring(0, s.Length - 2);
                int? val = int.Parse(hgt);
                if ((uom == UnitOfMeasure.Centimetre && val >= 150 && val <= 193)
                    || (uom == UnitOfMeasure.Inch && val >= 59 && val <= 76))
                {
                    return Tuple.Create<int?, string>(val, uom);
                }
            }
            return Tuple.Create<int?, string>(null, null);
        }
        public static string ValidateHairColor(string s)
        {
            if (Regex.IsMatch(s, @"#[0123456789abcdef]{6}"))
            {
                return s;
            }
            return null;
        }
        public static string ValidateEyeColor(string s)
        {
            return EyeColors.Contains(s) ? s : null;
        }
        public static long? ValidatePassportId(string s)
        {
            if (Regex.IsMatch(s, @"^\d{9}$"))
            {
                return long.Parse(s);
            }
            return null;
        }
    }
}
