using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models
{
    public class RectangularPrism
    {
        private readonly int length;
        private readonly int width;
        private readonly int height;

        public RectangularPrism(int length, int width, int height)
        {
            this.length = length;
            this.width = width;
            this.height = height;
        }
        private IEnumerable<int> TwoSmallestSides => new List<int>() { length, width, height }
                .OrderBy(x => x)
                .Take(2);

        public int SurfaceArea => 2 * length * width + 2 * width * height + 2 * height * length;
        
        public int AreaOfSmallestSide => TwoSmallestSides.Aggregate(1, (x, y) => x * y);

        public int Volume => length * width * height;

        public int SmallestPerimeterOfAnyFace => TwoSmallestSides.Sum(x => 2 * x);
    }
}
