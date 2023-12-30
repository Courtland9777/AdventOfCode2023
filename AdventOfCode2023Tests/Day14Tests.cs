using AdventOfCode2023._2023.Day_14;

namespace AdventOfCode2023Tests;

public class Day14Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             O....#....
                             O.OO#....#
                             .....##...
                             OO.#O....O
                             .O.....O#.
                             O.#..O.#.#
                             ..O..#O..O
                             .......O..
                             #....###..
                             #OO..#....

                             """;
        const string expectedValues = "136";
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

                             O....#....
                             O.OO#....#
                             .....##...
                             OO.#O....O
                             .O.....O#.
                             O.#..O.#.#
                             ..O..#O..O
                             .......O..
                             #....###..
                             #OO..#....

                             """;

        const string expectedWinnings = "64";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}