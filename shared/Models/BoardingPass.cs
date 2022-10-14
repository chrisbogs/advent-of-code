using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models
{
    public class BoardingPass
    {
        public int SeatId { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        private const int RowCount = 128;
        private const int ColumnCount = 8;

        public BoardingPass(string specifier)
        {
            Row = ConvertSpecifier(specifier.Take(7), RowCount, 'F', 'B');
            Column = ConvertSpecifier(specifier.TakeLast(3), ColumnCount, 'L', 'R');
            SeatId = Row * 8 + Column;
        }

        private int ConvertSpecifier(IEnumerable<char> s, int max, char lower, char higher)
        {
            int top = max - 1;
            int bottom = 0;
            foreach (var c in s)
            {
                if (c == lower)
                {
                    top -= (int)Math.Ceiling((top - bottom) / 2.0);

                }
                else if (c == higher)
                {
                    bottom += (int)Math.Ceiling((top - bottom) / 2.0);
                }
            }

            return bottom;
        }
    }
}
