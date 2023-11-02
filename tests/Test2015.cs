using AdventOfCodeShared.Models;
using AdventOfCodeShared.Logic;
using Server;
using Xunit;
using System.Threading.Tasks;

namespace Tests
{
    public class Test2015
    {
        [Fact]
        public async Task TestDay1()
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

            Assert.Equal("138", await sut.Router(2015, 1, 1));
            Assert.Equal("1771", await sut.Router(2015, 1, 2));
        }

        [Fact]
        public async Task TestDay2()
        {
            Assert.Equal(58, TwentyFifteen.Day2Part1(new string[] { "2x3x4" }));
            Assert.Equal(43, TwentyFifteen.Day2Part1(new string[] { "1x1x10" }));
            var sut = new YearController(new InputRetriever());

            Assert.Equal("1586300", await sut.Router(2015, 2, 1));
            Assert.Equal(10, new RectangularPrism(1, 1, 10).Volume);
            Assert.Equal(10, new RectangularPrism(2, 3, 4).SmallestPerimeterOfAnyFace);
            Assert.Equal(24, new RectangularPrism(2, 3, 4).Volume);
            Assert.Equal(34, TwentyFifteen.Day2Part2(new string[] { "2x3x4" }));
            Assert.Equal(14, TwentyFifteen.Day2Part2(new string[] { "1x1x10" }));
            Assert.Equal("3737498", await sut.Router(2015, 2, 2));
        }

        [Fact]
        public async Task TestDay3()
        {
            Assert.Equal(2, TwentyFifteen.Day3Part1(new string[] { ">" }));
            Assert.Equal(4, TwentyFifteen.Day3Part1(new string[] { "^>v<" }));
            Assert.Equal(2, TwentyFifteen.Day3Part1(new string[] { "^v^v^v^v^v" }));
            var sut = new YearController(new InputRetriever());

            Assert.Equal("2081", await sut.Router(2015, 3, 1));
            Assert.Equal(3, TwentyFifteen.Day3Part2(new string[] { "^v" }));
            Assert.Equal(3, TwentyFifteen.Day3Part2(new string[] { "^>v<" }));
            Assert.Equal(11, TwentyFifteen.Day3Part2(new string[] { "^v^v^v^v^v" }));
            Assert.Equal("2341", await sut.Router(2015, 3, 2));
        }

        [Fact]
        public async Task TestDay4()
        {
            //Assert.Equal(2, TwentyFifteen.Day4Part1(new string[] { ">" }));
            //var sut = new YearController(new InputRetriever());

            //Assert.Equal("2081", await sut.Router(2015, 4, 1));
            //Assert.Equal(3, TwentyFifteen.Day4Part2(new string[] { "^v" }));
            //Assert.Equal("2341", await sut.Router(2015, 4, 2));

        }

        [Fact]
        public async Task TestDay5()
        {

        }

        [Fact]
        public async Task TestDay6()
        {

        }

        [Fact]
        public async Task TestDay7()
        {

        }

        [Fact]
        public async Task TestDay8()
        {

        }

        [Fact]
        public async Task TestDay9()
        {

        }

        [Fact]
        public async Task TestDay10()
        {


        }

        [Fact]
        public async Task TestDay11()
        {
        }

        [Fact]
        public async Task TestDay12()
        {
        }

        [Fact]
        public async Task TestDay13()
        {
        }

        [Fact]
        public async Task TestDay14()
        {

        }

        [Fact]
        public async Task TestDay15()
        {
        }

        [Fact]
        public async Task TestDay16()
        {
        }

        [Fact]
        public async Task TestDay17()
        {
        }

        [Fact]
        public async Task TestDay18()
        {
        }

        [Fact]
        public async Task TestDay19()
        {
        }

        [Fact]
        public async Task TestDay20()
        {
        }

        [Fact]
        public async Task TestDay21()
        {
        }

        [Fact]
        public async Task TestDay22()
        {
        }

        [Fact]
        public async Task TestDay23()
        {
        }

        [Fact]
        public async Task TestDay24()
        {
        }

        [Fact]
        public async Task TestDay25()
        {
        }
    }
}
