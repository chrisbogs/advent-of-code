namespace AdventOfCodeShared.Models
{
    public class GridNode<T> where T: struct 
    {
        public T Value { get; set; }
        public bool Visited { get; set; }

        public GridNode(T value, bool visited=false)
        {
            Value = value;
            Visited = visited;
        }
        public override string ToString()
        {
            return $"{this.Value} " + (Visited ? "Y" : "N");
        }
    }    
    
}