using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AdventOfCodeShared.Algorithms
{
    internal class Graph
    {
        // Breadth-first search algorithm
        internal static int FindShortestPathBFSIterative(int[,] grid, Point start, Point end)
        {
            var queue = new Queue<(Point, int)>();
            queue.Enqueue((start, 0));
            var visited = new HashSet<Point>();

            while (queue.Any())
            {
                var (current, distance) = queue.Dequeue();
                
                if (visited.Contains(current))
                {
                    continue;
                }

                if (current == end)
                {
                    return distance;
                }

                visited.Add(current);

                // look at all neighbours

                // look up
                queue.Enqueue((new Point(current.X, current.Y - 1), distance + 1));
                // look down
                queue.Enqueue((new Point(current.X, current.Y + 1), distance + 1));
                // look left
                queue.Enqueue((new Point(current.X - 1, current.Y), distance + 1));
                // look right
                queue.Enqueue((new Point(current.X + 1, current.Y), distance + 1));
            }

            return 0;
        }
    }
}
