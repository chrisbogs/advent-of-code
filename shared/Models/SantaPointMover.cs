using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventOfCodeShared.Models
{
    internal class SantaPointMover
    {
        public static void MovePoint(IEnumerable<char> directions,
            ref HashSet<Point> visited)
        {
            var start = new Point();
            foreach (var move in directions)
            {
                switch (move)
                {
                    case '<':
                        start.X -= 1;
                        break;
                    case '>':
                        start.X += 1;
                        break;
                    case 'v':
                        start.Y -= 1;
                        break;
                    case '^':
                        start.Y += 1;
                        break;
                }

                if (!visited.Contains(start))
                {
                    visited.Add(start);
                }
            }
        }
    }
}
