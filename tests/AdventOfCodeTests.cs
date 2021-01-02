using AdventOfCodeShared.Extensions;
using AdventOfCodeShared.Models;
using AdventOfCodeShared.Services;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace tests
{
    public class AdventOfCodeTests
    {
        [Fact]
        public void Day1()
        {
            var sut = new YearController(new InputRetriever(new System.Net.Http.HttpClient(), "../../../../shared/PuzzleInput/2020/1.txt"));
            Assert.Equal(290784, sut.Day1Part1(2020));
            Assert.Equal(241861950, Helpers.Get3NumbersThatSumUpTo(new List<int>() { 1721, 979, 366, 299, 675, 1456 }));
            Assert.Equal(514579, Helpers.Get2NumbersThatSumUpTo(new List<int>() { 1721, 979, 366, 299, 675, 1456 }));
            Assert.Equal(177337980, sut.Day1Part2(2020));
        }

        [Fact]
        public void Day2()
        {
            var sut = new YearController(new InputRetriever(new System.Net.Http.HttpClient(), "../../../../shared/PuzzleInput/2020/2.txt"));
            var parsed = StringExtensions.ParsePasswords(new string[1] { "2-6 c: fcpwjqhcgtffzlbj" }).First();
            Assert.Equal('c', parsed.Character);
            Assert.Equal(2, parsed.First);
            Assert.Equal(6, parsed.Second);
            Assert.Equal("fcpwjqhcgtffzlbj", parsed.Password);

            Assert.True(new PasswordWithRule('c', 2, 6, "fcpwjqhcgtffzlbj").IsValidv1());
            Assert.True(new PasswordWithRule('c', 2, 6, "fcpwjqhcgtffzlbj").IsValidv2());
            Assert.Equal(582, sut.Day2Part1(2020));
            Assert.Equal(729, sut.Day2Part2(2020));
        }
        [Fact]
        public void Day3()
        {
            var testMap = new Map(new List<string>(){
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            }.ToArray());
            Assert.Equal(
                "..##.......\n#...#...#..\n.#....#..#.\n..#.#...#.#\n.#...##..#.\n..#.##.....\n.#.#.#....#\n.#........#\n#.##...#...\n#...##....#\n.#..#...#.#\n",
                testMap.Print());
            Assert.Equal(7, testMap.TraverseAndCountTrees(new Toboggan(){Right=3, Down=1}));

            var sut = new YearController(new InputRetriever(new System.Net.Http.HttpClient(), "../../../../shared/PuzzleInput/2020/3.txt"));
            Assert.Equal(173, sut.Day3Part1(2020));
            Assert.Equal(new List<long>(){2,7,3,4,2},
            new List<Toboggan>(){
                new Toboggan(){Right=1, Down=1},
                new Toboggan(){Right=3, Down=1},
                new Toboggan(){Right=5, Down=1},
                new Toboggan(){Right=7, Down=1},
                new Toboggan(){Right=1, Down=2}
            }
            .Select(s => testMap.TraverseAndCountTrees(s)).ToList());
            Assert.Equal(4385176320, sut.Day3Part2(2020));
        }

        [Fact]
        public void Day4()
        {
            var testData = new string[] {
                    "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\n"
                    ,"byr:1937 iyr:2017 cid:147 hgt:183cm\n"
                    ,""
                    ,"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\n"
                    ,"hcl:#cfa07d byr:1929\n"
                    ,""
                    ,"hcl:#ae17e1 iyr:2013\n"
                    ,"eyr:2024\n"
                    ,"ecl:brn pid:760753108 byr:1931\n"
                    ,"hgt:179cm\n"
                    ,""
                    ,"hcl:#cfa07d eyr:2025 pid:166559648\n"
                    ,"iyr:2011 ecl:brn hgt:59in\n"};
            var passports = Passport.ParsePassports(testData);
            Assert.Equal(4, passports.Count());
            Assert.Equal(2, passports.Count(x=>x.IsValid));
            var sut = new YearController(new InputRetriever(new System.Net.Http.HttpClient(), "../../../../shared/PuzzleInput/2020/4.txt"));
            Assert.Equal(210, sut.Day4Part1(2020));
            // Assert.Equal(0, sut.Day4Part2(2020));
        }

    }
}
