using AdventOfCode.Solution.Year2021.Models;

namespace AdventOfCode.Solution.Year2021
{
    public class TxtHelper2021 : ITxtHelper2021
    {
        public TxtHelper2021() { }
        public SquidBingoData GetSquidBingoData(string filepath)
        {
            var data = new SquidBingoData();
            string[] lines = System.IO.File.ReadAllLines(filepath);
            List<Place> row = null;
            int rowCount = 0;
            var board = new Board();
            for (int i = 0; i < lines.Count(); i++)
            {
                if (i == 0)
                {
                    data.DrawnNumbers = lines[i].Split(",").Select(x => Convert.ToInt32(x)).ToList();
                    continue;
                } 
                if (string.IsNullOrWhiteSpace(lines[i])) continue;

                row = lines[i].Trim().Replace("  ", " ").Split(" ").Select(x => new Place(Convert.ToInt32(x), false)).ToList();
                if (row.Count() != 5) throw new Exception("row doesn't have 5 numbers :(");
                
                for (int y = 0; y < 5; y++)
                {
                    board.Values[rowCount,y] = row[y];
                }
                rowCount++;
                if (rowCount == 5)
                {
                    data.Boards.Add(board);
                    board = new Board();
                    rowCount = 0;
                }
            }
            return data;
        }
    }
}