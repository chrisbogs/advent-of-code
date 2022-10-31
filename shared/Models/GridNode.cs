namespace AdventOfCodeShared.Models
{
    public class GridNode
    {
        public int Value { get; set; }
        public bool Visited { get; set; }

        public GridNode(int value)
        {
            Value = value;
        }
        public override string ToString()
        {
            return $"{this.Value}";
        }
    }    
    
}