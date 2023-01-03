using System.Drawing;

namespace AdventOfCodeShared.Models
{
    public class GridNode<T> where T: struct 
    {
        public T Value { get; set; }
        public bool Visited { get; set; }
        public Point Position { get; set; }

        public GridNode(T value, bool visited = false)
        {
            Value = value;
            Visited = visited;
        }
        public GridNode(T value, Point position, bool visited = false)
        {
            Value = value;
            Visited = visited;
            Position = position;
        }
        public override string ToString()
        {
            return $"{this.Value} " + (Visited ? "Y" : "N") + $" P({Position.X},{Position.Y})";
        }
    }    
    
}