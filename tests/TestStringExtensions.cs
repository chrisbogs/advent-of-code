using AdventOfCodeShared.Extensions;
using System.Collections.Generic;
using Xunit;

namespace Tests
{
    public class TestStringExtensions
    {
        [Fact]
        public void TestParseIntsOnLine_tabdelimiter()
        {
            var result = "626	2424	2593	139	2136	163	1689	367	2235	125	2365	924	135	2583	1425	2502".ParseIntsOnLine();
            Assert.Equal(new List<int>() { 626, 2424, 2593, 139, 2136, 163, 1689, 367, 2235, 125, 2365, 924, 135, 2583, 1425, 2502 }, result);
        }
        [Fact]
        public void TestParseIntsOnLine_spacedelimiter()
        {
            var result = "626 2424 2593 139 2136 163 1689 367 2235 125 2365 924 135 2583 1425 2502".ParseIntsOnLine();
            Assert.Equal(new List<int>() { 626, 2424, 2593, 139, 2136, 163, 1689, 367, 2235, 125, 2365, 924, 135, 2583, 1425, 2502 }, result);
        }

        [Fact]
        public void ParseIntsMultiplePerLine_single()
        {
            var result = new string[] { "626 2424 2593 139 2136 163 1689 367 2235 125 2365 924 135 2583 1425 2502" }.ParseIntsMultiplePerLine();
            Assert.Equal(new List<List<int>>() { new List<int>() { 626, 2424, 2593, 139, 2136, 163, 1689, 367, 2235, 125, 2365, 924, 135, 2583, 1425, 2502 } }, result);
        }
        [Fact]
        public void ParseIntsMultiplePerLine_multiple()
        {
            var result = new string[] { "626 2424 2593 ",
                "9 8 7",
                "3 4 66",
                "626 2424",
                "6 32"}.ParseIntsMultiplePerLine();
            Assert.Equal(new List<List<int>>() {
                new List<int>() { 626, 2424, 2593 },
                new List<int>() { 9,8,7},
                new List<int>() { 3,4,66},
                new List<int>() { 626,2424},
                new List<int>() { 6,32}
                }, result);
        }

        [Fact]
        public void ParseIntsOnePerLine_ReturnsEmptyForNullInput()
        {
            // Arrange
            string[] input = null;

            // Act
            IEnumerable<int> result = input.ParseIntsOnePerLine();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ParseIntsOnePerLine_ReturnsEmptyForEmptyInput()
        {
            // Arrange
            string[] input = new string[] { };

            // Act
            IEnumerable<int> result = input.ParseIntsOnePerLine();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ParseIntsOnePerLine_ParsesIntegersCorrectly()
        {
            // Arrange
            string[] input = new string[] { "1", "2", "3", "4", "5" };

            // Act
            IEnumerable<int> result = input.ParseIntsOnePerLine();

            // Assert
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void ParseIntsOnePerLine_IgnoresNonIntegerLines()
        {
            // Arrange
            string[] input = new string[] { "1", "abc", "3", "def", "5" };

            // Act
            IEnumerable<int> result = input.ParseIntsOnePerLine();

            // Assert
            Assert.Equal(new List<int> { 1, 3, 5 }, result);
        }

        [Fact]
        public void ParseIntsMultiplePerLine_ReturnsEmptyForNullInput()
        {
            // Arrange
            string[] input = null;

            // Act
            IEnumerable<IEnumerable<int>> result = input.ParseIntsMultiplePerLine();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ParseIntsMultiplePerLine_ReturnsEmptyForEmptyInput()
        {
            // Arrange
            string[] input = new string[] { };

            // Act
            IEnumerable<IEnumerable<int>> result = input.ParseIntsMultiplePerLine();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ParseIntsMultiplePerLine_ParsesIntegersCorrectly()
        {
            // Arrange
            string[] input = new string[] { "1 2 3", "4 5", "6" };

            // Act
            IEnumerable<IEnumerable<int>> result = input.ParseIntsMultiplePerLine();

            // Assert
            Assert.Collection(result,
                item => Assert.Equal(new List<int> { 1, 2, 3 }, item),
                item => Assert.Equal(new List<int> { 4, 5 }, item),
                item => Assert.Equal(new List<int> { 6 }, item));
        }

        [Fact]
        public void ParseIntsOnLine_ReturnsEmptyForNullInput()
        {
            // Arrange
            string input = null;

            // Act
            List<int> result = input.ParseIntsOnLine();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ParseIntsOnLine_ReturnsEmptyForEmptyInput()
        {
            // Arrange
            string input = "";

            // Act
            List<int> result = input.ParseIntsOnLine();

            // Assert
            Assert.Empty(result);
        }

        [Fact]
        public void ParseIntsOnLine_ParsesIntegersCorrectly()
        {
            string input = "1 2 3 4 5";
            List<int> result = input.ParseIntsOnLine();
            Assert.Equal(new List<int> { 1, 2, 3, 4, 5 }, result);
        }

        [Fact]
        public void ParseIntsOnLine_IgnoresNonIntegerTokens()
        {
            string input = "1 abc 3 def 5";
            List<int> result = input.ParseIntsOnLine();
            Assert.Equal(new List<int> { 1, 3, 5 }, result);
        }

        [Fact]
        public void FlipBitString_FlipsBitsCorrectly()
        {
            string input = "110110";
            string result = input.FlipBitString();
            Assert.Equal("001001", result);
        }
    }
}
