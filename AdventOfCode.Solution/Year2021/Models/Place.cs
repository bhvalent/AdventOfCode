namespace AdventOfCode.Solution.Year2021.Models
{
    public class Place
    {
        public Place(int value, bool marked)
        {
            Value = value;
            Marked = marked;
        }

        public int Value { get; set; }
        public bool Marked { get; set; }
    }
}