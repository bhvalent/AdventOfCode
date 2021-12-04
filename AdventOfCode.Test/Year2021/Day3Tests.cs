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
            var target = new Day3(_mockCsvHelper.Object);

            // act
            var result = target.PowerConsumption((List<DiagnosticData>)null);

            // assert
            Assert.Equal((int)0, result);
        }

        [Fact]
        public void Day3_PowerConsumption_ShouldReturnZeroWhenPassedEmpty()
        {
            // arrange
            var target = new Day3(_mockCsvHelper.Object);

            // act
            var result = target.PowerConsumption(new List<DiagnosticData>());

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
            var target = new Day3(_mockCsvHelper.Object);

            // act
            var result = target.PowerConsumption(report);

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
            var target = new Day3(_mockCsvHelper.Object);

            // act
            var result = target.PowerConsumption(report);

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