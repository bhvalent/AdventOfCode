using System.Collections.Generic;
using AdventOfCode.Solution.Helpers;
using AdventOfCode.Solution.Year2021;
using AdventOfCode.Solution.Year2021.Models;
using Moq;
using Xunit;

namespace AdventOfCode.Test.Year2021
{
    public class Day3Tests
    {
        private Mock<ICsvService> _mockCsvHelper;

        public Day3Tests()
        {
            _mockCsvHelper = new Mock<ICsvService>();
        }

        [Fact]
        public void Day3_PowerConsumption_ShouldReturnZeroWhenPassedNull()
        {
            // arrange
            _mockCsvHelper.Setup(x => x.GetListOf<DiagnosticData>(It.IsAny<string>())).Returns<List<DiagnosticData>>(null);
            var target = new Day3(_mockCsvHelper.Object);

            // act
            var result = target.PowerConsumption("report.csv");

            // assert
            Assert.Equal((int)0, result);
        }

        [Fact]
        public void Day3_PowerConsumption_ShouldReturnZeroWhenPassedEmpty()
        {
            // arrange
            var target = new Day3(_mockCsvHelper.Object);
            var report = new List<DiagnosticData>();

            // act
            _mockCsvHelper.Setup(x => x.GetListOf<DiagnosticData>(It.IsAny<string>())).Returns(report);
            var result = target.PowerConsumption("report.csv");

            // assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void Day3_PowerConsumption_ShouldReturnWhenPassedBasic()
        {
            // arrange
            var report = new List<DiagnosticData> 
            { 
                new DiagnosticData { Value = "10" }, 
                new DiagnosticData { Value = "10" }, 
                new DiagnosticData { Value = "00" } 
            };
            _mockCsvHelper.Setup(x => x.GetListOf<DiagnosticData>(It.IsAny<string>())).Returns(report);
            var target = new Day3(_mockCsvHelper.Object);

            // act
            var result = target.PowerConsumption("report.csv");

            // assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Day3_PowerConsumption_ShouldReturnWhenPassedComplex()
        {
            // arrange
            var report = new List<DiagnosticData> 
            { 
                new DiagnosticData { Value = "00100" },
                new DiagnosticData { Value = "11110" },
                new DiagnosticData { Value = "10110" },
                new DiagnosticData { Value = "10111" },
                new DiagnosticData { Value = "10101" },
                new DiagnosticData { Value = "01111" },
                new DiagnosticData { Value = "00111" },
                new DiagnosticData { Value = "11100" },
                new DiagnosticData { Value = "10000" },
                new DiagnosticData { Value = "11001" },
                new DiagnosticData { Value = "00010" },
                new DiagnosticData { Value = "01010" }
            };
            _mockCsvHelper.Setup(x => x.GetListOf<DiagnosticData>(It.IsAny<string>())).Returns(report);
            var target = new Day3(_mockCsvHelper.Object);

            // act
            var result = target.PowerConsumption("report.csv");

            // assert
            Assert.Equal(198, result);
        }

        [Fact]
        public void Day3_PowerConsumption_ToGetResult()
        {
            // arrange
            var target = GetTarget();

            // act
            var result = target.PowerConsumption("TestData/DiagnosticReport.csv");

            // assert
            Assert.Equal(3813416, result);
        }

        private Day3 GetTarget()
        {
            return new Day3(new CsvService(new CsvHelperWrapper()));
        }
    }
}