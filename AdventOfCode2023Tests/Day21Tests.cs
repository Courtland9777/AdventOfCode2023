using AdventOfCode2023._2023.Day_21;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023Tests;

public class Day21Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        // Arrange
        var input = FileReader.ReadInputToString(21);
        const string expectedValues = "3853";
        var solution = new Solution(input);
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        var input = FileReader.ReadInputToString(21);

        const string expectedWinnings = "639051580070841";
        var solution = new Solution(input);
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}