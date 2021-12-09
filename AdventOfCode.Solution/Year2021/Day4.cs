using AdventOfCode.Solution.Year2021.Models;

namespace AdventOfCode.Solution.Year2021
{
    public class Day4
    {
        private readonly ITxtHelper2021 _txtService;

        public Day4(ITxtHelper2021 txtService)
        {
            _txtService = txtService ?? throw new ArgumentNullException(nameof(txtService));
        }

        /* 
            You're already almost 1.5km (almost a mile) below the surface of the ocean, 
            already so deep that you can't see any sunlight. What you can see, however, 
            is a giant squid that has attached itself to the outside of your submarine.

            Maybe it wants to play bingo?

            Bingo is played on a set of boards each consisting of a 5x5 grid of numbers. 
            Numbers are chosen at random, and the chosen number is marked on all boards on which it appears. 
            (Numbers may not appear on all boards.) If all numbers in any row or any column of a board are marked, that board wins. 
            (Diagonals don't count.)

            The submarine has a bingo subsystem to help passengers (currently, you and the giant squid) pass the time. 
            It automatically generates a random order in which to draw numbers and a random set of boards (your puzzle input). 

            Start by finding the sum of all unmarked numbers on that board. Then, multiply that sum by the number that was just called when the board won.

            To guarantee victory against the giant squid, figure out which board will win first. 
            What will your final score be if you choose that board?
        */
        public int BeatGiantSquidBingo(string filepath) 
        {
            var squidBingoData = _txtService.GetSquidBingoData(filepath);
            return FindWinningBoardScore(squidBingoData);
        }

        /* 
            You aren't sure how many bingo boards a giant squid could play at once, so rather than waste time counting its arms, 
            the safe thing to do is to figure out which board will win last and choose that one. 
            That way, no matter which boards it picks, it will win for sure.

            Figure out which board will win last. Once it wins, what would its final score be?
        */
        public int LoseGiantSquidBingo(string filepath) 
        {
            var squidBingoData = _txtService.GetSquidBingoData(filepath);
            return FindLastWinningBoardScore(squidBingoData);
        }

        private int FindWinningBoardScore(SquidBingoData squidData)
        {
            if (squidData == null) throw new ArgumentNullException(nameof(squidData));
            if (squidData.DrawnNumbers == null || squidData.DrawnNumbers.Count < 1) throw new ArgumentNullException(nameof(squidData.DrawnNumbers));
            if (squidData.Boards == null || squidData.Boards.Count < 1) throw new ArgumentNullException(nameof(squidData.Boards));

            int? winningNumber = null;
            int? winningBoardScore = null;
            var drawnNumbersEnumerator = squidData.DrawnNumbers.GetEnumerator();
            drawnNumbersEnumerator.MoveNext();
            int currentNumber = drawnNumbersEnumerator.Current;
            var boardWon = false;
            while (!boardWon)
            {
                foreach (var board in squidData.Boards)
                {
                    board.MarkPlace(currentNumber);
                    boardWon = board.CheckHasWon();
                    if (boardWon)
                    {
                        winningNumber = drawnNumbersEnumerator.Current;
                        winningBoardScore = board.GetBoardScore();
                        return winningNumber.Value * winningBoardScore.Value;
                    } 
                }
                drawnNumbersEnumerator.MoveNext();
                currentNumber = drawnNumbersEnumerator.Current;
            }
            return 0;
        }

        private int FindLastWinningBoardScore(SquidBingoData squidData)
        {
            if (squidData == null) throw new ArgumentNullException(nameof(squidData));
            if (squidData.DrawnNumbers == null || squidData.DrawnNumbers.Count < 1) throw new ArgumentNullException(nameof(squidData.DrawnNumbers));
            if (squidData.Boards == null || squidData.Boards.Count < 1) throw new ArgumentNullException(nameof(squidData.Boards));

            int? winningNumber = null;
            int? winningBoardScore = null;
            var drawnNumbersEnumerator = squidData.DrawnNumbers.GetEnumerator();
            //drawnNumbersEnumerator.MoveNext();
            int currentNumber = 0; // = drawnNumbersEnumerator.Current;
            var boardWon = false;
            List<Board> boards = squidData.Boards;
            while (drawnNumbersEnumerator.MoveNext())
            {
                currentNumber = drawnNumbersEnumerator.Current;
                boards = boards.Where(x => !x.HasWon).ToList();
                foreach (var board in boards)
                {
                    board.MarkPlace(currentNumber);
                    boardWon = board.CheckHasWon();
                    if (boardWon)
                    {
                        winningNumber = drawnNumbersEnumerator.Current;
                        winningBoardScore = board.GetBoardScore();
                        //return winningNumber.Value * winningBoardScore.Value;
                    } 
                }
                // drawnNumbersEnumerator.MoveNext();
                // currentNumber = drawnNumbersEnumerator.Current;
            }
            return winningBoardScore.HasValue && winningNumber.HasValue ? winningBoardScore.Value * winningNumber.Value : 0;
        }
    }
}