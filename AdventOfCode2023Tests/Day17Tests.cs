using AdventOfCode2023._2023.Day_17;

namespace AdventOfCode2023Tests;

public class Day17Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             2413432311323
                             3215453535623
                             3255245654254
                             3446585845452
                             4546657867536
                             1438598798454
                             4457876987766
                             3637877979653
                             4654967986887
                             4564679986453
                             1224686865563
                             2546548887735
                             4322674655533

                             """;
        const string expectedValues = "102";
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

                             2413432311323
                             3215453535623
                             3255245654254
                             3446585845452
                             4546657867536
                             1438598798454
                             4457876987766
                             3637877979653
                             4654967986887
                             4564679986453
                             1224686865563
                             2546548887735
                             4322674655533

                             """;

        const string expectedWinnings = "94";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}