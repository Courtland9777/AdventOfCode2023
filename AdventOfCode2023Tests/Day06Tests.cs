using AdventOfCode2023._2023.Day_06;

namespace AdventOfCode2023Tests;

public class Day06Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             Time:      7  15   30
                             Distance:  9  40  200

                             """;
        const string expectedWaysToBreakRecord = "288";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWaysToBreakRecord = solution.PartOne();
        // Assert
        Assert.Equal(expectedWaysToBreakRecord, actualWaysToBreakRecord);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string input = """

                             Time:      7  15   30
                             Distance:  9  40  200

                             """;

        const string expectedWaysToBreakRecord = "71503";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWaysToBreakRecord = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWaysToBreakRecord, actualWaysToBreakRecord);
    }
}