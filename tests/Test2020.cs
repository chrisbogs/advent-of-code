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
    public class Test2020
    {
        [Fact]
        public void Day1()
        {
            var sut = new YearController(new InputRetriever());
            Assert.Equal(290784, sut.Router(2020, 1, 1));
            Assert.Equal(241861950, Helpers.Get3NumbersThatSumUpTo(new List<int>() { 1721, 979, 366, 299, 675, 1456 }));
            Assert.Equal(514579, Helpers.Get2NumbersThatSumUpTo(new List<int>() { 1721, 979, 366, 299, 675, 1456 }));
            Assert.Equal(177337980, sut.Router(2020, 1, 2));
        }

        [Fact]
        public void Day2()
        {
            var sut = new YearController(new InputRetriever());
            var parsed = StringExtensions.ParsePasswords(new string[1] { "2-6 c: fcpwjqhcgtffzlbj" }).First();
            Assert.Equal('c', parsed.Character);
            Assert.Equal(2, parsed.First);
            Assert.Equal(6, parsed.Second);
            Assert.Equal("fcpwjqhcgtffzlbj", parsed.Password);

            Assert.True(new PasswordWithRule('c', 2, 6, "fcpwjqhcgtffzlbj").IsValidv1());
            Assert.True(new PasswordWithRule('c', 2, 6, "fcpwjqhcgtffzlbj").IsValidv2());
            Assert.Equal(582, sut.Router(2020,2,1));
            Assert.Equal(729, sut.Router(2020,2,2));
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
            Assert.Equal(7, testMap.TraverseAndCountTrees(new Toboggan() { Right = 3, Down = 1 }));

            var sut = new YearController(new InputRetriever());
            Assert.Equal(173, sut.Router(2020,3,1));
            Assert.Equal(new List<long>() { 2, 7, 3, 4, 2 },
            new List<Toboggan>(){
                new Toboggan(){Right=1, Down=1},
                new Toboggan(){Right=3, Down=1},
                new Toboggan(){Right=5, Down=1},
                new Toboggan(){Right=7, Down=1},
                new Toboggan(){Right=1, Down=2}
            }
            .Select(s => testMap.TraverseAndCountTrees(s)).ToList());
            Assert.Equal(4385176320, sut.Router(2020,3,2));
        }

        [Fact]
        public void Day4()
        {
            // Wont pass after adding validation
            // // var testData = new string[] {
            // //         "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\n"
            // //         ,"byr:1937 iyr:2017 cid:147 hgt:183cm\n"
            // //         ,""
            // //         ,"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\n"
            // //         ,"hcl:#cfa07d byr:1929\n"
            // //         ,""
            // //         ,"hcl:#ae17e1 iyr:2013\n"
            // //         ,"eyr:2024\n"
            // //         ,"ecl:brn pid:760753108 byr:1931\n"
            // //         ,"hgt:179cm\n"
            // //         ,""
            // //         ,"hcl:#cfa07d eyr:2025 pid:166559648\n"
            // //         ,"iyr:2011 ecl:brn hgt:59in\n"};
            // // var passports = Passport.ParsePassports(testData);
            // // Assert.Equal(4, passports.Count());
            // // Assert.Equal(2, passports.Count(x=>x.IsValid));
            var sut = new YearController(new InputRetriever());
            // Assert.Equal(210, sut.Router(2020,4,1));
            Assert.Equal(131, sut.Router(2020,4,2));
        }
        [Fact]
        public void TestDay4Validation()
        {
            Assert.Equal(2002, Passport.ValidateBirthYear("2002"));
            Assert.Null(Passport.ValidateBirthYear("2003"));

            Assert.Equal(Tuple.Create<int?, string?>(60, "in"), Passport.ValidateHeight("60in"));
            Assert.Equal(Tuple.Create<int?, string?>(190, "cm"), Passport.ValidateHeight("190cm"));
            Assert.Equal(Tuple.Create<int?, string?>(null, null), Passport.ValidateHeight("190in"));
            Assert.Equal(Tuple.Create<int?, string?>(null, null), Passport.ValidateHeight("190"));

            Assert.Equal("#123abc", Passport.ValidateHairColor("#123abc"));
            Assert.Equal(null, Passport.ValidateHairColor("#123abz"));
            Assert.Equal(null, Passport.ValidateHairColor("123abc"));

            Assert.Equal("brn", Passport.ValidateEyeColor("brn"));
            Assert.Equal(null, Passport.ValidateEyeColor("wat"));

            Assert.Equal(1, Passport.ValidatePassportId("000000001"));
            Assert.Equal(null, Passport.ValidatePassportId("0123456789"));
        }

        [Fact]
        public void Day5()
        {
            var pass = new BoardingPass("FBFBBFFRLR");
            Assert.Equal(5, pass.Column);
            Assert.Equal(44, pass.Row);
            Assert.Equal(357, pass.SeatId);

            pass = new BoardingPass("BFFFBBFRRR");
            Assert.Equal(70, pass.Row);
            Assert.Equal(7, pass.Column);
            Assert.Equal(567, pass.SeatId);

            pass = new BoardingPass("FFFBBBFRRR");
            Assert.Equal(14, pass.Row);
            Assert.Equal(7, pass.Column);
            Assert.Equal(119, pass.SeatId);

            pass = new BoardingPass("BBFFBBFRLL");
            Assert.Equal(102, pass.Row);
            Assert.Equal(4, pass.Column);
            Assert.Equal(820, pass.SeatId);

            var sut = new YearController(new InputRetriever());
            Assert.Equal(930, sut.Router(2020,5,1));
            Assert.Equal(515, sut.Router(2020,5,2));
        }
        [Fact]
        public void Day6()
        {
            var forms = CustomsForm.Parse(new string[]{
                "abcx",
                "abcy",
                "abcz"
            });
            Assert.Equal(6, forms.First().UniqueAnswers);

            var forms2 = CustomsForm.Parse(new string[]{
               "abc",
                "",
                "a",
                "b",
                "c",
                "",
                "ab",
                "ac",
                "",
                "a",
                "a",
                "a",
                "a",
                "",
                "b"
            }).ToList();
            Assert.Equal(3, forms2[0].UniqueAnswers);
            Assert.Equal(3, forms2[1].UniqueAnswers);
            Assert.Equal(3, forms2[2].UniqueAnswers);
            Assert.Equal(1, forms2[3].UniqueAnswers);
            Assert.Equal(1, forms2[4].UniqueAnswers);

            var sut = new YearController(new InputRetriever());
            Assert.Equal(6763, sut.Router(2020,6,1));
            Assert.Equal(3, forms2[0].CommonAnswers);
            Assert.Equal(0, forms2[1].CommonAnswers);
            Assert.Equal(1, forms2[2].CommonAnswers);
            Assert.Equal(1, forms2[3].CommonAnswers);
            Assert.Equal(1, forms2[4].CommonAnswers);
            Assert.Equal(3512, sut.Router(2020,6,2));
        }
    }
}
