using AdventOfCode2023._2023.Day_10;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023Tests;

public class Day10Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             .....
                             .S-7.
                             .|.|.
                             .L-J.
                             .....

                             """;
        const string expectedValues = "4";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string expectedWinnings = "287";
        var solution = new Solution(FileReader.ReadInputToString(10));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}