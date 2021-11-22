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
    public class Test2015
    {
        [Fact]
        public void TestDay1()
        {
            Assert.Equal(0, Helpers.WhichFloorDoWeEndUpOn("(())"));
            Assert.Equal(0, Helpers.WhichFloorDoWeEndUpOn("()() "));
            Assert.Equal(3, Helpers.WhichFloorDoWeEndUpOn("((("));
            Assert.Equal(3, Helpers.WhichFloorDoWeEndUpOn("(()(()("));
            Assert.Equal(3, Helpers.WhichFloorDoWeEndUpOn("))((((("));
            Assert.Equal(-1, Helpers.WhichFloorDoWeEndUpOn("())"));
            Assert.Equal(-1, Helpers.WhichFloorDoWeEndUpOn("))("));
            Assert.Equal(-3, Helpers.WhichFloorDoWeEndUpOn(")))"));
            Assert.Equal(-3, Helpers.WhichFloorDoWeEndUpOn(")())())"));

            Assert.Equal(1, Helpers.WhichPositionMovesUsToBasement(")"));
            Assert.Equal(5, Helpers.WhichPositionMovesUsToBasement("()())"));

            var sut = new YearController(new InputRetriever());

            Assert.Equal("138", sut.Router(2015,1,1));
            Assert.Equal("1771", sut.Router(2015,1,2));
        }

        [Fact]
        public void TestDay2()
        {
            Assert.Equal(58, TwentyFifteen.Day2Part1(new string[]{"2x3x4"}));
            Assert.Equal(43, TwentyFifteen.Day2Part1(new string[]{"1x1x10"}));
            var sut = new YearController(new InputRetriever());

            Assert.Equal("1586300", sut.Router(2015, 2, 1));
            Assert.Equal(10, new RectangularPrism(1,1,10).Volume);
            Assert.Equal(10, new RectangularPrism(2,3,4).SmallestPerimeterOfAnyFace);
            Assert.Equal(24, new RectangularPrism(2,3,4).Volume);
            Assert.Equal(34, TwentyFifteen.Day2Part2(new string[]{"2x3x4"}));
            Assert.Equal(14, TwentyFifteen.Day2Part2(new string[]{ "1x1x10" }));
            Assert.Equal("3737498", sut.Router(2015, 2, 2));
        }

        [Fact]
        public void TestDay3()
        {
            Assert.Equal(2, TwentyFifteen.Day3Part1(new string[] { ">" }));
            Assert.Equal(4, TwentyFifteen.Day3Part1(new string[] { "^>v<" }));
            Assert.Equal(2, TwentyFifteen.Day3Part1(new string[] { "^v^v^v^v^v" }));
            var sut = new YearController(new InputRetriever());

            Assert.Equal("2081", sut.Router(2015, 3, 1));
            Assert.Equal(3, TwentyFifteen.Day3Part2(new string[] { "^v" }));
            Assert.Equal(3, TwentyFifteen.Day3Part2(new string[] { "^>v<" }));
            Assert.Equal(11, TwentyFifteen.Day3Part2(new string[] { "^v^v^v^v^v" }));
            Assert.Equal("2341", sut.Router(2015, 3, 2));
        }

        [Fact]
        public void TestDay4()
        {

        }

        [Fact]
        public void TestDay5()
        {

        }

        [Fact]
        public void TestDay6()
        {

        }

        [Fact]
        public void TestDay7()
        {

        }

        [Fact]
        public void TestDay8()
        {

        }

        [Fact]
        public void TestDay9()
        {

        }

        [Fact]
        public void TestDay10()
        {


        }

        [Fact]
        public void TestDay11()
        {
        }

        [Fact]
        public void TestDay12()
        {
        }

        [Fact]
        public void TestDay13()
        {
        }

        [Fact]
        public void TestDay14()
        {

        }

        [Fact]
        public void TestDay15()
        {
        }

        [Fact]
        public void TestDay16()
        {
        }

        [Fact]
        public void TestDay17()
        {
        }

        [Fact]
        public void TestDay18()
        {
        }

        [Fact]
        public void TestDay19()
        {
        }

        [Fact]
        public void TestDay20()
        {
        }

        [Fact]
        public void TestDay21()
        {
        }

        [Fact]
        public void TestDay22()
        {
        }

        [Fact]
        public void TestDay23()
        {
        }

        [Fact]
        public void TestDay24()
        {
        }

        [Fact]
        public void TestDay25()
        {
        }
    }
}
