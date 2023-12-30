using AdventOfCode2023._2023.Day_13;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023Tests;

public class Day13Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             #.##..##.
                             ..#.##.#.
                             ##......#
                             ##......#
                             ..#.##.#.
                             ..##..##.
                             #.#.##.#.

                             #...##..#
                             #....#..#
                             ..##..###
                             #####.##.
                             #####.##.
                             ..##..###
                             #....#..#

                             """;
        const string expectedValues = "405";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string expectedWinnings = "29083";
        var solution = new Solution(FileReader.ReadInputToString(13));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}