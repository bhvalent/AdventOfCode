using System.Collections.Generic;
using AdventOfCode.Solution.Helpers;
using AdventOfCode.Solution.Year2021;
using Moq;
using Xunit;

namespace AdventOfCode.Test.Year2021;

public class Day1Tests
{
    private Mock<ICsvService> _mockCsvHelper;

    public Day1Tests()
    {
        _mockCsvHelper = new Mock<ICsvService>();
    }

    [Fact]
    public void Day1_SonarSweep_ShouldReturnZeroWhenPassedNull()
    {
        // arrange
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns<List<int>>(null);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep("measurements.csv");

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweep_ShouldReturnZeroWhenPassedEmptyList()
    {
        // arrange
        var measurements = new List<int>();
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep("measurements.csv");

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweep_ShouldReturnZeroWhenPassed1Measurement()
    {
        // arrange
        var measurements = new List<int> { 1 };
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep("measurements.csv");

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweep_ShouldReturn1With1Increase()
    {
        // arrange
        var measurements = new List<int> { 1, 2 };
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep("measurements.csv");

        // assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Day1_SonarSweep_ShouldReturn1With1IncreaseAndDecrease()
    {
        // arrange
        var measurements = new List<int> { 1, 2, 0 };
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep("measurements.csv");

        // assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Day1_SonarSweep_ToGetResults()
    {
        // arrange
        var target = GetTarget();

        // act
        var result = target.SonarSweep("TestData/SonarSweep.csv");

        // assert
        Assert.Equal(1521, result);
    }

    [Fact]
    public void Day1_SonarSweepWithWindow_ShouldReturnZeroWhenPassedNull()
    {
        // arrange
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns<List<int>>(null);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweepWithWindow("measurements.csv");

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweepWithWindow_ShouldReturnZeroWhenPassedEmptyList()
    {
        // arrange
        var measurements = new List<int>();
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweepWithWindow("measurements.csv");

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweepWithWindow_ShouldReturnZeroWhenPassedListOf1()
    {
        // arrange
        var measurements = new List<int> { 1 };
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweepWithWindow("measurements.csv");

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweepWithWindow_ShouldReturnZeroWhenPassedListOf2()
    {
        // arrange
        var measurements = new List<int> { 1, 2 };
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweepWithWindow("measurements.csv");

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweepWithWindow_ShouldReturnZeroWhenPassedListOf3()
    {
        // arrange
        var measurements = new List<int> { 1, 2, 3 };
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweepWithWindow("measurements.csv");

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweepWithWindow_ShouldReturnResultWithOneIncrease()
    {
        // arrange
        var measurements = new List<int> { 1, 2, 3, 4 };
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweepWithWindow("measurements.csv");

        // assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Day1_SonarSweepWithWindow_ShouldReturnResultWithOneIncreaseAndDecrease()
    {
        // arrange
        var measurements = new List<int> { 1, 2, 3, 4, 0 };
        _mockCsvHelper.Setup(x => x.GetListOf<int>(It.IsAny<string>())).Returns(measurements);
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweepWithWindow("measurements.csv");

        // assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Day1_SonarSweepWithWindow_ToGetResults()
    {
        // arrange
        var target = GetTarget();

        // act
        var result = target.SonarSweepWithWindow("TestData/SonarSweep.csv");

        // assert
        Assert.Equal(1543, result);
    }

    private Day1 GetTarget()
    {
        return new Day1(new CsvService(new CsvHelperWrapper()));
    }
}