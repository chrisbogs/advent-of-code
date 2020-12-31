using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCodeShared.Models
{
    public class Map
    {
        public enum Space
        {
            Tree = '#',
            Open = '.'
        }

        public List<List<Space>> Grid { get; set; } = new List<List<Space>>();

        public Map(string[] lines)
        {
            // Accepts comma separated lines
            Grid = new List<List<Space>>();
            foreach (var line in lines)
            {
                Grid.Add(line.Select(s => (Space)s).ToList());
            }
        }

        public long TraverseAndCountTrees(Toboggan sled)
        {
            long treeCount = 0;
            var x = 0;
            var y = 0;

            var bottom = Grid.Count - 1;
            var maxColumn = Grid.First()?.Count ?? 0;

            while (y < bottom)
            {
                // make a move
                x = (x + sled.Right) % maxColumn;
                // Prevent us from going past the bottom
                y = Math.Min(bottom, y + sled.Down);

                if (Grid[y][x] is Space.Tree)
                {
                    treeCount++;
                }
            }

            return treeCount;
        }



        public string Print()
        {
            var sb = new StringBuilder();
            foreach (var row in Grid)
            {
                row.ForEach(f => sb.Append((char)f));
                sb.Append('\n');
            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

    }
}
