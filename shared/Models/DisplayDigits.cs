using AdventOfCodeShared.Services;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models
{
    public class DisplayDigits
    {
        private string zero = "";
        private string one = "";
        private string two = "";
        private string three = "";
        private string four = "";
        private string five = "";
        private string six = "";
        private string seven = "";
        private string eight = "";
        private string nine = "";

        public char[] Zero => this.zero.ToList().OrderBy(x => x).ToArray();
        public char[] One => this.one.ToList().OrderBy(x => x).ToArray();
        public char[] Two => this.two.ToList().OrderBy(x => x).ToArray();
        public char[] Three => this.three.ToList().OrderBy(x => x).ToArray();
        public char[] Four => this.four.ToList().OrderBy(x => x).ToArray();
        public char[] Five => this.five.ToList().OrderBy(x => x).ToArray();
        public char[] Six => this.six.ToList().OrderBy(x => x).ToArray();
        public char[] Seven => this.seven.ToList().OrderBy(x => x).ToArray();
        public char[] Eight => this.eight.ToList().OrderBy(x => x).ToArray();
        public char[] Nine => this.nine.ToList().OrderBy(x => x).ToArray();

        public DisplayDigits(string zero,
            string one,
            string two,
            string three,
            string four,
            string five,
            string six,
            string seven,
            string eight,
            string nine)
        {
            this.zero = zero;
            this.one = one;
            this.two = two;
            this.three = three;
            this.four = four;
            this.five = five;
            this.six = six;
            this.seven = seven;
            this.eight = eight;
            this.nine = nine;
        }

        public override string ToString() => $"{this.zero} {this.one} {this.two} {this.three} {this.four} {this.five} {this.six} {this.seven} {this.eight} {this.nine}";

        public string Lookup(IList<char> n)
        {
            var first = string.Join("", n);
            if (first == string.Join("", this.Zero))
                return "0";
            if (first == string.Join("", this.One))
                return "1";
            if (first == string.Join("", this.Two))
                return "2";
            if (first == string.Join("", this.Three))
                return "3";
            if (first == string.Join("", this.Four))
                return "4";
            if (first == string.Join("", this.Five))
                return "5";
            if (first == string.Join("", this.Six))
                return "6";
            if (first == string.Join("", this.Seven))
                return "7";
            if (first == string.Join("", this.Eight))
                return "8";
            if (first == string.Join("", this.Nine))
                return "9";
            return "-1";
        }

        public static DisplayDigits DetermineSegments(List<string> signalPattern)
        {
            var arr = signalPattern;

            var one = arr.Where(x => x.Length == 2).First();
            var four = signalPattern.Where((x) => x.Length == 4).First(); //doesn't use top segment
            var seven = signalPattern.Where((x) => x.Length == 3).First();
            var eight = signalPattern.Where((x) => x.Length == 7).First();

            var ASegment = Helpers.FindFirstDiff(seven, one).FirstOrDefault();

            var three = signalPattern.Where(x => x.Length == 5
                && x.Contains(one.First()) && x.Contains(one.ToList()[1])).ToList()[0];

            var GSegment = three.ToList().Where(x => x != ASegment
                && !one.ToList().Contains(x)
                && !four.ToList().Contains(x)).First();

            var DSegment = three.ToList().Where(x =>
                x != ASegment
                && x != GSegment
                && !one.ToList().Contains(x)).First();

            var BSegment = four.ToList().Where(x =>
                x != DSegment
                && !one.ToList().Contains(x)).First();


            var five = signalPattern.Where(x => x.Length == 5
                && Helpers.FindFirstDiff(three, x).Count() == 1
                && x.Contains(BSegment)).First();

            var two = signalPattern.Where((x) => x.Length == 5
                && x != three
                && x != five).First();

            var zero = signalPattern.Where((x) => x.Length == 6
                && !x.Contains(DSegment)).First();

            var nine = signalPattern.Where((x) => x.Length == 6
                && x != zero
                && one.ToList().OrderBy(x => x).All(y => x.ToList().OrderBy(x => x).Contains(y))
                ).First();

            var six = signalPattern.Where((x) => x.Length == 6
                && x != zero
                && x != nine).First();

            return new DisplayDigits(zero, one, two, three, four, five, six, seven, eight, nine);
        }
    }
}