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
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep((List<int>)null);

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweep_ShouldReturnZeroWhenPassedEmptyList()
    {
        // arrange
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep(new List<int>());

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweep_ShouldReturnZeroWhenPassed1Measurement()
    {
        // arrange
        var measurements = new List<int> { 1 };
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep(measurements);

        // assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void Day1_SonarSweep_ShouldReturn1With1Increase()
    {
        // arrange
        var measurements = new List<int> { 1, 2 };
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep(measurements);

        // assert
        Assert.Equal(1, result);
    }

    [Fact]
    public void Day1_SonarSweep_ShouldReturn1With1IncreaseAndDecrease()
    {
        // arrange
        var measurements = new List<int> { 1, 2, 0 };
        var target = new Day1(_mockCsvHelper.Object);

        // act
        var result = target.SonarSweep(measurements);

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

    private Day1 GetTarget()
    {
        return new Day1(new CsvService(new CsvHelperWrapper()));
    }
}