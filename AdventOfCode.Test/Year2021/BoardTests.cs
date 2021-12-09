using AdventOfCode.Solution.Year2021.Models;
using Xunit;

namespace AdventOfCode.Solution.Year2021
{
    public class BoardTests
    {
        [Fact]
        public void Board_HasWon_ShouldReturnTrueOnWinningRow1()
        {
            // arrange
            var target = new Board();
            target.Values = new Place [,] 
            {
                {new Place(1, true), new Place(1, true), new Place(1, true), new Place(1, true), new Place(1, true)},
                {new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)}
            };

            // act
            var result = target.CheckHasWon();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void Board_HasWon_ShouldReturnTrueOnWinningRow2()
        {
            // arrange
            var target = new Board();
            target.Values = new Place [,] 
            {
                {new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, true), new Place(1, true), new Place(1, true), new Place(1, true), new Place(1, true)},
                {new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)}
            };

            // act
            var result = target.CheckHasWon();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void Board_HasWon_ShouldReturnTrueOnWinningColumn1()
        {
            // arrange
            var target = new Board();
            target.Values = new Place [,] 
            {
                {new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false), new Place(1, false)}
            };

            // act
            var result = target.CheckHasWon();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void Board_HasWon_ShouldReturnTrueOnWinningColumn2()
        {
            // arrange
            var target = new Board();
            target.Values = new Place [,] 
            {
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)}
            };

            // act
            var result = target.CheckHasWon();

            // assert
            Assert.True(result);
        }

        [Fact]
        public void Board_GetBoardScore_ShouldReturnScore()
        {
            // arrange
            var target = new Board();
            target.Values = new Place [,] 
            {
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)},
                {new Place(1, false), new Place(1, true), new Place(1, false), new Place(1, false), new Place(1, false)}
            };

            // act
            var result = target.GetBoardScore();

            // assert
            Assert.Equal(20, result);
        }
    }
}