namespace AdventOfCode.Solution.Year2021.Models
{
    public class Board
    {
        private bool _hasWon;

        public Board()
        {
            Values = new Place[5, 5];
        }

        public bool HasWon => _hasWon;

        public Place[,] Values { get; set; }

        public bool CheckHasWon()
        {
            if (_hasWon) return true;

            bool hasCurrentRowWon = true;
            bool hasCurrentColumnWon = true;
            for (int i = 0; i < 5; i++)
            {
                hasCurrentRowWon = true;
                hasCurrentColumnWon = true;
                for (int y = 0; y < 5; y++)
                {
                    if (!hasCurrentColumnWon && !hasCurrentRowWon) continue;
                    if (!Values[i,y].Marked) hasCurrentRowWon = false;
                    if (!Values[y,i].Marked) hasCurrentColumnWon = false;
                }
                if (hasCurrentColumnWon || hasCurrentRowWon)
                {
                    _hasWon = true;
                    return _hasWon;
                } 
            }
            return _hasWon;
        }

        public void MarkPlace(int num)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (Values[i,y].Value == num) Values[i,y].Marked = true;
                }
            }
        }

        public int GetBoardScore()
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int y = 0; y < 5; y++)
                {
                    if (!Values[i,y].Marked) sum += Values[i,y].Value;
                }
            }
            return sum;
        }
    }

}