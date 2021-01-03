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

        private const long RowCount = 128;
        private const long ColumnCount = 8;

        public BoardingPass(string specifier)
        {
            Row = ConvertSpecifier(specifier.Take(7), RowCount, 'F', 'B');
            Column = ConvertSpecifier(specifier.TakeLast(3), ColumnCount, 'L', 'R');
            SeatId = Row * 8 + Column;
        }

        private long ConvertSpecifier(IEnumerable<char> s, long max, char lower, char higher)
        {
            long top = max-1;
            long bottom = 0;
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
