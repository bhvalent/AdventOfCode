using System.Collections.Generic;
using AdventOfCode.Solution.Year2021;
using AdventOfCode.Solution.Year2021.Models;
using Moq;
using Xunit;

namespace AdventOfCode.Test.Year2021
{
    public class Day4Tests
    {
        private Mock<ITxtHelper2021> _mockCsvHelper;

        public Day4Tests()
        {
            _mockCsvHelper = new Mock<ITxtHelper2021>();
        }

        [Fact]
        public void Day4_BeatGiantSquidBingo_Success()
        {
            // arrange
            var boards = new List<Board>
            {
                new Board
                {
                    Values = new Place [,] 
                    {
                        {new Place(22, false), new Place(13, false), new Place(17, false), new Place(11, false), new Place(0, false)},
                        {new Place(8, false), new Place(2, false), new Place(23, false), new Place(4, false), new Place(24, false)},
                        {new Place(21, false), new Place(9, false), new Place(14, false), new Place(16, false), new Place(7, false)},
                        {new Place(6, false), new Place(10, false), new Place(3, false), new Place(18, false), new Place(5, false)},
                        {new Place(1, false), new Place(12, false), new Place(20, false), new Place(15, false), new Place(19, false)}
                    }
                },
                new Board
                {
                    Values = new Place [,] 
                    {
                        {new Place(3, false), new Place(15, false), new Place(0, false), new Place(2, false), new Place(22, false)},
                        {new Place(9, false), new Place(18, false), new Place(13, false), new Place(17, false), new Place(5, false)},
                        {new Place(19, false), new Place(8, false), new Place(7, false), new Place(25, false), new Place(23, false)},
                        {new Place(20, false), new Place(11, false), new Place(10, false), new Place(24, false), new Place(4, false)},
                        {new Place(14, false), new Place(21, false), new Place(16, false), new Place(12, false), new Place(6, false)}
                    }
                },
                new Board
                {
                    Values = new Place[,]
                    {
                        {new Place(14, false), new Place(21, false), new Place(17, false), new Place(24, false), new Place(4, false)},
                        {new Place(10, false), new Place(16, false), new Place(15, false), new Place(9, false), new Place(19, false)},
                        {new Place(18, false), new Place(8, false), new Place(23, false), new Place(26, false), new Place(20, false)},
                        {new Place(22, false), new Place(11, false), new Place(13, false), new Place(6, false), new Place(5, false)},
                        {new Place(2, false), new Place(0, false), new Place(12, false), new Place(3, false), new Place(7, false)}
                    }
                }
            };
            var data = new SquidBingoData
            {
                DrawnNumbers = new List<int> 
                {
                    7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1
                },
                Boards = boards
            };

            _mockCsvHelper.Setup(x => x.GetSquidBingoData(It.IsAny<string>())).Returns(data);
            var target = new Day4(_mockCsvHelper.Object);

            // act
            var result = target.BeatGiantSquidBingo("filepath.csv");

            // assert
            Assert.Equal(4512, result);
        }

