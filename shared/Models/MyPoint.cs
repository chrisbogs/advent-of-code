using System;
using System.Drawing;

namespace AdventOfCodeShared.Models
{
    public class MyPoint
    {
        public int X;
        public int Y;
        public MyPoint(int x, int y) { this.X = x; this.Y = y; }

        // Accepts a string of the form: "number,number"
        public static MyPoint Parse(string point)
        {
            var coordinates = point.Split(',');
            return new MyPoint(
                int.Parse(coordinates[0]),
                int.Parse(coordinates[1]));
        }

        internal static double Distance(Point headPosition, Point tailPosition)
        {
            return Math.Sqrt(
                (headPosition.X - tailPosition.X)
                * (headPosition.X - tailPosition.X)
                + (headPosition.Y - tailPosition.Y) 
                * (headPosition.Y - tailPosition.Y));
        }

        public float Slope(MyPoint other)
        {
            if (other.X == this.X && other.Y == this.Y) return 0;
            var slope = (other.Y - this.Y) / (other.X - this.X);
            return slope;
        }

        public override string ToString()
        {
            return $"{this.X}{this.Y}";
        }
    }
}
