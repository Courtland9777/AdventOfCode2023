using AdventOfCode2023._2023.Day_24;
using AdventOfCode2023.Helpers;

namespace AdventOfCode2023Tests;

public class Day24Tests
{
    [Fact]
    public void PartOne_ReturnsCorrectValue()
    {
        var input = FileReader.ReadInputToString(24);
        const string expectedValues = "13910";
        var solution = new Solution(input);
        // Act
        var actualValues = solution.PartOne();
        // Assert
        Assert.Equal(expectedValues, actualValues);
    }

    [Fact]
    public void PartTwo_ReturnsCorrectValue()
    {
        var input = FileReader.ReadInputToString(24);

        const string expectedWinnings = "618534564836937";
        var solution = new Solution(input);
        // Act
        var actualWinnings = solution.PartTwo();
        // Assert
        Assert.Equal(expectedWinnings, actualWinnings);
    }
}