        [Fact]
        public void Day4_BeatGiantSquidBingo_Success2()
        {
            // arrange
            var boards = new List<Board>
            {
                new Board
                {
                    Values = new Place [,] 
                    {
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false)},
                        {new Place(3, false), new Place(4, false), new Place(5, false), new Place(6, false), new Place(7, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false)}
                    }
                },
                new Board
                {
                    Values = new Place [,] 
                    {
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(2, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(3, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(4, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(5, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(6, false), new Place(0, false)}
                    }
                },
                new Board
                {
                    Values = new Place[,]
                    {
                        {new Place(21, false), new Place(1, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(2, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(3, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(4, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(5, false), new Place(21, false), new Place(21, false), new Place(21, false)}
                    }
                },
                new Board
                {
                    Values = new Place[,]
                    {
                        {new Place(22, false), new Place(1, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(2, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(3, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(4, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(5, false), new Place(21, false), new Place(21, false), new Place(21, false)}
                    }
                }
            };
            var data = new SquidBingoData
            {
                DrawnNumbers = new List<int> 
                {
                    1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
                },
                Boards = boards
            };

            _mockCsvHelper.Setup(x => x.GetSquidBingoData(It.IsAny<string>())).Returns(data);
            var target = new Day4(_mockCsvHelper.Object);

            // act
            var result = target.BeatGiantSquidBingo("filepath.csv");

            // assert
            Assert.Equal(2100, result);
        }

        [Fact]
        public void Day4_BeatGiantSquidBingo_ToGetResult()
        {
            // arrange
            var target = new Day4(new TxtHelper2021());

            // act
            var result = target.BeatGiantSquidBingo("TestData/SquidBingo.txt");

            // assert
            Assert.Equal(39902, result);
        }

        [Fact]
        public void Day4_LoseGiantSquidBingo_Success2()
        {
            // arrange
            var boards = new List<Board>
            {
                new Board
                {
                    Values = new Place [,] 
                    {
                        {new Place(21, false), new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false)},
                        {new Place(3, false), new Place(4, false), new Place(5, false), new Place(6, false), new Place(7, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false), new Place(0, false)}
                    }
                },
                new Board
                {
                    Values = new Place [,] 
                    {
                        {new Place(21, false), new Place(0, false), new Place(0, false), new Place(2, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(3, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(4, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(5, false), new Place(0, false)},
                        {new Place(0, false), new Place(0, false), new Place(0, false), new Place(6, false), new Place(0, false)}
                    }
                },
                new Board
                {
                    Values = new Place[,]
                    {
                        {new Place(21, false), new Place(1, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(2, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(3, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(4, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(5, false), new Place(21, false), new Place(21, false), new Place(21, false)}
                    }
                },
                new Board
                {
                    Values = new Place[,]
                    {
                        {new Place(22, false), new Place(1, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(2, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(3, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(4, false), new Place(21, false), new Place(21, false), new Place(21, false)},
                        {new Place(21, false), new Place(5, false), new Place(21, false), new Place(21, false), new Place(21, false)}
                    }
                }
            };
            var data = new SquidBingoData
            {
                DrawnNumbers = new List<int> 
                {
                    1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
                },
                Boards = boards
            };

            _mockCsvHelper.Setup(x => x.GetSquidBingoData(It.IsAny<string>())).Returns(data);
            var target = new Day4(_mockCsvHelper.Object);

            // act
            var result = target.LoseGiantSquidBingo("filepath.csv");

            // assert
            Assert.Equal(147, result);
        }

        [Fact]
        public void Day4_LoseGiantSquidBingo_Success()
        {
            // arrange
            var boards = new List<Board>
            {
                new Board
                {
                    Values = new Place [,] 
                    {
                        {new Place(22, false), new Place(13, false), new Place(17, false), new Place(11, false), new Place(0, false)},
                        {new Place(8, false), new Place(2, false), new Place(23, false), new Place(4, false), new Place(24, false)},
                        {new Place(21, false), new Place(9, false), new Place(14, false), new Place(16, false), new Place(7, false)},
                        {new Place(6, false), new Place(10, false), new Place(3, false), new Place(18, false), new Place(5, false)},
                        {new Place(1, false), new Place(12, false), new Place(20, false), new Place(15, false), new Place(19, false)}
                    }
                },
                new Board
                {
                    Values = new Place [,] 
                    {
                        {new Place(3, false), new Place(15, false), new Place(0, false), new Place(2, false), new Place(22, false)},
                        {new Place(9, false), new Place(18, false), new Place(13, false), new Place(17, false), new Place(5, false)},
                        {new Place(19, false), new Place(8, false), new Place(7, false), new Place(25, false), new Place(23, false)},
                        {new Place(20, false), new Place(11, false), new Place(10, false), new Place(24, false), new Place(4, false)},
                        {new Place(14, false), new Place(21, false), new Place(16, false), new Place(12, false), new Place(6, false)}
                    }
                },
                new Board
                {
                    Values = new Place[,]
                    {
                        {new Place(14, false), new Place(21, false), new Place(17, false), new Place(24, false), new Place(4, false)},
                        {new Place(10, false), new Place(16, false), new Place(15, false), new Place(9, false), new Place(19, false)},
                        {new Place(18, false), new Place(8, false), new Place(23, false), new Place(26, false), new Place(20, false)},
                        {new Place(22, false), new Place(11, false), new Place(13, false), new Place(6, false), new Place(5, false)},
                        {new Place(2, false), new Place(0, false), new Place(12, false), new Place(3, false), new Place(7, false)}
                    }
                }
            };
            var data = new SquidBingoData
            {
                DrawnNumbers = new List<int> 
                {
                    7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1
                },
                Boards = boards
            };

            _mockCsvHelper.Setup(x => x.GetSquidBingoData(It.IsAny<string>())).Returns(data);
            var target = new Day4(_mockCsvHelper.Object);

            // act
            var result = target.LoseGiantSquidBingo("filepath.csv");

            // assert
            Assert.Equal(1924, result);
        }

        [Fact]
        public void Day4_LoseGiantSquidBingo_ToGetResult()
        {
            // arrange
            var target = new Day4(new TxtHelper2021());

            // act
            var result = target.LoseGiantSquidBingo("TestData/SquidBingo.txt");

            // assert
            Assert.Equal(1, result);
        }
    }
}