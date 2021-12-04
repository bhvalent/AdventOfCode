using System.Collections.Generic;
using AdventOfCode.Solution.Helpers;
using AdventOfCode.Solution.Year2021;
using AdventOfCode.Solution.Year2021.Models;
using Moq;
using Xunit;

namespace AdventOfCode.Test.Year2021
{
    public class Day2Tests
    {
        private Mock<ICsvService> _mockCsvHelper;

        public Day2Tests()
        {
            _mockCsvHelper = new Mock<ICsvService>();
        }

        [Fact]
        public void Day2_Dive_ShouldReturnZeroWhenPassedNull()
        {
            // arrange
            var target = new Day2(_mockCsvHelper.Object);

            // act
            var result = target.Dive((List<DiveMeasurement>)null);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Day2_Dive_ShouldReturnZeroWhenPassedEmpty()
        {
            // arrange
            var target = new Day2(_mockCsvHelper.Object);

            // act
            var result = target.Dive(new List<DiveMeasurement>());

            // assert
            Assert.Equal(0, result);
        }

		[Fact]
        public void Day2_Dive_ShouldReturnResultWithOneEach()
        {
            // arrange
			var measurements = new List<DiveMeasurement>
			{
				new DiveMeasurement 
                { 
                    Direction = "forward", 
                    Value = 1 
                },
                new DiveMeasurement 
                { 
                    Direction = "up", 
                    Value = 1 
                },
                new DiveMeasurement 
                { 
                    Direction = "down", 
                    Value = 2
                }
			};
            var target = new Day2(_mockCsvHelper.Object);

            // act
            var result = target.Dive(measurements);

            // assert
            Assert.Equal(1, result);
        }

		[Fact]
        public void Day2_Dive_ShouldReturnResultWithMultiple()
        {
            // arrange
			var measurements = new List<DiveMeasurement>
			{
                new DiveMeasurement 
                { 
                    Direction = "forward", 
                    Value = 5
                },
                new DiveMeasurement 
                { 
                    Direction = "down", 
                    Value = 5 
                },
                new DiveMeasurement 
                { 
                    Direction = "forward", 
                    Value = 8
                },
                new DiveMeasurement 
                { 
                    Direction = "up", 
                    Value = 3
                },
                new DiveMeasurement 
                { 
                    Direction = "down", 
                    Value = 8
                },
                new DiveMeasurement 
                { 
                    Direction = "forward", 
                    Value = 2
                }
			};
            var target = new Day2(_mockCsvHelper.Object);

            // act
            var result = target.Dive(measurements);

            // assert
            Assert.Equal(150, result);
        }

		[Fact]
        public void Day2_Dive_ToGetResults()
        {
            // arrange
            var target = GetTarget();

            // act
            var result = target.Dive("TestData/Dive.csv");

            // assert
            Assert.Equal(1893605, result);
        }

        [Fact]
        public void Day2_DiveWithAim_ShouldReturnZeroWhenPassedNull()
        {
            // arrange
            var target = new Day2(_mockCsvHelper.Object);

            // act
            var result = target.DiveWithAim((List<DiveMeasurement>)null);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Day2_DiveWithAim_ShouldReturnZeroWhenPassedEmpty()
        {
            // arrange
            var target = new Day2(_mockCsvHelper.Object);

            // act
            var result = target.DiveWithAim(new List<DiveMeasurement>());

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Day2_DiveWithAim_ShouldReturnResultWithOneEach()
        {
            // arrange
            var measurements = new List<DiveMeasurement>
            {
                new DiveMeasurement 
                { 
                    Direction = "forward", 
                    Value = 1 
                },
                new DiveMeasurement 
                { 
                    Direction = "up", 
                    Value = 1 
                },
                new DiveMeasurement 
                { 
                    Direction = "down", 
                    Value = 2
                }
            };
            var target = new Day2(_mockCsvHelper.Object);

            // act
            var result = target.DiveWithAim(measurements);

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Day2_DiveWithAim_ShouldReturnResultWithMultiple()
        {
            // arrange
            var measurements = new List<DiveMeasurement>
            {
                new DiveMeasurement 
                { 
                    Direction = "forward", 
                    Value = 5
                },
                new DiveMeasurement 
                { 
                    Direction = "down", 
                    Value = 5 
                },
                new DiveMeasurement 
                { 
                    Direction = "forward", 
                    Value = 8
                },
                new DiveMeasurement 
                { 
                    Direction = "up", 
                    Value = 3
                },
                new DiveMeasurement 
                { 
                    Direction = "down", 
                    Value = 8
                },
                new DiveMeasurement 
                { 
                    Direction = "forward", 
                    Value = 2
                }
            };
            var target = new Day2(_mockCsvHelper.Object);

            // act
            var result = target.DiveWithAim(measurements);

            // assert
            Assert.Equal(900, result);
        }

        [Fact]
        public void Day2_DiveWithAim_ToGetResults()
        {
            // arrange
            var target = GetTarget();

            // act
            var result = target.DiveWithAim("TestData/Dive.csv");

            // assert
            Assert.Equal(2120734350, result);
        }

		private Day2 GetTarget()
		{
			return new Day2(new CsvService(new CsvHelperWrapper()));
		}
    }
}