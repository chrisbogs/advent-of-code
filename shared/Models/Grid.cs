using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeShared.Models
{
    public class Grid
    {
        private List<List<GridNode>> grid;

        public Grid(string[] gridData)
        {
            grid = new List<List<GridNode>>();
            for (int i = 0; i < gridData.Length; i++)
            {
                grid.Add(new List<GridNode>());
                var numbers = gridData[i].Select(x => int.Parse(x.ToString())).ToList();
                foreach (var n in numbers)
                {
                    grid[i].Add(new GridNode(n));
                }
            }
            // this.grid.forEach(x => console.log(x + ""));
        }

        public GridNode ValueAt(int c, int r) => this.grid[c][r];
        public int Columns => this.grid.Count;

        public int RowCount(int columnNumber) => this.grid[columnNumber].Count;

        public bool LookAbove(int r, int c, bool ignoreVisited = false)
        {
            if (r - 1 >= 0 && (ignoreVisited || !this.grid[c][r - 1].Visited))
            {
                return this.grid[c][r - 1].Value < this.grid[c][r].Value;
            }
            return false;
        }

        public bool LookBelow(int r, int c, bool ignoreVisited = false)
        {
            if (r + 1 < this.grid[c].Count && (ignoreVisited || !this.grid[c][r + 1].Visited))
            {
                return this.grid[c][r + 1].Value < this.grid[c][r].Value;
            }
            return false;
        }

        public bool LookLeft(int r, int c, bool ignoreVisited = false)
        {
            if (c - 1 >= 0 && (ignoreVisited || !this.grid[c - 1][r].Visited))
            {
                return (this.grid[c - 1][r].Value < this.grid[c][r].Value);
            }
            return false;
        }
        public bool LookRight(int r, int c, bool ignoreVisited = false)
        {
            if (c + 1 < this.grid.Count && (ignoreVisited || !this.grid[c + 1][r].Visited))
            {
                return this.grid[c + 1][r].Value < this.grid[c][r].Value;
            }
            return false;
        }

        private bool IsMinPoint(int c, int r, bool ignoreVisited = false)
        {
            if (this.ValueAt(c, r).Value == 9) return false;
            if (this.LookAbove(r, c, ignoreVisited)) return false;
            if (this.LookBelow(r, c, ignoreVisited)) return false;
            if (this.LookLeft(r, c, ignoreVisited)) return false;
            if (this.LookRight(r, c, ignoreVisited)) return false;
            return true;
        }
        public List<int> FindMinPoints()
        {
            // for each number, check all adjacent cells for any number higher
            var minPoints = new List<int>();
            for (var c = 0; c < this.Columns; c++)
            {
                for (var r = 0; r < this.RowCount(c); r++)
                {
                    if (this.IsMinPoint(c, r))
                    {
                        var current = this.ValueAt(c, r);
                        minPoints.Add(current.Value);
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

            for (var c = 0; c < this.Columns; c++)
            {
                for (var r = 0; r < this.RowCount(c); r++)
                {
                    if (this.IsMinPoint(c, r, true))
                    {
                        this.ValueAt(c, r).Visited = true;
                        //This is a min point, look for the rest of the basin points:
                        // for all the adjacent points, check if they are min points excluding the visited nodes
                        var basin = new List<int>() { this.ValueAt(c, r).Value }.Concat(this.CheckAdjacentPoints(c, r)).ToList();
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
            if (r - 1 >= 0 && !this.grid[c][r - 1].Visited && this.IsMinPoint(c, r - 1))
            {
                basin.Add(this.ValueAt(c, r - 1).Value);
                this.ValueAt(c, r - 1).Visited = true;
                var rest = this.CheckAdjacentPoints(c, r - 1);
                if (rest.Count > 0)
                {
                    basin = basin.Concat(rest).ToList();
                }
            }
            if (r + 1 < this.grid[c].Count && !this.grid[c][r + 1].Visited && this.IsMinPoint(c, r + 1))
            {
                basin.Add(this.ValueAt(c, r + 1).Value);
                this.ValueAt(c, r + 1).Visited = true;
                var rest = this.CheckAdjacentPoints(c, r + 1);
                if (rest.Count > 0)
                {
                    basin = basin.Concat(rest).ToList();
                }
            }
            if (c - 1 >= 0 && !this.grid[c - 1][r].Visited && this.IsMinPoint(c - 1, r))
            {
                basin.Add(this.ValueAt(c - 1, r).Value);
                this.ValueAt(c - 1, r).Visited = true;
                var rest = this.CheckAdjacentPoints(c - 1, r);
                if (rest.Count > 0)
                {
                    basin = basin.Concat(rest).ToList();
                }
            }
            if (c + 1 < this.grid.Count && !this.grid[c + 1][r].Visited && this.IsMinPoint(c + 1, r))
            {
                basin.Add(this.ValueAt(c + 1, r).Value);
                this.ValueAt(c + 1, r).Visited = true;
                var rest = this.CheckAdjacentPoints(c + 1, r);
                if (rest.Count > 0)
                {
                    basin = basin.Concat(rest).ToList();
                }
            }
            return basin;
        }
    }
}