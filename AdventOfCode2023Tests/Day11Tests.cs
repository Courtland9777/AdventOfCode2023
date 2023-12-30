using AdventOfCode2023._2023.Day_11;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023Tests;

public class Day11Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             ...#......
                             .......#..
                             #.........
                             ..........
                             ......#...
                             .#........
                             .........#
                             ..........
                             .......#..
                             #...#.....

                             """;
        const string expectedValues = "374";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string expectedWinnings = "544723432977";
        var solution = new Solution(FileReader.ReadInputToString(11));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}