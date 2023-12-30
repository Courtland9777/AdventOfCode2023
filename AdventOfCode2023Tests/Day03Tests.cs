using AdventOfCode2023._2023.Day_03;

namespace AdventOfCode2023Tests;

public class Day03Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """
                             467..114..
                             ...*......
                             ..35..633.
                             ......#...
                             617*......
                             .....+.58.
                             ..592.....
                             ......755.
                             ...$.*....
                             .664.598..
                             """;
        const string expectedSumOfEngineSchematic = "4361";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualSumOfEngineSchematic = solution.PartOne();
        // Assert
        Assert.Equal(expectedSumOfEngineSchematic, actualSumOfEngineSchematic);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string input = """

                             467..114..
                             ...*......
                             ..35..633.
                             ......#...
                             617*......
                             .....+.58.
                             ..592.....
                             ......755.
                             ...$.*....
                             .664.598..

                             """;

        const string expectedSumOfGearRatios = "467835";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualSumOfGearRatios = solution.PartTwo();
        // Assert
        Assert.Equal(expectedSumOfGearRatios, actualSumOfGearRatios);
    }
}