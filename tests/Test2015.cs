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

        }

        [Fact]
        public void TestDay3()
        {

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
