using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCodeShared.Models
{
    public class BoardingPass
    {
        public long SeatId { get; set; }
        public long Row { get; set; }
        public long Column { get; set; }

        private const long RowCount = 127;
        private const long ColumnCount = 7;

        public BoardingPass(string specifier)
        {
            Row = ConvertRowSpecifier(specifier.Take(7));
            Column = ConvertColumnSpecifier(specifier.TakeLast(3));
            SeatId = Row * 8 + Column;
        }

        private long ConvertRowSpecifier(IEnumerable<char> s)
        {
            long top = RowCount;
            long bottom = 0;
            foreach (var c in s)
            {
                if (c == 'F')
                {
                    top -= (int)Math.Ceiling((top - bottom) / 2.0);

                }
                else if (c == 'B')
                {
                    bottom += (int)Math.Ceiling((top - bottom) / 2.0);
                }
            }

            return bottom;
        }
        private long ConvertColumnSpecifier(IEnumerable<char> s)
        {
            long top = ColumnCount;
            long bottom = 0;
            foreach (var c in s)
            {
                if (c == 'L')
                {
                    top -= (int)Math.Ceiling((top - bottom) / 2.0);
                }
                else if (c == 'R')
                {
                    bottom += (int)Math.Ceiling((top - bottom) / 2.0);
                }
            }

            return bottom;
        }
    }
}
