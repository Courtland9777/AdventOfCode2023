using AdventOfCode2023._2023.Day_01;

namespace AdventOfCode2023Tests;

public class Day01Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        string[] lines = ["1abc2", "pqr3stu8vwx", "a1b2c3d4e5f", "treb7uchet"];
        const string expectedTotalCalibrationValue = "142";
        var solution = new Solution(string.Join('\n', lines));
        // Act
        var actualTotalCalibrationValue = solution.PartOne();
        // Assert
        Assert.Equal(expectedTotalCalibrationValue, actualTotalCalibrationValue);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        // Arrange
        string[] lines =
        [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        ];
        const string expectedTotalCalibrationValue = "281";
        var solution = new Solution(string.Join('\n', lines));
        // Act
        var actualTotalCalibrationValue = solution.PartTwo();
        // Assert
        Assert.Equal(expectedTotalCalibrationValue, actualTotalCalibrationValue);
    }
}