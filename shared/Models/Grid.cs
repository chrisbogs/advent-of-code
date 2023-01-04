using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AdventOfCodeShared.Models
{
    public class Grid<T> where T : struct
    {
        private readonly List<List<GridNode<T>>> _grid;

        public Grid(List<List<GridNode<T>>> grid) { _grid = grid; }

        /// <summary>
        /// Accepts lines of integers and parses them into gridNodes.
        /// </summary>
        public static Grid<int> ParseIntGrid(string[] gridData)
        {
            var grid = new List<List<GridNode<int>>>();
            for (int i = 0; i < gridData.Length; i++)
            {
                grid.Add(new List<GridNode<int>>());
                var numbers = gridData[i].Select(x => int.Parse(x.ToString())).ToList();
                foreach (var n in numbers)
                {
                    grid[i].Add(new GridNode<int>(n));
                }
            }
            return new Grid<int>(grid);
        }

        /// <summary>
        /// Parses lines in the format: ["abcdefff", "asdasdasd"] 
        /// and converts each char to an GridNode.
        /// </summary>
        internal static Grid<char> ParseGridOfLettersIntoNodes(
            string[] input)
        {
            var result = new List<List<GridNode<char>>>();
            for (int i = 0; i < input.Length; i++)
            {
                var row = new List<GridNode<char>>();
                for (int j = 0; j < input[i].Length; j++)
                {
                    row.Add(new GridNode<char>(input[i][j], new Point(i, j)));
                }
                result.Add(row);
            }
            return new Grid<char>(result);
        }

        public GridNode<T> NodeAt(int c, int r) => _grid[c][r];
        public int Columns => _grid.Count;

        public int RowCount(int columnNumber) => _grid[columnNumber].Count;

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (var c = 0; c < Columns; c++)
            {
                for (var r = 0; r < RowCount(c); r++)
                {
                    //if (c == end.X && r == end.Y) Console.Write('E');
                    //else if (c == current.X && r == current.Y) Console.Write('X');
                    //else 
                    sb.Append(NodeAt(c, r).Visited ? '#' : 'o');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public List<Point> GetGridPositions(T value)
        {
            var result = new List<Point>();
            for (var c = 0; c < Columns; c++)
            {
                for (var r = 0; r < RowCount(c); r++)
                {
                    var cell = NodeAt(c, r);
                    if (typeof(T) == typeof(char))
                    {
                        if (Convert.ToChar(cell.Value) == Convert.ToChar(value))
                        {
                            result.Add(cell.Position);
                        }
                    }
                }
            }
            return result;
        }

        public bool LookAbove(int r, int c, bool ignoreVisited = false)
        {
            if (!typeof(T).Equals(typeof(int))) throw new ArgumentException("Only integer grid supported");

            if (r - 1 >= 0 && (ignoreVisited || !NodeAt(c, r - 1).Visited))
            {
                var currentCell = NodeAt(c, r - 1).Value;
                var aboveCell = NodeAt(c, r).Value;
                return Convert.ToInt32(currentCell) < Convert.ToInt32(aboveCell);
            }
            return false;
        }

        public bool LookBelow(int r, int c, bool ignoreVisited = false)
        {
            if (!typeof(T).Equals(typeof(int))) throw new ArgumentException("Only integer grid supported");
            if (r + 1 < RowCount(c) && (ignoreVisited || !NodeAt(c, r + 1).Visited))
            {
                return Convert.ToInt32(NodeAt(c, r + 1).Value) < Convert.ToInt32(NodeAt(c, r).Value);
            }
            return false;
        }

        public bool LookLeft(int r, int c, bool ignoreVisited = false)
        {
            if (!typeof(T).Equals(typeof(int))) throw new ArgumentException("Only integer grid supported");
            if (c - 1 >= 0 && (ignoreVisited || !NodeAt(c - 1, r).Visited))
            {
                return (Convert.ToInt32(NodeAt(c - 1, r).Value) < Convert.ToInt32(NodeAt(c, r).Value));
            }
            return false;
        }
        public bool LookRight(int r, int c, bool ignoreVisited = false)
        {
            if (!typeof(T).Equals(typeof(int))) throw new ArgumentException("Only integer grid supported");
            if (c + 1 < Columns && (ignoreVisited || !NodeAt(c + 1, r).Visited))
            {
                return Convert.ToInt32(NodeAt(c + 1, r).Value) < Convert.ToInt32(NodeAt(c, r).Value);
            }
            return false;
        }

        private bool IsMinPoint(int c, int r, bool ignoreVisited = false)
        {
            if (!typeof(T).Equals(typeof(int))) throw new ArgumentException("Only integer grid supported");
            if (Convert.ToInt32(NodeAt(c, r).Value) == 9) return false;
            if (LookAbove(r, c, ignoreVisited)) return false;
            if (LookBelow(r, c, ignoreVisited)) return false;
            if (LookLeft(r, c, ignoreVisited)) return false;
            if (LookRight(r, c, ignoreVisited)) return false;
            return true;
        }
        public List<int> FindMinPoints()
        {
            // for each number, check all adjacent cells for any number higher
            var minPoints = new List<int>();
            for (var c = 0; c < Columns; c++)
            {
                for (var r = 0; r < RowCount(c); r++)
                {
                    if (IsMinPoint(c, r))
                    {
                        var current = NodeAt(c, r);
                        minPoints.Add(Convert.ToInt32(current.Value));
                    }
                }
            }
            return minPoints;
        }

        // Find all basins and return them all ordered by length.
        public List<List<int>> FindBasins()
        {
            // A basin is all locations that eventually flow downward to a single low point. 
            // Therefore, every low point has a basin, although some basins are very small. 
            // Locations of height 9 do not count as being in any basin, and all other locations will 
            // always be part of exactly one basin.
            // The size of a basin is the number of locations within the basin, including the low point.
            var basins = new List<List<int>>();

            for (var c = 0; c < Columns; c++)
            {
                for (var r = 0; r < RowCount(c); r++)
                {
                    if (IsMinPoint(c, r, true))
                    {
                        NodeAt(c, r).Visited = true;
                        //This is a min point, look for the rest of the basin points:
                        // for all the adjacent points, check if they are min points excluding the visited nodes
                        var basin = new List<int>() { Convert.ToInt32(NodeAt(c, r).Value) }.Concat(CheckAdjacentPoints(c, r)).ToList();
                        basin = basin.OrderBy(x => x).ToList();
                        basins.Add(basin);
                    }
                }
            }

            basins.Sort((a, b) => b.Count - a.Count);
            return basins;
        }

        private List<int> CheckAdjacentPoints(int c, int r)
        {
            var basin = new List<int>();
            // check adjacent points and return the ones that are min points (of the unvisited)
            if (r - 1 >= 0 && !NodeAt(c, r - 1).Visited && IsMinPoint(c, r - 1))
            {
                basin.Add(Convert.ToInt32(NodeAt(c, r - 1).Value));
                NodeAt(c, r - 1).Visited = true;
                var rest = this.CheckAdjacentPoints(c, r - 1);
                if (rest.Count > 0)
                {
                    basin = basin.Concat(rest).ToList();
                }
            }
            if (r + 1 < RowCount(c) && !NodeAt(c, r + 1).Visited && IsMinPoint(c, r + 1))
            {
                basin.Add(Convert.ToInt32(NodeAt(c, r + 1).Value));
                NodeAt(c, r + 1).Visited = true;
                var rest = this.CheckAdjacentPoints(c, r + 1);
                if (rest.Count > 0)
                {
                    basin = basin.Concat(rest).ToList();
                }
            }
            if (c - 1 >= 0 && !NodeAt(c - 1, r).Visited && IsMinPoint(c - 1, r))
            {
                basin.Add(Convert.ToInt32(NodeAt(c - 1, r).Value));
                NodeAt(c - 1, r).Visited = true;
                var rest = this.CheckAdjacentPoints(c - 1, r);
                if (rest.Count > 0)
                {
                    basin = basin.Concat(rest).ToList();
                }
            }
            if (c + 1 < Columns && !NodeAt(c + 1, r).Visited && IsMinPoint(c + 1, r))
            {
                basin.Add(Convert.ToInt32(NodeAt(c + 1, r).Value));
                NodeAt(c + 1, r).Visited = true;
                var rest = this.CheckAdjacentPoints(c + 1, r);
                if (rest.Count > 0)
                {
                    basin = basin.Concat(rest).ToList();
                }
            }
            return basin;
        }

        private void PrintGrid(Point current, Point end)
        {
            Console.WriteLine();
            for (var c = 0; c < Columns; c++)
            {
                for (var r = 0; r < RowCount(c); r++)
                {
                    if (c == end.X && r == end.Y) Console.Write('E');
                    else if (c == current.X && r == current.Y) Console.Write('X');
                    else Console.Write(NodeAt(c, r).Visited ? '#' : Convert.ToChar(NodeAt(c, r).Value));
                }
                Console.WriteLine();
            }
            Console.WriteLine();

        }

        private static bool CanMove(Point start, Grid<T> grid, int newX, int newY)
        {
            if (newX < 0) return false;
            if (newY < 0) return false;
            if (newX >= grid.Columns) return false;
            if (newY >= grid.RowCount(newX)) return false;

            var heightValueOfSource = Convert.ToChar(grid.NodeAt(start.X, start.Y).Value);
            if (heightValueOfSource == 'E')
            {
                heightValueOfSource = 'z';
            }

            if (heightValueOfSource == 'S')
            {
                heightValueOfSource = 'a';
            }

            var heightValueOfDestination = Convert.ToChar(grid.NodeAt(newX, newY).Value);
            if (heightValueOfDestination == 'E')
            {
                heightValueOfDestination = 'z';
            }

            if (heightValueOfDestination == 'S')
            {
                heightValueOfDestination = 'a';
            }

            return heightValueOfDestination - heightValueOfSource <= 1;
        }

        internal static int FindShortestPathBFSIterative(
            Grid<T> grid, List<Point> startingPoints, Point end)
        {
            var queue = new Queue<(GridNode<T>, int)>();
            foreach (var p in startingPoints)
            {
                queue.Enqueue((grid.NodeAt(p.X, p.Y), 0));
            }

            return RunBFS(queue, grid, end);
        }

        private static int RunBFS(
            Queue<(GridNode<T>, int)> queue,
            Grid<T> grid, Point end)
        {
            while (queue.Any())
            {
                var (current, distance) = queue.Dequeue();
                var curPosition = current.Position;
                if (grid.NodeAt(curPosition.X, curPosition.Y).Visited)
                {
                    continue;
                }

                if (curPosition == end)
                {
                    return distance;
                }

                grid.NodeAt(curPosition.X, curPosition.Y).Visited = true;

                // look at all neighbours

                // look up
                if (CanMove(curPosition, grid, curPosition.X, curPosition.Y - 1))
                {
                    queue.Enqueue((grid.NodeAt(curPosition.X, curPosition.Y - 1), distance + 1));
                }
                // look down
                if (CanMove(curPosition, grid, curPosition.X, curPosition.Y + 1))
                {
                    queue.Enqueue((grid.NodeAt(curPosition.X, curPosition.Y + 1), distance + 1));
                }
                // look left
                if (CanMove(curPosition, grid, curPosition.X - 1, curPosition.Y))
                {
                    queue.Enqueue((grid.NodeAt(curPosition.X - 1, curPosition.Y), distance + 1));
                }
                // look right
                if (CanMove(curPosition, grid, curPosition.X + 1, curPosition.Y))
                {
                    queue.Enqueue((grid.NodeAt(curPosition.X + 1, curPosition.Y), distance + 1));
                }
            }
            return 0;
        }
    }
}