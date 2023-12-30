using AdventOfCode2023._2023.Day_08;

namespace AdventOfCode2023Tests;

public class Day08Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             LLR

                             AAA = (BBB, BBB)
                             BBB = (AAA, ZZZ)
                             ZZZ = (ZZZ, ZZZ)

                             """;
        const string expectedSteps = "6";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualSteps = solution.PartOne();
        // Assert
        Assert.Equal(expectedSteps, actualSteps);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string input = """

                             LLR

                             AAA = (BBB, BBB)
                             BBB = (AAA, ZZZ)
                             ZZZ = (ZZZ, ZZZ)

                             """;

        const string expectedWinnings = "6";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}