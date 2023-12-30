using AdventOfCode2023._2023.Day_20;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023Tests;

public class Day20Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        const string input = """

                             broadcaster -> a, b, c
                             %a -> b
                             %b -> c
                             %c -> inv
                             &inv -> a

                             """;
        const string expectedValues = "32000000";
        var solution = new Solution(input.Trim().Replace("\r", string.Empty));
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string expectedWinnings = "228300182686739";
        var solution = new Solution(FileReader.ReadInputToString(20));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}