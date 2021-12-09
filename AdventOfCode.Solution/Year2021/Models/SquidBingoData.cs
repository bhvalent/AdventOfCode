namespace AdventOfCode.Solution.Year2021.Models
{
    public class SquidBingoData
    {
        public SquidBingoData()
        {
            DrawnNumbers = new List<int>();
            Boards = new List<Board>();
        }

        public List<int> DrawnNumbers { get; set; }
        public List<Board> Boards { get; set; } // change int to board
    }
}