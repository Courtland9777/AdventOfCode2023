using AdventOfCode2023._2023.Day_09;

namespace AdventOfCode2023Tests;

public class Day09Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             0 3 6 9 12 15
                             1 3 6 10 15 21
                             10 13 16 21 30 45

                             """;
        const string expectedValues = "114";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string input = """

                             0 3 6 9 12 15
                             1 3 6 10 15 21
                             10 13 16 21 30 45

                             """;

        const string expectedWinnings = "2";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}