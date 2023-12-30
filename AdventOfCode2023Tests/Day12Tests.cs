using AdventOfCode2023._2023.Day_12;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023Tests;

public class Day12Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        const string expectedValues = "8180";
        var solution = new Solution(FileReader.ReadInputToString(12));
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        const string expectedWinnings = "620189727003627";
        var solution = new Solution(FileReader.ReadInputToString(12));
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}